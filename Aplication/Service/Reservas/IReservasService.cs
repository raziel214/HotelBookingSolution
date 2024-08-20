using Aplication.Dtos.Reservas;
using Domain.Models.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Service.Reservas
{
    public interface IReservasService
    {
        Task<Reserva> GetReservaByIdAsync(int id);
        Task<ReservasRead> CreateReservaAsync(ReservasCreate reserva);
        Task UpdateReservaAsync(int id,Reserva reserva);
        Task<Reserva> DeleteReservaByIdAsync(int id);
        Task<IEnumerable<Reserva>> GetAllReservasAsync();
    }
}
