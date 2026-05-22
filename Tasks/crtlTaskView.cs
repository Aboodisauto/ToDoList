using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList.Tasks
{
    public partial class crtlTaskView : UserControl
    {
        Task _task;
        void LoadData() 
        {
            label1.Text = _task.taskName;
            TimeSpan diff = _task.due - DateTime.Now;
            if (diff.Days < 10)
            {
                BackColor = Color.Orange;
            }
            else if(diff.Days < 5)
            {
                BackColor = Color.Red;
            }
            else if(diff.Days < 0)
            {
                BackColor = Color.DarkGray;
            }
            else
            {
                BackColor = Color.Green;
            }
        }
        public crtlTaskView(Task Task)
        {
            InitializeComponent();
            _task = Task;
            label1.Text = _task.taskName;
        }
    }
}
