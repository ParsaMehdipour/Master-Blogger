using MB.Domain.CommentAgg;

namespace MB.Infrastructure.EfCore.Repositories
{
    public class CommentRepository:ICommentRepository
    {
        private readonly MasterBloggerDbContext _context;

        public CommentRepository(MasterBloggerDbContext context)
        {
            _context = context;
        }

        public void CreateAndSave(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }
    }
}
