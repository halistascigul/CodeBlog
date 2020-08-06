using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.DTO.UserDTOs
{
    public class BasicUserDto
    {
        public string ProfilePicturePath { get; set; }
        public string AboutText { get; set; }
        public string Job { get; set; }
        public string FullName { get; set; }
    }
}
