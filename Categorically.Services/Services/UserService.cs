using Categorically.DataAccess;
using Categorically.DataAccess.Models;
using Categorically.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Categorically.Services;

public class UserService : IUserService
{
    private readonly AppDBContext _appDBContext;

    public UserService(AppDBContext appDBContext)
    {
        _appDBContext = appDBContext;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _appDBContext.Users.ToListAsync();
    }

    public async Task<bool> InsertUserAsync(User User)
    {
        await _appDBContext.Users.AddAsync(User);
        await _appDBContext.SaveChangesAsync();
        return true; // why bool
    }

    public async Task<User> GetUserAsync(int UserId)
    {
        User User = await _appDBContext.Users.FindAsync(UserId); // <- cool, read up on nullables
        return User;
    }

    public async Task<bool> UpdateUserAsync(User User)
    {
        _appDBContext.Users.Update(User);
        await _appDBContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteUserAsync(User User)
    {
        _appDBContext.Remove(User);
        await _appDBContext.SaveChangesAsync();
        return true;
    }
}