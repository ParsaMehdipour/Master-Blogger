using System.Collections.Generic;
using MB.Application.Contracts.Article;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MB.Presentation.Areas.Admin.Pages.Article
{
    public class ListModel : PageModel
    {
        public List<ArticleViewModel> Articles { get; set; }
        private readonly IArticleApplication _application;

        public ListModel(IArticleApplication application)
        {
            _application = application;
        }
        public void OnGet()
        {
            Articles = _application.GetList();
        }
    }
}
