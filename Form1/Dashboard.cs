using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form1
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void addNewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBooks abs = new AddBooks();
            abs.Show();
        }

        private void viewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewBooks vb = new ViewBooks();
            vb.Show();
        }

        private void viewStudentInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewStudentinformation viewStudentinformation = new ViewStudentinformation();
            viewStudentinformation.Show();
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudent addStudent = new AddStudent();
            addStudent.Show();
        }

        private void issueBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueBooks issueBooks = new IssueBooks();
            issueBooks.Show();
        }

        private void returnBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReturnBook returnBook = new ReturnBook();
            returnBook.Show();  
        }

        private void completeBookDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompleteBookDetails returnBookDetails = new CompleteBookDetails();
                returnBookDetails.Show();
        }
    }
}
