using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class SalonConfiguration : IEntityTypeConfiguration<Salon>
    {
        public void Configure(EntityTypeBuilder<Salon> builder)
        {
             builder.ToTable("salon");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
            .HasMaxLength(3);

            builder.Property(e => e.NombreSalon)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(e => e.Capacidad)
            .HasColumnType("int");

            
        }
    }
}