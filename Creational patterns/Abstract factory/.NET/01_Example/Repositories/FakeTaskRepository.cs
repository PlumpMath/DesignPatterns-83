using AbstractFactory.Entity;
using System.Collections.Generic;

namespace AbstractFactory.Repositories
{
    class FakeTaskRepository : ITaskRepository
    {
        public List<MyTask> GetAllTasks()
        {

            List<MyTask> listOfTasks = new List<MyTask>();
            listOfTasks.Add(new MyTask() { TaskId = 1 });
            listOfTasks.Add(new MyTask() { TaskId = 2 });
            listOfTasks.Add(new MyTask() { TaskId = 3 });
            listOfTasks.Add(new MyTask() { TaskId = 4 });

            return listOfTasks;
        }
    }
}
