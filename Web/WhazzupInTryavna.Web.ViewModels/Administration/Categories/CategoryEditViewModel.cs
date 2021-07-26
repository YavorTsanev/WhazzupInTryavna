namespace WhazzupInTryavna.Web.ViewModels.Administration.Categories
{
    using WhazzupInTryavna.Data.Models.Activities;
    using WhazzupInTryavna.Services.Mapping;

    public class CategoryEditViewModel : CategoryBaseViewModel, IMapFrom<Category>
    {
        public int Id { get; set; }
    }
}
