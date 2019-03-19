using Microsoft.AspNetCore.Http;
using System;

namespace Scar.Api.Middleware
{
    public sealed class GraphQLSettings
    {
        public PathString Path { get; set; } = "/api";

        public Func<HttpContext, object> BuildUserContext { get; set; }
    }
}