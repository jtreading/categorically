using Categorically.DataAccess.Models;
using Categorically.Services;
using Microsoft.Extensions.Logging;

namespace Categorically.Tasks;

public class TransactionTasks : ITransactionTasks
{
    private readonly ITransactionService _transactionService;
    private readonly ILogger<TransactionTasks> _logger;

    public TransactionTasks(ITransactionService transactionService, ILogger<TransactionTasks> logger)
    {
        _transactionService = transactionService;
        _logger = logger;
    }

    public async Task<List<SummaryItem>> GetSummaryItemsAsync(int? userId, DateTime start, DateTime end)
    {
        try
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
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting summary items.");
            throw;
        }
    }

    public async Task<List<Transaction>> GetTransactionsByUserAndTimeframeAsync(int? userId, DateTime start, DateTime end)
    {
        try
        {
            var transactions = await _transactionService.GetTransactionsByUserAndTimeframeAsync(userId, start, end);
            return transactions;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting transactions.");
            throw;
        }
    }

    public async Task<List<Transaction>> GetAllTransactionsAsync()
    {
        try
        {
            return await _transactionService.GetAllTransactionsAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting all transactions.");
            throw;
        }
    }

    public async Task InsertTransactionAsync(Transaction transaction)
    {
        try
        {
            _transactionService.InsertTransactionAsync(transaction);
            await Task.CompletedTask;
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
            return await _transactionService.GetTransactionAsync(transactionId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while getting transaction with ID {transactionId}.");
            throw;
        }
    }

    public async Task UpdateTransactionAsync(Transaction transaction)
    {
        try
        {
            _transactionService.UpdateTransactionAsync(transaction);
            await Task.CompletedTask;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while updating transaction with ID {transaction.TransactionId}.");
            throw;
        }
    }

    public async Task DeleteTransactionAsync(Transaction transaction)
    {
        try
        {
            _transactionService.DeleteTransactionAsync(transaction);
            await Task.CompletedTask;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while deleting transaction with ID {transaction.TransactionId}.");
            throw;
        }
    }
}
