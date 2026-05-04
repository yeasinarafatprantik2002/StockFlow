using StockFlow.Models;
using StockFlow.Repositories;
using System.Linq;
using System.Threading.Tasks;

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
            var users = await _userRepository.FindAsync(u => u.Username == username);
            var user = users.FirstOrDefault();

            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return user;
            }

            return null;
        }

        public async Task<bool> RegisterAsync(string username, string password, string role = "PartTimeStaff")
        {
            var existing = await _userRepository.FindAsync(u => u.Username == username);
            if (existing.Any())
            {
                return false; // Username already exists
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
            if (user == null) return false;

            user.Role = newRole;
            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();
            return true;
        }
    }
}
