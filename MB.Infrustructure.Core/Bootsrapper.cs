using System;
using System.Collections.Generic;
using System.Text;
using MB.Application.ArticleCategory;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
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
            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();

            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();

            services.AddDbContext<MasterBloggerDbContext>(options =>
            {
                options.UseSqlServer(conectionstring);
            });
        }
    }
}
