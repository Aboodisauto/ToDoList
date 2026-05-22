using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Tasks
{
    public class Task
    {
        private string _taskName;
        private string _description;
        private DateTime _due;
        private string _personAssigned;
        public string personAssigned
        {
            get { return _personAssigned; }
            set { _personAssigned = value; }
        }
        public DateTime due
        {
            get { return _due; }
            set { _due = value; }
        }
        public string taskName
        {
            get { return _taskName; }
            set { _taskName = value; }
        }
        public string description
        {
            get { return _description; }
            set { _description = value; }
        }
        public Task(string taskName, string description, DateTime due, string personAssigned)
        {
            _taskName = taskName;
            _description = description;
            _due = due;
            _personAssigned = personAssigned;
        }

    }
}
