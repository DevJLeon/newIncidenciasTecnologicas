namespace Dominio.Entities;
    public class TipoPersona : BaseEntity
    {
        public string DescripcionTipoPersona { get; set; }
        public ICollection<Persona> Personas{ get; set; }
    }
