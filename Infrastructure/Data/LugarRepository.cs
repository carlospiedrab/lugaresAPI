using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class LugarRepository : ILugarRepository
    {
        private readonly ApplicationDbContext _db;
        public LugarRepository(ApplicationDbContext db)
        {
            _db = db;

        }
        public async Task<IReadOnlyList<Lugar>> GetLugarAsync()
        {
           return await _db.Lugar.Include(l=>l.Categoria)
                                 .Include(l=>l.Pais)
                                 .ToListAsync();
        }

        public async Task<Lugar> GetLugarByIdAsync(int id)
        {
               return await _db.Lugar.Include(l=>l.Categoria)
                                 .Include(l=>l.Pais)
                                 .FirstOrDefaultAsync(l=>l.Id==id);
        }
    }
}