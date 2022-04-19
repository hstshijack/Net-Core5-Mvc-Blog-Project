using ProgrammersBLog.Entities.Concrete;
using ProgrammersBLog.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Abstract
{
    public interface IRoleRepository:IEntityRepository<Role>
    {
    }
}
