using CodeBlog.CORE.Data.EF;
using CodeBlog.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.DAL.Abstract
{
    public interface ITicketDal:IRepository<Ticket>
    {
    }
}
