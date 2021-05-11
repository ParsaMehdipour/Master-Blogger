using System;
using MB.Domain.ArticleAgg;

namespace MB.Domain.CommentAgg
{
    public class Comment
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Message { get; private set; }
        public int Status { get; private set; }
        public DateTime CreationDate { get; private set; }

        public long ArticleId { get; private set; }
        public Article Article { get; set; }

        public Comment()
        {
            
        }

        public Comment(string name,string email, string message, long articleId)
        {
            Name = name;
            Email = email;
            Message = message;
            ArticleId = articleId;
            Status = Statuses.New;
            CreationDate=DateTime.Now;
        }

        public void Confirm()
        {
            Status = Statuses.Confirmed;
        }

        public void Cancel()
        {
            Status = Statuses.Canceled;
        }
    }
}
