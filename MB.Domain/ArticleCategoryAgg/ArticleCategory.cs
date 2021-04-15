using System;

namespace MB.Domain.ArticleCategoryAgg
{
    public class ArticleCategory
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public bool isDeleted { get; private set; }
        public DateTime CreationDate { get; private set; }

        public ArticleCategory(string title)
        {
            Title = title;
            isDeleted = false;
            CreationDate=DateTime.Now;
        }

        public void Edit(string title)
        {
            Title = title;
        }

        public void Deleted()
        {
            isDeleted = true;
        }
    }
}
