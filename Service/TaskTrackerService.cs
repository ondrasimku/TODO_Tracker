using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TODO_Tracker.Utils.TodoTracker;
using TODO_Tracker.Entity;
using TODO_Tracker.Factory;
using TODO_Tracker.Config;
using TODO_Tracker.Utils;

namespace TODO_Tracker.Service
{
    class TaskTrackerService
    {
        private TaskTracker taskTracker = TaskTracker.getInstance();
        public void addTask(string title, string description, DateTime? dateTime, byte? priority, bool isDone) {
            Task task = TaskFactory.createTask(title, description, dateTime, priority, isDone);
            this.taskTracker.addItem(task);
            ConsoleUtil.writeInfo("Task created.");
        }

        public void removeTask(int taskId) {
            List<Task> list = this.taskTracker.getTaskList();

            int index = -1;
            Task foundTask = null;
            for (int i = 0; i < list.Count; ++i) { 
                if(list[i].getId() == taskId)
                {
                    index = i;
                    foundTask = list[i];
                    break;
                }
            }

            if (index == -1) {
                ConsoleUtil.writeError("Task with the ID of " + taskId + " was not found.");
                return;
            }
            bool result = this.taskTracker.removeItem(foundTask);
            if (result)
                ConsoleUtil.writeInfo("Task removed.");
            else
                ConsoleUtil.writeError("Task removal failed. If you encouter this problem again contact software admin.");
        }

        public void printTaskList() {
            if (ConsoleConfig.clearText)
                Console.Clear();
            Console.WriteLine("Currect task list:");
            List<Task> list = this.taskTracker.getTaskList();
            if (list.Count == 0)
                Console.WriteLine("Task list is empty");
            else
                Console.WriteLine("ID\tStatus\tTitle\t\t\t\t\t\tDue Date\tPriority");
            foreach (Task task in list) {
                Console.WriteLine(task);
            }
            Console.Write("\n");
        }
    }
}
