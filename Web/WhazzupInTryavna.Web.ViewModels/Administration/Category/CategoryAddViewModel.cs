namespace WhazzupInTryavna.Web.ViewModels.Administration.Category
{
    using System.ComponentModel.DataAnnotations;

    using WhazzupInTryavna.Services.Mapping;

    using static WhazzupInTryavna.Common.GlobalConstants;

    public class CategoryAddViewModel : IMapFrom<Data.Models.Activities.Category>
    {
        [Required]
        [MinLength(CategoryNameMinLength)]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [RegularExpression(CategoryImageRegEx, ErrorMessage = "Only Image files allowed.")]
        public string Image { get; set; }
    }
}
