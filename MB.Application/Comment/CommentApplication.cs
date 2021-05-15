using System.Collections.Generic;
using _01.Framework.Infrastructure;
using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;

namespace MB.Application.Comment
{
    public class CommentApplication:ICommentApplication
    {
        private readonly ICommentRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CommentApplication(ICommentRepository repository,IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public List<CommentViewModel> List()
        {
            return _repository.GetList();
        }

        public void Add(AddComment command)
        {
            _unitOfWork.BeginTran();
            var comment = new Domain.CommentAgg.Comment(command.Name, command.Email, command.Message, command.ArticleId);
            _repository.Create(comment);
            _unitOfWork.CommitTran();
        }

        public void Confirm(long id)
        {
            _unitOfWork.BeginTran();
            var comment = _repository.Get(id);

            comment.Confirm();
            _unitOfWork.CommitTran();
        }

        public void Cancel(long id)
        {
            _unitOfWork.BeginTran();
            var comment = _repository.Get(id);

            comment.Cancel();
            _unitOfWork.CommitTran();
        }
    }
}
