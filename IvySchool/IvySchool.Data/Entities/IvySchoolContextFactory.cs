using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;

namespace IvySchool.Data.Entities
{
    public class IvySchoolContextFactory : IDesignTimeDbContextFactory<IvySchoolContext>
    {
        public IvySchoolContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<IvySchoolContext>();

            //builder.UseSqlServer(connectionString);
            var connectionString = configuration.GetConnectionString("IvySchoolConnectionString");
            builder.UseNpgsql(connectionString);
            return new IvySchoolContext(builder.Options);
        }
    }
}
