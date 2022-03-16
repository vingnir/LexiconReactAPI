using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LexiconReactAPI.Models.Entities
{
    public class CountryEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CountryName { get; set; }
       
        public virtual ICollection<PersonEntity> People { get; set; }
    }
}
