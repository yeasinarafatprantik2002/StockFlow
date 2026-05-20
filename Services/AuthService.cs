using StockFlow.Models;
using StockFlow.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace StockFlow.Services
{
    public class AuthService
    {
        private readonly IRepository<User> _userRepository;

        public AuthService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> LoginAsync(string username, string password)
        {
            IEnumerable<User> users = await _userRepository.GetAllAsync();
            User? user = null;
            foreach (User currentUser in users)
            {
                if (currentUser.Username == username)
                {
                    user = currentUser;
                    break;
                }
            }

            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return user;
            }
            
            return null;
        }

        public async Task<bool> RegisterAsync(string username, string password, string role = "PartTimeStaff")
        {
            IEnumerable<User> users = await _userRepository.GetAllAsync();
            foreach (User existingUser in users)
            {
                if (existingUser.Username == username)
                {
                    return false;
                }
            }

            var user = new User
            {
                Username = username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                Role = role
            };

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user != null)
            {
                _userRepository.Remove(user);
                await _userRepository.SaveChangesAsync();
            }
        }

        public async Task<bool> UpdateUserRoleAsync(int userId, string newRole)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                return false;
            }

            user.Role = newRole;
            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();
            return true;
        }
    }
}
