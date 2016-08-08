using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PersonalThesaurus.Models
{
    public class Vocabulary
    {
        public int ID { get; set; }
        public string term { get; set; }
        //don't need to get set below because their corresponding classes already do this?
        [Display(Name="Image")]
        public int imageID { get; set; }
        public Image image { get; set; }


        public virtual ICollection<ContextTerm> contextTerms { get; set; }

        public Vocabulary()
        {
            // contextTerms = new List<ContextTerm>();
            List<object> contextTerms = new List<object>();
           image = new Image();


        }
      





    }
}
