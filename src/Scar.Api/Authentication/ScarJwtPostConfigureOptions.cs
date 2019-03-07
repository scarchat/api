using Microsoft.Extensions.Options;

namespace Scar.Api.Authentication
{
    public class ScarJwtPostConfigureOptions<TOptions, THandler> : IPostConfigureOptions<TOptions>
        where TOptions : ScarJwtOptions, new()
        where THandler : ScarJwtSecurityTokenHandler<TOptions>
    {
        public void PostConfigure(string name, TOptions options)
        {
            throw new System.NotImplementedException();
        }
    }
}