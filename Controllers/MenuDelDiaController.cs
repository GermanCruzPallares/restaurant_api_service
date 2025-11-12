using Microsoft.AspNetCore.Mvc;
using Models;
using RestauranteAPI.Services;

namespace RestauranteAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MenuDelDiaController : ControllerBase
{
    private readonly IMenuDelDiaService _menuDelDiaService;

    public MenuDelDiaController(IMenuDelDiaService menuDelDiaService)
    {
        _menuDelDiaService = menuDelDiaService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var menus = await _menuDelDiaService.GetAllAsync();
        return Ok(menus);
    }

    [HttpGet("{fecha}")]
    public async Task<IActionResult> GetByDate(DateTime fecha)
    {
        var menu = await _menuDelDiaService.GetByDateAsync(fecha);
        if (menu == null)
        {
            return NotFound();
        }
        return Ok(menu);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] MenuDelDia menu)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdMenu = await _menuDelDiaService.CreateAsync(menu);
        return CreatedAtAction(nameof(GetByDate), new { fecha = createdMenu.Fecha.ToString("yyyy-MM-dd") }, createdMenu);
    }
}