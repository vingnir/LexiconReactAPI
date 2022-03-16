using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LexiconReactAPI.Models.Entities
{
    public class CountryEntity
    {
        [Key]
        public int CountryId { get; set; }
        [Required]
        public string CountryName { get; set; }
       
        public virtual ICollection<PersonEntity> People { get; set; }
    }
}
