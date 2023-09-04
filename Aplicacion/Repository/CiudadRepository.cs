using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class CiudadRepository : GenericRepository<Ciudad>, ICiudad
{
        protected readonly ApiDbContext _context;
    
    public CiudadRepository(ApiDbContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Ciudad>> GetAllAsync()
    {
        return await _context.Ciudades
        .ToListAsync();
    }

    public override async Task<Ciudad> GetByIdAsync(int id)
    {
        return await _context.Ciudades
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}
