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
        public Image image { get; set; }
        public List<ContextTerm> contextTerm {get;set;}

       
        
    }
}
