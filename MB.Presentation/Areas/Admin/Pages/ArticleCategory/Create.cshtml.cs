using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.Areas.Admin.Pages.ArticleCategory
{
    public class CreateModel : PageModel
    {
        private readonly IArticleCategoryApplication _application;

        public CreateModel(IArticleCategoryApplication application)
        {
            _application = application;
        }

        public void OnGet()
        {
            ViewData["Title"] = "Create";
        }

        public RedirectToPageResult OnPost(CreateArticleCategory command)
        {
            _application.Create(command);
            return RedirectToPage("./List");
        }
    }
}
