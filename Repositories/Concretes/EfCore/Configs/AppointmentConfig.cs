using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Concretes.EfCore.Configs;

public class AppointmentConfig : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.
            HasKey(a => a.Id);

        builder.
            Property(a => a.PatientId).
            IsRequired();

        builder.Property(a=>a.CreatedDate).IsRequired();

        builder.
            Property(a => a.DentistId).
            IsRequired();

        builder.
            Property(a => a.DateOfAppointment).
            IsRequired();

        builder.
            Property(a => a.IsActive).
            IsRequired();

        builder.
            Property(a => a.CreatedDate).
            IsRequired();

        builder.
            Property(a => a.Notes).
            HasMaxLength(500);

        builder.
            HasOne(a => a.Patient).
            WithMany(p => p.Appointments).
            HasForeignKey(a => a.PatientId).
            OnDelete(DeleteBehavior.Cascade);

        builder.
           HasOne(a => a.Dentist).
           WithMany(a => a.Appointments).
           HasForeignKey(a => a.DentistId).
           OnDelete(DeleteBehavior.Cascade);

        builder.
            HasMany(a => a.Treatments).
            WithOne(t => t.Appointment).
            HasForeignKey(t => t.AppointmentId).
            OnDelete(DeleteBehavior.Cascade);

        builder.
            HasIndex(a => a.PatientId);

        builder.
            HasIndex(a => a.DentistId);

        builder.
            HasIndex(a => a.DateOfAppointment);
    }
}
