using System.Threading.Tasks;
using Navtrack.Api.Model.User;

namespace Navtrack.Api.Services.User
{
    public interface IUserService
    {
        Task<UserResponseModel> GetCurrentUser();
    }
}