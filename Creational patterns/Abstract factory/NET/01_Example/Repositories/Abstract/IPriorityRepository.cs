using AbstractFactory.Entity;
using System.Collections.Generic;

namespace AbstractFactory.Repositories
{
    public interface IPriorityRepository
    {
        List<Priority> GetAllPriorities();
    }
}
