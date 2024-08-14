using Application.Dtos.Usuarios;
using AutoMapper;
using Domain.Models.Roles;
using Domain.Models.Users;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Users
{
    public class UserService: IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserRead> CreateUserAsync(UserCreate userCreate)
        {
            User entity = _mapper.Map<User>(userCreate);
            entity = await _userRepository.CreateUserAsync(entity);
            UserRead dto = _mapper.Map<UserRead>(entity);
            return dto;
        }

        public async Task<User> DeleteUserAsync(int id)
        {
            // Verificar si el usuario existe antes de intentar eliminarlo
            var users = await _userRepository.GetUserByIdAsync(id);
            if (users == null)
            {
                throw new KeyNotFoundException($"El usuario con ID {id} no fue encontrado.");
            }
            // Eliminar el usuario directamente por ID
            await _userRepository.DeleteUserByIdAsync(id);
            await _userRepository.SaveChangesAsync();
            return users;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);

        }

        public async  Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task UpdateUserAsync(int id, User user)
        {
            await _userRepository.UpdateUserAsync(user);
        }

    }
}
