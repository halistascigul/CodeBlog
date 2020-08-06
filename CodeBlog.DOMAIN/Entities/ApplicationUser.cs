using CodeBlog.CORE.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBlog.DOMAIN.Entities
{
    public class ApplicationUser : BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime LastLogin { get; set; }
        public string Job { get; set; }
        public string ProfilePicturePath { get; set; }
        public string AboutText { get; set; }
        public List<Blog> Blogs { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public List<Social> Socials { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<TicketResponse> TicketResponses { get; set; }
    }
}
