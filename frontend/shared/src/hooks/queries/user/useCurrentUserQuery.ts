import { useUserGet } from "../../../api";
import { useAuthentication } from "../../app/authentication/useAuthentication";

export const useCurrentUserQuery = () => {
  const authentication = useAuthentication();

  const query = useUserGet({
    query: {
      enabled: authentication.state.isAuthenticated,
      refetchOnWindowFocus: false,
      refetchOnMount: false
    }
  });

  return query;
};
