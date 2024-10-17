using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Concretes.EfCore.Configs;

public class DentistConfig : IEntityTypeConfiguration<Dentist>
{
    public void Configure(EntityTypeBuilder<Dentist> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.CreatedDate).IsRequired();

        builder.
            Property(d => d.FirstName).
            HasMaxLength(100).
            IsRequired();

        builder.
            Property(d => d.LastName).
            HasMaxLength(100).
            IsRequired();

        builder.
            Property(d => d.PhoneNumber).
            HasMaxLength(15).
            IsRequired();

        builder.
            Property(d => d.DateOfBirth).
            IsRequired();

        builder.
            Property(d => d.IsActive).
            IsRequired();

        builder.
            Property(d => d.EmployeeTypeId).
            IsRequired();

        builder.
            Property(d => d.LicenseNumber).
            HasMaxLength(50).
            IsRequired();

        builder.
            Property(d => d.Specialty).
            HasMaxLength(100);

        builder.
           HasIndex(d => d.DateOfBirth);

        builder.
            HasIndex(d => d.PhoneNumber);

        builder.
            HasIndex(d => d.FirstName);

        builder.
            HasIndex(d => d.LastName);

        builder.
            HasIndex(d => d.LicenseNumber);

        builder.
            HasMany(d => d.Treatments).
            WithOne(t => t.Dentist).
            HasForeignKey(t => t.DentistId).
            OnDelete(DeleteBehavior.Cascade);

        builder.
            HasMany(d => d.Appointments).
            WithOne(a => a.Dentist).
            HasForeignKey(a => a.DentistId).
            OnDelete(DeleteBehavior.Cascade);

    }
}
