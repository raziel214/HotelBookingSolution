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

        public TipoHabitacionService( IMapper mapper, ITipoHabitacionRepository tipoHabitacionRepository)
        {
            _tipoHabitacionRepository = tipoHabitacionRepository;
            _mapper = mapper;
        }

        public Task<TipoHabitacionRead> CreateHabitacionAsync(TipoHabitacionCreate habitacion)
        {
            throw new NotImplementedException();
        }

        public Task<TipoHabitacionRead> CreateHabitacionTipoAsync(TipoHabitacionCreate habitacion)
        {
            throw new NotImplementedException();
        }

        public async Task<TipoHabitacionRead> CreateTipoHabitacionAsync(TipoHabitacionCreate tipoHabitacion)
        {
            var entity = _mapper.Map<TiposHabitacion>(tipoHabitacion);
            entity = await _tipoHabitacionRepository.CreateTipoHabitacionAsync(entity);
            var dto = _mapper.Map<TipoHabitacionRead>(entity);
            return dto;
        }

        public Task<TiposHabitacion> DeleteHabitacionAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<TiposHabitacion> DeleteHabitacionTipoAsync(int id)
        {
            var tipoHabitacion = await _tipoHabitacionRepository.DeleteHabitacionTipoAsync(id);
            if (tipoHabitacion == null)
            {
                throw new KeyNotFoundException($"El tipo de habitación con ID {id} no fue encontrado.");
            }
            await _tipoHabitacionRepository.DeleteHabitacionTipoAsync(id);
            await _tipoHabitacionRepository.SaveChangesAsync();
            return tipoHabitacion;
        }

       

        public async Task<IEnumerable<TiposHabitacion>> GetAllHabitacionTipoAsync()
        {
            return await _tipoHabitacionRepository.GetAllHabitacionTipoAsync();
        }

       

        public Task<TiposHabitacion> GetHabitacionByNombreAsync(string nombre)
        {
            throw new NotImplementedException();
        }

        public async Task<TiposHabitacion> GetHabitacionTipoByIdAsync(int id)
        {
            return await _tipoHabitacionRepository.GetHabitacionTipoByIdAsync(id);
        }

        public async Task<TiposHabitacion> GetHabitacionTipoByNombreAsync(string nombre)
        {
           var tipoHabitacion = await _tipoHabitacionRepository.GetHabitacionTipoByNombreAsync(nombre);
            if (tipoHabitacion == null)
            {
                throw new KeyNotFoundException($"El tipo de habitación con nombre {nombre} no fue encontrado.");
            }
            return tipoHabitacion;
        }

       

        public async Task UpdateHabitacionTipoAsync(TiposHabitacion habitacion)
        {
            await _tipoHabitacionRepository.UpdateHabitacionTipoAsync(habitacion);
            
        }
    }
}
