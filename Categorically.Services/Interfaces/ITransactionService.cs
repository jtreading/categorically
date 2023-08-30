using Categorically.DataAccess.Models;

namespace Categorically.Services.Interfaces;

public interface ITransactionService
{
    Task<bool> DeleteTransactionAsync(Transaction transaction);
    Task<List<Transaction>> GetAllTransactionsAsync();
    Task<Transaction> GetTransactionAsync(int transactionId);
    Task<List<Transaction>> GetTransactionsByUserAndTimeframeAsync(int? userId, DateTime start, DateTime end);
    Task<bool> InsertTransactionAsync(Transaction transaction);
    Task<bool> UpdateTransactionAsync(Transaction transaction);
}