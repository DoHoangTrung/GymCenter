using GymCenter.Utilities.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymCenter.Data.EF
{
    public class GymCenterContextFactory : IDesignTimeDbContextFactory<GymCenterDbContext>
    {
        public GymCenterDbContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString(SystemConstants.GymConnectionString);

            var optionsBuilder = new DbContextOptionsBuilder<GymCenterDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new GymCenterDbContext(optionsBuilder.Options);
        }
    }
}
