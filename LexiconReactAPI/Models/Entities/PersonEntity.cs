using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LexiconReactAPI.Models.Entities
{
    public class PersonEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        [ForeignKey("City")]
        public int CurrentCityId { get; set; }
        public CityEntity City { get; set; }

        public List<PersonLanguageEntity> Languages { get; set; }
        public string PhoneNumber { get; set; }

        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
    }
}
