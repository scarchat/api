using System;

namespace Scar.Api.Authentication.Database.Model
{
    public class ScarJwtUser : ScarJwtUser<long>
    {}

    public class ScarJwtUser<TKey>
        where TKey: IEquatable<TKey>
    {
        public TKey Id { get; set; }

        public DateTimeOffset TokensValidFrom { get; set; }
    }
}