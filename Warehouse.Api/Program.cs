var builder = WebApplication.CreateBuilder(args);

// Register support for API controllers
builder.Services.AddControllers();

var app = builder.Build();

// Map HTTP requests to our controller endpoints
app.MapControllers();

// Start the application
app.Run();