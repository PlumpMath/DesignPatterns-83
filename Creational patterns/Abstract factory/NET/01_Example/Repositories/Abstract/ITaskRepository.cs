using AbstractFactory.Entity;
using System.Collections.Generic;

namespace AbstractFactory
{
    public interface ITaskRepository
    {
        List <MyTask> GetAllTasks();
    }
}
