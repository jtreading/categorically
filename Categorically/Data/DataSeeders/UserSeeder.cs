using Bogus;
using Categorically.Data;

namespace Categorically.DataSeeders;

public static class UserSeeder
{
    public static List<User> GenerateUsers(int count)
    {
        var userFaker = new Faker<User>()
            .RuleFor(u => u.UserName, (f) => f.Internet.UserName())
            .RuleFor(u => u.FirstName, (f) => f.Name.FirstName())
            .RuleFor(u => u.LastName, (f) => f.Name.LastName())
            .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName));

        return userFaker.Generate(count);
    }
}
