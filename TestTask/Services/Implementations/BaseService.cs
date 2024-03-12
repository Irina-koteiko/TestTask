using TestTask.Data;

namespace TestTask.Services.Implementations;

public abstract class BaseService
{
    protected ApplicationDbContext Context { get; }
    public BaseService(ApplicationDbContext context)
    {
        Context = context;
    }
}
