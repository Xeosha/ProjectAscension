using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.API.Options
{
    public class TelegramOptions
    {
        public const string Telegram = nameof(Telegram);
        public string Token { get; set; } = string.Empty;
    }
}
