namespace Scar.Entities.Models
{
    public sealed class ChannelPermissions
    {
        public string Id { get; set; }

        public int Grant { get; set; }

        public int Deny { get; set; }
    }
}