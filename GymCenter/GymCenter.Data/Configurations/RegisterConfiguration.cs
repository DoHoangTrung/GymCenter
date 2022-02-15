using GymCenter.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymCenter.Data.Entity
{
    public class RegisterConfiguration : IEntityTypeConfiguration<Register>
    {
        public void Configure(EntityTypeBuilder<Register> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Date).IsRequired();

            builder.HasOne(x => x.User).WithMany(x => x.Registers).HasForeignKey(x => x.UserId);
        }
    }
}
