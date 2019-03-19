using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scar.Entities.Models
{
    public sealed class ChannelGraph : ObjectGraphType<Channel>
    {
        public ChannelGraph()
        {
            Name = "channel";
            Description = "A place for users to post messages in.";

            Field(c => c.Id)
                .Name("id")
                .Description("The unique identifier of the channel.");

            Field(c => c.Name)
                .Name("name")
                .Description("The name of the channel.");

            Field<ListGraphType<MessageGraph>>()
                .Name("messages")
                .Description("The message history of the channel.");
        }
    }
}
