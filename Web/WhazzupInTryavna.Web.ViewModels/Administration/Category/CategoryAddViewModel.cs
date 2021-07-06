namespace WhazzupInTryavna.Web.ViewModels.Administration.Category
{
    using System.ComponentModel.DataAnnotations;

    using WhazzupInTryavna.Services.Mapping;

    public class CategoryAddViewModel : IMapFrom<Data.Models.Activities.Category>
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"(?:([^:\/?#]+):)?(?:\/\/([^\/?#]*))?([^?#]*\.(?:jpg|gif|png))(?:\?([^#]*))?(?:#(.*))?", ErrorMessage = "Only Image files allowed.")]
        public string Image { get; set; }
    }
}
