using ProgrammersBLog.Entities.Concrete;
using ProgrammersBLog.Shared.Entitites.Absctract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBLog.Entities.Dtos
{
    public class CategoryListDto:DtoGetBase
    {

       public IList<Category> Categories { get; set; }

    }
}
