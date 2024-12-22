using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.API;
using TelegramBot.API.Features;
using TelegramBot.API.Options;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<TelegramBotBackroundService>();

builder.Services.Configure<TelegramOptions>(builder.Configuration.GetSection(TelegramOptions.Telegram));

builder.Services.AddTransient<ITelegramBotClient, TelegramBotClient>(serviceProvider =>
{
    var token = serviceProvider.GetRequiredService<IOptions<TelegramOptions>>().Value.Token;

    var botClient = new TelegramBotClient(token);

    return botClient;
});

//builder.Services.AddDbContext<TelegramBotDbContext>(
//    options =>
//    {
//        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(TelegramBotDbContext)));
//    });

builder.Services.AddTransient<IHandler<Message>, MessageHandler>();



var host = builder.Build();



// Код для выполнения миграции в бд
// если хочешь создать файл миграции:
// dotnet ef migrations add <Название без кавычек этих> -s src/TelegramBot.API/ -p src/TelegramBot.Data/
//using var scope = host.Services.CreateScope();
//scope.ServiceProvider
//    .GetRequiredService<TelegramBotDbContext>()
//    .Database
//    .Migrate();


host.Run();
