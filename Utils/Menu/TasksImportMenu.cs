using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TODO_Tracker.Service;
using TODO_Tracker.Utils;
using System.IO;

namespace TODO_Tracker.Utils.Menu
{
    class TasksImportMenu : AbstractMenu
    {
        private readonly TaskTrackerService taskTrackerService = new TaskTrackerService();
        private readonly ExportService exportService = new ExportService();
        public override void menuStart()
        {
            string path = this.getPathInput();
            if (path == null)
                return;
            this.exportService.import(path);
        }

        private string? getPathInput() {
            ConsoleUtil.clear();
            string path = null;
            bool gotPath = false;
            while (!gotPath) {
                Console.Write("Enter path to import file: ");
                path = Console.ReadLine();
                if (string.IsNullOrEmpty(path))
                {
                    ConsoleUtil.writeError("Incorrect input.");
                    continue;
                }
                if (!this.exportService.fileExists(path)) {
                    ConsoleUtil.writeError("File \"" + path + "\" not found.");
                    return null;
                }
                gotPath = true;
            }
            return path;
        }
    }
}
