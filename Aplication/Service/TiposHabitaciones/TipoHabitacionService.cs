using Aplication.Dtos.HabitacionesTipos;
using AutoMapper;
using Domain.Models.TiposHabitaciones;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Service.TiposHabitaciones
{
    public class TipoHabitacionService: ITipoHabitacionService
    {
        private readonly IMapper _mapper;
        private readonly ITipoHabitacionRepository _tipoHabitacionRepository;

        public TipoHabitacionService(ITipoHabitacionRepository tipoHabitacionRepository, IMapper mapper)
        {
            _tipoHabitacionRepository = tipoHabitacionRepository;
            _mapper = mapper;
        }

        public async Task<TipoHabitacionRead> CreateHabitacionAsync(TipoHabitacionCreate tipoHabitacion)
        {
            var entity = _mapper.Map<TiposHabitacion>(tipoHabitacion);
            entity = await _tipoHabitacionRepository.CreateHabitacionAsync(entity);
            var dto = _mapper.Map<TipoHabitacionRead>(entity);
            return dto;
        }
        public async Task<TiposHabitacion> DeleteHabitacionAsync(int id)
        {
            var tipoHabitacion = await _tipoHabitacionRepository.GetHabitacionByIdAsync(id);
            if (tipoHabitacion == null)
            {
                throw new KeyNotFoundException($"El tipo de habitación con ID {id} no fue encontrado.");
            }
            await _tipoHabitacionRepository.DeleteHabitacionAsync(id);
            await _tipoHabitacionRepository.SaveChangesAsync();
            return tipoHabitacion;
        }
        public async Task<IEnumerable<TiposHabitacion>> GetAllHabitacionAsync()
        {
            return await _tipoHabitacionRepository.GetAllHabitacionAsync();
        }
        public async Task<TiposHabitacion> GetHabitacionByIdAsync(int id)
        {
            return await _tipoHabitacionRepository.GetHabitacionByIdAsync(id);
        }

        public async Task<TiposHabitacion> GetHabitacionByNombreAsync(string nombre)
        {
           var tipoHabitacion = await _tipoHabitacionRepository.GetHabitacionByNombreAsync(nombre);
            if (tipoHabitacion == null)
            {
                throw new KeyNotFoundException($"El tipo de habitación con nombre {nombre} no fue encontrado.");
            }
            return tipoHabitacion;
        }

        public async Task UpdateHabitacionAsync(TiposHabitacion habitacion)
        {
            await _tipoHabitacionRepository.UpdateHabitacionAsync(habitacion);
            
        }
    }
}
