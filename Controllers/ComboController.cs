using Microsoft.AspNetCore.Mvc;
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

    public ComboController(IComboService ComboService)
        {
            _ComboService = ComboService;
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
        public async Task<ActionResult<Combo>>ComboUpdate(Combo combo)
        {
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