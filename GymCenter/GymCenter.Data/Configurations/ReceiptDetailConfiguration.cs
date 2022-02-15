using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymCenter.Data.Entity
{
    public class ReceiptDetailConfiguration : IEntityTypeConfiguration<ReceiptDetail>
    {
        public void Configure(EntityTypeBuilder<ReceiptDetail> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Discount).HasDefaultValue(0);

            builder.HasOne(x => x.Receipt).WithMany(x => x.ReceiptDetails).HasForeignKey(x => x.ReceiptId);
            builder.HasOne(x => x.GymService).WithMany(x => x.ReceiptDetails).HasForeignKey(x => x.ServiceId);
        }
    }
}
