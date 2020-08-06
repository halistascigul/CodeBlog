using CodeBlog.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBlog.DataAccess.Mapping
{
    public class TicketMap : BaseMap<Ticket>
    {
        public TicketMap()
        {
            ToTable("Tickets");
            Property(x => x.Title).HasMaxLength(50).IsRequired();
            Property(x => x.Content).HasMaxLength(500).IsRequired();

            HasMany(x => x.Responses)
                .WithRequired(x => x.Ticket)
                .HasForeignKey(x => x.TicketId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Owner)
                .WithMany(x => x.Tickets)
                .HasForeignKey(x => x.OwnerId)
                .WillCascadeOnDelete(false);

        }
    }
}
