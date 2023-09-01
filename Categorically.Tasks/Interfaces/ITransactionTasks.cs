using Categorically.DataAccess.Models;

namespace Categorically.Tasks;

public interface ITransactionTasks
{
    Task DeleteTransactionAsync(Transaction transaction);
    Task<List<Transaction>> GetAllTransactionsAsync();
    Task<List<SummaryItem>> GetSummaryItemsAsync(int? userId, DateTime start, DateTime end);
    Task<Transaction?> GetTransactionAsync(int transactionId);
    Task InsertTransactionAsync(Transaction transaction);
    Task UpdateTransactionAsync(Transaction transaction);
    Task<List<Transaction>> GetTransactionsByUserAndTimeframeAsync(int? userId, DateTime start, DateTime end);
}
