using System.ComponentModel.DataAnnotations;

namespace LexiconReactAPI.Models.Entities
{
    public class CountryEntity
    {
        [Key]
        public int CountryId { get; set; }
        [Required]
        public string CountryName { get; set; }

        public List<CityEntity> Cities { get; set; }

        public virtual ICollection<PersonEntity> People { get; set; }
    }
}
