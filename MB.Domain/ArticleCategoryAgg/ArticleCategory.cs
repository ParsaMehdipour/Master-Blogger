﻿using System;
using System.Collections.Generic;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg.Service;

namespace MB.Domain.ArticleCategoryAgg
{
    public class ArticleCategory
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public bool isDeleted { get; private set; }
        public DateTime CreationDate { get; private set; }

        public ICollection<Article> Articles { get; set; }

        public ArticleCategory(string title,IArticleCategoryService service)
        {
            service.CheckDuplication(title);
            GaurdAgainstEmptyTitle(title);
            Title = title;
            isDeleted = false;
            CreationDate=DateTime.Now;
            Articles = new List<Article>();
        }

        public void Edit(string title)
        {
            GaurdAgainstEmptyTitle(title);
            Title = title;
        }

        public void Remove()
        {
            isDeleted = true;
        }

        public void Activate()
        {
            isDeleted = false;
        }

        public void GaurdAgainstEmptyTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException();
        }
    }
}
