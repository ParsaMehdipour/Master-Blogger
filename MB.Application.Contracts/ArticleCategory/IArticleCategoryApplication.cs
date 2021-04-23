using System.Collections.Generic;

namespace MB.Application.Contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        List<ArticleCategoryViewModel> List();
        EditArticleCategory Get(long id);
        void Create(CreateArticleCategory command);
        void Edit(EditArticleCategory command);
        void Remove(long id);
        void Activate(long id);
    }
}
