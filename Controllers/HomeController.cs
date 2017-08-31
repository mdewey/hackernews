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
    public class HomeController : Controller
    {
        private readonly HackerNewsContext _context;

        public HomeController(HackerNewsContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {

            // query the database
            // create the viewmodels
            var vm = _context.NewsStory
                .Include(i => i.Comments)
                .Select(s => new StoryViewModel(s));
            return View(vm);
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
