using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Database.EntityConfigurations
{
    public class TicketNoteConfiguration : IEntityTypeConfiguration<Ticket_Note>
    {
        //Entity Type Configuration is meant to put restrictions on database model properties
        //A ticket can have many notes
        public void Configure(EntityTypeBuilder<Ticket_Note> builder)
        {
            
            builder.ToTable("TicketNote");
            builder.HasKey(x => x.ticket_note_id);
            builder.HasOne(x => x.ticket).WithMany(x => x.ticket_notes).HasForeignKey(x => x.ticket_id);
            
        }
    }
}
