﻿using Aplication.Dtos.HotelesPreferidos;
using AutoMapper;
using Domain.Models.HotelesPreferidos;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Service.HotelesPreferidos
{
    public class HotelesPreferidosService: IHotelesPreferidosService
    {
        private readonly IMapper _mapper;
        private readonly IHotelesPreferidosRepository _hotelesPreferidosRepository;

        public HotelesPreferidosService(IMapper mapper, IHotelesPreferidosRepository hotelesPreferidosRepository)
        {
            _mapper = mapper;
            _hotelesPreferidosRepository = hotelesPreferidosRepository;
        }

        public async Task<HotelPreferidoRead> CreateHotelPreferidoAsync(HotelPreferidoCreate hotelPreferidoCreate)
        {
            HotelPreferido entity = _mapper.Map<HotelPreferido>(hotelPreferidoCreate);
            entity = await _hotelesPreferidosRepository.CreateHotelPreferidoAsync(entity);
            HotelPreferidoRead dto = _mapper.Map<HotelPreferidoRead>(entity);
            return dto;
           
        }

        public async Task<HotelPreferido> DeleteHotelPreferidoByIdAsync(int idHotelPreferido)
        {
            var hotelPreferido = await _hotelesPreferidosRepository.GetHotelPreferidoByIdAsync(idHotelPreferido);
            if (hotelPreferido == null)
            {
                throw new KeyNotFoundException($"El hotel preferido con ID {idHotelPreferido} no fue encontrado.");
            }
            await _hotelesPreferidosRepository.DeleteHotelPreferidoByIdAsync(idHotelPreferido);
            await _hotelesPreferidosRepository.SaveChangesAsync();
            return hotelPreferido;

        }

        public async Task<IEnumerable<HotelPreferido>> GetAllHotelesPreferidosAsync()
        {
            return await _hotelesPreferidosRepository.GetAllHotelesPreferidosAsync();
        }

        public async Task<IEnumerable<HotelPreferido>> GetHotelesPreferidosByUserIdAsync(int userId)
        {
            return await _hotelesPreferidosRepository.GetHotelesPreferidosByUserIdAsync(userId);
        }

        public async  Task<HotelPreferido> GetHotelPreferidoByIdAsync(int idHotelPreferido)
        {
           return await _hotelesPreferidosRepository.GetHotelPreferidoByIdAsync(idHotelPreferido);
        }

        public async Task<HotelPreferido> GetHotelPreferidoByUserIdHotelIdAsync(int userId, int hotelId)
        {
            return await _hotelesPreferidosRepository.GetHotelPreferidoByUserIdHotelIdAsync(userId, hotelId);
        }

        public async  Task UpdateHotelPreferidoAsync(int IdPreferido, HotelPreferido hotelPreferido)
        {
            await _hotelesPreferidosRepository.GetAllHotelesPreferidosAsync();
        }
    }
}
