using Dominio.Entities;
using AutoMapper;
using API.Dtos;
namespace API.Profiles;
public class MappingProfiles : Profile
{
     public MappingProfiles(){
        CreateMap<Pais,PaisDto>().ReverseMap();
        CreateMap<Departamento,DepartamentoDto>().ReverseMap();
        CreateMap<Ciudad,CiudadDto>().ReverseMap();
        CreateMap<Pais,PaisxDepDto>().ReverseMap();
    }
}
