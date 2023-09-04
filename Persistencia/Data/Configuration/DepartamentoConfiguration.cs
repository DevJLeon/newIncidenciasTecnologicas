using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data;

public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.ToTable("departamento");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
        .HasMaxLength(3);

        builder.Property(e => e.NombreDep)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasOne(e => e.Pais)
        .WithMany(p => p.Departamentos)
        .HasForeignKey(p => p.IdPaisFk);
    }     
}
