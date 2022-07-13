using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace IDGeneratorAPI;


public class Name
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Firstname { get; set; }
    
    [Required]
    public string Sex { get; set; }
    public List<Country> Countries { get; set; } = new List<Country>();

    public Name(string name)
    {
        Firstname = name;
    }

    public Name()
    {
        
    }
}