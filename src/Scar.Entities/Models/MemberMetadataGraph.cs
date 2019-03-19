using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scar.Entities.Models
{
    public sealed class MemberMetadataGraph : ObjectGraphType<MemberMetadata>
    {
        public MemberMetadataGraph()
        {
            Name = "member_metadata";
            Description = "Node-specific user metadata.";

            Field(m => m.Id)
                .Name("id")
                .Description("The unique identifier of the member metadata.");

            Field(m => m.Nickname)
                .Name("nickname")
                .Description("The nickname of the user.");

            Field<UserGroupGraph>()
                .Name("user_groups")
                .Description("The usergroups this user is a member of.");
        }
    }
}
