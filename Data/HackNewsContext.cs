using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using hackernews.Models;

    public class HackNewsContext : DbContext
    {
        public HackNewsContext (DbContextOptions<HackNewsContext> options)
            : base(options)
        {
        }

        public DbSet<hackernews.Models.NewsStory> NewsStory { get; set; }
    }
