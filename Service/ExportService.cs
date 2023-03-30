using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using TODO_Tracker.Entity;
using System.IO;
using TODO_Tracker.Utils.TaskTracker;
using TODO_Tracker.Utils;
using TODO_Tracker.Utils.Exporter;
using TODO_Tracker.Strategy.TaskSortStrategy;

namespace TODO_Tracker.Service
{
    class ExportService
    {
        private TaskTracker taskTracker = TaskTracker.getInstance();
        private JsonExporter jsonExporter = new JsonExporter();

        private List<string> supportedFormats = new List<string> {"json"};

        public void export(string format = "json", bool runtimeSaving = false) {
            if (!this.formatCheck(format)) {
                ConsoleUtil.writeError("Invalid format");
                return;
            }

            try
            {
                string exportLocation = null;
                if (format == "json")
                {
                    if(!runtimeSaving)
                        exportLocation = this.jsonExporter.export("export-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".json");
                    else
                        exportLocation = this.jsonExporter.export("runtime-save.json");
                }
                if(!runtimeSaving)
                    ConsoleUtil.writeInfo("Exported at location \"" + exportLocation + "\"");
            }
            catch (Exception e) {
                ConsoleUtil.writeError("Failed to write export to filesystem.\n" + e.ToString());
            }
        }

        public void import(string path, string format = "json", bool append = false) {
            if (!this.formatCheck(format))
            {
                ConsoleUtil.writeError("Invalid format");
                return;
            }

            if (format == "json") {
                ExportData importData = this.jsonExporter.import(path);
                if (!append)
                {
                    this.taskTracker.setTaskList(importData.list);
                    if (!this.checkHash(importData))
                    {
                        ConsoleUtil.writeError("Import file is corrupted. Wrong check sum\nImportData checksum: " + importData.checksum + "\nExporttData checksum: " + exportData.checksum);
                        return;
                    }
                }
                else
                {
                    List<Task> currentList = this.taskTracker.getTaskList();
                    currentList.AddRange(importData.list);
                    this.taskTracker.setTaskList(currentList);
                }
                   
            }
            string jsonString = File.ReadAllText(path);
        }

        private bool checkHash(ExportData importData) {
            ITaskSortStrategy currentStrategy = this.taskTracker.getSortingStrategy();
            this.taskTracker.setSortingStrategy(new IdSortStrategy());
            ExportData exportData = new ExportData(this.taskTracker.getTaskList());
            this.taskTracker.setSortingStrategy(currentStrategy);
            return importData.checksum == exportData.checksum;
        }

        public bool fileExists(string path) {
            return File.Exists(path);
        }

        private bool formatCheck(string format) {
            return this.supportedFormats.Contains(format);
        }
    }
}
