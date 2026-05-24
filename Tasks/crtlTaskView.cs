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
        clsTask _task;
        public EventHandler leftButtonClicked;
        public EventHandler rightButtonClicked;

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
        public crtlTaskView(clsTask Task)
        {
            InitializeComponent();
            _task = Task;
            label1.Text = _task.taskName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rightButtonClicked?.Invoke(this, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            leftButtonClicked?.Invoke(this, e);
        }
    }
}
