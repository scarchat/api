using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scar.Entities.Models
{
    public sealed class ChannelPermissionsGraph : ObjectGraphType<ChannelPermissions>
    {
        public ChannelPermissionsGraph()
        {
            Name = "channel_permissions";
            Description = "A container for permissions metadata relating to node usergroups.";

            Field(x => x.Id)
                .Name("id")
                .Description("The identifier of the user or usergroup this metadata applies to");

            Field(x => x.Grant)
                .Name("grant")
                .Description("The computed bitwise integer of granted permissions.");

            Field(x => x.Deny)
                .Name("deny")
                .Description("The computed bitwise integer of denied permissions.");
        }
    }
}
