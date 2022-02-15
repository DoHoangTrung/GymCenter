using GymCenter.Data.Configurations;
using GymCenter.Data.Entity;
using GymCenter.Data.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymCenter.Data.EF
{
    public class GymCenterDbContext : IdentityDbContext<AppUser,AppRole,Guid>
    {
        public GymCenterDbContext(DbContextOptions options) : base(options){}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Bỏ tiền tố AspNet của các bảng: mặc định
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }

            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new CheckInHistoryConfiguration());
            builder.ApplyConfiguration(new ServiceConfiguration());
            builder.ApplyConfiguration(new MembershipCardConfiguration());
            builder.ApplyConfiguration(new ReceiptConfiguration());
            builder.ApplyConfiguration(new ReceiptDetailConfiguration());
            builder.ApplyConfiguration(new RegisterConfiguration());
            builder.ApplyConfiguration(new RegisterDetailConfiguration());
            builder.ApplyConfiguration(new ServiceInCardConfiguration());

            builder.Seed();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CheckInHistory> CheckInHistories { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<MembershipCard> MembershipCards { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ReceiptDetail> ReceiptDetails { get; set; }
        public DbSet<Register> Registers { get; set; }
        public DbSet<RegisterDetail> RegisterDetails { get; set; }
        public DbSet<ServiceInCard> ServiceInCards { get; set; }
    }
}
