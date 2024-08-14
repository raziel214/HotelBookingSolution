using Application.Dtos.Usuarios;
using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Users
{
    public interface IUserService
    {
        Task<UserRead> CreateUserAsync(UserCreate userCreate);
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task UpdateUserAsync(int id, User user);
        Task<User> DeleteUserAsync(int id);
    }
}
