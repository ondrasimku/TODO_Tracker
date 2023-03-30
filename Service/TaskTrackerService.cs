using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TODO_Tracker.Utils.TaskTracker;
using TODO_Tracker.Entity;
using TODO_Tracker.Factory;
using TODO_Tracker.Config;
using TODO_Tracker.Utils;
using TODO_Tracker.Strategy.TaskSortStrategy;

namespace TODO_Tracker.Service
{
    class TaskTrackerService
    {
        private TaskTracker taskTracker = TaskTracker.getInstance();
        public void addTask(string title, string description, DateTime? dateTime, ushort? priority, ushort? timeComplexity, bool isDone) {
            Task task = TaskFactory.createTask(title, description, dateTime, priority, timeComplexity, isDone);
            this.taskTracker.addItem(task);
            ConsoleUtil.writeInfo("Task created.");
        }

        public void setSortingStrategy(ITaskSortStrategy strategy) {
            this.taskTracker.setSortingStrategy(strategy);
        }

        public Task? findTaskById(int taskId) {
            List<Task> list = this.taskTracker.getTaskList();

            int index = -1;
            Task foundTask = null;
            for (int i = 0; i < list.Count; ++i)
            {
                if (list[i].getId() == taskId)
                {
                    index = i;
                    foundTask = list[i];
                    break;
                }
            }

            if (index == -1)
                return null;

            return foundTask;
        }

        public void removeTask(int taskId) {
            Task task = this.findTaskById(taskId);
            if (task == null)
            {
                ConsoleUtil.writeError("Task with the ID of " + taskId + " was not found.");
                return;
            }
            
            bool result = this.taskTracker.removeItem(task);
            if (result)
                ConsoleUtil.writeInfo("Task removed.");
            else
                ConsoleUtil.writeError("Task removal failed. If you encouter this problem again contact software admin.");
        }

        public void printTaskDetail(int taskId) {
            Task task = this.findTaskById(taskId);
            if(task == null)
            {
                ConsoleUtil.writeError("Task with the ID of " + taskId + " was not found.");
                return;
            }

            ConsoleUtil.clear();
            Console.WriteLine("Deatil of task with ID " + taskId + ":");
            Console.WriteLine("Title");
            Console.WriteLine("-----");
            Console.WriteLine(task.getTitle());
            Console.Write("\n");

            Console.WriteLine("Description");
            Console.WriteLine("-----------");
            Console.WriteLine(task.getDescription());
            Console.Write("\n");

            Console.WriteLine("Due date");
            Console.WriteLine("--------");
            if (task.getDateTime() != null)
                Console.WriteLine(task.getDateTime().Value.Date.ToString("dd.MM yyyy"));
            else
                Console.WriteLine("No due date");
            Console.Write("\n");

            Console.WriteLine("Priority");
            Console.WriteLine("--------");
            if (task.getPriority() != null)
                Console.WriteLine(task.getPriority());
            else
                Console.WriteLine("No priority");
            Console.Write("\n");

            Console.WriteLine("Time complexity");
            Console.WriteLine("---------------");
            if (task.getPriority() != null)
                Console.WriteLine(task.getTimeComplexity());
            else
                Console.WriteLine("No time complexity");
            Console.Write("\n\n");
        }

        public void printTaskList() {
            if (ConsoleConfig.clearText)
                Console.Clear();
            Console.WriteLine("Currect task list:");
            Console.WriteLine("Sorting mode: " + this.taskTracker.getSortingStrategy().getStrategyName());
            List<Task> list = this.taskTracker.getTaskList();
            if (list.Count == 0)
                Console.WriteLine("Task list is empty");
            else
                Console.WriteLine("ID\tStatus\tTitle\t\t\t\t\t\tDue Date\tPriority\tTime complexity");
            foreach (Task task in list) {
                Console.WriteLine(task);
            }
            Console.Write("\n");
        }
    }
}
