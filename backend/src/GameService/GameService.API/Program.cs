using GameService.Data.DI;
using GameService.Application.DI;
using Microsoft.EntityFrameworkCore;
using GameService.Data.DbContexts;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration
    .AddEnvironmentVariables();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// onion DI
builder.Services.AddData(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();    
app.UseAuthorization();

app.MapControllers();

// dotnet ef migrations add Init -s src/GameService/GameService.API/ -p src/GameService/GameService.Data
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<WriteDbContext>();
    // Обновляем базу данных, если есть миграции
    dbContext.Database.Migrate();
}

app.Run();
