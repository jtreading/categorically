using Categorically.DataAccess.Models;

namespace Categorically.Tasks.Interfaces;

public interface ITransactionTasks
{
    Task<List<SummaryItem>> GetSummaryItemsAsync(int? userId, DateTime start, DateTime end);
    Task<List<Transaction>> GetTransactionsByUserAndTimeframeAsync(int? userId, DateTime start, DateTime end);
}