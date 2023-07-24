using System;
using System.Collections.Generic;
using Bogus;
using Categorically.Data;

namespace Categorically.DataSeeders;

public static class TransactionSeeder
{
    public static List<Transaction> GenerateTransactions(List<User> users, List<Category> categories)
    {
        var transactionFaker = new Faker<Transaction>()
            .RuleFor(t => t.TransactionDate, (f) => f.Date.Past())
            .RuleFor(t => t.Amount, (f) => f.Finance.Amount())
            .RuleFor(t => t.ChargedByName, (f) => f.Company.CompanyName()) // Use random company name
            .RuleFor(t => t.Description, (f) => f.Lorem.Sentence(5))
            .RuleFor(t => t.UserId, (f, t) => GetRandomUserId(users))
            .RuleFor(t => t.CategoryId, (f, t) => GetRandomCategoryId(categories));

        var transactions = transactionFaker.Generate(100); // Generate 100 transactions

        return transactions;
    }

    private static int GetRandomUserId(List<User> users)
    {
        var random = new Random();
        int index = random.Next(users.Count);
        return users[index].UserId;
    }

    private static int GetRandomCategoryId(List<Category> categories)
    {
        var random = new Random();
        int index = random.Next(categories.Count);
        return categories[index].CategoryId;
    }
}
