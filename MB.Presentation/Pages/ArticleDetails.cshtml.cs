using MB.Application.Contracts.Comment;
using MB.Infrastructure.Query;
using MB.Infrastructure.Query.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.Pages
{
    public class ArticleDetailsModel : PageModel
    {
        private readonly IArticleQuery _query;
        private readonly ICommentApplication _commentApplication;
        public ArticleQueryView Article { get; set; }

        public ArticleDetailsModel(IArticleQuery query,ICommentApplication commentApplication)
        {
            _query = query;
            _commentApplication = commentApplication;
        }

        public void OnGet(long id)
        {
            Article = _query.GetOneArticle(id);
        }

        public RedirectToPageResult OnPost(AddComment command)
        {
            _commentApplication.Add(command);

            return RedirectToPage("./ArticleDetails" , new {id = command.ArticleId});
        }
    }
}