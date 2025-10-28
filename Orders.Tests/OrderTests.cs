using FluentAssertions;
using Orders.Domain.Entities;

namespace Orders.Tests;

public class OrderTests
{
    [Fact]
    public void Total_Should_Sum_Items()
    {
        var o = new Order
        {
            CustomerId = "C1",
            Items = [new("A", 2, 10m), new("B", 1, 5m)]
        };
        o.Total.Should().Be(25m);
    }
}
