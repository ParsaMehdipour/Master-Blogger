using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.Areas.Admin.Pages.ArticleCategory
{
    public class EditModel : PageModel
    {
        private readonly IArticleCategoryApplication _application;

        [BindProperty] public EditArticleCategory ArticleCategory { get; set; }

        public EditModel(IArticleCategoryApplication application)
        {
            _application = application;
        }

        public void OnGet(long id)
        {
            ArticleCategory = _application.Get(id);
        }

        public RedirectToPageResult OnPost()
        {
            _application.Edit(ArticleCategory);
            return RedirectToPage("./List");
        }
    }
}
