using System;

namespace WhazzupInTryavna.Services.Models
{
    public class NewsDto
    {
        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string ImageUrl { get; set; }

        public string Content { get; set; }
    }
}
