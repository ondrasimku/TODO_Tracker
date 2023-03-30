using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TODO_Tracker.Entity;
using TODO_Tracker.Strategy.TaskSortStrategy;

namespace TODO_Tracker.Utils.TaskTracker
{
    sealed class TaskTracker
    {
        private TaskTracker() { }
        private static TaskTracker taskTrackerInstance = null;

        private List<Task> taskList = new List<Task>();
        private ITaskSortStrategy sortStrategy = new IdSortStrategy();
        public static TaskTracker getInstance() {
            if (TaskTracker.taskTrackerInstance == null)
                TaskTracker.taskTrackerInstance = new TaskTracker();
            return taskTrackerInstance;
        }

        public TaskTracker setSortingStrategy(ITaskSortStrategy strategy) {
            this.sortStrategy = strategy;
            this.sort();
            return this;
        }

        public ITaskSortStrategy getSortingStrategy() {
            return this.sortStrategy;
        }

        public List<Task> getTaskList() {
            return this.taskList;
        }

        public void sort() {
            this.setTaskList(this.sortStrategy.sort(this.taskList));
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
            this.sort();
            return this;
        }

        public bool removeItem(Task task) {
            return this.taskList.Remove(task);
        }
    }
}
