using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonalThesaurus.Data;
using PersonalThesaurus.Models;

namespace PersonalThesaurus.Controllers
{
    public class VocabularyViewController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VocabularyViewController(ApplicationDbContext context)
        {
            _context = context;    
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<Vocabulary> vocab = new List<Vocabulary>();
            using (_context)
            {
                vocab = _context.Vocabulary.Include(p => p.contextTerms).ToList();
            }
            return View("Index", vocab);
        }

        // GET: VocabularyView
        //public async Task<IActionResult> Index()
        //{


        //    var applicationDbContext = _context.Vocabulary.Include(v => v.image);





        //    return View(await applicationDbContext.ToListAsync());
        //}

        // GET: VocabularyView/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vocabulary = await _context.Vocabulary.SingleOrDefaultAsync(m => m.ID == id);
            if (vocabulary == null)
            {
                return NotFound();
            }

            return View(vocabulary);
        }

        // GET: VocabularyView/Create
        public IActionResult Create()
        {
            ViewData["imageID"] = new SelectList(_context.Image, "ID", "ID");

           
            return View();
        }

        // POST: VocabularyView/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,imageID,term")] Vocabulary vocabulary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vocabulary);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["imageID"] = new SelectList(_context.Image, "ID", "ID", vocabulary.imageID);

            
            return View(vocabulary);
        }

        // GET: VocabularyView/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vocabulary = await _context.Vocabulary.SingleOrDefaultAsync(m => m.ID == id);
            if (vocabulary == null)
            {
                return NotFound();
            }
            ViewData["imageID"] = new SelectList(_context.Image, "ID", "ID", vocabulary.imageID);
            return View(vocabulary);
        }

        // POST: VocabularyView/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,imageID,term")] Vocabulary vocabulary)
        {
            if (id != vocabulary.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vocabulary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VocabularyExists(vocabulary.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["imageID"] = new SelectList(_context.Image, "ID", "ID", vocabulary.imageID);
            return View(vocabulary);
        }

        // GET: VocabularyView/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vocabulary = await _context.Vocabulary.SingleOrDefaultAsync(m => m.ID == id);
            if (vocabulary == null)
            {
                return NotFound();
            }

            return View(vocabulary);
        }

        // POST: VocabularyView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vocabulary = await _context.Vocabulary.SingleOrDefaultAsync(m => m.ID == id);
            _context.Vocabulary.Remove(vocabulary);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool VocabularyExists(int id)
        {
            return _context.Vocabulary.Any(e => e.ID == id);
        }
    }
}
