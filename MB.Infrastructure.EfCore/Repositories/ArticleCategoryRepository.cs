using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using _01.Framework.Domain;
using _01.Framework.Infrastructure;
using MB.Domain.ArticleCategoryAgg;

namespace MB.Infrastructure.EfCore.Repositories
{
    public class ArticleCategoryRepository : BaseRepository<long, ArticleCategory>, IArticleCategoryRepository
    {
        private readonly MasterBloggerDbContext _context;

        public ArticleCategoryRepository(MasterBloggerDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
