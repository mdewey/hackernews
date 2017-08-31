using System;
using hackernews.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace hackernews
{
    public partial class HackerNewsContext : DbContext
    {

        public DbSet<NewsStory> NewsStory{get;set;}

        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql(@"Host=localhost;Database=hackernews;Username=dev;Password=dev");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { }
    }
}
