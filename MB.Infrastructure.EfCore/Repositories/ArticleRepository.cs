﻿using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EfCore.Repositories
{
    public class ArticleRepository:IArticleRepository
    {
        private readonly MasterBloggerDbContext _context;

        public ArticleRepository(MasterBloggerDbContext context)
        {
            _context = context;
        }

        public List<ArticleViewModel> GetList()
        {
            return _context.Articles.Include(a => a.ArticleCategory)
                .Select(a => new ArticleViewModel
                {

                    Id = a.Id,
                    Title = a.Title,
                    ShortDescription = a.ShortDescription,
                    ArticleCategory = a.ArticleCategory.Title,
                    IsDeleted = a.IsDeleted,
                    CreationDate = a.CreationDate.ToString(CultureInfo.InvariantCulture)

                }).ToList();
        }

        public Article Get(long id)
        {
            return _context.Articles.FirstOrDefault(x => x.Id == id);
        }

        public void CreateAndSave(Article article)
        {
            _context.Articles.Add(article);
            _context.SaveChanges();
        }

        public bool Exists(string titile)
        {
            return _context.Articles.Any(x => x.Title == titile);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
