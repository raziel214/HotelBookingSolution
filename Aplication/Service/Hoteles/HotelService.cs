using Aplication.Dtos.Hoteles;
using AutoMapper;
using Domain.Models.Hoteles;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Service.Hoteles
{
    public class HotelService: IHotelService
    {
        private readonly IMapper _mapper;
        private readonly IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }

        public async Task<HotelRead> CreateHotelAsync(HotelCreate hotel)
        {
            Hotel entity= _mapper.Map<Hotel>(hotel);
            entity = await _hotelRepository.CreateHotelAsync(entity);
            HotelRead dto = _mapper.Map<HotelRead>(entity);
            return dto;
        }

        public async Task<Hotel> DeleteHotelByIdAsync(int id)
        {
             var hotel = await _hotelRepository.GetHotelByIdAsync(id);
            if (hotel == null) 
            {
                throw new KeyNotFoundException($"El hotel con ID {id} no fue encontrado.");
            }
            await _hotelRepository.DeleteHotelByIdAsync(id);
            await _hotelRepository.SaveChangesAsync();
            return hotel;
        }

        public async Task<IEnumerable<Hotel>> GetAllHotelsAsync()
        {
            return await _hotelRepository.GetAllHotelsAsync();
        }

        public async Task<Hotel> GetHotelByCodeAsync(string code)
        {
            return await _hotelRepository.GetHotelByCodeAsync(code);
        }

        public async Task<Hotel> GetHotelByIdAsync(int id)
        {
            return await _hotelRepository.GetHotelByIdAsync(id);
        }

        public async Task<Hotel> GetHotelByNameAsync(string name)
        {
            return await _hotelRepository.GetHotelByNameAsync(name);
        }

        public async Task UpdateHotelAsync(int id, Hotel hotel)
        {
            await _hotelRepository.UpdateHotelAsync(id,hotel);  
        }
    }
}
