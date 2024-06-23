

using Domain;
using MediatR;
using Microsoft.Data.SqlClient;
using Persistence.Database;
using Response;
using TicketsEventHandler.Commands;

namespace TicketsEventHandler
{
    public class TicketsCreateEventHandler : IRequestHandler<TicketsCreateCommand, RequestResult>
    {
        private readonly ApplicationDbContext _context;
        public TicketsCreateEventHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RequestResult> Handle(TicketsCreateCommand command, CancellationToken cancellationToken)
        {
            #region Validations

            var userBD = _context.Users.Where(u => u.UserID == command.UserID).FirstOrDefault();

            if (userBD == null)
                return new RequestResult { Success = false, Message = "ID del usuario no existe o no es valido." };

            #endregion

            try
            {
                var ticket = new Domain.Tickets
                {
                    ID = Guid.NewGuid(),
                    UserID = command.UserID,
                    Status = command.Status,
                    AddAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                };

                await _context.AddAsync(ticket);
                await _context.SaveChangesAsync(cancellationToken);

                var ticketDto = new TicketsDTO
                {
                    ID = ticket.ID,
                    UserID = ticket.UserID,
                    User = ticket.UsersNavigation != null ? ticket.UsersNavigation.Name + " " + ticket.UsersNavigation.Lastname + " - " + ticket.UsersNavigation.Document : "Sin información",
                    Status = ticket.Status,
                    StatusDescriptions = ticket.Status ? "Abierto" : "Cerrado",
                    AddAt = ticket.AddAt,
                    UpdateAt = ticket.UpdateAt
                };

                return new RequestResult { Success = true, Message = "Ticket creado exitosamente.", Result = ticketDto };
            }
            catch (SqlException ex) when (ex.Number == -1)
            {
                // Error de conexión a la base de datos
                return new RequestResult { Success = false, Message = "Error de conexión a la base de datos. Por favor, verifica tu conexión y vuelve a intentarlo." };
            }
            catch (SqlException ex)
            {
                // Otros errores relacionados con SQL
                return new RequestResult { Success = false, Message = $"Error de base de datos: {ex.Message}" };
            }
            catch (NullReferenceException)
            {
                // Error de referencia nula
                return new RequestResult { Success = false, Message = "Se produjo un error inesperado al procesar la información. Por favor, contacta al soporte técnico." };
            }
            catch (Exception ex)
            {
                // Otros tipos de errores
                return new RequestResult { Success = false, Message = $"Intenta nuevamente, error: {ex.Message}" };
            }
        }
    }
}
