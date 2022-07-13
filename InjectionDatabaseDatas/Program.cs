// See https://aka.ms/new-console-template for more information

using System.Globalization;
using CsvHelper;
using IDGeneratorAPI;
using Microsoft.EntityFrameworkCore;


List<Country> countries = new List<Country>();
List<Name> names = new List<Name>();
var file = File.ReadAllLines("../../../firstnames.csv");
for (int i = 2; i < file[0].Split(",").Length; i++)
{
    countries.Add(new Country(file[0].Split(",")[i]));
    
}

for (int i = 1; i < file.Length; i+=2)
{
    Name name = new Name(file[i].Split(",")[0]);
    name.Sex = file[i].Split(",")[1];
    for (int j = 2; j < file[i].Split(",").Length; j++)
    {
        if ( !string.IsNullOrEmpty(file[i].Split(",")[j]))
        {
            for (int k = 0; k < countries.Count; k++)
            {
                if (countries[k].CountryName == file[0].Split(",")[j])
                {
                    name.Countries.Add(countries[k]);
                    names.Add(name);
                    countries[k].Names.Add(name);
                    
                    k = countries.Count;
                }
            }
        }
    }
}
Console.WriteLine("Integrate Names Done");
Console.WriteLine("Work Done.");

using (var _context = new IDGeneratorAPIDbContext())
{
    _context.AddRange(countries);
    Console.WriteLine("Integrate Countries Done");
    _context.AddRange(names);
    Console.WriteLine("Integrate Names Done");
    _context.SaveChanges();
    Console.WriteLine("Work Done.");
}









   
