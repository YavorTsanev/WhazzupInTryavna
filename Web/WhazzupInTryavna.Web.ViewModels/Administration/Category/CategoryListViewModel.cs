namespace WhazzupInTryavna.Web.ViewModels.Administration.Category
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CategoryListViewModel
    {
        public ICollection<CategoryInListViewModel> Categories { get; set; }
    }
}
