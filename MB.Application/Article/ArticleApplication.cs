using System.Collections.Generic;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;

namespace MB.Application.Article
{
    public class ArticleApplication:IArticleApplication
    {
        private readonly IArticleRepository _repository;

        public ArticleApplication(IArticleRepository repository)
        {
            _repository = repository;
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
            var article = new Domain.ArticleAgg.
                Article(command.Title, command.ShortDescription, command.Content, command.Image,
                    command.ArticleCategoryId);
            
            _repository.CreateAndSave(article);
        }

        public void Edit(EditArticle command)
        {
            var article = _repository.Get(command.Id);
            article.Edit(command.Title,command.ShortDescription,command.Content,command.Image,command.ArticleCategoryId);
            _repository.Save();
        }
    }
}
