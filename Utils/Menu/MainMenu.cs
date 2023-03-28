using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO_Tracker.Service;
using TODO_Tracker.Utils.Menu;

namespace TODO_Tracker.Utils.Menu
{

    class MainMenu : AbstractMenu
    {
        private readonly TaskTrackerSerice taskTrackerService = new TaskTrackerSerice();
        private readonly TaskCreationMenu taskCreationMenu = new TaskCreationMenu();

        public override void menuStart() {
            int choice;
            bool running = true;
            while (running) {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. List tasks");
                Console.WriteLine("2. Filter tasks");
                Console.WriteLine("3. Add task");
                Console.WriteLine("4. Task detail");
                Console.WriteLine("5. Bulk action");
                Console.WriteLine("6. Remove item");
                Console.WriteLine("7. Export to file");
                Console.WriteLine("8. Import from file");
                Console.WriteLine("0. Exit");

                Console.Write("\nYour choice (0-8): ");
                bool validChoice = int.TryParse(Console.ReadLine(), out choice);
                if (validChoice)
                {
                    switch (choice)
                    {
                        case 0:
                            Console.WriteLine("Exiting");
                            running = false;
                            break;
                        case 1:
                            Console.WriteLine(this.taskTrackerService.getTask());
                            break;
                        case 2:
                            Console.WriteLine("You chose Option 2.");
                            break;
                        case 3:
                            this.taskCreationMenu.menuStart();
                            break;
                        case 4:
                            Console.WriteLine("You chose Option 4.");
                            break;
                        case 5:
                            Console.WriteLine("You chose Option 5.");
                            break;
                        case 6:
                            Console.WriteLine("Exiting program.");
                            break;
                        case 7:
                            Console.WriteLine("Exiting program.");
                            break;
                        case 8:
                            Console.WriteLine("Exiting program.");
                            break;
                        default:
                            this.writeError("Invaĺid choice");
                            break;
                    }
                }
                else
                {
                    this.writeError("You must enter a number.");
                }
            }
        }
    }
}
