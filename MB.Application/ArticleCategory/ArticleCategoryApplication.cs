using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using _01.Framework.Infrastructure;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Service;

namespace MB.Application.ArticleCategory
{
    public class ArticleCategoryApplication:IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _repository;
        private readonly IArticleCategoryService _service;
        private readonly IUnitOfWork _unitOfWork;

        public ArticleCategoryApplication(IArticleCategoryRepository repository,IArticleCategoryService service,IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _service = service;
            _unitOfWork = unitOfWork;
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
            _unitOfWork.BeginTran();
            var articleCategory = new Domain.ArticleCategoryAgg.ArticleCategory(command.Title,_service);

            _repository.Create(articleCategory);
            _unitOfWork.CommitTran();
        }

        public void Edit(EditArticleCategory command)
        {
            _unitOfWork.BeginTran();
            var articleCategory = _repository.Get(command.Id);
            articleCategory.Edit(command.Title);
            _unitOfWork.CommitTran();
        }

        public void Remove(long id)
        {
            _unitOfWork.BeginTran();
            var articleCategory = _repository.Get(id);
            articleCategory.Remove();
            _unitOfWork.CommitTran();
        }

        public void Activate(long id)
        {
            _unitOfWork.BeginTran();
            var articleCategory = _repository.Get(id);
            articleCategory.Activate();
            _unitOfWork.CommitTran();
        }
    }
}
