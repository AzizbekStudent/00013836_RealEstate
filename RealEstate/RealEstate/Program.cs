
using Microsoft.EntityFrameworkCore;
using RealEstate.Data;

var builder = WebApplication.CreateBuilder(args);
var _connStr = "SqlServer_Connection";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Initializing RealEstate_DbContext
try
{
    builder.Services.AddDbContext<RealEstate_DbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString(_connStr)));
}
catch (Exception ex)
{
    Console.WriteLine($"Error configuring DbContext: {ex.Message}");
    throw; // Ensure the exception is propagated
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
