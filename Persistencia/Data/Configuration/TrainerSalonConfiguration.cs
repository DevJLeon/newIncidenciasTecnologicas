using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class TrainerSalonConfiguration : IEntityTypeConfiguration<TrainerSalon>
    {
        public void Configure(EntityTypeBuilder<TrainerSalon> builder)
        {
             builder.ToTable("trainersalon");

        builder.Property(e => e.IdPersonaTrainerFk)
        .HasMaxLength(20);

        builder.Property(e => e.IdSalonFk)
        .HasColumnType("int");

        builder.HasOne(e => e.Persona)
        .WithMany(p => p.TrainerSalones)
        .HasForeignKey(p => p.IdPersonaTrainerFk); 

        builder.HasOne(e => e.Salon)
        .WithMany(p => p.TrainerSalones)
        .HasForeignKey(p => p.IdSalonFk);

        }
    }
}