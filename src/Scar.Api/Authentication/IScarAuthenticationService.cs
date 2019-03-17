using System.Security.Claims;
using System.Threading.Tasks;

namespace Scar.Api.Authentication
{
    public interface IScarAuthenticationService
    {
        Task<bool> CheckPasswordAsync(ClaimsPrincipal principal, string password);

        Task<bool> ResetPasswordAsync(ClaimsPrincipal principal);
    }
}