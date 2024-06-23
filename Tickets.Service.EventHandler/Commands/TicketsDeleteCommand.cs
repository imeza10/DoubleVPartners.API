using MediatR;
using Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.Service.EventHandler.Commands
{
    public class TicketsDeleteCommand : IRequest<RequestResult>
    {
        public Guid ID { get; set; }
    }
}
