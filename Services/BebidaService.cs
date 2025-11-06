using RestauranteAPI.Repositories;

namespace RestauranteAPI.Services
{
    public class BebidaService : IBebidaService
    {
        private readonly IBebidaRepository _bebidaRepository;

        public BebidaService(IBebidaRepository bebidaRepository)
        {
            _bebidaRepository = bebidaRepository;
            
        }

        public async Task<List<Bebida>> GetAllAsync()
        {
            return await _bebidaRepository.GetAllAsync();
        }

        public async Task<Bebida?> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero.");

            return await _bebidaRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Bebida bebida)
        {
            if (string.IsNullOrWhiteSpace(bebida.Nombre))
                throw new ArgumentException("El nombre del plato no puede estar vacío.");

            if (bebida.Precio <= 0)
                throw new ArgumentException("El precio debe ser mayor que cero.");

            await _bebidaRepository.AddAsync(bebida);
        }

        public async Task UpdateAsync(Bebida bebida)
        {
            if (bebida.Id <= 0)
                throw new ArgumentException("El ID no es válido para actualización.");

            if (string.IsNullOrWhiteSpace(bebida.Nombre))
                throw new ArgumentException("El nombre del postre no puede estar vacío.");

            await _bebidaRepository.UpdateAsync(bebida);
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID no es válido para eliminación.");

            await _bebidaRepository.DeleteAsync(id);
        }

        public async Task InicializarDatosAsync() {
            await _bebidaRepository.InicializarDatosAsync();
        }
    }
}
