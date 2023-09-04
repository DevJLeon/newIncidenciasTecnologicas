using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class PaisConfiguration : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder.ToTable("pais");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
            .HasMaxLength(3);

            builder.Property(e => e.NombrePais)
            .IsRequired()
            .HasMaxLength(50);
        }
    }
}