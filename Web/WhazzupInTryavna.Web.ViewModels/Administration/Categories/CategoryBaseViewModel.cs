namespace WhazzupInTryavna.Web.ViewModels.Administration.Categories
{
    using System.ComponentModel.DataAnnotations;

    using static WhazzupInTryavna.Common.GlobalConstants;

    public abstract class CategoryBaseViewModel
    {
        [Required]
        [MinLength(CategoryConst.NameMinLength)]
        [MaxLength(CategoryConst.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [RegularExpression(CategoryConst.ImageRegEx, ErrorMessage = ErrorMessageConst.AllowedExtensionError)]
        public string Image { get; set; }
    }
}
