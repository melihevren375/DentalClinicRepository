using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Concretes.EfCore.Configs;

public class TreatmentConfig : IEntityTypeConfiguration<Treatment>
{
    public void Configure(EntityTypeBuilder<Treatment> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.AppointmentId).
            IsRequired();

        builder.Property(t => t.TotalAmount).
            IsRequired();

        builder.Property(t => t.PatientId).
            IsRequired();

        builder.Property(t => t.DentistId).
            IsRequired();

        builder.HasOne(t => t.Appointment).
            WithMany(a => a.Treatments).
            HasForeignKey(t => t.AppointmentId).
            OnDelete(DeleteBehavior.Restrict);

        builder.
            HasOne(t => t.Patient).
            WithMany(p => p.Treatments).
            HasForeignKey(t => t.PatientId).
            OnDelete(DeleteBehavior.Restrict);

        builder.
           HasOne(t => t.Dentist).
           WithMany(d => d.Treatments).
           HasForeignKey(t => t.DentistId).
           OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(t => t.AppointmentId);
        builder.HasIndex(t => t.PatientId);
        builder.HasIndex(t => t.DentistId);
    }
}
