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

        public EditArticleCategory Get(long id)
        {
            var article = _repository.Get(id);
            return new EditArticleCategory
            {
                Id = article.Id,
                Title = article.Title
            };
        }

        public void Create(CreateArticleCategory command)
        {
            var articleCategory = new Domain.ArticleCategoryAgg.ArticleCategory(command.Title);

            _repository.Create(articleCategory);
        }

        public void Edit(EditArticleCategory command)
        {
            var articleCategory = _repository.Get(command.Id);
            articleCategory.Edit(command.Title);
            _repository.Save();
        }

        public void Remove(long id)
        {
            var articleCategory = _repository.Get(id);
            articleCategory.Remove();
            _repository.Save();
        }

        public void Activate(long id)
        {
            var articleCategory = _repository.Get(id);
            articleCategory.Activate();
            _repository.Save();
        }
    }
}
