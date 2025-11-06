namespace RestauranteAPI.Services
{
    public interface IPostreService
    {
        Task<List<Postre>> GetAllAsync();
        Task<Postre?> GetByIdAsync(int id);
        Task AddAsync(Postre plato);
        Task UpdateAsync(Postre plato);
        Task DeleteAsync(int id);
        Task InicializarDatosAsync();

    }
}
