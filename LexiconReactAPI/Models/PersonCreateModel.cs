using LexiconReactAPI.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace LexiconReactAPI.Models
{
    public class PersonCreateModel
    {
        [Required]
        public string Name { get; set; }
        
        public string CityName { get; set; }
        
        public string CountryName { get; set; }
        public string PhoneNumber { get; set; }
        //public string Language { get; set; } TODO
        



    }
}
