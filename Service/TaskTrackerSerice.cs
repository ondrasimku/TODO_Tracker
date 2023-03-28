using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO_Tracker.Utils.TodoTracker;

namespace TODO_Tracker.Service
{
    class TaskTrackerSerice
    {
        private TaskTracker taskTracker = TaskTracker.getInstance();
        public void addTask(string title) {
            this.taskTracker.addItem(title);
        }

        public string getTask() {
            return taskTracker.getTaskList()[0];
        }
    }
}
