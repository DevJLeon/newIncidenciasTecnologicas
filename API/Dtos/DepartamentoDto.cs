using Dominio.Entities;

namespace API.Dtos;
public class DepartamentoDto : BaseEntity
{
    public string NombreDep { get; set; }
    public  int IdPaisFk { get; set; }
    public List<CiudadDto> Ciudades { get; set; }      
}
