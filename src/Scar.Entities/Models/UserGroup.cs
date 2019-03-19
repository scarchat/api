using System;
using System.Collections.Generic;
using System.Text;

namespace Scar.Entities.Models
{
    public sealed class UserGroup
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Color { get; set; }

        public NodePermissions NodePermissions { get; set; }

        public List<ChannelPermissions> ChannelPermissions { get; set; }
    }
}
