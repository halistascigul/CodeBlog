using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.CORE.Model
{
    public abstract class BaseEntity : IBaseEntity
    {
        public BaseEntity()
        {
            Created = DateTime.Now;
            IsActive = true;
        }
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
