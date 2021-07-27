﻿namespace WhazzupInTryavna.Web.ViewModels.News
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using static WhazzupInTryavna.Common.GlobalConstants;

    public abstract class NewsBaseViewModel
    {
        [Required]
        public string Title { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [RegularExpression(NewsImageRegEx, ErrorMessage = AllowedExtensionError)]
        public string ImageUrl { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
