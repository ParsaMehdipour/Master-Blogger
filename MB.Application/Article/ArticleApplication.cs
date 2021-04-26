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
    }
}
