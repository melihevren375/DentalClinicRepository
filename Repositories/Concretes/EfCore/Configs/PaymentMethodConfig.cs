using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Concretes.EfCore.Configs;

public class PaymentMethodConfig : IEntityTypeConfiguration<PaymentMethod>
{
    public void Configure(EntityTypeBuilder<PaymentMethod> builder)
    {
        builder.HasKey(pm => pm.Id);

        builder.Property(pm => pm.Name).
            HasMaxLength(100).
            IsRequired();

        builder.Property(pm => pm.CreatedDate).
            IsRequired();

        builder.HasIndex(pm => pm.Name).
            IsUnique();

        builder.
            HasMany(pm => pm.Payments).
            WithOne(p => p.PaymentMethod).
            HasForeignKey(p => p.PaymentMethodId).
            OnDelete(DeleteBehavior.Restrict);

    }
}
