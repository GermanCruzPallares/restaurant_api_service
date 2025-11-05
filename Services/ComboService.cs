using RestauranteAPI.Repositories;

namespace RestauranteAPI.Services
{
    public class ComboService : IComboService
    {
        private readonly IComboService _comboRepository;

        public ComboService(IComboService comboService)
        {
            _comboRepository = comboService;
            
        }

        public async Task<List<Combo>> GetAllAsync()
        {
            return await _comboRepository.GetAllAsync();
        }

        public async Task<Combo?> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero.");

            return await _comboRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Combo combo)
        {
            if (string.IsNullOrWhiteSpace(combo.Nombre))
                throw new ArgumentException("El nombre del plato no puede estar vacío.");

            if (combo.Precio <= 0)
                throw new ArgumentException("El precio debe ser mayor que cero.");

            await _comboRepository.AddAsync(combo);
        }

        public async Task UpdateAsync(Combo combo)
        {
            if (combo.Id <= 0)
                throw new ArgumentException("El ID no es válido para actualización.");

            if (string.IsNullOrWhiteSpace(combo.Nombre))
                throw new ArgumentException("El nombre del postre no puede estar vacío.");

            await _comboRepository.UpdateAsync(combo);
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID no es válido para eliminación.");

            await _comboRepository.DeleteAsync(id);
        }

        public async Task InicializarDatosAsync() {
            await _comboRepository.InicializarDatosAsync();
        }
    }
}
