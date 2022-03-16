using System.ComponentModel.DataAnnotations;

namespace LexiconReactAPI.Models
{
    public class PersonUpdateModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
       
        public int CurrentCityId { get; set; }
        public int CountryId { get; set; }
        public string PhoneNumber { get; set; }
       // public string Language { get; set; }
    }
}
