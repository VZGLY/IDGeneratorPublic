using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IDGeneratorAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NameController : ControllerBase
{
    private readonly IDGeneratorAPIDbContext _context;

    public NameController(IDGeneratorAPIDbContext context)
    {
        _context = context;
    }
    
    [HttpGet("AllByCountry")]
    public async Task<ActionResult<IEnumerable<Name>>> GetNamesByCountry(int countryId)
    {
        Country? country = await _context.Countries.FindAsync(countryId);
        
        if (country == null)
        {
            return NotFound();
        }

        var names =await ( from n in _context.Names
            where n.Countries.Contains(country)
            select n).ToListAsync();

        if (names == null)
        {
            return NotFound();
        }
        
        return names;
        
        
    }
    
    [HttpPost("AllByCountryAndSex")]
    public async Task<ActionResult<IEnumerable<Name>>> GetNamesByCountry(CountrySexParam param)
    {
        Country? country = await _context.Countries.FindAsync(param.CountryID);
        
        if (country == null)
        {
            return NotFound();
        }

        var names =await ( from n in _context.Names
            where n.Countries.Contains(country) && n.Sex == param.Sex
            select n).ToListAsync();

        if (names == null)
        {
            return NotFound();
        }
        
        return names;
    }
    
    [HttpGet("RandomByCountryAndSex")]
    public async Task<ActionResult<Name>> GetNamesByCountry(int countryId, string sex)
    {
        Country? country = await _context.Countries.FindAsync(countryId);
        
        if (country == null)
        {
            return NotFound();
        }

        var names =await ( from n in _context.Names
            where n.Countries.Contains(country) && n.Sex == sex
            select n).ToListAsync();

        if (names == null)
        {
            return NotFound();
        }

        Random random = new Random();
        int index = random.Next(names.Count);
        return names[index];
    
        
        
    }
}