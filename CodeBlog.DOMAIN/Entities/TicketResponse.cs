using CodeBlog.CORE.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBlog.DOMAIN.Entities
{
    public class TicketResponse : BaseEntity
    {
        public string Content { get; set; }
        public int OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}