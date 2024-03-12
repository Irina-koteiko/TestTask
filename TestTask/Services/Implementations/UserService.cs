using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations;

public class UserService : BaseService, IUserService
{
    public UserService(ApplicationDbContext context) : base(context)
    {

    }

    public async Task<User> GetUser()
    {
        foreach (var user in Context.Users)
        {
            user.Orders = Context.Orders.Where(order => order.UserId == user.Id).ToList();
        }

        return Context.Users.MaxBy(user => user.Orders.Count);
    }

    public async Task<List<User>> GetUsers()
    {
        return Context.Users.Where(user => user.Status == Enums.UserStatus.Inactive).ToList() ?? new List<User>();
    }
}
