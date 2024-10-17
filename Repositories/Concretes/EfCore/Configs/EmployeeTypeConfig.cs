using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Concretes.EfCore.Configs;

public class EmployeeTypeConfig : IEntityTypeConfiguration<EmployeeType>
{
    public void Configure(EntityTypeBuilder<EmployeeType> builder)
    {
        builder.HasKey(et => et.Id);

        builder.Property(et => et.Name).IsRequired();

        builder.Property(et=>et.CreatedDate).IsRequired();  

        builder.Property(et=>et.Name).HasMaxLength(100);

        builder.HasIndex(et => et.Name);

    }
}
