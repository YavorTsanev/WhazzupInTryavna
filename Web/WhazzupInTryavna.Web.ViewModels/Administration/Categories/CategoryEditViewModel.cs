namespace WhazzupInTryavna.Web.ViewModels.Administration.Categories
{
    using System.ComponentModel.DataAnnotations;

    using WhazzupInTryavna.Data.Models.Activities;
    using WhazzupInTryavna.Services.Mapping;

    using static WhazzupInTryavna.Common.GlobalConstants;

    public class CategoryEditViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(CategoryNameMinLength)]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [RegularExpression(CategoryImageRegEx, ErrorMessage = "Only Image files allowed.")]
        public string Image { get; set; }
    }
}
