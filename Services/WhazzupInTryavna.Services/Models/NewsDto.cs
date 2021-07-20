namespace WhazzupInTryavna.Services.Models
{
    using System;

    public class NewsDto
    {
        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string ImageUrl { get; set; }

        public string Content { get; set; }
    }
}
