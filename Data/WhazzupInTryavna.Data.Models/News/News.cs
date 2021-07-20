using System;

namespace WhazzupInTryavna.Data.Models.News
{
    using WhazzupInTryavna.Data.Common.Models;

    public class News : BaseDeletableModel<int>
    {
        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string ImageUrl { get; set; }

        public string Content { get; set; }
    }
}
