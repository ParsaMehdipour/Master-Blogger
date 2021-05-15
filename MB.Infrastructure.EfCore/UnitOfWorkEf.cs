using _01.Framework.Infrastructure;

namespace MB.Infrastructure.EfCore
{
    public class UnitOfWorkEf : IUnitOfWork
    {
        private readonly MasterBloggerDbContext _context;

        public UnitOfWorkEf(MasterBloggerDbContext context)
        {
            _context = context;
        }

        public void BeginTran()
        {
            _context.Database.BeginTransaction();
        }

        public void CommitTran()
        {
            _context.SaveChanges();
            _context.Database.CommitTransaction();
        }

        public void RollBack()
        {
            _context.Database.RollbackTransaction();
        }
    }
}
