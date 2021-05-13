using System.Collections.Generic;
using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;

namespace MB.Application.Comment
{
    public class CommentApplication:ICommentApplication
    {
        private readonly ICommentRepository _repository;

        public CommentApplication(ICommentRepository repository)
        {
            _repository = repository;
        }

        public List<CommentViewModel> List()
        {
            return _repository.GetList();
        }

        public void Add(AddComment command)
        {
            var comment = new Domain.CommentAgg.Comment(command.Name, command.Email, command.Message, command.ArticleId);
            _repository.Create(comment);
        }

        public void Confirm(long id)
        {
            var comment = _repository.Get(id);

            comment.Confirm();

            //_repository.Save();
        }

        public void Cancel(long id)
        {
            var comment = _repository.Get(id);

            comment.Cancel();

            //_repository.Save();
        }
    }
}
