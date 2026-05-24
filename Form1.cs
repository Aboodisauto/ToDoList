using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoList.Tasks;

namespace ToDoList
{
    public partial class Form1 : Form
    {
        clsTaskSystem _taskSystem;
        public Form1()
        {
            InitializeComponent();
            _taskSystem = new clsTaskSystem();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tasks.AddNewTask frm = new Tasks.AddNewTask();
            frm.TaskCreated += _addTaskToUI;
            frm.ShowDialog();
        }
        
        private void _addTaskToUI(clsTask task)
        {
            crtlTaskView taskView = new crtlTaskView(task);
            _taskSystem.addTask(task);
            _loadTaskstoUi();
        }
        private void _clearPanels() {
            FlowLayoutPanel[] panels = { flowLayoutPanel1, flowLayoutPanel2, flowLayoutPanel3 };
            foreach (FlowLayoutPanel panel in panels)
            {
                panel.Controls.Clear();
            }
        }
        private void _loadTaskstoUi()
        {
            _clearPanels();

            _PopulatePanelsWithTasks(flowLayoutPanel1, _taskSystem.notStartedTasks, leftTarget: null, rightTarget: _taskSystem.inProgressTasks);
            _PopulatePanelsWithTasks(flowLayoutPanel2, _taskSystem.inProgressTasks, leftTarget: _taskSystem.notStartedTasks, rightTarget: _taskSystem.completedTasks);
            _PopulatePanelsWithTasks(flowLayoutPanel3, _taskSystem.completedTasks, leftTarget: _taskSystem.inProgressTasks, rightTarget: null);
        }
        private void _PopulatePanelsWithTasks(FlowLayoutPanel panel, LinkedList<clsTask> tasks, LinkedList<clsTask> leftTarget, LinkedList<clsTask> rightTarget)
        {
            foreach(clsTask task in tasks)
            {
                crtlTaskView taskView = new crtlTaskView(task);
                if (leftTarget != null)
                {
                    taskView.leftButtonClicked += (s, e) => {
                        _taskSystem.moveTask(task, tasks, leftTarget);
                        _loadTaskstoUi();
                    };
                }
                if (rightTarget != null)
                {
                    taskView.rightButtonClicked += (s, e) => {
                        _taskSystem.moveTask(task, tasks, rightTarget);
                        _loadTaskstoUi();
                    };
                }
                panel.Controls.Add(taskView);
            }
        }
        private void _HandleTaskMovement(clsTask task, LinkedList<clsTask> from, LinkedList<clsTask> to)
        {
            _taskSystem.moveTask(task, from, to);
            _loadTaskstoUi();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _loadTaskstoUi();
        }

        

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
        private void SaveProject()
        {
            string filePath = textBox1.Text;
            _taskSystem.saveProject(System.IO.Path.GetFileNameWithoutExtension(filePath));
            
        }
        private void LoadProject()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Binary files (*.bin)|*.bin|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = @"C:\Users\PCM\source\repos\Aboodisauto\ToDoList\bin\Debug\Projects";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = System.IO.Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                _taskSystem = clsTaskSystem.LoadProject(filePath);
                textBox1.Text = filePath;
                _loadTaskstoUi();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SaveProject();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            LoadProject();
        }
    }
}
