using System.Collections.Generic;
using System.Globalization;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;

namespace MB.Application.ArticleCategory
{
    public class ArticleCategoryApplication:IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _repository;

        public ArticleCategoryApplication(IArticleCategoryRepository repository)
        {
            _repository = repository;
        }
        public List<ArticleCategoryViewModel> List()
        {
           var list = new List<ArticleCategoryViewModel>();

           var categoryArticles = _repository.GetAll();

           foreach (var item in categoryArticles)
           {
               list.Add(new ArticleCategoryViewModel
               {
                   Id = item.Id,
                   Title = item.Title,
                   IsDeleted = item.isDeleted,
                   CreationDate = item.CreationDate.ToString(CultureInfo.InvariantCulture)
               });
           }

           return list;

        }

        public void Create(CreateArticleCategory command)
        {
            var articleCategory = new Domain.ArticleCategoryAgg.ArticleCategory(command.Title);

            _repository.Create(articleCategory);
        }
    }
}
