using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MB.Domain.ArticleCategoryAgg;

namespace MB.Infrastructure.EfCore.Repositories
{
    public class ArticleCategoryRepository:IArticleCategoryRepository
    {
        private readonly MasterBloggerDbContext _context;

        public ArticleCategoryRepository(MasterBloggerDbContext context)
        {
            _context = context;
        }

        public void Create(ArticleCategory category)
        {
            _context.ArticleCategories.Add(category);
            _context.SaveChanges();
        }

        public List<ArticleCategory> GetAll()
        {
            return _context.ArticleCategories.ToList();
        }
    }
}
