using Models;

namespace RestauranteAPI.Repositories;

public interface IMenuDelDiaRepository
{
    Task<IEnumerable<MenuDelDia>> GetAllAsync();
    Task<MenuDelDia?> GetByDateAsync(DateTime fecha);
    Task AddAsync(MenuDelDia menu);
}