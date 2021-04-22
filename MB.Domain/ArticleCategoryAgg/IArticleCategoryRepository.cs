using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository
    {
        void Create(ArticleCategory category);
        ArticleCategory Get(long id);
        List<ArticleCategory> GetAll();
        void Save();
    }
}
