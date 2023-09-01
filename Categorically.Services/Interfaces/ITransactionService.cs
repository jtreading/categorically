using Categorically.DataAccess.Models;

namespace Categorically.Services;

public interface ITransactionService
{
    void DeleteTransactionAsync(Transaction transaction);
    Task<List<Transaction>> GetAllTransactionsAsync();
    Task<Transaction?> GetTransactionAsync(int transactionId);
    Task<List<Transaction>> GetTransactionsByUserAndTimeframeAsync(int? userId, DateTime start, DateTime end);
    void InsertTransactionAsync(Transaction transaction);
    void UpdateTransactionAsync(Transaction transaction);
}