using System;
using System.ComponentModel.DataAnnotations;

namespace hackernews.Models
{
    public class Comment{
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime TimePosted { get; set; } = DateTime.Now;

        public int VoteCount { get; set; }

        public string  Submitter { get; set; }

        public int NewsStoryId { get; set; }
        public NewsStory NewsStory { get; set; }
    }
}