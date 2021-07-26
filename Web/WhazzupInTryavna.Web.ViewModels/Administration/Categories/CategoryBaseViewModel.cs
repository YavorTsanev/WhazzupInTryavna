using System.ComponentModel.DataAnnotations;

namespace WhazzupInTryavna.Web.ViewModels.Administration.Categories
{
    using static WhazzupInTryavna.Common.GlobalConstants;

    public abstract class CategoryBaseViewModel
    {
        [Required]
        [MinLength(CategoryNameMinLength)]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [RegularExpression(CategoryImageRegEx, ErrorMessage = AllowedExtensionError)]
        public string Image { get; set; }
    }
}
