namespace Categorically.Data.Interfaces;
using Categorically.Services.Models;

public interface IUserService
{
    Task<bool> DeleteUserAsync(User User);
    Task<List<User>> GetAllUsersAsync();
    Task<User> GetUserAsync(int UserId);
    Task<bool> InsertUserAsync(User User);
    Task<bool> UpdateUserAsync(User User);
}