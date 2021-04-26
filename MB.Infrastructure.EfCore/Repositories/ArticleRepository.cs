using MB.Domain.ArticleAgg;

namespace MB.Infrastructure.EfCore.Repositories
{
    public class ArticleRepository:IArticleRepository
    {
        private readonly MasterBloggerDbContext _context;

        public ArticleRepository(MasterBloggerDbContext context)
        {
            _context = context;
        }
    }
}
