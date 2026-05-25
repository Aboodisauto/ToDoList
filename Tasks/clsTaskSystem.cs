using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace ToDoList.Tasks
{
    [Serializable]
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
        private void createNecessaryDirectory()
        {
            if (!Directory.Exists("Projects"))
            {
                Directory.CreateDirectory("Projects");
            }
        }
        public void saveProject(string projectName)
        {
            createNecessaryDirectory();
            BinaryFormatter formatter = new BinaryFormatter();
            if (File.Exists($"Projects/{projectName}.bin"))
            {
                File.Delete($"Projects/{projectName}.bin");
            }
            using (FileStream stream = new FileStream($"Projects/{projectName}.bin", FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(stream, this);
            }

        }
        public static clsTaskSystem LoadProject(string projectName)
        {
            clsTaskSystem taskSystem = new clsTaskSystem();
            BinaryFormatter formatter = new BinaryFormatter();
            if (projectName == null || !File.Exists($"Projects/{projectName}.bin"))
            {
                return null;
            }
            using (FileStream stream = new FileStream($"Projects/{projectName}.bin", FileMode.Open, FileAccess.Read))
            {
                taskSystem = (clsTaskSystem)formatter.Deserialize(stream);
            }
            return taskSystem;
        }
        public static string[] getSavedProjects()
        {
            string[] projectFiles = Directory.GetFiles("Projects", "*.bin");
            for (int i = 0; i < projectFiles.Length; i++)
            {
                projectFiles[i] = Path.GetFileNameWithoutExtension(projectFiles[i]);
            }
            return projectFiles;
        }
        public static bool deleteProject(string projectName)
        {
            if (File.Exists($"Projects/{projectName}.bin"))
            {
                File.Delete($"Projects/{projectName}.bin");
                return true;
            }
            return false;
        }
        public static void createProject(string projectName)
        {
            clsTaskSystem taskSystem = new clsTaskSystem();
            taskSystem.saveProject(projectName);
        }
    }
}
