

namespace TelegramBot.API.Features
{
    public interface IHandler<in T>
    {
        Task Handle(T request, CancellationToken cancellationToken);
    }
}
