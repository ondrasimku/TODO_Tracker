using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TODO_Tracker.Service;

namespace TODO_Tracker.Utils.Menu
{
    class TaskRemoveMenu : AbstractMenu
    {
        private readonly TaskTrackerService taskTrackerService = new TaskTrackerService();
        public override void menuStart()
        {
            int? taskId = this.getTaskIdInput();
            if (taskId == null)
                return;
            this.taskTrackerService.removeTask((int)taskId);
        }

        public int? getTaskIdInput() {
            bool gotId = false;
            byte taskId = 0;
            while (!gotId)
            {
                Console.Write("Enter task ID you wish to remove: ");
                bool validChoice = byte.TryParse(Console.ReadLine(), out taskId);
                if (validChoice)
                    gotId = true;
                else
                    ConsoleUtil.writeError("Enter a whole number.");
            }
            bool agree = this.agree("Do you really want to remove task with ID of " + taskId + " (Y/N):");
            if (!agree)
                return null;
            return taskId;
        }
    }
}
