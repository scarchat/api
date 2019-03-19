using System.Collections.Generic;

namespace Scar.Entities.Models
{
    public sealed class MemberMetadata
    {
        public string Id { get; set; }

        public string Nickname { get; set; }

        public List<UserGroup> UserGroups { get; set; }
    }
}