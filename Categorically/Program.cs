using Categorically.Data;
using Categorically.DataSeeders;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<TransactionService>();

var Demo = false; // SETS DEMO MODE

#region Connection String
if (Demo)
{
    var configuration = builder.Configuration;
    builder.Services.AddDbContext<AppDBContext>(options =>
        options.UseLazyLoadingProxies().UseSqlServer(configuration.GetConnectionString("mydemoconn")));
}
else
{
    var configuration = builder.Configuration;
    builder.Services.AddDbContext<AppDBContext>(options =>
        options.UseLazyLoadingProxies().UseSqlServer(configuration.GetConnectionString("myconn")));
}
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");


if (Demo) // CLEARS AND SEEDS DB
{
    // Seed the database with test data
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDBContext>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

        try
        {
            // Clear the database
            dbContext.Database.EnsureDeleted();

            // Apply any pending migrations
            dbContext.Database.Migrate();

            // Seed the database with test data
            if (!dbContext.Users.Any())
            {
                var users = UserSeeder.GenerateUsers(20);
                dbContext.Users.AddRange(users);
                dbContext.SaveChanges();
            }

            if (!dbContext.Categories.Any())
            {
                var users = dbContext.Users.ToList();
                var categories = CategorySeeder.GenerateCategories(users);
                dbContext.Categories.AddRange(categories);
                dbContext.SaveChanges();
            }

            if (!dbContext.Transactions.Any())
            {
                var users = dbContext.Users.ToList();
                var categories = dbContext.Categories.ToList();
                var transactions = TransactionSeeder.GenerateTransactions(users, categories);
                dbContext.Transactions.AddRange(transactions);
                dbContext.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while seeding the database.");
        }
    }
}

app.Run();