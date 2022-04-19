using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBLog.Entities.Concrete;
using ProgrammersBLog.Shared.Data.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concrete
{
    public class ArticleRepository : EfEntityRepositoryBase<Article>,IArticleRepository
    {
        public ArticleRepository(DbContext context) : base(context)
        {

        }
    }
}
