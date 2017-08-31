using System;
using System.ComponentModel.DataAnnotations;

namespace hackernews.Models
{
    public class NewsStory
    {
        public int Id { get; set; }
      
        [Required]
        public string Title { get; set; }
        public string Body { get; set; }
        public string Url { get; set; }
        public string Submitter { get; set; }
        public int Points { get; set; }
        public DateTime TimePosted { get; set; } = DateTime.Now;
    }
}