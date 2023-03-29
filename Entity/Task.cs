using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TODO_Tracker.Entity
{
    class Task
    {
        private int         id;
        private string      title;
        private string      description;
        private DateTime?   dateTime;
        private byte?       priority;
        private bool        isDone;

        public Task() { }
        public Task(string title, string description, DateTime? dateTime, byte? priority, bool isDone) {
            this.title = title;
            this.description = description;
            this.dateTime = dateTime;
            this.priority = priority;
            this.isDone = isDone;
        }

        public int getId() {
            return this.id;
        }

        public Task setId(int id) {
            this.id = id;
            return this;
        }

        public string getTitle() {
            return this.title;
        }
        public Task setTitle(string title) {
            this.title = title;
            return this;
        }

        public string getDescription()
        {
            return this.description;
        }
        public Task setDescription(string description)
        {
            this.description = description;
            return this;
        }

        public DateTime? getDateTime()
        {
            return this.dateTime;
        }
        public Task setDateTime(DateTime? dateTime)
        {
            this.dateTime = dateTime;
            return this;
        }

        public byte? getPriority()
        {
            return this.priority;
        }
        public Task setPriority(byte? priority)
        {
            this.priority = priority;
            return this;
        }

        public bool getIsDone()
        {
            return this.isDone;
        }
        public Task setIsDone(bool isDone)
        {
            this.isDone = isDone;
            return this;
        }

        public override string ToString()
        {
            string objStr = "[" + this.id + "]\t";
            if (this.isDone)
                objStr += "O\t";
            else
                objStr += "X\t";

            objStr += title;
            int remainder = 48 - title.Length;
            for (int i = remainder; remainder > 0; remainder -= 8) {
                objStr += "\t";
            }
            if (this.dateTime != null)
                objStr += this.dateTime.Value.Date.ToString("dd.MM yyyy");
            else
                objStr += "\t";
            if (this.priority != null)
                objStr += "\t" + this.priority;
            return objStr;
        }
    }
}
