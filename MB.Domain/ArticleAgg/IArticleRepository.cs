﻿using System.Collections.Generic;
using MB.Application.Contracts.Article;

namespace MB.Domain.ArticleAgg
{
    public interface IArticleRepository
    {
        List<ArticleViewModel> GetList();
        Article Get(long id);
        void CreateAndSave(Article article);
        void Save();
    }
}
