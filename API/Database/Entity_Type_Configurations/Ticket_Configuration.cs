using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Database.EntityConfigurations
{
    public class Ticket_Configuration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("Ticket");
            builder.HasKey(x => x.ticket_id);
           builder.HasMany(x => x.ticket_notes).WithOne(x => x.ticket); 

            builder.Property(x => x.ticket_resolution_type).HasDefaultValue(Ticket_Resolution_Type.none).IsRequired(false);
            builder.Property(x => x.ticket_status).HasDefaultValue(Ticket_Status.new_ticket);
            
            
            
        }
    }
}