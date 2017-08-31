using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using hackernews.Models;

namespace hackernews.Controllers
{
    public class StoryController : Controller
    {
        private readonly HackerNewsContext _context;

        public StoryController(HackerNewsContext context)
        {
            _context = context;
        }

        // GET: Story
        public async Task<IActionResult> Index()
        {
            return View(await _context.NewsStory.ToListAsync());
        }

        // GET: Story/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsStory = await _context
                .NewsStory
                .Include(i => i.Comments)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (newsStory == null)
            {
                return NotFound();
            }

            return View(newsStory);
        }

        // GET: Story/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Story/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Body,Url")] NewsStory newsStory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newsStory);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(newsStory);
        }

        // GET: Story/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsStory = await _context.NewsStory.SingleOrDefaultAsync(m => m.Id == id);
            if (newsStory == null)
            {
                return NotFound();
            }
            return View(newsStory);
        }

        // POST: Story/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Body,Url,Submitter,Points,TimePosted")] NewsStory newsStory)
        {
            if (id != newsStory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newsStory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsStoryExists(newsStory.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(newsStory);
        }

        // GET: Story/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsStory = await _context.NewsStory
                .SingleOrDefaultAsync(m => m.Id == id);
            if (newsStory == null)
            {
                return NotFound();
            }

            return View(newsStory);
        }

        // POST: Story/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newsStory = await _context.NewsStory.SingleOrDefaultAsync(m => m.Id == id);
            _context.NewsStory.Remove(newsStory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsStoryExists(int id)
        {
            return _context.NewsStory.Any(e => e.Id == id);
        }
    }
}
