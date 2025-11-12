using Microsoft.AspNetCore.Mvc;
using RestauranteAPI.Repositories;
<<<<<<< HEAD
=======
using RestauranteAPI.Services;
>>>>>>> master

namespace RestauranteAPI.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class PostreController : ControllerBase
   {
    private static List<Postre> postres = new List<Postre>();

<<<<<<< HEAD
    private readonly IPostreRepository _repository;

    public PostreController(IPostreRepository repository)
        {
            _repository = repository;
=======
    private readonly IPostreService _postreService;

    public PostreController(IPostreService PostreService)
        {
            _postreService = PostreService;
>>>>>>> master
        }
    
        [HttpGet]
        public async Task<ActionResult<List<Postre>>> GetPostres()
        {
<<<<<<< HEAD
            var postres = await _repository.GetAllAsync();
=======
            var postres = await _postreService.GetAllAsync();
>>>>>>> master
            return Ok(postres);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Postre>> GetPostre(int id)
        {
<<<<<<< HEAD
            var postre = await _repository.GetByIdAsync(id);
=======
            var postre = await _postreService.GetByIdAsync(id);
>>>>>>> master
            if (postre == null)
            {
                return NotFound();
            }
            return Ok(postre);
        }

        [HttpPost]
        public async Task<ActionResult<Postre>> CreatePostre(Postre postre)
        {
<<<<<<< HEAD
            await _repository.AddAsync(postre);
=======
            await _postreService.AddAsync(postre);
>>>>>>> master
            return CreatedAtAction(nameof(GetPostre), new { id = postre.Id }, postre);
        }

       [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePostre(int id, Postre updatedPostre)
        {
<<<<<<< HEAD
            var existingPostre = await _repository.GetByIdAsync(id);
=======
            var existingPostre = await _postreService.GetByIdAsync(id);
>>>>>>> master
            if (existingPostre == null)
            {
                return NotFound();
            }

            // Actualizar el postre existente
            existingPostre.Nombre = updatedPostre.Nombre;
            existingPostre.Precio = updatedPostre.Precio;
            existingPostre.Calorias = updatedPostre.Calorias;

<<<<<<< HEAD
            await _repository.UpdateAsync(existingPostre);
=======
            await _postreService.UpdateAsync(existingPostre);
>>>>>>> master
            return NoContent();
        }

        ///Cambio necesario///
  
       [HttpDelete("{id}")]
       public async Task<IActionResult> DeletePostre(int id)
       {
<<<<<<< HEAD
           var postre = await _repository.GetByIdAsync(id);
=======
           var postre = await _postreService.GetByIdAsync(id);
>>>>>>> master
           if (postre == null)
           {
               return NotFound();
           }
<<<<<<< HEAD
           await _repository.DeleteAsync(id);
=======
           await _postreService.DeleteAsync(id);
>>>>>>> master
           return NoContent();
       }

        [HttpPost("inicializar")]
        public async Task<IActionResult> InicializarDatos()
        {
<<<<<<< HEAD
            await _repository.InicializarDatosAsync();
=======
            await _postreService.InicializarDatosAsync();
>>>>>>> master
            return Ok("Datos inicializados correctamente.");
        }

   }
}