using Categorically.DataAccess.Models;

namespace Categorically.Services;

public interface IUserService
{
    void InsertUserAsync(User user);
    Task<User?> GetUserAsync(int userId);
    Task<List<User>> GetAllUsersAsync();
    void UpdateUserAsync(User user);
    void DeleteUserAsync(User user);
}