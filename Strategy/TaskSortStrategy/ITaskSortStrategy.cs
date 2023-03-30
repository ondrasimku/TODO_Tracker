using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TODO_Tracker.Entity;

namespace TODO_Tracker.Strategy.TaskSortStrategy
{
    interface ITaskSortStrategy
    {
        List<Task>  sort(List<Task> list);
        string      getStrategyName();
    }
}
