using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class PaisRepository  : GenericRepository<Pais>, IPais
{
    protected readonly ApiDbContext _context;
    
    public PaisRepository(ApiDbContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Pais>> GetAllAsync()
    {

        return await _context.Paises
            .Include(p => p.Departamentos).ThenInclude(c=>c.Ciudades)
            .ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<Pais> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Paises as IQueryable<Pais>;
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.NombrePais.ToLower().Contains(search));
        }
        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(u => u.Departamentos)
                                .Skip((pageIndex -1) *pageSize)
                                .Take(pageSize)
                                .ToListAsync();
        return (totalRegistros, registros);
    }
}
