using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymCenter.Data.Entity
{
    public class ReceiptConfiguration : IEntityTypeConfiguration<Receipt>
    {
        public void Configure(EntityTypeBuilder<Receipt> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.CashierName).IsRequired();

            builder.Property(x => x.Date).IsRequired();

            builder.HasOne(x => x.User).WithMany(x => x.Receipts).HasForeignKey(x => x.UserId);

        }
    }
}
