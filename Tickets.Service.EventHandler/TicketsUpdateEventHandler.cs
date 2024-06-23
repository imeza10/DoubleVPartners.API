using Domain;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TicketsEventHandler.Commands;

namespace TicketsEventHandler
{
    public class TicketsUpdateEventHandler : IRequestHandler<TicketsUpdateCommand, RequestResult>
    {
        private readonly ApplicationDbContext _context;
        public TicketsUpdateEventHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RequestResult> Handle(TicketsUpdateCommand command, CancellationToken cancellationToken)
        {
            #region Validations

            var ticketsBD = _context.Tickets.Where(u => u.ID == command.ID).FirstOrDefault();

            if (ticketsBD == null)
                return new RequestResult { Success = false, Message = "No existe un ticket con ese ID." };

            var userBD = _context.Users.Where(u => u.UserID == command.UserID).FirstOrDefault();

            if (userBD == null)
                return new RequestResult { Success = false, Message = "ID del usuario no existe o no es valido." };

            #endregion

            try
            {
                ticketsBD.UserID = command.UserID;
                ticketsBD.Status = command.Status;
                ticketsBD.UpdateAt = DateTime.Now;

                _context.Tickets.Update(ticketsBD);
                await _context.SaveChangesAsync(cancellationToken);

                var ticketDto = new TicketsDTO
                {
                    ID = ticketsBD.ID,
                    UserID = ticketsBD.UserID,
                    User = userBD.Name + " " + userBD.Lastname + " - " + userBD.Document,
                    Status = ticketsBD.Status,
                    StatusDescriptions = ticketsBD.Status ? "Abierto" : "Cerrado",
                    AddAt = ticketsBD.AddAt,
                    UpdateAt = ticketsBD.UpdateAt
                };

                return new RequestResult { Success = true, Message = "Ticket actualizado exitosamente.", Result = ticketDto };
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
