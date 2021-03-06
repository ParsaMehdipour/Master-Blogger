using System;
using System.Collections.Generic;
using _01.Framework.Domain;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.CommentAgg;

namespace MB.Domain.ArticleAgg
{
    public class Article:BaseDomain<long>
    {
        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Content { get; private set; }
        public string Image { get; private set; }
        public bool IsDeleted { get; private set; }
        public long ArticleCategoryId { get; private set; }

        public ArticleCategory ArticleCategory { get; private set; }
        public ICollection<Comment> Comments { get; set; }

        public Article()
        {
            
        }

        public Article(string title, string shortDescription, string content, string image, long articleCategoryId)
        {
            Validation(title,articleCategoryId);

            Title = title;
            ShortDescription = shortDescription;
            Content = content;
            Image = image;
            ArticleCategoryId = articleCategoryId;
            IsDeleted = false;
        }

        public void Edit(string title, string shortDescription, string content, string image, long articleCategoryId)
        {
            Validation(title,articleCategoryId);

            Title = title;
            ShortDescription = shortDescription;
            Content = content;
            Image = image;
            ArticleCategoryId = articleCategoryId;
        }

        public void Remove()
        {
            IsDeleted = true;
        }

        public void Activate()
        {
            IsDeleted = false;
        }

        public void Validation(string title, long articleCategoryid)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new NullReferenceException();

            if (articleCategoryid == 0)
                throw new ArgumentOutOfRangeException();
        }

    }
}
