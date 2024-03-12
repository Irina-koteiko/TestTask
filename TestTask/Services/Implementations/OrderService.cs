using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations;

public class OrderService : BaseService, IOrderService
{
    public OrderService(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Order> GetOrder()
    {
        return Context.Orders.MaxBy(order => order.Price);
    }

    public async Task<List<Order>> GetOrders()
    {
        return Context.Orders.Where(order => order.Quantity > 10).ToList() ?? new List<Order>();
    }
}
