using System.Collections.Generic;
using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.Areas.Admin.Pages.ArticleCategory
{
    public class ListModel : PageModel
    {
        public List<ArticleCategoryViewModel> ArticleCategoryViewModels { get; set; }

        private readonly IArticleCategoryApplication _application;

        public ListModel(IArticleCategoryApplication application)

        {
            _application = application;
        }
        public void OnGet()
        {
            ArticleCategoryViewModels = _application.List();
        }
    }
}
