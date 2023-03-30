using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO_Tracker.Entity;

namespace TODO_Tracker.Utils.Exporter
{
    interface IExporter
    {
        public string export(string filename);

        public ExportData import(string path);
    }
}
