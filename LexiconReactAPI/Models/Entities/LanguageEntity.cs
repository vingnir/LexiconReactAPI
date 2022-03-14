using System.ComponentModel.DataAnnotations;

namespace LexiconReactAPI.Models.Entities
{
    public class LanguageEntity
    {
        [Key]
        public int LanguageId { get; set; }
        
        public string LanguageName { get; set; }

        public List<PersonLanguageEntity> People { get; set; }
    }
}
