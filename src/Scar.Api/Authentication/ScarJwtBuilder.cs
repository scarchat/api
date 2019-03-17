using System;
using Microsoft.Extensions.DependencyInjection;
using Scar.Api.Authentication.Database;
using Scar.Api.Authentication.Database.Model;

namespace Scar.Api.Authentication
{
    public class ScarJwtBuilder
    {
        public IServiceCollection Services { get; private set; }

        public ScarJwtBuilder(IServiceCollection services)
            => this.Services = services;

        public ScarJwtBuilder AddAuthenticationService<TService>()
            where TService: class, IScarAuthenticationService
        {
            this.Services.AddScoped<TService>();
            return this;
        }

        public ScarJwtBuilder AddUserStore<TContext>()
            where TContext : ScarJwtDbContext
        {
            this.Services.AddScoped<TContext>();
            return this;
        }

        public ScarJwtBuilder AddUserStore<TContext, TUser>()
            where TUser: ScarJwtUser<long>
            where TContext : ScarJwtDbContext<TUser, long>
        {
            this.Services.AddScoped<TContext>();
            return this;
        }

        public ScarJwtBuilder AddUserStore<TContext, TUser, TKey>()
            where TKey: IEquatable<TKey>
            where TUser: ScarJwtUser<TKey>
            where TContext : ScarJwtDbContext<TUser, TKey>
        {
            this.Services.AddScoped<TContext>();
            return this;
        }
    }
}