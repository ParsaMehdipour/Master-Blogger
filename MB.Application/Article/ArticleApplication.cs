using System.Collections.Generic;
using _01.Framework.Infrastructure;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;

namespace MB.Application.Article
{
    public class ArticleApplication:IArticleApplication
    {
        private readonly IArticleRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ArticleApplication(IArticleRepository repository,IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public List<ArticleViewModel> GetList()
        {
            return _repository.GetList();
        }

        public EditArticle Get(long id)
        {
            var article = _repository.Get(id);
            return new EditArticle
            {
                Id = article.Id,
                Title = article.Title,
                ShortDescription = article.ShortDescription,
                Content = article.Content,
                Image = article.Image,
                ArticleCategoryId = article.ArticleCategoryId
            };
        }

        public void Create(CreateArticle command)
        {
            _unitOfWork.BeginTran();
            var article = new Domain.ArticleAgg.
                Article(command.Title, command.ShortDescription, command.Content, command.Image,
                    command.ArticleCategoryId);
            
            _repository.Create(article);
            _unitOfWork.CommitTran();
        }

        public void Edit(EditArticle command)
        {
            _unitOfWork.BeginTran();
            var article = _repository.Get(command.Id);
            article.Edit(command.Title,command.ShortDescription,command.Content,command.Image,command.ArticleCategoryId);
            _unitOfWork.CommitTran();
        }

        public void Remove(long id)
        {
            _unitOfWork.BeginTran();
            var article = _repository.Get(id);
            article.Remove();
            _unitOfWork.CommitTran();
        }

        public void Activate(long id)
        {
            _unitOfWork.BeginTran();
            var article = _repository.Get(id);
            article.Activate();
            _unitOfWork.CommitTran();
        }
    }
}
