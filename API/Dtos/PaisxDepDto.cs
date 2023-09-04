using Dominio.Entities;

namespace API.Dtos
{
    public class PaisxDepDto : BaseEntity
    {
    public string NombrePais { get; set; }
    public List<DepartamentoDto> Departamentos { get; set; }      
    }
}