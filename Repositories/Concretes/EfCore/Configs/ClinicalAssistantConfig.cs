using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class ClinicalAssistantConfig : IEntityTypeConfiguration<ClinicalAssistant>
{
    public void Configure(EntityTypeBuilder<ClinicalAssistant> builder)
    {
        builder.HasKey(ca => ca.Id);

        builder.Property(ca => ca.CreatedDate).IsRequired();

        builder.Property(ca => ca.FirstName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(ca => ca.LastName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(ca => ca.PhoneNumber)
               .IsRequired()
               .HasMaxLength(15); 

        builder.Property(ca => ca.DateOfBirth)
               .IsRequired();

        builder.Property(ca => ca.IsActive)
               .IsRequired();

        builder.Property(ca => ca.EmployeeTypeId)
               .IsRequired();

        builder.Property(ca => ca.CertificationNumber)
               .HasMaxLength(50); 

        builder.Property(ca => ca.SpecialtyArea)
               .HasMaxLength(100);

        builder.
            HasIndex(ca => ca.DateOfBirth);

        builder.
            HasIndex(ca => ca.PhoneNumber);

        builder.
            HasIndex(ca => ca.FirstName);

        builder.
            HasIndex(ca => ca.LastName);

        builder.
            HasOne(ca => ca.EmployeeType).
            WithMany(et => et.Employees);

    }
}
