using System;
using AbstractFactory.Entity;
using AbstractFactory.Repositories;
using System.Collections.Generic;



namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<MyTask> arr_result = new List<MyTask>();

            //Console.WriteLine("Enter repository:\n 1. SQL \n 2. XML \n 3. FAKE");
            //string s = Console.ReadLine();
            //int result = Convert.ToInt32(s);
            //if (result == 1)
            //{
            //    ITaskRepository MyTasks = new SqlTaskRepository(@"Server = localhost; user = sa; password = 1; Database = Hotel;");
            //    arr_result = MyTasks.GetAllTasks();
            //}
            //else if (result == 2)
            //{
            //    ITaskRepository MyTasks = new XmlTaskRepository(@"D:\System c#\AbstractFactory\DataSource\MyTasks.xml");
            //    arr_result = MyTasks.GetAllTasks();
            //}
            //else if (result == 3)
            //{
            //    ITaskRepository MyTasks = new FakeTaskRepository();
            //    arr_result = MyTasks.GetAllTasks();
            //}
            //else
            //{
            //    return;
            //}

            //foreach (var item in arr_result)
            //{
            //    Console.WriteLine("Task ID: {0:d}", item.TaskId);
            //}

            IRepositoryFactory Factory;

            Console.WriteLine("Enter repository:\n 1. SQL \n 2. XML \n 3. FAKE");
            string s = Console.ReadLine();
            int result = Convert.ToInt32(s);
            if (result == 1)
            {
                Factory = new SqlRepositoryFactory();
            }
            else if (result == 2)
            {
                Factory = new XmlRepositoryFactory();
            }
            else if (result == 3)
            {
                Factory = new FakeRepositoryFactory();
            }
            else
            {
                return;
            }


            ITaskRepository TaskRepository = Factory.CreateTaskRepository();
            List<MyTask> tasks = TaskRepository.GetAllTasks();
            foreach (var item in tasks)
            {
                Console.WriteLine("Task ID: {0:d}", item.TaskId);
            }


            IPriorityRepository PriorityRepository = Factory.CreatePriorityRepository();
            List<Priority> priorities = PriorityRepository.GetAllPriorities();
            foreach (var item in priorities)
            {
                Console.WriteLine("Priority ID: {0:d}", item.PriorityId);
            }

        }
    }
}
