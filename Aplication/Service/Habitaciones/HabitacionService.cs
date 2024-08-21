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
        private readonly IHotelRepository _hotelRepository;
        private readonly ITipoHabitacionRepository _tipoHabitacionRepository;

       
        public HabitacionService(IMapper mapper, IHabitacionRepository habitacionRepository, IHotelRepository hotelRepository, ITipoHabitacionRepository tipoHabitacionRepository)
        {
            _mapper = mapper;
            _habitacionRepository = habitacionRepository;
            _hotelRepository = hotelRepository;
            _tipoHabitacionRepository = tipoHabitacionRepository;
        }   

        public async Task<HabitacionRead> CreateHabitacionAsync(HabitacionCreate habitacion)
        {

            var habitaciontipo= await _tipoHabitacionRepository.GetHabitacionTipoByIdAsync(habitacion.IdTipoHabitacion);
            var hotel = await _hotelRepository.GetHotelByIdAsync(habitacion.IdHotel);
            if (habitaciontipo != null && hotel!=null)
            {
                var habitacionEntity = _mapper.Map<Habitacion>(habitacion);
                await _habitacionRepository.CreateHabitacionAsync(habitacionEntity);
                await _habitacionRepository.SaveChangesAsync();
                return _mapper.Map<HabitacionRead>(habitacionEntity);
            }
            else
            {
                throw new KeyNotFoundException($"El tipo de habitacion con el ID {habitacion.IdTipoHabitacion} no fue encontrado.");
            }
        }

        public async Task<Habitacion> DeleteHabitacionByIdAsync(int id)
        {
            var habitacion = await _habitacionRepository.GetByIdHabitacionAsync(id);
            if (habitacion == null)
            {
                throw new KeyNotFoundException($"La habitacion con el ID {id} no fue encontrada.");
            }
            await _habitacionRepository.DeleteHabitacionByIdAsync(id);
            await _habitacionRepository.SaveChangesAsync();
            return habitacion;
            
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
            var habitaciontipo = await _tipoHabitacionRepository.GetHabitacionTipoByIdAsync(habitacion.IdTipoHabitacion);
            var hotel = await _hotelRepository.GetHotelByIdAsync(habitacion.IdHotel);
            if (habitaciontipo != null && hotel != null) 
            {
                await _habitacionRepository.UpdateHabitacionAsync(id, habitacion);
            }
            else
            {
                throw new KeyNotFoundException($"El tipo de habitacion con el ID {habitacion.IdTipoHabitacion} o el hotel con el ID {habitacion.IdHotel} no fue encontrado.");
            }
                
            
        }
        
    }
}
