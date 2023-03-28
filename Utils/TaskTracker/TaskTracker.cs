using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO_Tracker.Utils.TodoTracker
{
    sealed class TaskTracker
    {
        private TaskTracker() { }
        private static TaskTracker todoTrackerInstance = null;

        private List<string> taskList = new List<string>();

        public static TaskTracker getInstance() {
            if (TaskTracker.todoTrackerInstance == null)
                TaskTracker.todoTrackerInstance = new TaskTracker();
            return todoTrackerInstance;
        }

        public List<string> getTaskList() {
            return this.taskList;
        }

        public TaskTracker setTaskList(List<string> taskList) {
            this.taskList = taskList;
            return this;
        }

        public TaskTracker addItem(string title) {
            this.taskList.Add(title);
            return this;
        }
    }
}
