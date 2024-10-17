using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Concretes.EfCore.Configs;

public class InvoiceConfig : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(i => i.CreatedDate).IsRequired();
        builder.Property(i => i.PatientId).IsRequired();
        builder.Property(i => i.TotalAmount).IsRequired();
        builder.Property(i => i.IssueDate).IsRequired();
        builder.Property(i => i.IsPaid).IsRequired();

        builder.HasIndex(i => i.PatientId);
        builder.HasIndex(i => i.TotalAmount);
        builder.HasIndex(i => i.IssueDate);
        builder.HasIndex(i => i.IsPaid);

        builder.Property(i => i.Notes)
       .HasMaxLength(500);

        builder.HasOne(i=>i.Patient).
            WithMany(p=>p.Invoices).
            HasForeignKey(i => i.PatientId).
            OnDelete(DeleteBehavior.Cascade);
    }
}
