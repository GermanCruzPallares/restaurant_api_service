using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using RestauranteAPI.Repositories;
=======
using RestauranteAPI.Models;
using RestauranteAPI.Repositories;
using RestauranteAPI.Services;
>>>>>>> master

namespace RestauranteAPI.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class ComboController : ControllerBase
   {
    private static List<Combo> combos = new List<Combo>();

<<<<<<< HEAD
    private readonly IComboRepository _repository;

    public ComboController(IComboRepository repository)
        {
            _repository = repository;
=======
    private readonly IComboService _ComboService;
    private readonly IPlatoPrincipalService _platoPrincipalService;
    private readonly IBebidaService _bebidaService;
    private readonly IPostreService _postreService;

    public ComboController(IComboService comboService, IPlatoPrincipalService platoPrincipalService, IBebidaService bebidaService, IPostreService postreService)
        {
            _ComboService = comboService;
            _platoPrincipalService = platoPrincipalService;
            _bebidaService = bebidaService;
            _postreService = postreService;
>>>>>>> master
        }
    
        [HttpGet]
        public async Task<ActionResult<List<Combo>>> GetCombos()
        {
<<<<<<< HEAD
            var combos = await _repository.GetAllAsync();
=======
            var combos = await _ComboService.GetAllAsync();
>>>>>>> master
            return Ok(combos);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Combo>> GetCombo(int id)
        {
<<<<<<< HEAD
            var combo = await _repository.GetByIdAsync(id);
=======
            var combo = await _ComboService.GetByIdAsync(id);
>>>>>>> master
            if (combo == null)
            {
                return NotFound();
            }
            return Ok(combo);
        }

        [HttpPost]
<<<<<<< HEAD
        public async Task<ActionResult<Combo>> CreateCombo(Combo combo)
        {
            await _repository.AddAsync(combo);
=======
        public async Task<ActionResult<Combo>> CreateCombo(ComboCreateDto comboDto)
        {
            var plato = await _platoPrincipalService.GetByIdAsync(comboDto.PlatoPrincipalId);
            if (plato == null)
            {
                return BadRequest("El PlatoPrincipal con el ID proporcionado no existe.");
            }

            var bebida = await _bebidaService.GetByIdAsync(comboDto.BebidaId);
            if (bebida == null)
            {
                return BadRequest("La Bebida con el ID proporcionado no existe.");
            }

            var postre = await _postreService.GetByIdAsync(comboDto.PostreId);
            if (postre == null)
            {
                return BadRequest("El Postre con el ID proporcionado no existe.");
            }

            var combo = new Combo
            {
                Nombre = comboDto.Nombre,
                PlatoPrincipal = plato,
                Bebida = bebida,
                Postre = postre,
                Descuento = comboDto.Descuento
            };

            await _ComboService.AddAsync(combo);
>>>>>>> master
            return CreatedAtAction(nameof(GetCombo), new { id = combo.Id }, combo);
        }

       [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCombo(int id, Combo updatedCombo)
        {
<<<<<<< HEAD
            var existingCombo = await _repository.GetByIdAsync(id);
=======
            var existingCombo = await _ComboService.GetByIdAsync(id);
>>>>>>> master
            if (existingCombo == null)
            {
                return NotFound();
            }

            // Actualizar el combo existente
            existingCombo.PlatoPrincipal = updatedCombo.PlatoPrincipal;
            existingCombo.Bebida = updatedCombo.Bebida;
            existingCombo.Postre = updatedCombo.Postre;
            existingCombo.Descuento = updatedCombo.Descuento;

<<<<<<< HEAD
            await _repository.UpdateAsync(existingCombo);
            return NoContent();
        }

        ///Cambio necesario///
  
       [HttpDelete("{id}")]
       public async Task<IActionResult> DeleteCombo(int id)
       {
           var combo = await _repository.GetByIdAsync(id);
=======
            await _ComboService.UpdateAsync(existingCombo);
            return NoContent();
        }
          
       [HttpDelete("{id}")]
       public async Task<IActionResult> DeleteCombo(int id)
       {
           var combo = await _ComboService.GetByIdAsync(id);
>>>>>>> master
           if (combo == null)
           {
               return NotFound();
           }
<<<<<<< HEAD
           await _repository.DeleteAsync(id);
=======
           await _ComboService.DeleteAsync(id);
>>>>>>> master
           return NoContent();
       }

   }
}