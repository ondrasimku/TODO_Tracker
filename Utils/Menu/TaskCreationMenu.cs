using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using TODO_Tracker.Service;

namespace TODO_Tracker.Utils.Menu
{
    class TaskCreationMenu : AbstractMenu
    {
        private readonly TaskTrackerSerice todoListService = new TaskTrackerSerice();

        private readonly string cultureCode = "cs-CZ";
        private readonly string dateFormat = "dd.MM.yyyy";
        public override void menuStart()
        {
            string title = this.getTitleInput();
            string description = this.getDescriptionInput();
            DateTime? dueDate = this.getDueDateInput();
            int? priority = this.getPriorityInput();

            todoListService.addTask(title);

            Console.WriteLine(title);
            Console.WriteLine(description);
            if (dueDate != null)
                Console.WriteLine(dueDate.ToString());
            else
                Console.WriteLine("No date");

            if (priority != null)
                Console.WriteLine(priority);
            else
                Console.WriteLine("No priority");
        }

        private string getTitleInput() {
            this.clear();
            bool gotTitle = false;
            String title = null;
            while (!gotTitle)
            {
                Console.Write("Enter task title: ");
                title = Console.ReadLine();
                if (string.IsNullOrEmpty(title))
                {
                    this.writeError("Title must not be empty");
                    continue;
                }
                    
                if (title.Length > 80)
                    this.writeError("Title must not contain more than 80 characters.");
                else
                    gotTitle = true;
            }
            return title;
        }

        private string getDescriptionInput()
        {
            this.clear();
            bool gotTitle = false;
            string description = null;
            while (!gotTitle)
            {
                Console.Write("Enter task description: ");
                description = Console.ReadLine();
                if (string.IsNullOrEmpty(description))
                {
                    this.writeError("Description must not be empty");
                    continue;
                }

                if (description.Length > 80)
                    this.writeError("Title mustn't contain more than 80 characters.");
                else
                    gotTitle = true;
            }
            return description;
        }

        private DateTime? getDueDateInput() {
            this.clear();
            bool agree = this.agree("Do want the task to have a due date? (Y/N): ");
            if (!agree)
                return null;

            CultureInfo cultureInfo = new CultureInfo(this.cultureCode);
            DateTime? dateTime = null;
            bool gotDueDate = false;
            while (!gotDueDate) {
                Console.Write("Enter date in format \"day.month.year\"(ex. 03.12.2001): ");
                try
                {
                    dateTime = DateTime.ParseExact(Console.ReadLine(), this.dateFormat, cultureInfo);
                    gotDueDate = true;
                }
                catch (FormatException exception)
                {
                    this.writeError("Wrong date format.\n"+exception.Message);
                }
            }
            return dateTime;
        }

        private int? getPriorityInput() {
            this.clear();
            bool agree = this.agree("Do want the task to have priority level? (Y/N): ");
            if (!agree)
                return null;

            bool gotPriority = false;
            int priority = 0;
            while (!gotPriority)
            {
                Console.Write("Enter task priority level (0-5): ");
                bool validChoice = int.TryParse(Console.ReadLine(), out priority);
                if (validChoice)
                {
                    if (priority < 0 || priority > 5)
                        this.writeError("Enter a whole number between 0 and 5");
                    else
                        gotPriority = true;
                }
                else
                {
                    this.writeError("Enter a whole number between 0 and 5");
                }
            }
            return priority;
        }
    }
}
