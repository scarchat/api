using GraphQL.Types;
using Scar.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scar.Entities
{
    public sealed class ScarChatMutation : ObjectGraphType
    {
        public ScarChatMutation()
        {
            Field<UserGraph>("createUser",
                arguments: new QueryArguments(new QueryArgument<IdGraphType>() { Name = "id" }),
                resolve: context => 
                {
                    var user = context.GetArgument<User>("user");
                    return user;
                });
        }
    }
}
