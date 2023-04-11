using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TODO_Tracker.Service;
using TODO_Tracker.Utils.Menu;

namespace TODO_Tracker.Utils.Menu
{

    class MainMenu : AbstractMenu
    {
        private readonly TaskTrackerService taskTrackerService = new TaskTrackerService();
        private readonly ExportService exportService = new ExportService();
        private readonly TaskCreationMenu taskCreationMenu = new TaskCreationMenu();
        private readonly TaskRemoveMenu taskRemoveMenu = new TaskRemoveMenu();
        private readonly TaskDetailMenu taskDetailMenu = new TaskDetailMenu();
        private readonly TaskSortMenu taskSortMenu = new TaskSortMenu();
        private readonly TasksImportMenu tasksImportMenu = new TasksImportMenu();

        public override void menuStart() {
            this.exportService.checkRuntimeSave();
            ushort choice;
            bool running = true;
            while (running) {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. List tasks"); // Done
                Console.WriteLine("2. Sort tasks"); // Done
                Console.WriteLine("3. Add task"); // Done
                Console.WriteLine("4. Task detail"); // Done
                Console.WriteLine("5. Remove task"); // Done
                Console.WriteLine("6. Export to file"); // Done
                Console.WriteLine("7. Import from file");
                Console.WriteLine("0. Exit"); // Done

                Console.Write("\nYour choice (0-7): ");
                bool validChoice = ushort.TryParse(Console.ReadLine(), out choice);
                if (validChoice)
                {
                    switch (choice)
                    {
                        case 0:
                            ConsoleUtil.writeInfo("Exiting");
                            this.exportService.export("json", true);
                            running = false;
                            break;
                        case 1:
                            this.taskTrackerService.printTaskList();
                            break;
                        case 2:
                            this.taskSortMenu.menuStart();
                            break;
                        case 3:
                            this.taskCreationMenu.menuStart();
                            break;
                        case 4:
                            this.taskDetailMenu.menuStart();
                            break;
                        case 5:
                            this.taskRemoveMenu.menuStart();
                            break;
                        case 6:
                            this.exportService.export();
                            break;
                        case 7:
                            this.tasksImportMenu.menuStart();
                            break;
                        default:
                            ConsoleUtil.writeError("Invalid choice");
                            break;
                    }
                }
                else
                {
                    ConsoleUtil.writeError("You must enter a number.");
                }
            }
        }
    }
}
