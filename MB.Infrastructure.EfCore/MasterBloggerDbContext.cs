using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg;
using MB.Infrastructure.EfCore.Mappings;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EfCore
{
    public class MasterBloggerDbContext : DbContext
    {
        public MasterBloggerDbContext(DbContextOptions<MasterBloggerDbContext> options)
             : base(options)
        {

        }

        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ArticleConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
