using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using RestauranteAPI.Repositories;
=======
using RestauranteAPI.Services;
>>>>>>> master

namespace RestauranteAPI.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class BebidaController : ControllerBase
   {
    private static List<Bebida> bebidas = new List<Bebida>();

<<<<<<< HEAD
    private readonly IBebidaRepository _repository;

    public BebidaController(IBebidaRepository repository)
        {
            _repository = repository;
=======
    private readonly IBebidaService _bebidaService;

    public BebidaController(IBebidaService bebidaService)
        {
            _bebidaService = bebidaService;
>>>>>>> master
        }
    
        [HttpGet]
        public async Task<ActionResult<List<Bebida>>> GetBebidas()
        {
<<<<<<< HEAD
            var bebidas = await _repository.GetAllAsync();
=======
            var bebidas = await _bebidaService.GetAllAsync();
>>>>>>> master
            return Ok(bebidas);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Bebida>> GetBebida(int id)
        {
<<<<<<< HEAD
            var bebida = await _repository.GetByIdAsync(id);
=======
            var bebida = await _bebidaService.GetByIdAsync(id);
>>>>>>> master
            if (bebida == null)
            {
                return NotFound();
            }
            return Ok(bebida);
        }

        [HttpPost]
        public async Task<ActionResult<Bebida>> CreateBebida(Bebida bebida)
        {
<<<<<<< HEAD
            await _repository.AddAsync(bebida);
=======
            await _bebidaService.AddAsync(bebida);
>>>>>>> master
            return CreatedAtAction(nameof(GetBebida), new { id = bebida.Id }, bebida);
        }

       [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBebida(int id, Bebida updatedBebida)
        {
<<<<<<< HEAD
            var existingBebida = await _repository.GetByIdAsync(id);
=======
            var existingBebida = await _bebidaService.GetByIdAsync(id);
>>>>>>> master
            if (existingBebida == null)
            {
                return NotFound();
            }

            // Actualizar el bebida existente
            existingBebida.Nombre = updatedBebida.Nombre;
            existingBebida.Precio = updatedBebida.Precio;
            existingBebida.EsAlcoholica = updatedBebida.EsAlcoholica;

<<<<<<< HEAD
            await _repository.UpdateAsync(existingBebida);
=======
            await _bebidaService.UpdateAsync(existingBebida);
>>>>>>> master
            return NoContent();
        }

        ///Cambio necesario///
  
       [HttpDelete("{id}")]
       public async Task<IActionResult> DeleteBebida(int id)
       {
<<<<<<< HEAD
           var bebida = await _repository.GetByIdAsync(id);
=======
           var bebida = await _bebidaService.GetByIdAsync(id);
>>>>>>> master
           if (bebida == null)
           {
               return NotFound();
           }
<<<<<<< HEAD
           await _repository.DeleteAsync(id);
=======
           await _bebidaService.DeleteAsync(id);
>>>>>>> master
           return NoContent();
       }

        [HttpPost("inicializar")]
        public async Task<IActionResult> InicializarDatos()
        {
<<<<<<< HEAD
            await _repository.InicializarDatosAsync();
=======
            await _bebidaService.InicializarDatosAsync();
>>>>>>> master
            return Ok("Datos inicializados correctamente.");
        }

   }
}