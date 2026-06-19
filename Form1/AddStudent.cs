using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Form1
{
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(
            ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString
        );

        // =========================
        // EXIT
        // =========================
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm Exit?", "Alert",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        // =========================
        // REFRESH
        // =========================
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtEnroll.Clear();
            txtDepartment.Clear();
            txtSemester.Clear();
            txtContact.Clear();
            txtEmail.Clear();
        }

        // =========================
        // SAVE STUDENT
        // =========================
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtEnroll.Text) ||
                string.IsNullOrWhiteSpace(txtDepartment.Text) ||
                string.IsNullOrWhiteSpace(txtSemester.Text) ||
                string.IsNullOrWhiteSpace(txtContact.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please fill all fields", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!long.TryParse(txtContact.Text, out long mobile))
            {
                MessageBox.Show("Contact must be a number", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            con.Open();

            SqlCommand cmd = new SqlCommand(
                @"INSERT INTO NewStudent
                (sname, enroll, dep, sem, contact, email)
                VALUES
                (@name, @enroll, @dep, @sem, @contact, @mail)",
                con
            );

            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@enroll", txtEnroll.Text);
            cmd.Parameters.AddWithValue("@dep", txtDepartment.Text);
            cmd.Parameters.AddWithValue("@sem", txtSemester.Text);
            cmd.Parameters.AddWithValue("@contact", mobile);
            cmd.Parameters.AddWithValue("@mail", txtEmail.Text);

            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Student Saved Successfully", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnRefresh_Click(sender, e);
        }
    }
}