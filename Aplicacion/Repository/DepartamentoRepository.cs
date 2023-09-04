using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class DepartamentoRepository : GenericRepository<Departamento>, IDepartamento
{
    protected readonly ApiDbContext _context;
    
    public DepartamentoRepository(ApiDbContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Departamento>> GetAllAsync()
    {
        return await _context.Departamentos
            .Include(p => p.Ciudades)
            .ToListAsync();
    }

    public override async Task<Departamento> GetByIdAsync(int id)
    {
        return await _context.Departamentos
        .Include(p => p.Ciudades)
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}
