using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO_Tracker.Utils.Menu
{
    abstract class AbstractMenu
    {
        private ConsoleColor menuColor = ConsoleColor.Gray;
        private ConsoleColor errorColor = ConsoleColor.Red;
        private ConsoleColor infoColor = ConsoleColor.Cyan;
        private bool clearText = false;

        public abstract void menuStart();

        protected void writeError(string message)
        {
            if (this.clearText)
                Console.Clear();
            Console.ForegroundColor = this.errorColor;
            Console.WriteLine(message);
            Console.ForegroundColor = this.menuColor;
        }

        protected void writeInfo(string message)
        {
            if (this.clearText)
                Console.Clear();
            Console.ForegroundColor = this.infoColor;
            Console.WriteLine(message);
            Console.ForegroundColor = this.menuColor;
        }

        protected bool agree(string message) {
            string agree = null;
            while (true)
            {
                Console.Write(message);
                agree = Console.ReadLine();
                if (agree != "Y" && agree != "Yes" && agree != "y" && agree != "N" && agree != "No" && agree != "n")
                    this.writeError("Unknown option.");
                else
                    break;
            }

            if (agree == "N" || agree == "No" || agree == "n")
                return false;

            return true;
        }

        protected void clear() {
            if (this.clearText)
                Console.Clear();
        }
    }
}
