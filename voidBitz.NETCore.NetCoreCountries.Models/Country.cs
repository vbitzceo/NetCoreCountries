using System.ComponentModel.DataAnnotations;

namespace voidBitz.NETCore.NetCoreCountries.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
    }
}
