using Aplicacion.Repository;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiDbContext context;
    private PaisRepository _paises;
    private DepartamentoRepository _departamentos;
    private CiudadRepository _ciudades;


    public UnitOfWork(ApiDbContext _context)
    {
        context = _context;
    }
    public IPais Paises
    {
        get{
            if(_paises == null){
                _paises = new PaisRepository(context);
            }
            return _paises;
        }
    }
    public IDepartamento Departamentos
    {
        get{
            if(_departamentos == null){
                _departamentos = new DepartamentoRepository(context);
            }
            return _departamentos;
        }
    }

    public ICiudad Ciudades
    {
        get{
            if(_ciudades == null){
                _ciudades = new CiudadRepository(context);
            }
            return _ciudades;
        }
    }
    public void Dispose()
    {
        context.Dispose();
    }
    public async Task<int> SaveAsync()
    {
        return await context.SaveChangesAsync();
    }
}
