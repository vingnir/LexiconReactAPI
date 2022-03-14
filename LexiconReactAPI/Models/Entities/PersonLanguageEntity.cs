namespace LexiconReactAPI.Models.Entities
{
    public class PersonLanguageEntity //Join tabel class
    {
        public int PersonId { get; set; }
        public PersonEntity Person { get; set; }

        public int LanguageId { get; set; }
        public LanguageEntity Language { get; set; }
    }
}
