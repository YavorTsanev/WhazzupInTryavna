namespace WhazzupInTryavna.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WhazzupInTryavna.Common;
    using WhazzupInTryavna.Services.Data.News;
    using WhazzupInTryavna.Web.Controllers;
    using WhazzupInTryavna.Web.ViewModels.Administration.News;
    using WhazzupInTryavna.Web.ViewModels.News;

    public class NewsController : AdminBaseController
    {
        private readonly INewsService newsService;

        public NewsController(INewsService newsService)
        {
            this.newsService = newsService;
        }

        public IActionResult All()
        {
            var model = new NewsAdminListingViewModel
            {
                NewsList = this.newsService.GetAll<NewsInListViewModel>(),
            };

            return this.View(model);
        }

        public IActionResult Edit(int id)
        {
            var model = this.newsService.GetById<NewsAdminEditViewModel>(id);

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewsAdminEditViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.newsService.UpdateByIdAsync(id, model);

            return this.RedirectToAction(nameof(this.All));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.newsService.DeleteAsync(id);
            return this.RedirectToAction(nameof(this.All));
        }
    }
}
