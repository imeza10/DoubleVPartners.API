using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Database.Configuration
{
    public class UsersConfiguration
    {
        public UsersConfiguration(EntityTypeBuilder<Users> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.UserID);
            entityTypeBuilder.Property(x => x.Name).IsRequired();
            entityTypeBuilder.Property(x => x.Lastname).IsRequired();

            // Configurar relación con Tickets
            entityTypeBuilder
                .HasMany(u => u.Tickets)
                .WithOne(t => t.UsersNavigation)
                .HasForeignKey(t => t.UserID);

            var userList = new List<Users>();
            var random = new Random();

            for (var i = 1; i < 21; i++)
            {
                userList.Add(new Users
                {
                    UserID = Guid.NewGuid(),
                    Document = random.Next().ToString(),
                    Name = $"Name {i}",
                    Lastname = $"Lastname {i}",
                    Email = $"email{i}@gmail.com",
                    Status = true,
                    AddAt = DateTime.Now
                });
            }

            entityTypeBuilder.HasData(userList);

        }
    }
}
