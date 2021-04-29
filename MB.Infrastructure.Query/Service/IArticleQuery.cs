using System.Collections.Generic;

namespace MB.Infrastructure.Query.Service
{
    public interface IArticleQuery
    {
        List<ArticleQueryView> GetArticles();
    }
}
