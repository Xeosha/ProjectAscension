using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot.API.Features
{
    public class MessageHandler : IHandler<Message>
    {
        private readonly ITelegramBotClient _botClient;

        public MessageHandler(ITelegramBotClient botClient)
        {
            _botClient = botClient;
        }

        private static ReplyKeyboardMarkup GetReplyKeyboard()
        {
            var buttons = new List<KeyboardButton[]>
            {
                new KeyboardButton[] { new("🚀 Майнинг"), new("📋 Задания") },
                new KeyboardButton[] { new("💰 Баланс"), new("ℹ️ Информация") }
            };

            return new ReplyKeyboardMarkup(buttons)
            {
                ResizeKeyboard = true
            };
        }

        public async Task Handle(Message message, CancellationToken cancellationToken)
        {
            var responseText = "Выберите опцию";

            await _botClient.SendMessage(
                chatId: message.Chat.Id,
                text: responseText,
                replyMarkup: GetReplyKeyboard(), // Отправляем клавиатуру вместе с сообщением
                cancellationToken: cancellationToken);
        }
    }
}
