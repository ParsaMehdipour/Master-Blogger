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

        public void Create(CreateArticle command)
        {
            var article = new Domain.ArticleAgg.
                Article(command.Title, command.ShortDescription, command.Content, command.Image,
                    command.ArticleCategoryId);
            
            _repository.CreateAndSave(article);
        }
    }
}
