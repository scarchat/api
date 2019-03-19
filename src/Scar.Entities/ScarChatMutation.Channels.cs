using GraphQL.Types;
using Scar.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scar.Entities
{
    public partial class ScarChatMutation : ObjectGraphType
    {
        public ScarChatMutation()
        {
            Field<ChannelGraph>("createChannel", description: "Create a new channel.",
                arguments: new QueryArguments(new[]
                {
                    new QueryArgument<StringGraphType>() { Name = "nodeId" },
                    new QueryArgument<StringGraphType>() { Name = "name" }
                }),
                resolve: context =>
                {
                    var nodeId = context.GetArgument<string>("nodeId");
                    var name = context.GetArgument<string>("name");

                    return new Channel() { Name = name };
                });

            Field<ChannelGraph>("deleteChannel", description: "Delete an existing channel.",
                arguments: new QueryArguments(new[]
                {
                    new QueryArgument<StringGraphType>() { Name = "nodeId" },
                    new QueryArgument<StringGraphType>() { Name = "id" }
                }),
                resolve: context =>
                {
                    var nodeId = context.GetArgument<string>("nodeId");
                    var id = context.GetArgument<string>("id");

                    return new Channel() { Id = id };
                });

            Field<ChannelGraph>("editChannel", description: "Update a channel.",
                arguments: new QueryArguments(new[]
                {
                    new QueryArgument<StringGraphType>() { Name = "nodeId" },
                    new QueryArgument<StringGraphType>() { Name = "id" },
                    new QueryArgument<StringGraphType>() { Name = "name", DefaultValue = "" }
                }),
                resolve: context =>
                {
                    var nodeId = context.GetArgument<string>("nodeId");
                    var id = context.GetArgument<string>("id");
                    var newName = context.GetArgument<string>("name");

                    return new Channel() { Name = newName };
                });

            /*
            Field<>("", description: "",
                arguments: new QueryArguments(new[]
                {

                }),
                resolve: context =>
                {
                });
            */
        }
    }
}
