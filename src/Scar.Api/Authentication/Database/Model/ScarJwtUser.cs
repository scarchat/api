using System;

namespace Scar.Api.Authentication.Database.Model
{
    public class ScarJwtUser : ScarJwtUser<int>
    {}

    public class ScarJwtUser<TKey>
    {
        public TKey Id { get; set; }

        public DateTimeOffset TokensValidFrom { get; set; }
    }
}