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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDb>().ToTable("User");
        }
    }
}
