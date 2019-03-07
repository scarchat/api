using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Scar.Api.Authentication
{
    public static class ScarJwtExtensions
    {
        public static AuthenticationBuilder AddScarJwtBearer(this AuthenticationBuilder builder, string authenticationScheme, Action<ScarJwtOptions> configureOptions)
            => builder.AddScarJwtBearer<ScarJwtOptions, ScarJwtSecurityTokenHandler<ScarJwtOptions>>(authenticationScheme, configureOptions);

        public static AuthenticationBuilder AddScarJwtBearer(this AuthenticationBuilder builder, string authenticationScheme, string displayName, Action<ScarJwtOptions> configureOptions)
            => builder.AddScarJwtBearer<ScarJwtOptions, ScarJwtSecurityTokenHandler<ScarJwtOptions>>(authenticationScheme, displayName, configureOptions);

        public static AuthenticationBuilder AddScarJwtBearer<TOptions, THandler>(this AuthenticationBuilder builder, string authenticationScheme, Action<TOptions> configureOptions)
            where TOptions: ScarJwtOptions, new()
            where THandler: ScarJwtSecurityTokenHandler<TOptions>
            => builder.AddScarJwtBearer<TOptions, THandler>(authenticationScheme, ScarJwtDefaults.DisplayName, configureOptions);
        public static AuthenticationBuilder AddScarJwtBearer<TOptions, THandler>(this AuthenticationBuilder builder, string authenticationScheme, string displayName, Action<TOptions> configureOptions)
            where TOptions: ScarJwtOptions, new()
            where THandler: ScarJwtSecurityTokenHandler<TOptions>
        {
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IPostConfigureOptions<TOptions>, ScarJwtPostConfigureOptions<TOptions, THandler>>());
            return builder.AddScheme<TOptions, THandler>(authenticationScheme, displayName, configureOptions);
        }
    }
}