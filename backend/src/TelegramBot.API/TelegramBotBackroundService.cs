using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using TelegramBot.API.Features;

namespace TelegramBot.API
{
    public class TelegramBotBackroundService(
        ITelegramBotClient botClient,
        IServiceScopeFactory scopeFactory,
        ILogger<TelegramBotBackroundService> logger) : BackgroundService
    {

        private readonly ITelegramBotClient _botClient = botClient;
        private readonly IServiceScopeFactory _scopeFactory = scopeFactory;
        private readonly ILogger<TelegramBotBackroundService> _logger = logger;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            ReceiverOptions receiverOptions = new()
            {
                AllowedUpdates = []
            };

            while (!stoppingToken.IsCancellationRequested)
            {
                await _botClient.ReceiveAsync(
                    updateHandler: HandleUpdateAsync,
                    errorHandler: HandleErrorAsync,
                    receiverOptions: receiverOptions,
                    cancellationToken: stoppingToken
                    );
            }
        }

        private async Task HandleUpdateAsync(
            ITelegramBotClient botClient,
            Update update,
            CancellationToken cancellationToken)
        {
            var scope = _scopeFactory.CreateScope();

            var messageHandler = scope.ServiceProvider.GetRequiredService<IHandler<Message>>();

            var handler = update switch
            {
                { Message: { } message } => messageHandler.Handle(message, cancellationToken),
                //{ CallBackQuery: { } query } => CallBackQueryHandler(query, cancellationToken),
                _ => UnknownUpdateHandlerAsync(update, cancellationToken)
            };

            await handler;
        }

        private Task UnknownUpdateHandlerAsync(Update update, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Unknown type message");
            return Task.CompletedTask;
        }

        private Task HandleErrorAsync(
            ITelegramBotClient botClient,
            Exception exception,
            CancellationToken cancellationToken)
        {
            switch (exception)
            {
                case ApiRequestException apiRequestException:
                    _logger.LogError(
                        apiRequestException,
                        "Telegram API Error:\n[{errorCode}]\n{message}\n{httpStatucCode}",
                        apiRequestException.ErrorCode,
                        apiRequestException.Message,
                        apiRequestException.HttpStatusCode);
                    return Task.CompletedTask;

                default:
                    _logger.LogError(exception, "Error while processing message in telegram bot");
                    return Task.CompletedTask;
            }
        }
    }
}
