using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Concretes.EfCore.Configs;

public class ReceptionitsConfig : IEntityTypeConfiguration<Receptionist>
{
    public void Configure(EntityTypeBuilder<Receptionist> builder)
    {
        builder.HasKey(r=>r.Id);

        builder.Property(r => r.FirstName).
            HasMaxLength(100).
            IsRequired();

        builder.Property(r => r.LastName).
           HasMaxLength(100).
           IsRequired();

        builder.Property(r => r.PhoneNumber).
           HasMaxLength(15).
           IsRequired();

        builder.Property(r => r.DateOfBirth).
            IsRequired();

        builder.Property(r => r.IsActive).
            IsRequired();

        builder.Property(r=>r.EmployeeTypeId).
            IsRequired();


    }
}
