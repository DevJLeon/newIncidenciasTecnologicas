using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;
public class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
{
    public void Configure(EntityTypeBuilder<Ciudad> builder)
    {
        builder.ToTable("ciudad");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
        .HasMaxLength(3);

        builder.Property(e => e.NombreCiudad)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasOne(e => e.Departamento)
        .WithMany(p => p.Ciudades)
        .HasForeignKey(p => p.IdepFk);
    }
}
