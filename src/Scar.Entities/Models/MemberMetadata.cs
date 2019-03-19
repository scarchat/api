using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scar.Entities.Models
{
    public sealed class MemberMetadata : ObjectGraphType<MemberMetadata>
    {
        public string Id { get; set; }

        public string Nickname { get; set; }

        public List<string> UserGroupIds { get; set; }
    }
}
