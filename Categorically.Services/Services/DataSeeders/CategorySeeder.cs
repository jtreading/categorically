using Bogus;
using Categorically.DataAccess.Models;

namespace Categorically.DataSeeders;

public static class CategorySeeder
{
    public static List<Category> GenerateCategories(List<User> users)
    {
        var categoryFaker = new Faker<Category>()
            .RuleFor(c => c.CategoryName, (f) => f.Commerce.Department())
            .RuleFor(c => c.UserId, (f, c) => GetRandomUserId(users));

        var categories = new List<Category>();
        foreach (var user in users)
        {
            var f = new Faker();
            int numberOfCategories = f.Random.Int(1, 12);
            var userCategories = categoryFaker.Generate(numberOfCategories);
            categories.AddRange(userCategories);
        }

        return categories;
    }

    private static int GetRandomUserId(List<User> users)
    {
        var random = new Random();
        int index = random.Next(users.Count);
        return users[index].UserId;
    }
}
