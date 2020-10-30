using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace IvySchool.Data.Entities
{
    public class IvySchoolContext:DbContext
    {
        public IvySchoolContext(DbContextOptions<IvySchoolContext> options) : base(options)
        {
        }

        public DbSet<UserDb> Users { get; set; }
        public DbSet< RoleUserDb> RoleUsers{ get; set; }
        public DbSet<RoleDb> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDb>().ToTable("User").HasKey(u => u.UserId);
            modelBuilder.Entity<RoleDb>().ToTable("Role").HasKey(r => r.RoleId);
            modelBuilder.Entity<RoleUserDb>().HasKey(s => new { s.RoleId, s.UserId });
            

        }
    }
}
