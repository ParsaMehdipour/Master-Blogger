using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Service;

namespace MB.Application.ArticleCategory
{
    public class ArticleCategoryApplication:IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _repository;
        private readonly IArticleCategoryService _service;

        public ArticleCategoryApplication(IArticleCategoryRepository repository,IArticleCategoryService service)
        {
            _repository = repository;
            _service = service;
        }
        public List<ArticleCategoryViewModel> List()
        {
           var list = new List<ArticleCategoryViewModel>();

           var articleCategories = _repository.GetAll();

           return articleCategories.Select(c => new ArticleCategoryViewModel
           {
               Id = c.Id,
               Title = c.Title,
               IsDeleted = c.isDeleted,
               CreationDate = c.CreationDate.ToString(CultureInfo.InvariantCulture)
           }).OrderByDescending(c => c.Id).ToList();
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
            var articleCategory = new Domain.ArticleCategoryAgg.ArticleCategory(command.Title,_service);

            _repository.Create(articleCategory);
        }

        public void Edit(EditArticleCategory command)
        {
            var articleCategory = _repository.Get(command.Id);
            articleCategory.Edit(command.Title);
            //_repository.Save();
        }

        public void Remove(long id)
        {
            var articleCategory = _repository.Get(id);
            articleCategory.Remove();
            //_repository.Save();
        }

        public void Activate(long id)
        {
            var articleCategory = _repository.Get(id);
            articleCategory.Activate();
            //_repository.Save();
        }
    }
}
