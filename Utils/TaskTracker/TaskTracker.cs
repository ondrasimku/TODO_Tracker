using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TODO_Tracker.Entity;

namespace TODO_Tracker.Utils.TodoTracker
{
    sealed class TaskTracker
    {
        private TaskTracker() { }
        private static TaskTracker taskTrackerInstance = null;

        private List<Task> taskList = new List<Task>();
        public static TaskTracker getInstance() {
            if (TaskTracker.taskTrackerInstance == null)
                TaskTracker.taskTrackerInstance = new TaskTracker();
            return taskTrackerInstance;
        }

        public List<Task> getTaskList() {
            return this.taskList;
        }

        public TaskTracker setTaskList(List<Task> taskList) {
            this.taskList = taskList;
            return this;
        }

        public TaskTracker addItem(Task task) {
            Task last = this.taskList.LastOrDefault();
            if (last == null)
                task.setId(1);
            else
                task.setId(last.getId() + 1);
            this.taskList.Add(task);
            return this;
        }

        public bool removeItem(Task task) {
            return this.taskList.Remove(task);
        }
    }
}
