using System;
using System.Collections.Generic;
using System.Text;
using _01.Framework.Infrastructure;
using MB.Application.Article;
using MB.Application.ArticleCategory;
using MB.Application.Comment;
using MB.Application.Contracts.Article;
using MB.Application.Contracts.ArticleCategory;
using MB.Application.Contracts.Comment;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleAgg.Services;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Service;
using MB.Domain.CommentAgg;
using MB.Infrastructure.EfCore;
using MB.Infrastructure.EfCore.Repositories;
using MB.Infrastructure.Query.Service;
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

            services.AddTransient<ICommentRepository, CommentRepository>();

            services.AddTransient<ICommentApplication, CommentApplication>();

            services.AddTransient<IArticleQuery, ArticleQuery>();

            services.AddTransient<IUnitOfWork, UnitOfWorkEf>();

            services.AddDbContext<MasterBloggerDbContext>(options =>
            {
                options.UseSqlServer(conectionstring);
            });
        }
    }
}
