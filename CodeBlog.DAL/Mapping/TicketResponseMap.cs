using CodeBlog.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBlog.DataAccess.Mapping
{
    public class TicketResponseMap : BaseMap<TicketResponse>
    {
        public TicketResponseMap()
        {
            ToTable("TicketResponses");

            Property(x => x.Content).HasMaxLength(500).IsRequired();

            HasRequired(x => x.Owner)
                .WithMany(x => x.TicketResponses)
                .HasForeignKey(x => x.OwnerId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Ticket)
                .WithMany(x => x.Responses)
                .HasForeignKey(x => x.TicketId)
                .WillCascadeOnDelete(false);
        }
    }
}
