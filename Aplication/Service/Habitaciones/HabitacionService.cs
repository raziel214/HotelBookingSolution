using Aplication.Dtos.Habitaciones;
using AutoMapper;
using Domain.Models.Habitaciones;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Service.Habitaciones
{
    public class HabitacionService: IHabitacionService
    {
        private readonly IMapper _mapper;
        private readonly IHabitacionRepository _habitacionRepository;

        public HabitacionService(IHabitacionRepository habitacionRepository, IMapper mapper)
        {
            _habitacionRepository = habitacionRepository;
            _mapper = mapper;
        }

        public async Task<HabitacionRead> CreateHabitacionAsync(HabitacionCreate habitacion)
        {
            Habitacion entity= _mapper.Map<Habitacion>(habitacion);
            entity = await _habitacionRepository.CreateHabitacionAsync(entity);
            HabitacionRead dto = _mapper.Map<HabitacionRead>(entity);
            return dto;
        }

        public Task<Habitacion> DeleteHabitacionByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Habitacion>> GetAllHabitacionAsync()
        {
            return await _habitacionRepository.GetAllHabitacionAsync();
        }

        public async Task<Habitacion> GetByIdHabitacionAsync(int id)
        {
            var habitacion = _habitacionRepository.GetByIdHabitacionAsync(id);
            if (habitacion == null)
            {
                throw new KeyNotFoundException($"La habitacion con el ID {id} no fue encontrada.");
            }
          return await _habitacionRepository.GetByIdHabitacionAsync(id);  
        }

        public async Task<Habitacion> GetHabitacionByCodeAsync(int  code)
        {
            var habitacion = _habitacionRepository.GetHabitacionByCodeAsync(code);
            if (habitacion == null)
            {
                throw new KeyNotFoundException($"La habitacion con el codigo {code} no fue encontrada.");
            }
            return await _habitacionRepository.GetHabitacionByCodeAsync(code);
        }

        public async Task<IEnumerable<Habitacion>> GetHabitacionByHotelAsync(int hotelId)
        {
            var habitaciones = await _habitacionRepository.GetHabitacionByHotelAsync(hotelId);
            if (habitaciones == null || !habitaciones.Any())
            {
                throw new KeyNotFoundException($"No se encontraron habitaciones para el hotel con ID {hotelId}.");
            }

            return habitaciones;
        }


        public async Task<IEnumerable<Habitacion>> GetHabitacionByPriceAsync(int price)
        {
            var habitaciones = await _habitacionRepository.GetHabitacionByPriceAsync(price);

            if (habitaciones == null)
            {
                throw new KeyNotFoundException($"No se encontraron habitaciones con precio {price}.");
            }

            return habitaciones;
        }


        public async Task<IEnumerable<Habitacion>> GetHabitacionByStatusAsync(int status)
        {
            var habitaciones = await _habitacionRepository.GetHabitacionByStatusAsync(status);
            if (habitaciones == null || !habitaciones.Any())
            {
                throw new KeyNotFoundException($"No se encontraron habitaciones con estado {status}.");
            }
            return habitaciones;
        }


        public async Task<IEnumerable<Habitacion>> GetHabitacionByTypeAsync(int type)
        {
           var habitaciones = await _habitacionRepository.GetHabitacionByTypeAsync(type);
            if (habitaciones == null || !habitaciones.Any())
            {
                throw new KeyNotFoundException($"No se encontraron habitaciones con tipo {type}.");
            }
            return habitaciones;
        }

       

        public async  Task UpdateHabitacionAsync(int id, Habitacion habitacion)
        {
            await _habitacionRepository.UpdateHabitacionAsync(id,habitacion);
            
        }
        
    }
}
