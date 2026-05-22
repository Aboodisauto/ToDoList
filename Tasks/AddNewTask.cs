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
    public partial class AddNewTask : Form
    {
        Task _task;
        LinkedList<Task> _tasks;
        enum enMode{
            Add,
            Edit
        }
        enMode Mode = enMode.Add;
        public AddNewTask(LinkedList<Task> tasks)
        {
            InitializeComponent();
            _tasks = tasks;
            _reset();
        }
        void _LoadTaskInformation()
        {
            textBox1.Text = _task.taskName;
            textBox2.Text = _task.description;
            textBox3.Text = _task.personAssigned;
            dateTimePicker1.Value = _task.due;

        }
        public AddNewTask(Task task,LinkedList<Task> tasks)
        {
            InitializeComponent();
            _task = task;
            _tasks = tasks;
            _LoadTaskInformation();
        }
        private void _reset()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        }
        Task createNewTask()
        {
            return new Task(textBox1.Text, textBox2.Text, dateTimePicker1.Value, textBox3.Text);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if(Mode == enMode.Edit)
            {
                _tasks.Remove(_task);
            }
            if (this.ValidateChildren())
            {
                _task = createNewTask();
                _tasks.AddLast(_task);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private void validateInput(TextBox textBox, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text.ToString()))
            {
                errorProvider1.SetError(textBox, "This field is required.");
                e.Cancel = true;
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            validateInput((TextBox)sender, e);
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            validateInput((TextBox)sender, e);
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            validateInput((TextBox)sender, e);
        }

        private void dateTimePicker1_Validating(object sender, CancelEventArgs e)
        {
            if(dateTimePicker1.Value < DateTime.Now)
            {
                errorProvider1.SetError(dateTimePicker1, "Due date must be in the future.");
                e.Cancel = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
