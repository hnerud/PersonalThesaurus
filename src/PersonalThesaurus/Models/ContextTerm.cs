using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PersonalThesaurus.Models
{
    public class ContextTerm
    {
        public int ID { get; set; }
        public string term { get; set; }
        public string type { get; set; }

        public int VocabularyID { get; set; }

        public virtual Vocabulary Vocabulary { get; set; }

       
       
    }
}