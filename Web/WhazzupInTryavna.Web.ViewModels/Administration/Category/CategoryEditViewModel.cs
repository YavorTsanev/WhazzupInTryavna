using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WhazzupInTryavna.Services.Mapping;

namespace WhazzupInTryavna.Web.ViewModels.Administration.Category
{
    public class CategoryEditViewModel : IMapFrom<Data.Models.Activities.Category>
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"(?:([^:\/?#]+):)?(?:\/\/([^\/?#]*))?([^?#]*\.(?:jpg|gif|png))(?:\?([^#]*))?(?:#(.*))?", ErrorMessage = "Only Image files allowed.")]
        public string Image { get; set; }
    }
}
