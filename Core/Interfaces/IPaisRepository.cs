using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IPaisRepository
    {
        Task<Pais> GetPaisByIdAsync(int id);
        Task<IReadOnlyList<Pais>> GetPaisAsync();
    }
}