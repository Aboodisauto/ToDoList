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
using ToDoList.Projects;

namespace ToDoList
{
    public partial class ChooseProjectfrm : Form
    {
        public ChooseProjectfrm()
        {
            InitializeComponent();
        }
        private void loadProjects()
        {
            projectsBox.Items.Clear();
            string[] projects = clsTaskSystem.getSavedProjects();
            foreach (string project in projects)
            {
                projectsBox.Items.Add(project);
            }
        }
        private void ChooseProjectfrm_Load(object sender, EventArgs e)
        {
            loadProjects();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string projectName = projectsBox.SelectedItem as string;
            if(string.IsNullOrEmpty(projectName))
            {
                MessageBox.Show("Please select a project to open.");
                return;
            }
            clsTaskSystem taskSystem = clsTaskSystem.LoadProject(projectName);
            frmTaskSystemViewer mainForm = new frmTaskSystemViewer(taskSystem, projectName);
            mainForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clsTaskSystem.deleteProject(projectsBox.SelectedItem as string);
            projectsBox.Items.Remove(projectsBox.SelectedItem);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmCreateProject createProjectForm = new frmCreateProject();
            createProjectForm.ShowDialog();
            loadProjects();
        }
    }
}
