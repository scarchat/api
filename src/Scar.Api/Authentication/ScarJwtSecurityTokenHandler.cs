using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Scar.Api.Authentication.Database;
using Scar.Api.Authentication.Database.Model;

namespace Scar.Api.Authentication
{
    public class ScarJwtSecurityTokenHandler<TOptions> : AuthenticationHandler<TOptions>, ISecurityTokenValidator
        where TOptions: ScarJwtOptions, new()
    {
        private readonly JwtSecurityTokenHandler _tokenHandler;
        private readonly ScarJwtDbContext<ScarJwtUser> _database;
        private int maxTokenSizeInBytes = TokenValidationParameters.DefaultMaximumTokenSizeInBytes;

        public ScarJwtSecurityTokenHandler(IOptionsMonitor<TOptions> optionsMonitor,
            ILoggerFactory loggerFactory,
            UrlEncoder urlEncoder,
            ISystemClock systemClock,
            ScarJwtDbContext<ScarJwtUser> database)
            : base(optionsMonitor, loggerFactory, urlEncoder, systemClock)
        {
            this._tokenHandler = new JwtSecurityTokenHandler();
        }

        public bool CanValidateToken => this._tokenHandler.CanValidateToken;

        public int MaximumTokenSizeInBytes
            {
                get => this.maxTokenSizeInBytes;
                set => this.maxTokenSizeInBytes = value;
            }

        public bool CanReadToken(string securityToken)
            => this._tokenHandler.CanReadToken(securityToken);

        public ClaimsPrincipal ValidateToken(string securityToken, TokenValidationParameters validationParameters, out SecurityToken validatedToken)
        {
            throw new System.NotImplementedException();
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}