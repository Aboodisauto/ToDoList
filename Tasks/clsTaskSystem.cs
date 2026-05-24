using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Tasks
{
    public class clsTaskSystem
    {
        LinkedList<clsTask> _notStartedTasks;
        LinkedList<clsTask> _inProgressTasks;
        LinkedList<clsTask> _completedTasks;
        public LinkedList<clsTask> notStartedTasks
        {
            get { return _notStartedTasks; }
            set { _notStartedTasks = value; }
        }
        public LinkedList<clsTask> inProgressTasks
        {
            get { return _inProgressTasks; }
            set { _inProgressTasks = value; }
        }
        public LinkedList<clsTask> completedTasks
        {
            get { return _completedTasks; }
            set { _completedTasks = value; }
        }
        public clsTaskSystem()
        {
            _notStartedTasks = new LinkedList<clsTask>();
            _inProgressTasks = new LinkedList<clsTask>();
            _completedTasks = new LinkedList<clsTask>();
        }
        public void addTask(clsTask task)
        {
            _notStartedTasks.AddLast(task);
        }
        public void moveTask(clsTask task, LinkedList<clsTask> from, LinkedList<clsTask> to)
        {
            if (from.Contains(task))
            {
                from.Remove(task);
                to.AddLast(task);
            }
        }
        public void removeTask(clsTask task, LinkedList<clsTask> from)
        {
            if (from.Contains(task))
            {
                from.Remove(task);
            }
        }
    }
}
