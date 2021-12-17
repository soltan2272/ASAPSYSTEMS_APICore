using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PersonAddress
{
    public class ProjectContextFactory:IDesignTimeDbContextFactory<ProjectDBContect>
    {
        public ProjectDBContect CreateDbContext(string[] args)
        {
            IConfigurationRoot SettingsObj
                = new ConfigurationBuilder().SetBasePath
                (Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            DbContextOptionsBuilder<ProjectDBContect>
                 Builder
                 = new DbContextOptionsBuilder<ProjectDBContect>();
            Builder.UseSqlServer(SettingsObj.GetConnectionString("ASAP"));

            ProjectDBContect Context
                = new ProjectDBContect(Builder.Options);
            return Context;

        }
    }
}
