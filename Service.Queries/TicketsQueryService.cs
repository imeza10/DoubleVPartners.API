using Collection;
using Domain;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Persistence.Database;
using Response;
using Service.Queries.BO;
using Service.Queries.Repository.Interface.ITickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Queries
{
    public class TicketsQueryService : IReadTickets
    {
        private readonly ApplicationDbContext _context;
        private IConfiguration _configuration;
        public BOTickets ticketsObj;

        public TicketsQueryService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            ticketsObj = new(_context);
            _configuration = configuration;
        }

        public RequestResult GetAllTickets(int take, int page)
        {
            try
            {
                DataCollection<TicketsDTO> ticketsList = ticketsObj.GetAllTickets(take, page);

                if (ticketsList != null && ticketsList.Total > 0)
                    return new RequestResult { Success = true, Message = "Tickets encontrados", Result = ticketsList };
                else
                    return new RequestResult { Success = false, Message = "No hay tickets registrados." };

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

        public RequestResult GetTicketsById(Guid ID)
        {
            try
            {
                #region Validations

                if (ID == Guid.Empty)
                    return new RequestResult { Success = false, Message = "ID del Tickets invalido, intenta nuevamente." };

                #endregion

                TicketsDTO tickets = ticketsObj.GetTicketsById(ID);

                if (tickets != null)
                    return new RequestResult { Success = true, Message = "Tickets encontrados", Result = tickets };
                else
                    return new RequestResult { Success = false, Message = "Ticket no encontrado, verifique e intente nuevamente." };

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

        public RequestResult GetTicketsByUserID(Guid UserID)
        {
            try
            {
                #region Validations

                if (UserID == Guid.Empty)
                    return new RequestResult { Success = false, Message = "ID de usuario invalido, intenta nuevamente." };

                Users userBD = ticketsObj.GetUserByID(UserID);
                if(userBD == null)
                    return new RequestResult { Success = false, Message = "Usuario no se encuentra registrado." };

                #endregion

                List<TicketsDTO> ticketsList = ticketsObj.GetTicketsByUserID(UserID);

                if (ticketsList != null && ticketsList.Count() > 0)
                    return new RequestResult { Success = true, Message = "Tickets encontrados", Result = ticketsList };
                else
                    return new RequestResult { Success = false, Message = "El usuario no tiene tickets registrados." };

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
