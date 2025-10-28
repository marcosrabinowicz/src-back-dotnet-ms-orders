namespace Orders.Application.Abstractions;

public interface IMessageBus
{
    Task PublishAsync<T>(T message, string topicOrQueue, CancellationToken ct = default);
}
