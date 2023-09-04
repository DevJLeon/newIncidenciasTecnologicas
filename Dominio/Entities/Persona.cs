namespace Dominio.Entities;

    public class Persona : BaseEntity
    {
        public string NombrePersona { get; set; }
        public string ApellidoPersona { get; set; }
        public int IdGeneroFk { get; set; }
        public Genero Genero { get; set; }
        public int IdCiudadFk { get; set; }
        public Ciudad Ciudad{ get; set; }
        public int IdTipoPerFk { get; set; }
        public TipoPersona TipoPersona { get; set; }
        public ICollection<Matricula> Matriculas { get; set; }
        public ICollection<TrainerSalon> TrainerSalones { get; set; }
        public ICollection<Salon> Salones { get; set; }
    }
