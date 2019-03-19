using GraphiQl;
using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Scar.Api.Authentication;
using Scar.Api.Authentication.Database;
using Scar.Api.Middleware;
using Scar.Entities;
using Scar.Entities.Models;

namespace Scar.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var secret = new ScarJwtSecret(new byte[] { 0, 1, 2 });

            services.AddAuthentication()
                .AddScarJwtBearer(x =>
                {
                    x.Secret = secret;
                    x.ValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(secret.Data),
                        ValidateActor = false,
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateLifetime = false,
                        ValidateIssuerSigningKey = false,
                        RequireExpirationTime = false
                    };
                })
                .AddUserStore<ScarUserDbContext>();

            RegisterGraphQLServices(services);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseGraphiQl(path: "/graphql", apiPath: "/api");
            app.UseMiddleware<GraphQLMiddleware>(new GraphQLSettings());
            app.UseMvc();
        }

        private void RegisterGraphQLServices(IServiceCollection services)
        {
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>()
                .AddSingleton<IDocumentWriter, DocumentWriter>()
                .AddSingleton<ScarChatQuery>()
                .AddSingleton<ScarChatMutation>()
                .AddSingleton<IdGraphType>()
                .AddSingleton<UserGraph>()
                .AddSingleton<ChannelGraph>()
                .AddSingleton<ChannelPermissionsGraph>()
                .AddSingleton<MemberMetadataGraph>()
                .AddSingleton<MessageGraph>()
                .AddSingleton<NodeGraph>()
                .AddSingleton<NodePermissionsGraph>()
                .AddSingleton<UserGroupGraph>();

            var provider = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new ScarChatSchema(new FuncDependencyResolver(type => provider.GetService(type))));
        }
    }
}