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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleCategoryConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
