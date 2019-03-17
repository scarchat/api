using System;

namespace Scar.Api.Authentication.Database.Model
{
    public class ScarUser : ScarUser<long>
    {}

    public class ScarUser<TKey> : ScarJwtUser<TKey>
        where TKey: IEquatable<TKey>
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }
    }
}