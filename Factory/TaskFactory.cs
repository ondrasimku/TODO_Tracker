using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TODO_Tracker.Entity;

namespace TODO_Tracker.Factory
{
    class TaskFactory
    {
        public static Task createTask(string title, string description, DateTime? dateTime, byte? priority, bool isDone) {
            Task task = new Task(title, description, dateTime, priority, isDone);
            return task;
        }
    }
}
