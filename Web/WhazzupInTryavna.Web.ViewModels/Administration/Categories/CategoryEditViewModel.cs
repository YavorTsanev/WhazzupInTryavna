namespace WhazzupInTryavna.Web.ViewModels.Administration.Categories
{
    using System.ComponentModel.DataAnnotations;

    using WhazzupInTryavna.Data.Models.Activities;
    using WhazzupInTryavna.Services.Mapping;

    using static WhazzupInTryavna.Common.GlobalConstants;

    public class CategoryEditViewModel : CategoryBaseViewModel, IMapFrom<Category>
    {
        public int Id { get; set; }
    }
}
