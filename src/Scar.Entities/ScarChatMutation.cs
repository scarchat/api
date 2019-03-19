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
            Name = "mutateApi";
            Description = "Provides methods to perform client actions over HTTP.";

            Field<ChannelGraph>("createChannel", description: "Creates a new channel.",
                arguments: new QueryArguments(new[]
                {
                    new QueryArgument<StringGraphType>() { Name = "nodeId", Description = "The id of the node this channel is in." },
                    new QueryArgument<StringGraphType>() { Name = "name", Description = "The name of the channel to be created." }
                }),
                resolve: context =>
                {
                    var nodeId = context.GetArgument<string>("nodeId");
                    var name = context.GetArgument<string>("name");

                    return new Channel() { Name = name };
                });

            Field<ChannelGraph>("deleteChannel", description: "Deletes an existing channel.",
                arguments: new QueryArguments(new[]
                {
                    new QueryArgument<StringGraphType>() { Name = "nodeId", Description = "The id of the node this channel is in." },
                    new QueryArgument<StringGraphType>() { Name = "id", Description = "The id of the channel to be deleted." }
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
                    new QueryArgument<StringGraphType>() { Name = "nodeId", Description = "The id of the node this channel is in." },
                    new QueryArgument<StringGraphType>() { Name = "id", Description = "The id of the channel to be edited." },
                    new QueryArgument<StringGraphType>() { Name = "name", DefaultValue = "", Description = "The new name of the channel." }
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
