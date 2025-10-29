using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Orders.Application.Contracts;

namespace Orders.Tests;

public class ApiIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    public ApiIntegrationTests(WebApplicationFactory<Program> factory) => _client = factory.CreateClient();

    [Fact]
    public async Task Post_Then_Get_Should_Work()
    {
        var req = new CreateOrderRequest("C1", [new("SKU", 1, 9.9m)]);
        var post = await _client.PostAsJsonAsync("/orders", req);
        post.EnsureSuccessStatusCode();

        var created = await post.Content.ReadFromJsonAsync<OrderResponse>();
        var get = await _client.GetAsync($"/orders/{created!.Id}");
        get.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    }

    [Fact]
    public async Task Post_Should_Return_BadRequest_When_Request_Is_Invalid()
    {
        // Arrange — requisição sem itens (inválida)
        var invalidReq = new CreateOrderRequest("C1", []);

        // Act
        var response = await _client.PostAsJsonAsync("/orders", invalidReq);

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);

        // (Opcional) checar a mensagem de erro retornada
        var content = await response.Content.ReadAsStringAsync();
        content.Should().Contain("Items required");
    }

    private sealed record OrderResponse(Guid Id, string CustomerId, DateTime CreatedAt, decimal Total);
}
