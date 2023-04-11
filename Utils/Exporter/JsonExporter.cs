using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using TODO_Tracker.Utils.TaskTracker;
using TODO_Tracker.Utils;
using System.Reflection;
using TODO_Tracker.Entity;
using System.Text.Json;
using System.Text.Json.Serialization;
using TODO_Tracker.Strategy.TaskSortStrategy;

namespace TODO_Tracker.Utils.Exporter
{
    class JsonExporter : IExporter
    {
        private TaskTracker.TaskTracker taskTracker = TaskTracker.TaskTracker.getInstance();
        public string export(string filename)
        {
            ITaskSortStrategy currentStrategy = this.taskTracker.getSortingStrategy();
            this.taskTracker.setSortingStrategy(new IdSortStrategy());
            ExportData exportData = new ExportData(this.taskTracker.getTaskList());
            this.taskTracker.setSortingStrategy(currentStrategy);

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                IncludeFields = true,
                WriteIndented = true,
            };
            string jsonData = JsonSerializer.Serialize(exportData, options);
            // Cross-platform way to get executable working directory
            string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\export\\";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            File.WriteAllText(path+filename, jsonData);
            return path + filename;
        }

        // File already exists here, since we checked in ExportService
        public ExportData import(string path)
        {
            string jsonData = File.ReadAllText(path);
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                IncludeFields = true,
                WriteIndented = true,
            };
            ExportData importData = JsonSerializer.Deserialize<ExportData>(jsonData, options);
            return importData;
        }
    }
}
