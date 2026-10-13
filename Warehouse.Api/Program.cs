
using Warehouse.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register API controllers.
builder.Services.AddControllers();

// Register our database context.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("Default")
    )
);

var app = builder.Build();

// Connect routes to controllers.
app.MapControllers();

// Only initialize the demo database in development.
if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();

    var db = scope.ServiceProvider
        .GetRequiredService<AppDbContext>();

    // Apply any outstanding database migrations.
    await db.Database.MigrateAsync();

    // Insert fictional sample records if needed.
    await SeedData.InitializeAsync(db);
}

// Start the HTTP server.
app.Run();
