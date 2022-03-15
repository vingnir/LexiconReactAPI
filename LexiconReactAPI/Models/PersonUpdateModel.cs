using System.ComponentModel.DataAnnotations;

namespace LexiconReactAPI.Models
{
    public class PersonUpdateModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int CurrentCityId { get; set; }
        public string CountryId { get; set; }
        public string PhoneNumber { get; set; }
       // public string Language { get; set; }
    }
}
