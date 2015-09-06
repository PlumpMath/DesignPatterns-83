
namespace AbstractFactory.Repositories
{
    class FakeRepositoryFactory : IRepositoryFactory
    {
        public IPriorityRepository CreatePriorityRepository()
        {
            IPriorityRepository PriorityRepository = new FakePriorityRepository();
            return PriorityRepository;
        }

        public ITaskRepository CreateTaskRepository()
        {
            ITaskRepository TaskRepository = new FakeTaskRepository();
            return TaskRepository;
        }
    }
}
