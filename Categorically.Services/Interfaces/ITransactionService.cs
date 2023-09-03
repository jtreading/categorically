using Categorically.DataAccess.Models;

namespace Categorically.Services;

public interface ITransactionService
{
    Task DeleteTransactionAsync(Transaction transaction);
    Task<List<Transaction>> GetAllTransactionsAsync();
    Task<Transaction?> GetTransactionAsync(int transactionId);
    Task<List<Transaction>> GetTransactionsByUserAndTimeframeAsync(int? userId, DateTime start, DateTime end);
    Task InsertTransactionAsync(Transaction transaction);
    Task UpdateTransactionAsync(Transaction transaction);
}