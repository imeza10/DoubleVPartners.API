using MediatR;
using Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsEventHandler.Commands
{
    public class TicketsUpdateCommand : IRequest<RequestResult>
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public required bool Status { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
