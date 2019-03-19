using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using GraphQL.Validation.Complexity;
using Microsoft.AspNetCore.Mvc;
using Scar.Entities;

namespace Scar.Api.Controllers
{
    [Route("[controller]")]
    public class ApiController : Controller
    {
        private static ComplexityConfiguration _complexity = new ComplexityConfiguration()
        {
            MaxDepth = 15
        };

        private readonly IDocumentExecuter _executer;

        private readonly IDocumentWriter _writer;

        private readonly ISchema _schema;

        public ApiController(IDocumentExecuter executer, IDocumentWriter writer, ISchema schema)
        {
            this._executer = executer;
            this._writer = writer;
            this._schema = schema;
        }

        [HttpPost]
        public async Task<string> Query([FromBody] GraphQLQuery query)
        {
            var inputs = query.Variables.ToInputs();
            var result = await _executer.ExecuteAsync(options =>
            {
                options.Schema = _schema;
                options.Query = query.Query;
                options.OperationName = query.OperationName;
                options.Inputs = inputs;

                options.ComplexityConfiguration = _complexity;
            }).ConfigureAwait(false);

            var httpResult = result.Errors?.Count > 0 ? HttpStatusCode.BadRequest : HttpStatusCode.OK;

            var writeResult = await _writer.WriteAsync(result);
            var json = Encoding.UTF8.GetString(writeResult.Result.Array, writeResult.Result.Offset, writeResult.Result.Count);

            Response.ContentType = "application/json";
            Response.StatusCode = (int)httpResult;

            return json;
        }
    }
}