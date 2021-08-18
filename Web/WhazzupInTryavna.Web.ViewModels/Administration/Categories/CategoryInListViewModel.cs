namespace WhazzupInTryavna.Web.ViewModels.Administration.Categories
{
    using System;

    using WhazzupInTryavna.Data.Models.Activities;
    using WhazzupInTryavna.Services.Mapping;

    public class CategoryInListViewModel : CategoryBaseViewModel, IMapFrom<Category>
    {
        public int Id { get; set; }

        public int ActivitiesCount { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
