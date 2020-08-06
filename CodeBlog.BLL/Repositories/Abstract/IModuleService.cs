using CodeBlog.CORE.ResultTypes;
using CodeBlog.DAL.Abstract;
using CodeBlog.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.BLL.Repositories.Abstract
{
    public interface IModuleService : IGenericService<Module>
    {
        EntityResult<Module> GetByRoleName(string name, params string[] includeList);
    }
}
