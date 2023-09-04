namespace Dominio.Interfaces;
public interface IUnitOfWork
{
    IPais Paises { get; }
    IDepartamento Departamentos { get; }
    ICiudad Ciudades { get; }

    Task<int> SaveAsync();
}
