using System;

namespace hackernews.Models
{
    public class StoryViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Url { get; set; }
        public string Submitter { get; set; }
        public int Points { get; set; }
        public DateTime TimePosted { get; set; }

        public int NumberOfComments{get;set;}

        public StoryViewModel()
        {
        }
        public StoryViewModel(NewsStory story)
        {
            this.Id = story.Id;
            this.Body = story.Body;
            this.Points = story.Points;
            this.NumberOfComments = 0;
            this.Submitter = story.Submitter;
            this.TimePosted = story.TimePosted;
            this.Title = story.Title;
            this.Url = story.Url;
        }


    }
}