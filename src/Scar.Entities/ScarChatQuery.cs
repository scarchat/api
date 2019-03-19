using GraphQL;
using GraphQL.Types;
using Scar.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scar.Entities
{
    public sealed class ScarChatQuery : ObjectGraphType
    {
        public ScarChatQuery()
        {
            Field<UserGraph>("user",
                arguments: new QueryArguments(new QueryArgument<IdGraphType>() { Name = "id" }),
                resolve: context => {
                    if (context.GetArgument<string>("id").Equals("123456789"))
                        return new User() { Id = "123456789", Name = "trinitrotoluene", CdnIcon = "asfadsfas3241j" };
                    else
                        throw new ExecutionError("A user with that id was not found.");
                    }
                );
        }
    }
}
