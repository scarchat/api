using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scar.Entities.Models
{
    public sealed class NodeGraph : ObjectGraphType<Node>
    {
        public NodeGraph()
        {
            Field(n => n.Id)
                .Name("id")
                .Description("The unique identifier of the node.");

            Field(n => n.Name)
                .Name("name")
                .Description("The name of the node.");

            Field(n => n.CdnIcon)
                .Name("cdn_icon")
                .Description("The unique hash of the icon accessible through the Scar CDN.");

            Field<ListGraphType<ChannelGraph>>()
                .Name("channels")
                .Description("Channels available to node users.");

            Field<ListGraphType<UserGroupGraph>>()
                .Name("user_groups")
                .Description("Usergroups that node members can belong to.");

            Field<ListGraphType<MemberMetadataGraph>>()
                .Name("member_metadata")
                .Description("Node-specific user metadata.");
        }
    }
}
