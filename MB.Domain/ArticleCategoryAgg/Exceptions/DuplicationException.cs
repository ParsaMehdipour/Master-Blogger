using System;

namespace MB.Domain.ArticleCategoryAgg.Exceptions
{
    public class DuplicationException:Exception
    {
        public DuplicationException(string message)
            :base(message)
        {
            
        }
    }
}
