using Core.Entities;

namespace Core.Interfaces
{
    public interface ILugarRepository
    {
         Task<Lugar> GetLugarByIdAsync(int id);
        Task<IReadOnlyList<Lugar>> GetLugarAsync();
    }
}