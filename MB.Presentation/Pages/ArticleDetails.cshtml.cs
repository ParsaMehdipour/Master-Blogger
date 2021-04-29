using MB.Infrastructure.Query;
using MB.Infrastructure.Query.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.Pages
{
    public class ArticleDetailsModel : PageModel
    {
        private readonly IArticleQuery _query;
        public ArticleQueryView Article { get; set; }

        public ArticleDetailsModel(IArticleQuery query)
        {
            _query = query;
        }

        public void OnGet(long id)
        {
            Article = _query.GetOneArticle(id);
        }
    }
}