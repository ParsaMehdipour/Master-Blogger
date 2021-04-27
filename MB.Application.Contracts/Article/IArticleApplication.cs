using System.Collections.Generic;

namespace MB.Application.Contracts.Article
{
    public interface IArticleApplication
    {
        List<ArticleViewModel> GetList();
        EditArticle Get(long id);
        void Create(CreateArticle command);
        void Edit(EditArticle command);
    }
}
