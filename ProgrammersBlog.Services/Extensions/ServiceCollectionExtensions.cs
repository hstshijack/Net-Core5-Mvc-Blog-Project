using Microsoft.Extensions.DependencyInjection;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Data.Concrete;
using ProgrammersBlog.Data.Concrete.EntityFramework.Contexts;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceColection)
        {
            serviceColection.AddDbContext<ProgrammersBlogContext>();
            serviceColection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceColection.AddScoped<ICategoryService, CategoryManager>();
            serviceColection.AddScoped<IArticleService, ArticleManager>();
            return serviceColection;

        }
    }
}
