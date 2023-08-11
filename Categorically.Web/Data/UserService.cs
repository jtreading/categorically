using Categorically.Data.Interfaces;
using Categorically.DataAccess;
using Categorically.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace Categorically.Data
{
    public class UserService : IUserService
    {
        #region Property
        private readonly AppDBContext _appDBContext;
        #endregion

        #region Constructor
        public UserService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        #endregion

        #region Get List of Users
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _appDBContext.Users.ToListAsync();
        }
        #endregion

        #region Insert User
        public async Task<bool> InsertUserAsync(User User)
        {
            await _appDBContext.Users.AddAsync(User);
            await _appDBContext.SaveChangesAsync();
            return true; // why bool
        }
        #endregion

        #region Get User by Id
        public async Task<User> GetUserAsync(int UserId)
        {
            User User = await _appDBContext.Users.FindAsync(UserId); // <- cool, read up on nullables
            return User;
        }
        #endregion

        #region Update User
        public async Task<bool> UpdateUserAsync(User User)
        {
            _appDBContext.Users.Update(User);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region DeleteUser
        public async Task<bool> DeleteUserAsync(User User)
        {
            _appDBContext.Remove(User);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}