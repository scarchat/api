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
        private static Node DemoNode = new Node()
        {
            Id = "test",
            Name = "Demo",
            CdnIcon = "jqej23ejefkw3",
            Channels = new List<Channel>()
            {
                new Channel() {Name = "test 1"},
                new Channel() {Name = "test 2"}
            },
            UserGroups = new List<UserGroup>()
            {
                new UserGroup() { Name = "cool kids" }
            },
            MemberMetadata = new List<MemberMetadata>()
            {
                new MemberMetadata() { Id = "test", Nickname = "trinit", UserGroups = new List<UserGroup>() { new UserGroup() { Name = "cool kids" } } }
            }
        };

        public ScarChatQuery()
        {
            Field<UserGraph>("user",
                arguments: new QueryArguments(new QueryArgument<IdGraphType>() { Name = "id" }),
                resolve: context => 
                {
                    if (context.GetArgument<string>("id").Equals("123456789"))
                        return new User() { Id = "123456789", Name = "trinitrotoluene", CdnIcon = "asfadsfas3241j" };
                    else
                        throw new ExecutionError("A user with that id was not found.");
                });

            Field<NodeGraph>("node",
                arguments: new QueryArguments(new QueryArgument<IdGraphType>() { Name = "id" }),
                resolve: context =>
                {
                    return DemoNode;
                });
        }
    }
}
