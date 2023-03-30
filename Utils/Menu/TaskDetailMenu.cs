using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TODO_Tracker.Service;

namespace TODO_Tracker.Utils.Menu
{
    class TaskDetailMenu : AbstractMenu
    {
        private readonly TaskTrackerService taskTrackerService = new TaskTrackerService();
        public override void menuStart()
        {
            int taskId = this.getTaskIdInput();
            this.taskTrackerService.printTaskDetail(taskId);
        }

        public int getTaskIdInput()
        {
            bool gotId = false;
            byte taskId = 0;
            while (!gotId)
            {
                Console.Write("Enter task ID you want to see the detail of: ");
                bool validChoice = byte.TryParse(Console.ReadLine(), out taskId);
                if (validChoice)
                    gotId = true;
                else
                    ConsoleUtil.writeError("Enter a whole number.");
            }
            return taskId;
        }
    }
}
