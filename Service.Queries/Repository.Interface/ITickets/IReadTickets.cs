using Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Queries.Repository.Interface.ITickets
{
    public interface IReadTickets
    {
        public RequestResult GetAllTickets(int take, int page);
        public RequestResult GetTicketsById(Guid ID);
        public RequestResult GetTicketsByUserID(Guid UserID);
    }
}
