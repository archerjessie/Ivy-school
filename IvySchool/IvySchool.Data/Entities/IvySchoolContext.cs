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
        public DbSet<StudentDb> Students { get; set; }
        public DbSet<SigninHistoryDb> SignIns { get; set; }
        public DbSet<CourseDb> Courses { get; set; }
        public DbSet<CourseStudentDb> CourseStudents { get; set; }
        public DbSet<AssignmentDb> Assignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDb>().ToTable("User").HasKey(u => u.UserId);
            modelBuilder.Entity<RoleDb>().ToTable("Role").HasKey(r => r.RoleId);
            modelBuilder.Entity<StudentDb>().ToTable("Student").HasKey(s => s.StudentId);
            modelBuilder.Entity<RoleUserDb>().HasKey(s => new { s.RoleId, s.UserId });
            modelBuilder.Entity<CourseStudentDb>().HasKey(s => new { s.CourseId, s.StudentId });
            

        }
    }
}
