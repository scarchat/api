﻿using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using GraphQL.Validation;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Scar.Api.Middleware
{
    public class GraphQLMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly GraphQLSettings _settings;

        private readonly IDocumentExecuter _executer;

        private readonly IDocumentWriter _writer;

        public GraphQLMiddleware(RequestDelegate next, GraphQLSettings settings, IDocumentExecuter executer, IDocumentWriter writer)
        {
            this._next = next;
            this._settings = settings;
            this._executer = executer;
            this._writer = writer;
        }

        public async Task Invoke(HttpContext context, ISchema schema)
        {
            if (!IsGraphQLRequest(context))
            {
                await _next(context);
                return;
            }

            await ExecuteAsync(context, schema);
        }

        private bool IsGraphQLRequest(HttpContext context)
        {
            return context.Request.Path.StartsWithSegments(_settings.Path)
                && string.Equals(context.Request.Method, "POST", StringComparison.OrdinalIgnoreCase);
        }

        private async Task ExecuteAsync(HttpContext context, ISchema schema)
        {
            var request = Deserialize<GraphQLRequest>(context.Request.Body);

            var result = await _executer.ExecuteAsync(options =>
            {
                options.Schema = schema;
                options.Query = request.Query;
                options.OperationName = request.OperationName;
                options.Inputs = request.Variables.ToInputs();
                options.UserContext = _settings.BuildUserContext?.Invoke(context);
                options.ValidationRules = DocumentValidator.CoreRules();
            });

            await WriteResponseAsync(context, result);
        }

        private async Task WriteResponseAsync(HttpContext context, ExecutionResult result)
        {
            var byteResult = await _writer.WriteAsync(result);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = result.Errors?.Any() == true ? (int)HttpStatusCode.BadRequest : (int)HttpStatusCode.OK;

            await context.Response.WriteAsync(Encoding.UTF8.GetString(byteResult.Result.Array, byteResult.Result.Offset,
                byteResult.Result.Count));
        }

        private static T Deserialize<T>(Stream s)
        {
            using (var reader = new StreamReader(s))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var ser = new JsonSerializer();
                return ser.Deserialize<T>(jsonReader);
            }
        }
    }
}
