using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Response;
using Service.Queries.Repository.Interface.ITickets;
using TicketsEventHandler.Commands;

namespace Tickets.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly IReadTickets _readTicketsService;
        private readonly IMediator _mediator;
        private IConfiguration _configuration;

        public TicketsController(IReadTickets readTicketsService, IMediator mediator, IConfiguration configuration)
        {
            _readTicketsService = readTicketsService;
            _mediator = mediator;
            _configuration = configuration;
        }

        /// <summary>
        /// Consulta todos los Tickets registrados
        /// </summary>
        /// <returns>Retorna una lista de objetos Tickets </returns>
        /// <author>Ismael Meza Castillo</author>
        [HttpGet]
        [Route(nameof(TicketsController.GetAllTickets))]
        public RequestResult GetAllTickets(int take = 10, int page = 1)
        {
            return _readTicketsService.GetAllTickets(take, page);
        }

        /// <summary>
        /// Consulta un Ticket por su ID
        /// </summary>
        /// <returns>Retorna un Ticket </returns>
        /// <author>Ismael Meza Castillo</author>
        [HttpPost]
        [Route(nameof(TicketsController.GetTicketsById))]
        public RequestResult GetTicketsById(Guid ID)
        {
            return _readTicketsService.GetTicketsById(ID);
        }

        /// <summary>
        /// Consulta un Ticket por el UserID
        /// </summary>
        /// <returns>Retorna un Ticket </returns>
        /// <author>Ismael Meza Castillo</author>
        [HttpPost]
        [Route(nameof(TicketsController.GetTicketsByUserID))]
        public RequestResult GetTicketsByUserID(Guid UserID)
        {
            return _readTicketsService.GetTicketsByUserID(UserID);
        }

        /// <summary>
        /// Crea un Tickets
        /// </summary>
        /// <returns>Retorna un Ticket </returns>
        /// <author>Ismael Meza Castillo</author>
        [HttpPost]
        [Route(nameof(TicketsController.CreateTicket))]
        public async Task<RequestResult> CreateTicket([FromBody] TicketsCreateCommand command)
        {
            return await _mediator.Send(command);
        }

        /// <summary>
        /// Actualiza un Tickets
        /// </summary>
        /// <returns>Retorna un Ticket </returns>
        /// <author>Ismael Meza Castillo</author>
        [HttpPut]
        [Route(nameof(TicketsController.UpdateTicket))]
        public async Task<RequestResult> UpdateTicket([FromBody] TicketsUpdateCommand command)
        {
            return await _mediator.Send(command);
        }

        /// <summary>
        /// Actualiza un Tickets
        /// </summary>
        /// <returns>Retorna un Ticket </returns>
        /// <author>Ismael Meza Castillo</author>
        [HttpDelete]
        [Route(nameof(TicketsController.DeleteTicket))]
        public async Task<RequestResult> DeleteTicket([FromBody] TicketsUpdateCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
