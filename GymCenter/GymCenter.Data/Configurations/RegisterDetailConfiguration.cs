using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymCenter.Data.Entity
{
    public class RegisterDetailConfiguration : IEntityTypeConfiguration<RegisterDetail>
    {
        public void Configure(EntityTypeBuilder<RegisterDetail> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Discount).HasDefaultValue(0);

            builder.HasOne(x => x.Register).WithMany(x => x.RegisterDetails).HasForeignKey(x => x.RegisterId);
            builder.HasOne(x => x.GymService).WithMany(x => x.RegisterDetails).HasForeignKey(x => x.ServiceId);
        }
    }
}
