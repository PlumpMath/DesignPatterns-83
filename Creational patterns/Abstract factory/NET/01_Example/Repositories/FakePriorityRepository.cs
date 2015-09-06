using System.Collections.Generic;
using AbstractFactory.Entity;

namespace AbstractFactory.Repositories
{
    class FakePriorityRepository : IPriorityRepository
    {
        public List<Priority> GetAllPriorities()
        {
            List<Priority> listOfPriorities = new List<Priority>();
            listOfPriorities.Add(new Priority() { PriorityId = 10 });
            listOfPriorities.Add(new Priority() { PriorityId = 20 });
            listOfPriorities.Add(new Priority() { PriorityId = 30 });
            listOfPriorities.Add(new Priority() { PriorityId = 40 });

            return listOfPriorities;
        }
    }
}
