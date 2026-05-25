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

namespace ToDoList.Projects
{
    public partial class frmCreateProject : Form
    {
        public frmCreateProject()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string projectName = textBox1.Text;
            clsTaskSystem.createProject(projectName);
            MessageBox.Show($"{projectName} Project Created Successfully!");
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
