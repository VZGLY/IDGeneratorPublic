using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IDGeneratorAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountriesController : ControllerBase
{
    private readonly IDGeneratorAPIDbContext _context;

    public CountriesController(IDGeneratorAPIDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
    {
        if (_context.Countries == null)
        {
            return NotFound();
        }
        return await _context.Countries.ToListAsync();
    }
}