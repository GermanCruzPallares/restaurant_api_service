using Models;

namespace RestauranteAPI.Services;

public interface IMenuDelDiaService
{
    Task<IEnumerable<MenuDelDia>> GetAllAsync();
    Task<MenuDelDia?> GetByDateAsync(DateTime fecha);
    Task<MenuDelDia> CreateAsync(MenuDelDia menu);
}
