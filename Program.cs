using ManufacturingEquipmentOrderProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DatabaseService
string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
}
builder.Services.AddSingleton(new DatabaseService(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // HTTPS redirection is not used in development
}
else
{
    app.UseHttpsRedirection();
}

app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

// Initialize the database
using (var scope = app.Services.CreateScope())
{
    var dbService = scope.ServiceProvider.GetRequiredService<DatabaseService>();
    dbService.InitializeDatabase();
}

app.Run();
