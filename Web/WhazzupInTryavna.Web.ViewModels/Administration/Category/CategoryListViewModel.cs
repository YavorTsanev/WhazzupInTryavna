using System;
using System.Collections.Generic;
using System.Text;

namespace WhazzupInTryavna.Web.ViewModels.Administration.Category
{
    public class CategoryListViewModel
    {
        public ICollection<CategoryInListViewModel> Categories { get; set; }
    }
}
