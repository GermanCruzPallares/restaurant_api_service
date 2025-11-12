using Microsoft.AspNetCore.Mvc;
using RestauranteAPI.Models;
using RestauranteAPI.Repositories;
using RestauranteAPI.Services;

namespace RestauranteAPI.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class ComboController : ControllerBase
   {
    private static List<Combo> combos = new List<Combo>();

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
        }
    
        [HttpGet]
        public async Task<ActionResult<List<Combo>>> GetCombos()
        {
            var combos = await _ComboService.GetAllAsync();
            return Ok(combos);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Combo>> GetCombo(int id)
        {
            var combo = await _ComboService.GetByIdAsync(id);
            if (combo == null)
            {
                return NotFound();
            }
            return Ok(combo);
        }

        [HttpPost]
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
            return CreatedAtAction(nameof(GetCombo), new { id = combo.Id }, combo);
        }

       [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCombo(int id, Combo updatedCombo)
        {
            var existingCombo = await _ComboService.GetByIdAsync(id);
            if (existingCombo == null)
            {
                return NotFound();
            }

            // Actualizar el combo existente
            existingCombo.PlatoPrincipal = updatedCombo.PlatoPrincipal;
            existingCombo.Bebida = updatedCombo.Bebida;
            existingCombo.Postre = updatedCombo.Postre;
            existingCombo.Descuento = updatedCombo.Descuento;

            await _ComboService.UpdateAsync(existingCombo);
            return NoContent();
        }

        ///Cambio necesario///
  
       [HttpDelete("{id}")]
       public async Task<IActionResult> DeleteCombo(int id)
       {
           var combo = await _ComboService.GetByIdAsync(id);
           if (combo == null)
           {
               return NotFound();
           }
           await _ComboService.DeleteAsync(id);
           return NoContent();
       }

   }
}