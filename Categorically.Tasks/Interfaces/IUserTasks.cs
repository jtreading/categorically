using Categorically.DataAccess.Models;

namespace Categorically.Tasks;
public interface IUserTasks
{
    Task DeleteUserAsync(User user);
    Task<List<User>> GetAllUsersAsync();
    Task<User?> GetUserAsync(int userId);
    Task InsertUserAsync(User user);
    Task UpdateUserAsync(User user);
}