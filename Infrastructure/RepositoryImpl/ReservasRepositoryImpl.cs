using Domain.Models.Reservas;
using Domain.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryImpl
{
    public  class ReservasRepositoryImpl: IreservasRepository
    {
        private readonly AppDbContext _context;

        public ReservasRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Reserva> CreateReservaAsync(Reserva reserva)
        {
            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();
            return reserva;
        }

        public async Task<Reserva> DeleteReservaByIdAsync(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva != null) 
            {
                _context.Reservas.Remove(reserva);
                await _context.SaveChangesAsync();
                return reserva;
            } else {
                throw new Exception("La reserva no existe");
            }
        }

        public async Task<IEnumerable<Reserva>> GetAllReservasAsync()
        {
           return await _context.Reservas.ToListAsync();
        }

        public async  Task<Reserva> GetReservaByIdAsync(int id)
        {
            return await _context.Reservas.FindAsync(id);
        }

        public async Task UpdateReservaAsync(Reserva reserva)
        {
            _context.Reservas.Update(reserva);
            await _context.SaveChangesAsync();
        }
    }
}
