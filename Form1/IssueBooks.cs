using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Form1
{
    public partial class IssueBooks : Form
    {
        public IssueBooks()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(
            ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString
        );

        int count = 0;

        // =========================
        // LOAD BOOKS
        // =========================
        private void IssueBooks_Load(object sender, EventArgs e)
        {
            comboBoxBooks.Items.Clear();

            SqlCommand cmd = new SqlCommand(
                "SELECT bName FROM NewBook",
                con
            );

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBoxBooks.Items.Add(dr[0].ToString());
            }

            dr.Close();
            con.Close();
        }

        // =========================
        // SEARCH STUDENT
        // =========================
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEnrollement.Text))
                return;

            string eid = txtEnrollement.Text;

            // Get student
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT * FROM NewStudent WHERE enroll = @e",
                con
            );

            da.SelectCommand.Parameters.AddWithValue("@e", eid);

            DataTable dt = new DataTable();
            da.Fill(dt);

            // Get issued book count
            SqlDataAdapter da2 = new SqlDataAdapter(
                "SELECT COUNT(*) FROM IRBook WHERE std_enroll = @e AND book_return_date IS NULL",
                con
            );

            da2.SelectCommand.Parameters.AddWithValue("@e", eid);

            DataTable dt2 = new DataTable();
            da2.Fill(dt2);

            count = Convert.ToInt32(dt2.Rows[0][0]);

            // Fill student info
            if (dt.Rows.Count > 0)
            {
                txtName.Text = dt.Rows[0][1].ToString();
                txtDepartment.Text = dt.Rows[0][3].ToString();
                txtSemester.Text = dt.Rows[0][4].ToString();
                txtContact.Text = dt.Rows[0][5].ToString();
                txtEmail.Text = dt.Rows[0][6].ToString();
            }
            else
            {
                ClearFields();
                MessageBox.Show("Invalid Enrollment No", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================
        // ISSUE BOOK
        // =========================
        private void btnIssueBooks_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Enter valid enrollment number", "Error");
                return;
            }

            if (comboBoxBooks.SelectedIndex == -1)
            {
                MessageBox.Show("Select a book", "Error");
                return;
            }

            if (count >= 2)
            {
                MessageBox.Show("Maximum 2 books already issued", "Limit Reached");
                return;
            }

            con.Open();

            SqlCommand cmd = new SqlCommand(
                @"INSERT INTO IRBook 
                (std_enroll, std_name, std_dep, std_sem, std_contact, std_email, book_name, book_issue_date, book_return_date)
                VALUES
                (@enroll, @name, @dep, @sem, @contact, @email, @book, @date, NULL)",
                con
            );

            cmd.Parameters.AddWithValue("@enroll", txtEnrollement.Text);
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@dep", txtDepartment.Text);
            cmd.Parameters.AddWithValue("@sem", txtSemester.Text);
            cmd.Parameters.AddWithValue("@contact", Convert.ToInt64(txtContact.Text));
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@book", comboBoxBooks.Text);
            cmd.Parameters.AddWithValue("@date", dateTimePicker1.Text);

            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Book Issued Successfully", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // =========================
        // CLEAR STUDENT DATA
        // =========================
        private void txtEnrollement_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEnrollement.Text))
            {
                ClearFields();
            }
        }

        private void ClearFields()
        {
            txtName.Clear();
            txtDepartment.Clear();
            txtSemester.Clear();
            txtContact.Clear();
            txtEmail.Clear();
        }

        // =========================
        // REFRESH
        // =========================
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtEnrollement.Clear();
            comboBoxBooks.SelectedIndex = -1;
            ClearFields();
        }

        // =========================
        // EXIT
        // =========================
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Confirm",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}