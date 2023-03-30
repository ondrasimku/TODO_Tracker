using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace TODO_Tracker.Entity
{
    
    class Task
    {
        private int         id;
        private string      title;
        private string      description;
        private DateTime?   dateTime;
        private ushort?     priority;
        private ushort?     timeComplexity;
        private bool        isDone;

        
        

        public int          Id { get { return this.id; } set { this.id = value; } }
        public string       Title { get { return this.title; } set { this.title = value; } }
        public string       Description { get { return this.description; } set { this.description = value; } }
        public DateTime?    DateTime { get { return this.dateTime; } set { this.dateTime = value; } }
        public ushort?      Priority { get { return this.priority; } set { this.priority = value; } }
        public ushort?      TimeComplexity { get { return this.timeComplexity; } set { this.timeComplexity = value; } }
        public bool         IsDone { get { return this.isDone; } set { this.isDone = value; } }

        public Task() { }
        public Task(string title, string description, DateTime? dateTime, ushort? priority, ushort? timeComplexity,bool isDone) {
            this.title = title;
            this.description = description;
            this.dateTime = dateTime;
            this.priority = priority;
            this.timeComplexity = timeComplexity;
            this.isDone = isDone;
        }

        public int getId() {
            Task test = new Task();
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

        public ushort? getPriority()
        {
            return this.priority;
        }
        public Task setPriority(ushort? priority)
        {
            this.priority = priority;
            return this;
        }

        public ushort? getTimeComplexity()
        {
            return this.timeComplexity;
        }
        public Task setTimeComplexity(ushort? timeComplexity)
        {
            this.timeComplexity = timeComplexity;
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
            else
                objStr += "\t";
            if (this.timeComplexity != null)
                objStr += "\t\t" + this.timeComplexity;
            return objStr;
        }
    }
}
