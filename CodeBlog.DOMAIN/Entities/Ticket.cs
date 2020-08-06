using CodeBlog.CORE.Model;
using CodeBlog.DOMAIN.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBlog.DOMAIN.Entities
{
    public class Ticket : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public TicketStatus Status { get; set; }
        public List<TicketResponse> Responses { get; set; }
        public int OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }
    }
}
