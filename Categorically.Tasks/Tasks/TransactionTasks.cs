using Categorically.DataAccess.Models;
using Categorically.Services;
using Categorically.Tasks.Interfaces;

namespace Categorically.Tasks.Tasks;

public class TransactionTasks : ITransactionTasks
{
    private readonly TransactionService _transactionService;
    public TransactionTasks(TransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public async Task<List<Transaction>> GetTransactionsByUserAndTimeframeAsync(int? userId, DateTime start, DateTime end)
    {
        return await _transactionService.GetTransactionsByUserAndTimeframeAsync(userId, start, end);
    }

    public async Task<List<SummaryItem>> GetSummaryItemsAsync(int? userId, DateTime start, DateTime end)
    {
        var transactions = await _transactionService.GetTransactionsByUserAndTimeframeAsync(userId, start, end);

        var summaryItems = transactions.GroupBy(t => t.Category)
            .Select(g => new SummaryItem
            {
                CategoryName = g.Key?.CategoryName,
                Amount = g.Sum(t => t.Amount)
            }).ToList();

        return summaryItems;
    }
}
