using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Scar.Api.Authentication
{
    public static class ScarJwtExtensions
    {
        public static ScarJwtBuilder AddScarJwtBearer(this AuthenticationBuilder builder, Action<ScarJwtOptions> configureOptions)
            => builder.AddScarJwtBearer<ScarJwtOptions, ScarJwtSecurityTokenHandler<ScarJwtOptions>>(ScarJwtDefaults.AuthenticationScheme, ScarJwtDefaults.DisplayName, configureOptions);

        private static ScarJwtBuilder AddScarJwtBearer<TOptions, THandler>(this AuthenticationBuilder builder, string authenticationScheme, string displayName, Action<TOptions> configureOptions)
            where TOptions: ScarJwtOptions, new()
            where THandler: ScarJwtSecurityTokenHandler<TOptions>
        {
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IPostConfigureOptions<TOptions>, ScarJwtPostConfigureOptions<TOptions, THandler>>());
            builder.AddScheme<TOptions, THandler>(authenticationScheme, displayName, configureOptions);
            return new ScarJwtBuilder(builder.Services);
        }
    }
}