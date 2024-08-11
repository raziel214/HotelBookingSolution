using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByUserNameAsync(string userName);
        Task<User> GetUserByUserNameAndPasswordAsync(string userName, string password);
        Task<User> GetUserByUserNameAndEmailAsync(string userName, string email);
        Task<User> GetUserByUserNameAndEmailAndPasswordAsync(string userName, string email, string password);
        Task<User> AddUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task<User> DeleteUserAsync(User user);
        Task<User> DeleteUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
