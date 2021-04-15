using System;
using System.Reflection.Metadata.Ecma335;

namespace MB.Domain.ArticleCategoryAgg
{
    public class ArticleCategory
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreationDate { get; set; }


        public ArticleCategory(string title)
        {
            Title = title;
            IsDeleted = false;
            CreationDate=DateTime.Now;
        }

        public void Edit(string title)
        {
            Title = title;
        }

        public void Deleted()
        {
            IsDeleted = true;
        }
    }
}
