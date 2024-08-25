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
                var habitacionEntity = _mapper.Map<Habitacion>(habitacion);
                await _habitacionRepository.CreateHabitacionAsync(habitacionEntity);
                await _habitacionRepository.SaveChangesAsync();
                return _mapper.Map<HabitacionRead>(habitacionEntity);
            
            
        }

        public async Task<Habitacion> DeleteHabitacionByIdAsync(int id)
        {
            var habitacion = await _habitacionRepository.GetByIdHabitacionAsync(id);            
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
          return await _habitacionRepository.GetByIdHabitacionAsync(id);  
        }

        public async Task<Habitacion> GetHabitacionByCodeAsync(int  code)
        {
            var habitacion = await _habitacionRepository.GetHabitacionByCodeAsync(code);
            return habitacion;
        }

        public async Task<IEnumerable<Habitacion>> GetHabitacionByHotelAsync(int hotelId)
        {
            var habitaciones = await _habitacionRepository.GetHabitacionByHotelAsync(hotelId);
            return habitaciones;
        }


        public async Task<IEnumerable<Habitacion>> GetHabitacionByPriceAsync(int price)
        {
            var habitaciones = await _habitacionRepository.GetHabitacionByPriceAsync(price);
            return habitaciones;
        }


        public async Task<IEnumerable<Habitacion>> GetHabitacionByStatusAndCapacityAsync(int status,int cantidadPersonas)
        {
            var habitaciones = await _habitacionRepository.GetHabitacionByStatusAndCapacityAsync(status,cantidadPersonas);
            return habitaciones;
        }


        public async Task<IEnumerable<Habitacion>> GetHabitacionByTypeAsync(int type)
        {
           var habitaciones = await _habitacionRepository.GetHabitacionByTypeAsync(type);            
            return habitaciones;
        }

       

        public async  Task UpdateHabitacionAsync(int id, Habitacion habitacion)
        {
            var habitaciontipo = await _tipoHabitacionRepository.GetHabitacionTipoByIdAsync(habitacion.IdTipoHabitacion);
            var hotel = await _hotelRepository.GetHotelByIdAsync(habitacion.IdHotel);            
            await _habitacionRepository.UpdateHabitacionAsync(id, habitacion);            
        }
        
    }
}
