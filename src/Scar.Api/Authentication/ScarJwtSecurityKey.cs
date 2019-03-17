namespace Scar.Api.Authentication
{
    public class ScarJwtSecret
    {
        public byte[] Data { get; private set; }

        public ScarJwtSecret(byte[] data)
            => this.Data = data;
    }
}