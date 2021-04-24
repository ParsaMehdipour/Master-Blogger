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
            Save();;
        }

        public ArticleCategory Get(long id)
        {
            return _context.ArticleCategories.Find(id);
        }

        public List<ArticleCategory> GetAll()
        {
            return _context.ArticleCategories.OrderByDescending(x=>x.Id).ToList();
        }

        public bool Exists(string title)
        {
            return _context.ArticleCategories.Any(x => x.Title == title);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
