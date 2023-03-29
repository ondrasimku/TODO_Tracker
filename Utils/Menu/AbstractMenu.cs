using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TODO_Tracker.Config;
using TODO_Tracker.Utils;

namespace TODO_Tracker.Utils.Menu
{
    abstract class AbstractMenu
    {
        public abstract void menuStart();

        protected bool agree(string message) {
            string agree = null;
            while (true)
            {
                Console.Write(message);
                agree = Console.ReadLine();
                if (agree != "Y" && agree != "Yes" && agree != "y" && agree != "N" && agree != "No" && agree != "n")
                    ConsoleUtil.writeError("Unknown option.");
                else
                    break;
            }

            if (agree == "N" || agree == "No" || agree == "n")
                return false;

            return true;
        }
    }
}
