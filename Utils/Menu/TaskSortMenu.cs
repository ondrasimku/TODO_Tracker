using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TODO_Tracker.Strategy.TaskSortStrategy;
using TODO_Tracker.Service;

namespace TODO_Tracker.Utils.Menu
{
    class TaskSortMenu : AbstractMenu
    {
        private readonly TaskTrackerService taskTrackerService = new TaskTrackerService();
        public override void menuStart()
        {
            ITaskSortStrategy strategy = this.getStrategyInput();
            if(strategy != null)
                this.taskTrackerService.setSortingStrategy(strategy);
            this.taskTrackerService.printTaskList();
        }

        private ITaskSortStrategy? getStrategyInput() {
            ConsoleUtil.clear();
            ushort choice;
            bool gotStrategy = false;
            ITaskSortStrategy returnStrategy = null;
            while (!gotStrategy)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Sort by task ID");
                Console.WriteLine("2. Sort by task priority");
                Console.WriteLine("3. Sort by time complexity");
                Console.WriteLine("4. Sort by date");
                Console.WriteLine("0. Back");

                Console.Write("\nYour choice (0-4): ");
                bool validChoice = ushort.TryParse(Console.ReadLine(), out choice);
                if (validChoice)
                {
                    switch (choice)
                    {
                        case 0:
                            gotStrategy = true;
                            break;
                        case 1:
                            returnStrategy = new IdSortStrategy();
                            gotStrategy = true;
                            break;
                        case 2:
                            returnStrategy = new PrioritySortStrategy();
                            gotStrategy = true;
                            break;
                        case 3:
                            returnStrategy = new TimeComplexitySortStrategy();
                            gotStrategy = true;
                            break;
                        case 4:
                            returnStrategy = new DateTimeSortStrategy();
                            gotStrategy = true;
                            break;
                        default:
                            ConsoleUtil.writeError("Invalid choice.");
                            break;
                    }
                }
                else
                {
                    ConsoleUtil.writeError("You must enter a number.");
                }
            }
            return returnStrategy;
        }
    }
}
