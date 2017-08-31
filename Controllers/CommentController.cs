using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using hackernews.Models;
using Microsoft.EntityFrameworkCore;

namespace hackernews.Controllers
{
    public class CommentController : Controller
    {
        private readonly HackerNewsContext _context;

        public CommentController(HackerNewsContext context)
        {
            this._context = context;
        }



        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromRoute]int id, [FromForm]string comment)
        {
            Console.WriteLine(id);
            Console.WriteLine(comment);

            var newComment = new Comment {NewsStoryId = id, Text = comment};
            var story = await _context.NewsStory.SingleOrDefaultAsync( s => s.Id == id);
            story.Comments.Add(newComment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Story", new {id});
        }
    }
}
