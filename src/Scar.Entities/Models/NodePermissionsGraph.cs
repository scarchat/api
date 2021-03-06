﻿using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scar.Entities.Models
{
    public sealed class NodePermissionsGraph : ObjectGraphType<NodePermissions>
    {
        public NodePermissionsGraph()
        {
            Description = "A container for node-level permissions metadata.";

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
