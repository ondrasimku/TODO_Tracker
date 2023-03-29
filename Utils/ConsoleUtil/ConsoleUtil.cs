using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TODO_Tracker.Config;

namespace TODO_Tracker.Utils
{
    class ConsoleUtil
    {
        public static void writeError(string message)
        {
            if (ConsoleConfig.clearText)
                Console.Clear();
            Console.ForegroundColor = ConsoleConfig.errorColor;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleConfig.menuColor;
        }

        public static void writeInfo(string message)
        {
            if (ConsoleConfig.clearText)
                Console.Clear();
            Console.ForegroundColor = ConsoleConfig.infoColor;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleConfig.menuColor;
        }
        public static void clear()
        {
            if (ConsoleConfig.clearText)
                Console.Clear();
        }

    }
}
