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

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();

app.UseCors();


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

// dotnet ef migrations add Init -s src/GameService/GameService.API/ -p src/GameService/GameService.Data --context WriteDbContext
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<WriteDbContext>();
    // ��������� ���� ������, ���� ���� ��������
    dbContext.Database.Migrate();
}

app.Run();
