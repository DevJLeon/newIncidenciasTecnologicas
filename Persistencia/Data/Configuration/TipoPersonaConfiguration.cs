using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class TipoPersonaConfiguration : IEntityTypeConfiguration<TipoPersona>
    {
        public void Configure(EntityTypeBuilder<TipoPersona> builder)
        {
             builder.ToTable("tipopersona");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
            .HasMaxLength(3);

            builder.Property(e => e.DescripcionTipoPersona)
            .IsRequired()
            .HasMaxLength(50);

        }
    }
}