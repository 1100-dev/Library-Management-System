using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace Form1
{
    public partial class ViewStudentinformation : Form
    {
        public ViewStudentinformation()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(
            ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString
        );

        int bid;
        long rowid;

        // =========================
        // LOAD FORM
        // =========================
        private void ViewStudentinformation_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            LoadStudents();
        }

        private void LoadStudents()
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT * FROM NewStudent",
                con
            );

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        // =========================
        // SEARCH
        // =========================
        private void txtSearchEnrollement_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da;

            if (!string.IsNullOrWhiteSpace(txtSearchEnrollement.Text))
            {
                label1.Visible = false;

                da = new SqlDataAdapter(
                    "SELECT * FROM NewStudent WHERE enroll LIKE @e + '%'",
                    con
                );

                da.SelectCommand.Parameters.AddWithValue("@e", txtSearchEnrollement.Text);
            }
            else
            {
                label1.Visible = true;

                da = new SqlDataAdapter(
                    "SELECT * FROM NewStudent",
                    con
                );
            }

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        // =========================
        // CELL CLICK
        // =========================
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            bid = Convert.ToInt32(
                dataGridView1.Rows[e.RowIndex].Cells[0].Value
            );

            panel2.Visible = true;

            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT * FROM NewStudent WHERE stuid = @id",
                con
            );

            da.SelectCommand.Parameters.AddWithValue("@id", bid);

            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                rowid = Convert.ToInt64(dt.Rows[0][0]);

                txtSName.Text = dt.Rows[0][1].ToString();
                txtEnrollNo.Text = dt.Rows[0][2].ToString();
                txtDepartment.Text = dt.Rows[0][3].ToString();
                txtSSemester.Text = dt.Rows[0][4].ToString();
                txtContact.Text = dt.Rows[0][5].ToString();
                txtEmail.Text = dt.Rows[0][6].ToString();
            }
        }

        // =========================
        // DELETE
        // =========================
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be Deleted. Confirm?",
                "Delete",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning) == DialogResult.OK)
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM NewStudent WHERE stuid = @id",
                    con
                );

                cmd.Parameters.AddWithValue("@id", rowid);

                cmd.ExecuteNonQuery();
                con.Close();

                LoadStudents();
            }
        }

        // =========================
        // UPDATE
        // =========================
        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be Updated. Confirm?",
                "Success",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.OK)
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    @"UPDATE NewStudent 
                      SET sname=@n,
                          enroll=@e,
                          dep=@d,
                          sem=@s,
                          contact=@c,
                          email=@m
                      WHERE stuid=@id",
                    con
                );

                cmd.Parameters.AddWithValue("@n", txtSName.Text);
                cmd.Parameters.AddWithValue("@e", txtEnrollNo.Text);
                cmd.Parameters.AddWithValue("@d", txtDepartment.Text);
                cmd.Parameters.AddWithValue("@s", txtSSemester.Text);
                cmd.Parameters.AddWithValue("@c", Convert.ToInt64(txtContact.Text));
                cmd.Parameters.AddWithValue("@m", txtEmail.Text);
                cmd.Parameters.AddWithValue("@id", rowid);

                cmd.ExecuteNonQuery();
                con.Close();

                LoadStudents();
            }
        }

        // =========================
        // REFRESH
        // =========================
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearchEnrollement.Clear();
            LoadStudents();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }
    }
}