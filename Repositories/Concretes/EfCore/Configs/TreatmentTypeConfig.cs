using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Concretes.EfCore.Configs
{
    public class TreatmentTypeConfig : IEntityTypeConfiguration<TreatmentType>
    {
        public void Configure(EntityTypeBuilder<TreatmentType> builder)
        {
            builder.HasKey(tt => tt.Id);

            builder.Property(tt => tt.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(tt => tt.Price)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.HasMany(tt => tt.TreatmentDetail)
                   .WithOne(td => td.TreatmentType)
                   .HasForeignKey(td => td.TreatmentTypeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(tt => tt.Name);
        }
    }
}
