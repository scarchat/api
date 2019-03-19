using System.Collections.Generic;

namespace Scar.Entities.Models
{
    public sealed class Channel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public List<Message> Messages { get; set; }
    }
}