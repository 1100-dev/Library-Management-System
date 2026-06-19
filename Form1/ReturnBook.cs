using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Form1
{
    public partial class ReturnBook : Form
    {
        public ReturnBook()
        {
            InitializeComponent();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
        }

        Int64 rowid = 0;

        // =========================
        // SAFE ROW SELECTION
        // =========================
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.IsNewRow)
                return;

            var row = dataGridView1.CurrentRow;

            if (row.Cells["id"].Value != null)
                rowid = Convert.ToInt64(row.Cells["id"].Value);

            txtBookName.Text = row.Cells["book_name"]?.Value?.ToString() ?? "";
            txtIssueDate.Text = row.Cells["book_issue_date"]?.Value?.ToString() ?? "";
        }

        // =========================
        // LOAD DATA
        // =========================
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEnrollement.Text))
            {
                MessageBox.Show("Enter Enrollment No");
                return;
            }

            using (SqlConnection con = new SqlConnection(
                "data source=DESKTOP-MG878RP\\MSSQLSERVER01; database=library; integrated security=true"))
            using (SqlCommand cmd = new SqlCommand(
                "SELECT * FROM IRBook WHERE std_enroll = @enroll AND book_return_date IS NULL", con))
            {
                cmd.Parameters.AddWithValue("@enroll", txtEnrollement.Text);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    dataGridView1.DataSource = null;
                    panel2.Visible = false;
                    MessageBox.Show("No Issued Book Found");
                    return;
                }

                dataGridView1.DataSource = dt;
                panel2.Visible = true;

                dataGridView1.Rows[0].Selected = true;
            }
        }

        // =========================
        // RETURN BOOK
        // =========================
        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (rowid == 0)
            {
                MessageBox.Show("Select a book first");
                return;
            }

            using (SqlConnection con = new SqlConnection(
                "data source=DESKTOP-MG878RP\\MSSQLSERVER01; database=library; integrated security=true"))
            using (SqlCommand cmd = new SqlCommand(
                @"UPDATE IRBook 
                  SET book_return_date = @returnDate 
                  WHERE id = @id", con))
            {
                cmd.Parameters.AddWithValue("@returnDate", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@id", rowid);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Return Successful", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnSearch_Click(sender, e);
        }

        // =========================
        // REFRESH
        // =========================
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtEnrollement.Clear();
            dataGridView1.DataSource = null;
            panel2.Visible = false;
            rowid = 0;
        }

        // =========================
        // EXIT
        // =========================
        private void btnexit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure?", "Confirm",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }
    }
}