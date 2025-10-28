using System.Text.Json;
using Orders.Application.Abstractions;

namespace Orders.Infrastructure.Messaging;

public sealed class InMemoryMessageBus : IMessageBus
{
    public Task PublishAsync<T>(T message, string topicOrQueue, CancellationToken ct = default)
    {
        Console.WriteLine($"[PUBLISH] {topicOrQueue} -> {JsonSerializer.Serialize(message)}");
        return Task.CompletedTask;
    }
}
