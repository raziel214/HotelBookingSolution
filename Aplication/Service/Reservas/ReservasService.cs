using Aplication.Dtos.Reservas;
using AutoMapper;
using Domain.Models.Reservas;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Service.Reservas
{
    public class ReservasService: IReservasService
    {
        private readonly IMapper _mapper;
        private readonly IReservasRepository _reservasRepository;

        public ReservasService(IMapper mapper, IReservasRepository reservasRepository)
        {
            _mapper = mapper;
            _reservasRepository = reservasRepository;
        }

        public async Task<ReservasRead> CreateReservaAsync(ReservasCreate reserva)
        {
            try 
            {
                Reserva entity = _mapper.Map<Reserva>(reserva);
                entity = await _reservasRepository.CreateReservaAsync(entity);
                ReservasRead dto = _mapper.Map<ReservasRead>(entity);
                return dto;
            }
            catch (Exception e)
            {
                throw new Exception("Error al crear la reserva");
            }
        }

        public async Task<Reserva> DeleteReservaByIdAsync(int id)
        {
           var reserva= await _reservasRepository.GetReservaByIdAsync(id);
            if (reserva == null)
            {
                throw new KeyNotFoundException($"La reserva con ID {id} no fue encontrada.");
            }
            await _reservasRepository.DeleteReservaByIdAsync(id);
            await _reservasRepository.SaveChangesAsync();
            return reserva;
        }

        public async Task<IEnumerable<Reserva>> GetAllReservasAsync()
        {
           var reservas =  await _reservasRepository.GetAllReservasAsync();
            if(reservas.Count() == 0)
            {
                throw new KeyNotFoundException("No se encontraron reservas");
            }
            return reservas;
        }

        public async Task<Reserva> GetReservaByIdAsync(int id)
        {
            var reserva = await _reservasRepository.GetReservaByIdAsync(id);
            if (reserva == null)
            {
                throw new KeyNotFoundException($"La reserva con ID {id} no fue encontrada.");
            }
            return reserva;
        }

        public async Task UpdateReservaAsync(int id,Reserva reserva)
        {
            var reservaExistente = await _reservasRepository.GetReservaByIdAsync(id);
            if(reservaExistente == null)
            {
                throw new KeyNotFoundException($"La reserva con ID {id} no fue encontrada.");
            }
            await _reservasRepository.UpdateReservaAsync(reserva);
        }
    }
}
