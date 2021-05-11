using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MB.Domain.CommentAgg;
using MB.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.Query.Service
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly MasterBloggerDbContext _context;

        public ArticleQuery(MasterBloggerDbContext context)
        {
            _context = context;
        }

        public List<ArticleQueryView> GetArticles()
        {
            return _context.Articles
                .Include(x=>x.Comments)
                .Include(x => x.ArticleCategory)
                .Select(x => new ArticleQueryView
                {
                    Id = x.Id,
                    Title = x.Title,
                    ShortDescription = x.ShortDescription,
                    CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                    Image = x.Image,
                    ArticleCategory = x.ArticleCategory.Title,
                    CommentsCount = x.Comments.Count(x=>x.Status == Statuses.Confirmed)
                }).ToList();
        }

        public ArticleQueryView GetOneArticle(long id)
        {
            return _context.Articles.Include(x => x.ArticleCategory)
                .Select(x => new ArticleQueryView
                {
                    Id = x.Id,
                    Title = x.Title,
                    ShortDescription = x.ShortDescription,
                    Content = x.Content,
                    CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                    Image = x.Image,
                    ArticleCategory = x.ArticleCategory.Title,
                    Comments = MapComments(x.Comments.Where(x=>x.Status == Statuses.Confirmed))
                }).FirstOrDefault(x => x.Id == id);
        }

        private static List<CommentQueryView> MapComments(IEnumerable<Comment> comments)
        {
            List<CommentQueryView> list = new List<CommentQueryView>();

            foreach (var comment in comments)
            {
                list.Add(new CommentQueryView
                {
                    Name = comment.Name,
                    Message = comment.Message,
                    CreationDate = comment.CreationDate.ToString(CultureInfo.InvariantCulture)
                });
            }

            return list;
        }
    }
}