namespace RestauranteAPI.Services
{
    public interface IBebidaService
    {
        Task<List<Bebida>> GetAllAsync();
        Task<Bebida?> GetByIdAsync(int id);
        Task AddAsync(Bebida plato);
        Task UpdateAsync(Bebida plato);
        Task DeleteAsync(int id);
        Task InicializarDatosAsync();

    }
}
