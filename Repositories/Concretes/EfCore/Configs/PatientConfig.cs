using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Concretes.EfCore.Configs
{
    public class PatientConfig : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.FirstName)
                   .IsRequired()
                   .HasMaxLength(100); 

            builder.Property(p => p.LastName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.PhoneNumber)
                   .IsRequired()
                   .HasMaxLength(15); 

            builder.Property(p => p.DateOfBirth)
                   .IsRequired();

            builder.Property(p => p.CreatedDate)
                   .IsRequired();

            builder.Property(p => p.IsActive)
                   .IsRequired();

            builder.HasMany(p => p.Appointments)
                   .WithOne(a => a.Patient)
                   .HasForeignKey(a => a.PatientId)
                   .OnDelete(DeleteBehavior.Cascade); 

            builder.HasMany(p => p.Invoices)
                   .WithOne(i => i.Patient)
                   .HasForeignKey(i => i.PatientId)
                   .OnDelete(DeleteBehavior.Cascade); 

            builder.HasMany(p => p.Treatments)
                   .WithOne(t => t.Patient)
                   .HasForeignKey(t => t.PatientId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(p => p.PhoneNumber).IsUnique(); 
            builder.HasIndex(p => p.LastName);               
            builder.HasIndex(p => p.FirstName);               
            builder.HasIndex(p => p.IsActive);
        }
    }
}
