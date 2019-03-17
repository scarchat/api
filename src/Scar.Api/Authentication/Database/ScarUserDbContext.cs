using System;
using Microsoft.EntityFrameworkCore;
using Scar.Api.Authentication.Database.Model;

namespace Scar.Api.Authentication.Database
{
    public class ScarUserDbContext : ScarUserDbContext<ScarUser>
    {
        public ScarUserDbContext()
        {}

        public ScarUserDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {}
    }

    public class ScarUserDbContext<TUser> : ScarUserDbContext<TUser, long>
        where TUser : ScarUser
    {
        public ScarUserDbContext()
        {}

        public ScarUserDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {}
    }

    public class ScarUserDbContext<TUser, TKey> : ScarJwtDbContext<TUser, TKey>
        where TKey: IEquatable<TKey>
        where TUser : ScarUser<TKey>
    {
        public ScarUserDbContext()
        {}

        public ScarUserDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
    }
}