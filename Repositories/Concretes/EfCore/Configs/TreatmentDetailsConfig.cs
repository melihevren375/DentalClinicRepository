using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Concretes.EfCore.Configs
{
    public class TreatmentDetailsConfig : IEntityTypeConfiguration<TreatmentDetails>
    {
        public void Configure(EntityTypeBuilder<TreatmentDetails> builder)
        {
            builder.HasKey(td => td.Id);

            
            builder.Property(td => td.TreatmentId)
                   .IsRequired();

            builder.Property(td => td.TreatmentTypeId)
                   .IsRequired();

            builder.Property(td => td.ToothNumber)
                   .IsRequired(false); 

            builder.Property(td => td.Notes)
                   .HasMaxLength(500); 

            builder.Property(td => td.IsCompleted)
                   .IsRequired();

            builder.HasOne(td => td.Treatment)
                   .WithMany(t => t.TreatmentDetails)
                   .HasForeignKey(td => td.TreatmentId)
                   .OnDelete(DeleteBehavior.Cascade); 

            builder.HasOne(td => td.TreatmentType)
                   .WithMany(tt => tt.TreatmentDetails)
                   .HasForeignKey(td => td.TreatmentTypeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(td => td.TreatmentId);
            builder.HasIndex(td => td.TreatmentTypeId);
        }
    }
}
