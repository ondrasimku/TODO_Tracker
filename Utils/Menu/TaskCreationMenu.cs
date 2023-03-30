using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using TODO_Tracker.Service;

namespace TODO_Tracker.Utils.Menu
{
    class TaskCreationMenu : AbstractMenu
    {
        private readonly TaskTrackerService taskTrackerService = new TaskTrackerService();

        private readonly string cultureCode = "cs-CZ";
        private readonly string dateFormat = "dd.MM.yyyy";
        public override void menuStart()
        {
            string title = this.getTitleInput();
            string description = this.getDescriptionInput();
            DateTime? dueDate = this.getDueDateInput();
            ushort? priority = this.getPriorityInput();
            ushort? timeComplexity = this.getTimeComplexityInput();
            taskTrackerService.addTask(title, description, dueDate, priority, timeComplexity, false);
            ConsoleUtil.writeInfo("Task created.");
        }

        private string getTitleInput() {
            ConsoleUtil.clear();
            bool gotTitle = false;
            String title = null;
            while (!gotTitle)
            {
                Console.Write("Enter task title: ");
                title = Console.ReadLine();
                if (string.IsNullOrEmpty(title))
                {
                    ConsoleUtil.writeError("Title must not be empty");
                    continue;
                }
                    
                if (title.Length > 47)
                    ConsoleUtil.writeError("Title must not contain more than 47 characters.");
                else
                    gotTitle = true;
            }
            return title;
        }

        private string getDescriptionInput()
        {
            ConsoleUtil.clear();
            bool gotTitle = false;
            string description = null;
            while (!gotTitle)
            {
                Console.Write("Enter task description: ");
                description = Console.ReadLine();
                if (string.IsNullOrEmpty(description))
                {
                    ConsoleUtil.writeError("Description must not be empty");
                    continue;
                }

                if (description.Length > 50)
                    ConsoleUtil.writeError("Title mustn't contain more than 80 characters.");
                else
                    gotTitle = true;
            }
            return description;
        }

        private DateTime? getDueDateInput() {
            ConsoleUtil.clear();
            bool agree = this.agree("Do want the task to have a due date? (Y/N): ");
            if (!agree)
                return null;

            CultureInfo cultureInfo = new CultureInfo(this.cultureCode);
            DateTime? dateTime = null;
            bool gotDueDate = false;
            while (!gotDueDate) {
                Console.Write("Enter date in format \""+ this.dateFormat +"\"(ex. "+ DateTime.Now.Date.ToString(this.dateFormat)+"): ");
                try
                {
                    dateTime = DateTime.ParseExact(Console.ReadLine(), this.dateFormat, cultureInfo);
                    gotDueDate = true;
                }
                catch (FormatException exception)
                {
                    ConsoleUtil.writeError("Wrong date format.\n"+exception.Message);
                }
            }
            return dateTime;
        }

        private ushort? getPriorityInput() {
            ConsoleUtil.clear();
            bool agree = this.agree("Do want the task to have priority level? (Y/N): ");
            if (!agree)
                return null;

            bool gotPriority = false;
            ushort priority = 0;
            while (!gotPriority)
            {
                Console.Write("Enter task priority level (0-5): ");
                bool validChoice = ushort.TryParse(Console.ReadLine(), out priority);
                if (validChoice)
                {
                    if (priority > 5)
                        ConsoleUtil.writeError("Enter a whole number between 0 and 5");
                    else
                        gotPriority = true;
                }
                else
                {
                    ConsoleUtil.writeError("Enter a whole number between 0 and 5");
                }
            }
            return priority;
        }

        private ushort? getTimeComplexityInput()
        {
            ConsoleUtil.clear();
            bool agree = this.agree("Do want the task to have time complexity? (Y/N): ");
            if (!agree)
                return null;

            bool gotComplexity = false;
            ushort complexity = 0;
            while (!gotComplexity)
            {
                Console.Write("Enter task time complexity (0-10): ");
                bool validChoice = ushort.TryParse(Console.ReadLine(), out complexity);
                if (validChoice)
                {
                    if (complexity > 10)
                        ConsoleUtil.writeError("Enter a whole number between 0 and 10");
                    else
                        gotComplexity = true;
                }
                else
                {
                    ConsoleUtil.writeError("Enter a whole number between 0 and 10");
                }
            }
            return complexity;
        }
    }
}
