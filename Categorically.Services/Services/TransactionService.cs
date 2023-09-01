using Categorically.DataAccess;
using Categorically.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Categorically.Services;

public class TransactionService : ITransactionService
{
    private readonly AppDBContext _appDBContext;
    private readonly ILogger<TransactionService> _logger;

    public TransactionService(AppDBContext appDBContext, ILogger<TransactionService> logger)
    {
        _appDBContext = appDBContext;
        _logger = logger;
    }

    public async Task<List<Transaction>> GetAllTransactionsAsync()
    {
        try
        {
            return await _appDBContext.Transactions.Include(t => t.User).ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while fetching all transactions.");
            throw;
        }
    }

    public async void InsertTransactionAsync(Transaction transaction)
    {
        try
        {
            await _appDBContext.Transactions.AddAsync(transaction);
            await _appDBContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while inserting a transaction.");
            throw;
        }
    }

    public async Task<Transaction?> GetTransactionAsync(int transactionId)
    {
        try
        {
            return await _appDBContext.Transactions.Include(t => t.User).FirstOrDefaultAsync(t => t.TransactionId == transactionId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while fetching transaction with ID {transactionId}.");
            throw;
        }
    }

    public async void UpdateTransactionAsync(Transaction transaction)
    {
        try
        {
            _appDBContext.Transactions.Update(transaction);
            await _appDBContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while updating transaction with ID {transaction.TransactionId}.");
            throw;
        }
    }

    public async void DeleteTransactionAsync(Transaction transaction)
    {
        try
        {
            _appDBContext.Transactions.Remove(transaction);
            await _appDBContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while deleting transaction with ID {transaction.TransactionId}.");
            throw;
        }
    }

    public async Task<List<Transaction>> GetTransactionsByUserAndTimeframeAsync(int? userId, DateTime start, DateTime end)
    {
        try
        {
            var query = _appDBContext.Transactions.Include(t => t.User).Where(t => t.TransactionDate >= start && t.TransactionDate <= end);

            if (userId.HasValue && userId.Value != 0)
            {
                query = query.Where(t => t.UserId == userId);
            }

            return await query.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while fetching transactions by user and timeframe.");
            throw;
        }
    }
}
