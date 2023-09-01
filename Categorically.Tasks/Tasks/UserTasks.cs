using Categorically.DataAccess.Models;
using Categorically.Services;
using Microsoft.Extensions.Logging;

namespace Categorically.Tasks;

public class UserTasks : IUserTasks
{
    private readonly IUserService _userService;
    private readonly ILogger<UserTasks> _logger;

    public UserTasks(IUserService userService, ILogger<UserTasks> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        try
        {
            return await _userService.GetAllUsersAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting all users.");
            throw;
        }
    }

    public async Task InsertUserAsync(User user)
    {
        try
        {
            _userService.InsertUserAsync(user);
            await Task.CompletedTask;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while inserting a user.");
            throw;
        }
    }

    public async Task<User?> GetUserAsync(int userId)
    {
        try
        {
            return await _userService.GetUserAsync(userId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while getting user with ID {userId}.");
            throw;
        }
    }

    public async Task UpdateUserAsync(User user)
    {
        try
        {
            _userService.UpdateUserAsync(user);
            await Task.CompletedTask;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while updating user with ID {user.UserId}.");
            throw;
        }
    }

    public async Task DeleteUserAsync(User user)
    {
        try
        {
            _userService.DeleteUserAsync(user);
            await Task.CompletedTask;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while deleting user with ID {user.UserId}.");
            throw;
        }
    }
}
