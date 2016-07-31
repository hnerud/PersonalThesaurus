using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonalThesaurus.Data;
using PersonalThesaurus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalThesaurus.Models
{
    public class SeedData
    {
       
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.ContextTerm.Any())
                {
                    return;
                }

                context.Vocabulary.AddRange(
                     new Vocabulary
                     {
                         term = "conformity",
                         image = { size = 6, fileName = "idyllic.jpg", imagePath = "images/idyllic.jpg" },
                        
                         
                         
                        
                         //contextTerms.Add(new ContextTerm
                         //{
                         //    term = "pleasant",
                         //    type = "basic"
                         //})
                         //add context terms where vocab Id = current 

                        
                         

                     }
                       );

                context.ContextTerm.AddRange(
                    new ContextTerm
                    {




                        VocabularyID=7,
                        term = "pleasant",
                        type = "basic",
                    },

                        new ContextTerm
                        {
                            VocabularyID=7,
                            term = "bucolic",
                            type = "advanced",

                            //add context terms where vocab Id = current 




                        }
                      );


                context.SaveChanges();
            }
        }
    }
}
