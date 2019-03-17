using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;

namespace Scar.Api.Authentication
{
    public class ScarJwtOptions : AuthenticationSchemeOptions
    {
        public ScarJwtSecret Secret { get; set; }

        public TokenValidationParameters ValidationParameters { get; set; }
    }
}