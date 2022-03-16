using System.ComponentModel.DataAnnotations;

namespace LexiconReactAPI.Models.Entities
{
    public class CityEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CityName { get; set; }
        public List<PersonEntity> People { get; set; }
    }
}
