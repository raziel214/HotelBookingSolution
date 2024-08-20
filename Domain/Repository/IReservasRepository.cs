using Domain.Models.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IReservasRepository
    {
        Task<Reserva> GetReservaByIdAsync(int id);
        Task<Reserva> CreateReservaAsync(Reserva reserva);
        Task UpdateReservaAsync(Reserva reserva);
        Task<Reserva> DeleteReservaByIdAsync(int id);
        Task<IEnumerable<Reserva>> GetAllReservasAsync();
        Task<int> SaveChangesAsync();
    }
}
