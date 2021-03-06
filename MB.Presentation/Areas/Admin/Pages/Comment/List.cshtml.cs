using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MB.Application.Contracts.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.Areas.Admin.Pages.Comment
{
    public class ListModel : PageModel
    {
        public List<CommentViewModel> Comments { get; set; }

        private readonly ICommentApplication _application;

        public ListModel(ICommentApplication application)
        {
            _application = application;
        }
        public void OnGet()
        {
            ViewData["Title"] = "Comment Management";

            Comments = _application.List();
        }

        public RedirectToPageResult OnPostConfirm(long id)
        {
            _application.Confirm(id);

            return RedirectToPage("./List");
        }

        public RedirectToPageResult OnPostCancel(long id)
        {
            _application.Cancel(id);

            return RedirectToPage("./List");
        }
    }
}
