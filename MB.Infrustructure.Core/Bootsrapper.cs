using System;
using System.Collections.Generic;
using System.Text;
using MB.Application.Article;
using MB.Application.ArticleCategory;
using MB.Application.Contracts.Article;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleAgg.Services;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Service;
using MB.Infrastructure.EfCore;
using MB.Infrastructure.EfCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MB.Infrustructure.Core
{
    public class Bootsrapper
    {
        public static void Config(IServiceCollection services, string conectionstring)
        {
            services.AddTransient<IArticleCategoryService, ArticleCategoryService>();

            services.AddTransient<IArticleValidatorService, ArticleValidatorService>();

            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();

            services.AddTransient<IArticleRepository, ArticleRepository>();

            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();

            services.AddTransient<IArticleApplication, ArticleApplication>();

            services.AddDbContext<MasterBloggerDbContext>(options =>
            {
                options.UseSqlServer(conectionstring);
            });
        }
    }
}
