using Collection;
using Domain;
using Paging;
using Persistence.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Queries.BO
{
    public class BOTickets
    {
        private readonly ApplicationDbContext _context;

        public BOTickets(ApplicationDbContext context)
        {
            _context = context;
        }

        public DataCollection<TicketsDTO> GetAllTickets(int take, int page)
        {
            var collection = _context.Tickets
                .Select(x => new TicketsDTO
                {
                    ID = x.ID,
                    UserID = x.UserID,
                    User = x.UsersNavigation != null ? x.UsersNavigation.Name + " " + x.UsersNavigation.Lastname + " - " + x.UsersNavigation.Document : "Sin información",
                    Status = x.Status,
                    StatusDescriptions = x.Status ? "Abierto" : "Cerrado",
                    AddAt = x.AddAt,
                    UpdateAt = x.UpdateAt,
                }).GetPaged(page, take);

            return new DataCollection<TicketsDTO>
            {
                Items = collection.Items,
                Total = collection.Total,
                Page = collection.Page,
                Pages = collection.Pages
            };
        }

        public TicketsDTO GetTicketsById(Guid ID)
        {
            var ticket = _context.Tickets
                         .Where(t => t.ID == ID)
                         .Select(x => new TicketsDTO
                         {
                             ID = x.ID,
                             UserID = x.UserID,
                             User = x.UsersNavigation != null ? x.UsersNavigation.Name + " " + x.UsersNavigation.Lastname + " - " + x.UsersNavigation.Document : "Sin información",
                             Status = x.Status,
                             StatusDescriptions = x.Status ? "Abierto" : "Cerrado",
                             AddAt = x.AddAt,
                             UpdateAt = x.UpdateAt
                         })
                         .FirstOrDefault();

            return ticket;

        }

        public List<TicketsDTO> GetTicketsByUserID(Guid UserID)
        {
            IQueryable<Tickets> listTickets = _context.Tickets.Where(t => t.UserID == UserID);

            listTickets.Select(x => new Tickets
            {
                ID = x.ID,
                UserID = x.UserID,
                Status = x.Status,
                AddAt = x.AddAt,
                UpdateAt = x.UpdateAt,
            }).ToList();

            return listTickets.Select(x => new TicketsDTO
            {
                ID = x.ID,
                UserID = x.UserID,
                User = x.UsersNavigation != null ? x.UsersNavigation.Name + " " + x.UsersNavigation.Lastname + " - " + x.UsersNavigation.Document : "Sin información",
                Status = x.Status,
                StatusDescriptions = x.Status ? "Abierto" : "Cerrado",
                AddAt = x.AddAt,
                UpdateAt = x.UpdateAt
            }).ToList();
        }

        public Users GetUserByID(Guid UserID)
        {
            return _context.Users.Where(u => u.UserID == UserID).FirstOrDefault();
        }
    }
}
