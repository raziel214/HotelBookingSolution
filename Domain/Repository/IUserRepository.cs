using Domain.Models.Users;
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
        Task<User> GetUserByUserNameAndEmailAndPasswordAsync( string email, string password);
        Task<User> CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task<User> DeleteUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<int> SaveChangesAsync();

    }
}
