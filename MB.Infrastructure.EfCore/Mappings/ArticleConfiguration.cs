using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MB.Infrastructure.EfCore.Mappings
{
    public class ArticleConfiguration:IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired().
                HasMaxLength(255);

            builder.
                Property(x => x.ShortDescription)
                .IsRequired();

            builder.Property(x => x.Content)
                .IsRequired();

            builder.
                Property(x => x.Image)
                .IsRequired()
                .HasMaxLength(255);


            builder.
                Property(x => x.IsDeleted);


            builder.
                Property(x => x.CreationDate);


            builder.HasOne(x => x.ArticleCategory)
                .WithMany(x => x.Articles)
                .HasForeignKey(x => x.ArticleCategoryId);

            builder.HasMany(x => x.Comments)
                .WithOne(x => x.Article)
                .HasForeignKey(x => x.ArticleId);
        }
    }
}
