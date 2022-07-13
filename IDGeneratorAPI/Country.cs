using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace IDGeneratorAPI;


public class Country
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string CountryName { get; set; }
    
    
    public List<Name> Names { get; set; } = new List<Name>();

    
    public Country(string name)
    {
        CountryName = name;
    }

    public Country()
    {
        
    }
}