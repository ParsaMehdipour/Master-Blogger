using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MB.Infrastructure.EfCore.Mappings
{
    public class CommentConfiguration:IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255);
           
            builder.Property(x=>x.Email)
                .IsRequired()
                .HasMaxLength(255);
           
            builder.Property(x => x.CreationDate);

            builder.Property(x => x.Message)
                .IsRequired();

            builder.Property(x => x.Status);

            builder.HasOne(x => x.Article)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.ArticleId);
        }
    }
}
