namespace WhazzupInTryavna.Web.ViewModels.Administration.Category
{
    using System;

    using WhazzupInTryavna.Services.Mapping;
    using Data.Models.Activities;

    public class CategoryInListViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public DateTime? ModifiedOn { get; set; }

    }
}
