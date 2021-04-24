using System;
using MB.Domain.ArticleCategoryAgg.Exceptions;

namespace MB.Domain.ArticleCategoryAgg.Service
{
    class ArticleCategoryService : IArticleCategoryService
    {
        private readonly IArticleCategoryRepository _repository;

        public ArticleCategoryService(IArticleCategoryRepository repository)
        {
            _repository = repository;
        }

        public void CheckDuplication(string title)
        {
            if(_repository.Exists(title))
                throw new DuplicationException("This Article Category Already Exists");
        }
    }
}