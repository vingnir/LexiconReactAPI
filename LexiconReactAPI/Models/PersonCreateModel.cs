using LexiconReactAPI.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace LexiconReactAPI.Models
{
    public class PersonCreateModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        //public string Language { get; set; }
        



    }
}
