using System;
using Microsoft.EntityFrameworkCore;
using Scar.Api.Authentication.Database.Model;

namespace Scar.Api.Authentication.Database
{
    public class ScarJwtDbContext<TUser> : ScarJwtDbContext<TUser, long>
        where TUser : ScarJwtUser
    {
        public ScarJwtDbContext()
        {}

        public ScarJwtDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {}
    }

    public class ScarJwtDbContext<TUser, TKey> : ScarJwtDbContext
        where TKey: IEquatable<TKey>
        where TUser: ScarJwtUser<TKey>
    {
        public DbSet<TUser> Users { get; set; }

        public ScarJwtDbContext()
        {}

        public ScarJwtDbContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {}
    }

    public abstract class ScarJwtDbContext : DbContext
    {
        public ScarJwtDbContext()
        {}

        public ScarJwtDbContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {}
    }
}