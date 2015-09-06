
namespace AbstractFactory.Repositories
{
    public interface IRepositoryFactory
    {
        ITaskRepository CreateTaskRepository();
        IPriorityRepository CreatePriorityRepository();
    }
}
