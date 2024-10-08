﻿using Domain.Models.Reservas;
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
    public  class ReservasRepositoryImpl: IReservasRepository
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
                throw new KeyNotFoundException("La reserva no existe");
            }
        }

        public async Task<IEnumerable<Reserva>> GetAllReservasAsync()
        {
           return await _context.Reservas.ToListAsync();
        }

        public async  Task<Reserva> GetReservaByIdAsync(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                throw new KeyNotFoundException("La reserva no existe");
            }
            return reserva;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task UpdateReservaAsync(Reserva reserva)
        {
            var entity = await _context.Reservas.FindAsync(reserva.IdReserva);
            if (entity == null)
            {
                throw new KeyNotFoundException("La reserva no existe");
            }
            _context.Reservas.Update(reserva);
            await _context.SaveChangesAsync();
        }
    }
}
