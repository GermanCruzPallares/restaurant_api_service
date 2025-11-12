using Microsoft.Data.SqlClient;
using Models;

namespace RestauranteAPI.Repositories;

public class MenuDelDiaRepository : IMenuDelDiaRepository
{
    private readonly string _connectionString;
    private readonly IPlatoPrincipalRepository _platoPrincipalRepository;
    private readonly IBebidaRepository _bebidaRepository;
    private readonly IPostreRepository _postreRepository;

    public MenuDelDiaRepository(IConfiguration configuration, IPlatoPrincipalRepository platoPrincipalRepository, IBebidaRepository bebidaRepository, IPostreRepository postreRepository)
    {
        _connectionString = configuration.GetConnectionString("RestauranteDB") ?? "Not found";
        _platoPrincipalRepository = platoPrincipalRepository;
        _bebidaRepository = bebidaRepository;
        _postreRepository = postreRepository;
    }

    public async Task<IEnumerable<MenuDelDia>> GetAllAsync()
    {
        var menus = new List<MenuDelDia>();
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = "SELECT Id, Fecha, PlatoPrincipalId, BebidaId, PostreId, PrecioTotal FROM MenuDelDia";
            using (var command = new SqlCommand(query, connection))
            {
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var menu = new MenuDelDia
                        {
                            Id = reader.GetInt32(0),
                            Fecha = reader.GetDateTime(1),
                            PlatoPrincipalId = reader.GetInt32(2),
                            BebidaId = reader.GetInt32(3),
                            PostreId = reader.GetInt32(4),
                            PrecioTotal = (double)reader.GetDecimal(5),
                            PlatoPrincipal = await _platoPrincipalRepository.GetByIdAsync(reader.GetInt32(2)),
                            Bebida = await _bebidaRepository.GetByIdAsync(reader.GetInt32(3)),
                            Postre = await _postreRepository.GetByIdAsync(reader.GetInt32(4))
                        };
                        menus.Add(menu);
                    }
                }
            }
        }
        return menus;
    }

    public async Task<MenuDelDia?> GetByDateAsync(DateTime fecha)
    {
        MenuDelDia? menu = null;
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = "SELECT Id, Fecha, PlatoPrincipalId, BebidaId, PostreId, PrecioTotal FROM MenuDelDia WHERE Fecha = @Fecha";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Fecha", fecha.Date);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        menu = new MenuDelDia
                        {
                            Id = reader.GetInt32(0),
                            Fecha = reader.GetDateTime(1),
                            PlatoPrincipalId = reader.GetInt32(2),
                            BebidaId = reader.GetInt32(3),
                            PostreId = reader.GetInt32(4),
                            PrecioTotal = (double)reader.GetDecimal(5),
                            PlatoPrincipal = await _platoPrincipalRepository.GetByIdAsync(reader.GetInt32(2)),
                            Bebida = await _bebidaRepository.GetByIdAsync(reader.GetInt32(3)),
                            Postre = await _postreRepository.GetByIdAsync(reader.GetInt32(4))
                        };
                    }
                }
            }
        }
        return menu;
    }

    public async Task AddAsync(MenuDelDia menu)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = "INSERT INTO MenuDelDia (Fecha, PlatoPrincipalId, BebidaId, PostreId, PrecioTotal) VALUES (@Fecha, @PlatoPrincipalId, @BebidaId, @PostreId, @PrecioTotal)";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Fecha", menu.Fecha);
                command.Parameters.AddWithValue("@PlatoPrincipalId", menu.PlatoPrincipalId);
                command.Parameters.AddWithValue("@BebidaId", menu.BebidaId);
                command.Parameters.AddWithValue("@PostreId", menu.PostreId);
                command.Parameters.AddWithValue("@PrecioTotal", menu.PrecioTotal);
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
<<<<<<< HEAD

=======
>>>>>>> master
