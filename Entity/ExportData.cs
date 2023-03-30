using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TODO_Tracker.Entity;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Security.Cryptography;

namespace TODO_Tracker.Entity
{
    class ExportData
    {
        public List<Task> list;
        public string checksum;

        public ExportData(List<Task> list) {
            this.list = list;
            this.checksum = this.hashList();
        }

        private string hashList() {
            string dataStr = "";
            foreach (Task task in this.list) {
                dataStr += task.getId() + task.getTitle() + task.getDescription() +
                            task.getDateTime() + task.getPriority() + task.getTimeComplexity() + task.getIsDone();
            }

            byte[] dataBytes = Encoding.UTF8.GetBytes(dataStr);
            byte[] hashBytes;
            StringBuilder hashStringBuilder = new StringBuilder();
            using (SHA512 shaManaged = new SHA512Managed())
            {
                hashBytes = shaManaged.ComputeHash(dataBytes);
                foreach (byte b in hashBytes)
                {
                    hashStringBuilder.Append($"{b:X2}");
                }
            }
            return hashStringBuilder.ToString();
        }

    }
}
