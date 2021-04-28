using System;

namespace MB.Domain.ArticleCategoryAgg.Exceptions
{
    public class DuplicationException:Exception
    {

        public DuplicationException()
        :base("This Record Already Exists")
        {

        }
        public DuplicationException(string message)
            :base(message)
        {
            
        }
    }
}
