import { IdentityApi } from "../../apis/IdentityApi";
import { TokenResponse } from "../../apis/types/identity/TokenResponse";
import { AppContextAccessor } from "../appContext/AppContextAccessor";
import { InitialAuthenticationInfo, AuthenticationInfo } from "./AuthenticationInfo";

export const AuthenticationService = {
  clearAuthenticationInfo: (sessionExpired?: boolean) => {
    AppContextAccessor.setAppContext((appContext) => {
      return {
        ...appContext,
        authenticationInfo: {
          ...InitialAuthenticationInfo,
          session_expired: sessionExpired ? true : false
        }
      };
    });
  },

  login: async (email: string, password: string): Promise<boolean> => {
    const tokenResponse = await IdentityApi.login(email, password);

    if (tokenResponse.error) {
      return false;
    } else {
      AppContextAccessor.setAppContext((appContext) => {
        return {
          ...appContext,
          authenticationInfo: getNewAuthenticationInfo(email, tokenResponse)
        };
      });

      return true;
    }
  },

  checkAndRenewAccessToken: async (): Promise<boolean> => {
    let appContext = AppContextAccessor.getAppContext();

    if (appContext.authenticationInfo.authenticated) {
      if (accessTokenIsExpired(appContext.authenticationInfo.expiry_date)) {
        const tokenResponse = await IdentityApi.refreshToken(
          appContext.authenticationInfo.refresh_token
        );

        if (renewFailed(tokenResponse)) {
          AuthenticationService.clearAuthenticationInfo(true);

          return false;
        }

        AppContextAccessor.setAppContext((appContext) => {
          return {
            ...appContext,
            authenticationInfo: getNewAuthenticationInfo(
              appContext.authenticationInfo.email,
              tokenResponse
            )
          };
        });
      }

      return true;
    }

    return false;
  },

  isAuthenticated: (): boolean => {
    let appContext = AppContextAccessor.getAppContext();

    return appContext.authenticationInfo.authenticated;
  }
};

const getNewAuthenticationInfo = (
  email: string,
  tokenResponse: TokenResponse
): AuthenticationInfo => {
  const newAuthenticationInfo: AuthenticationInfo = {
    email: email,
    authenticated: true,
    access_token: tokenResponse.access_token,
    refresh_token: tokenResponse.refresh_token,
    expiry_date: new Date(new Date().getTime() + tokenResponse.expires_in * 1000).toString(),
    session_expired: false
  };

  return newAuthenticationInfo;
};

const accessTokenIsExpired = (expiry: string): boolean => {
  const date = new Date();
  const expiryDate = new Date(expiry);

  return date > expiryDate;
};

const renewFailed = (tokenResponse: TokenResponse) =>
  !tokenResponse ||
  tokenResponse.error ||
  !tokenResponse.access_token ||
  !tokenResponse.refresh_token;
