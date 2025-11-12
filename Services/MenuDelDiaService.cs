using Models;
using RestauranteAPI.Repositories;

namespace RestauranteAPI.Services;

public class MenuDelDiaService : IMenuDelDiaService
{
    private readonly IMenuDelDiaRepository _menuDelDiaRepository;
    private readonly IPlatoPrincipalRepository _platoPrincipalRepository;
    private readonly IBebidaRepository _bebidaRepository;
    private readonly IPostreRepository _postreRepository;

    public MenuDelDiaService(
        IMenuDelDiaRepository menuDelDiaRepository,
        IPlatoPrincipalRepository platoPrincipalRepository,
        IBebidaRepository bebidaRepository,
        IPostreRepository postreRepository)
    {
        _menuDelDiaRepository = menuDelDiaRepository;
        _platoPrincipalRepository = platoPrincipalRepository;
        _bebidaRepository = bebidaRepository;
        _postreRepository = postreRepository;
    }

    public async Task<IEnumerable<MenuDelDia>> GetAllAsync()
    {
        return await _menuDelDiaRepository.GetAllAsync();
    }

    public async Task<MenuDelDia?> GetByDateAsync(DateTime fecha)
    {
        return await _menuDelDiaRepository.GetByDateAsync(fecha);
    }

    public async Task<MenuDelDia> CreateAsync(MenuDelDia menu)
    {
        var plato = await _platoPrincipalRepository.GetByIdAsync(menu.PlatoPrincipalId) ?? throw new ArgumentException("El plato principal no existe.");
        var bebida = await _bebidaRepository.GetByIdAsync(menu.BebidaId) ?? throw new ArgumentException("La bebida no existe.");
        var postre = await _postreRepository.GetByIdAsync(menu.PostreId) ?? throw new ArgumentException("El postre no existe.");

        menu.PrecioTotal = plato.Precio + bebida.Precio + postre.Precio;

        await _menuDelDiaRepository.AddAsync(menu);
        return menu;
    }
}