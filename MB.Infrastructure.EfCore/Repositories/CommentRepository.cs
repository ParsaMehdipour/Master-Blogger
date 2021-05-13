using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using _01.Framework.Infrastructure;
using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EfCore.Repositories
{
    public class CommentRepository : BaseRepository<long, Comment>, ICommentRepository
    {
        private readonly MasterBloggerDbContext _context;

        public CommentRepository(MasterBloggerDbContext context) : base(context)
        {
            _context = context;
        }

        public List<CommentViewModel> GetList()
        {
            return _context.Comments.Include(x => x.Article).Select(x => new CommentViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Message = x.Message,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Article = x.Article.Title,
                Status = x.Status
            }).ToList();

        }

        public Comment GetComment(long id)
        {
            return _context.Comments.FirstOrDefault(c => c.Id == id);
        }

        public void CreateAndSave(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
