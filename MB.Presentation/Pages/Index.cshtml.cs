using System.Collections.Generic;
using MB.Infrastructure.Query;
using MB.Infrastructure.Query.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IArticleQuery _query;
        public List<ArticleQueryView> Articles { get; set; }

        public IndexModel(IArticleQuery query)
        {
            _query = query;
        }

        public void OnGet()
        {
            Articles = _query.GetArticles();
        }
    }
}