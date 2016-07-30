using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalThesaurus.Models
{
    public class Vocabulary
    {
        public int ID { get; set; }
        public string term { get; set; }
        //don't need to get set below because their corresponding classes already do this?
        public int imageID { get; set; }
        public Image image { get; set; }

        public virtual ICollection<ContextTerm> contextTerms { get; set; }

        public Vocabulary()
        {
            //contextTerms = new List<ContextTerm>();
           image = new Image();

        }





    }
}
