using System;
using System.Collections.Generic;
using System.Text;

namespace Scar.Entities.Models
{
    public sealed class Node
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string CdnIcon { get; set; }

        public List<Channel> Channels { get; set; }

        public List<MemberMetadata> MemberMetadata { get; set; }

        public List<UserGroup> UserGroups { get; set; }
    }
}
