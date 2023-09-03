using Categorically.DataAccess.Models;

namespace Categorically.Services;

public interface IUserService
{
    Task InsertUserAsync(User user);
    Task<User?> GetUserAsync(int userId);
    Task<List<User>> GetAllUsersAsync();
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(User user);
}