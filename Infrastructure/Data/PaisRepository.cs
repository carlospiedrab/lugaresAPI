using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class PaisRepository : IPaisRepository
    {
        private readonly ApplicationDbContext _db;

        public PaisRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public async Task<IReadOnlyList<Pais>> GetPaisAsync()
        {
            return await _db.Pais.ToListAsync();
        }

        public async Task<Pais> GetPaisByIdAsync(int id)
        {
            return await _db.Pais.FindAsync(id);
        }
    }
}