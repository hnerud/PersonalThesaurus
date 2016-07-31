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
    public class ContextTermsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContextTermsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ContextTerms
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContextTerm.ToListAsync());
        }

        // GET: ContextTerms/Details/5
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

        // GET: ContextTerms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContextTerms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,term,type")] ContextTerm contextTerm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contextTerm);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(contextTerm);
        }

        // GET: ContextTerms/Edit/5
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
            return View(contextTerm);
        }

        // POST: ContextTerms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,term,type")] ContextTerm contextTerm)
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
            return View(contextTerm);
        }

        // GET: ContextTerms/Delete/5
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

        // POST: ContextTerms/Delete/5
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
