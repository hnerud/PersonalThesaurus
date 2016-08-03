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
    public class ContextTermController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContextTermController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ContextTerm
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ContextTerm.Include(c => c.Vocabulary);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ContextTerm/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contextTerm = await _context.ContextTerm.SingleOrDefaultAsync(m => m.ID == id);
            if (contextTerm == null)
            {
                return NotFound();
            }

            return View(contextTerm);
        }

        // GET: ContextTerm/Create
        public IActionResult Create()
        {
            //ViewData["VocabularyID"] = new SelectList(_context.Vocabulary, "ID", "ID");

            ViewBag.Items = new SelectList(_context.Vocabulary, "ID", "Name");
            return View();
        }

        // POST: ContextTerm/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,VocabularyID,term,type")] ContextTerm contextTerm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contextTerm);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            //ViewData["VocabularyID"] = new SelectList(_context.Vocabulary, "ID", "ID", contextTerm.VocabularyID);
            ViewBag.Items = new SelectList(_context.Vocabulary, "ID", "Name", contextTerm.VocabularyID);
            return View(contextTerm);
        }

        // GET: ContextTerm/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contextTerm = await _context.ContextTerm.SingleOrDefaultAsync(m => m.ID == id);
            if (contextTerm == null)
            {
                return NotFound();
            }
            //ViewData["VocabularyID"] = new SelectList(_context.Vocabulary, "ID", "ID", contextTerm.VocabularyID);
            ViewBag.Items = new SelectList(_context.Vocabulary, "ID", "Name", contextTerm.VocabularyID);
            return View(contextTerm);
        }

        // POST: ContextTerm/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,VocabularyID,term,type")] ContextTerm contextTerm)
        {
            if (id != contextTerm.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contextTerm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContextTermExists(contextTerm.ID))
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
            //ViewData["VocabularyID"] = new SelectList(_context.Vocabulary, "ID", "ID", contextTerm.VocabularyID);
            ViewBag.Items = new SelectList(_context.Vocabulary, "ID", "Name", contextTerm.VocabularyID);
            return View(contextTerm);
        }

        // GET: ContextTerm/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contextTerm = await _context.ContextTerm.SingleOrDefaultAsync(m => m.ID == id);
            if (contextTerm == null)
            {
                return NotFound();
            }

            return View(contextTerm);
        }

        // POST: ContextTerm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contextTerm = await _context.ContextTerm.SingleOrDefaultAsync(m => m.ID == id);
            _context.ContextTerm.Remove(contextTerm);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ContextTermExists(int id)
        {
            return _context.ContextTerm.Any(e => e.ID == id);
        }
    }
}
