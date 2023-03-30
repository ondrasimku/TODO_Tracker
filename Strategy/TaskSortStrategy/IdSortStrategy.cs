using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TODO_Tracker.Entity;

namespace TODO_Tracker.Strategy.TaskSortStrategy
{
    class IdSortStrategy : ITaskSortStrategy
    {
        public string getStrategyName()
        {
            return "Sort by ID";
        }

        public List<Task> sort(List<Task> list)
        {
            return list.OrderBy(task => task.getId()).ToList();
        }
    }
}
