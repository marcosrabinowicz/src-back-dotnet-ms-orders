using Orders.Application.Abstractions;
using Orders.Application.Contracts;
using Orders.Domain.Entities;
using Orders.Infrastructure.Messaging;
using Orders.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IOrdersRepository, InMemoryOrdersRepository>();
builder.Services.AddSingleton<IMessageBus, InMemoryMessageBus>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/orders", async (IOrdersRepository repo) =>
{
    var all = await repo.GetAllAsync();
    return Results.Ok(all);
});

app.MapGet("/orders/{id:guid}", async (Guid id, IOrdersRepository repo) =>
{
    var order = await repo.GetAsync(id);
    return order is null ? Results.NotFound() : Results.Ok(order);
});

app.MapPost("/orders", async (CreateOrderRequest req, IOrdersRepository repo, IMessageBus bus, CancellationToken ct) =>
{
    if (string.IsNullOrWhiteSpace(req.CustomerId)) return Results.BadRequest("CustomerId required.");
    if (req.Items is null || req.Items.Count == 0) return Results.BadRequest("Items required.");

    var order = new Order { CustomerId = req.CustomerId, Items = req.Items };
    await repo.CreateAsync(order);

    var evt = new OrderCreatedEvent(order.Id, order.CustomerId, order.Total, order.CreatedAt);
    await bus.PublishAsync(evt, topicOrQueue: "orders.created", ct);

    return Results.Created($"/orders/{order.Id}", order);
});

app.MapDelete("/orders/{id:guid}", async (Guid id, IOrdersRepository repo) =>
{
    var removed = await repo.DeleteAsync(id);
    return removed ? Results.NoContent() : Results.NotFound();
});

app.Run();

public partial class Program { }