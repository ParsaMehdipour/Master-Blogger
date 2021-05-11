using System.Collections.Generic;

namespace MB.Application.Contracts.Comment
{
    public interface ICommentApplication
    {
        List<CommentViewModel> List();
        void Add(AddComment command);
        void Confirm(long id);
        void Cancel(long id);
    }
}
