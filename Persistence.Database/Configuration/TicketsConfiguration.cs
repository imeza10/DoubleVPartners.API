using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Database.Configuration
{
    public class TicketsConfiguration
    {
        public TicketsConfiguration(EntityTypeBuilder<Tickets> entityTypeBuilder) 
        {
            entityTypeBuilder.HasKey(x => x.ID); 
            entityTypeBuilder.Property(x => x.UserID).IsRequired();
            entityTypeBuilder.Property(x => x.Status).IsRequired();
            entityTypeBuilder.Property(x => x.AddAt).IsRequired();
            entityTypeBuilder.Property(x => x.UpdateAt).IsRequired();

            // Configurar la relación con Users
            entityTypeBuilder
                .HasOne(t => t.UsersNavigation)
                .WithMany(u => u.Tickets)
                .HasForeignKey(t => t.UserID);
        }
    }
}
