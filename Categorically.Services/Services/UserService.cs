using Categorically.DataAccess;
using Categorically.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Categorically.Services;

public class UserService : IUserService
{
    private readonly AppDBContext _appDBContext;
    private readonly ILogger<UserService> _logger;

    public UserService(AppDBContext appDBContext, ILogger<UserService> logger)
    {
        _appDBContext = appDBContext;
        _logger = logger;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        try
        {
            return await _appDBContext.Users.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while fetching all users.");
            throw;
        }
    }

    public async void InsertUserAsync(User user)
    {
        try
        {
            await _appDBContext.Users.AddAsync(user);
            await _appDBContext.SaveChangesAsync();
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
            return await _appDBContext.Users.FindAsync(userId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while fetching user with ID {userId}.");
            throw;
        }
    }

    public async void UpdateUserAsync(User user)
    {
        try
        {
            _appDBContext.Users.Update(user);
            await _appDBContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while updating user with ID {user.UserId}.");
            throw;
        }
    }

    public async void DeleteUserAsync(User user)
    {
        try
        {
            _appDBContext.Remove(user);
            await _appDBContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while deleting user with ID {user.UserId}.");
            throw;
        }
    }
}
