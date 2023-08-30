using Categorically.DataAccess;
using Categorically.DataAccess.Models;
using Categorically.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Categorically.Services;

public class TransactionService : ITransactionService
{
    private readonly AppDBContext _appDBContext;

    public TransactionService(AppDBContext appDBContext)
    {
        _appDBContext = appDBContext;
    }

    public async Task<List<Transaction>> GetAllTransactionsAsync()
    {
        return await _appDBContext.Transactions.Include(t => t.User).ToListAsync();
    }

    public async Task<bool> InsertTransactionAsync(Transaction transaction)
    {
        await _appDBContext.Transactions.AddAsync(transaction);
        await _appDBContext.SaveChangesAsync();
        return true;
    }

    public async Task<Transaction> GetTransactionAsync(int transactionId)
    {
        return await _appDBContext.Transactions.Include(t => t.User).FirstOrDefaultAsync(t => t.TransactionId == transactionId);
    }

    public async Task<bool> UpdateTransactionAsync(Transaction transaction)
    {
        _appDBContext.Transactions.Update(transaction);
        await _appDBContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteTransactionAsync(Transaction transaction)
    {
        _appDBContext.Transactions.Remove(transaction);
        await _appDBContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<Transaction>> GetTransactionsByUserAndTimeframeAsync(int? userId, DateTime start, DateTime end)
    {
        var query = _appDBContext.Transactions.Include(t => t.User).Where(t => t.TransactionDate >= start && t.TransactionDate <= end);

        if (userId.HasValue && userId.Value != 0)
        {
            query = query.Where(t => t.UserId == userId);
        }

        return await query.ToListAsync();
    }
}
