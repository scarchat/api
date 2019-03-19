using System;
using System.Collections.Generic;
using System.Text;

namespace Scar.Entities.Models
{
    public sealed class Message
    {
        public string Id { get; set; }

        public User Author { get; set; }

        public string Content { get; set; }
    }
}
