using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Form1
{
    public partial class ViewBooks : Form
    {
        public ViewBooks()
        {
            InitializeComponent();
        }

        // Global connection (portable)
        SqlConnection con = new SqlConnection(
            ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString
        );

        int bid;
        long rowid;

        private void ViewBooks_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            LoadBooks();
        }

        // =========================
        // LOAD ALL BOOKS
        // =========================
        private void LoadBooks()
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT * FROM NewBook",
                con
            );

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        // =========================
        // GRID CLICK
        // =========================
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            bid = Convert.ToInt32(
                dataGridView1.Rows[e.RowIndex].Cells[0].Value
            );

            panel2.Visible = true;

            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT * FROM NewBook WHERE bId = @id",
                con
            );

            da.SelectCommand.Parameters.AddWithValue("@id", bid);

            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                rowid = Convert.ToInt64(dt.Rows[0][0]);

                txtBName.Text = dt.Rows[0][1].ToString();
                txtAuthor.Text = dt.Rows[0][2].ToString();
                txtPublication.Text = dt.Rows[0][3].ToString();
                txtPDate.Text = dt.Rows[0][4].ToString();
                txtPrice.Text = dt.Rows[0][5].ToString();
                txtQuantity.Text = dt.Rows[0][6].ToString();
            }
        }

        // =========================
        // SEARCH
        // =========================
        private void txtBookName_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da;

            if (txtBookName.Text == "")
            {
                da = new SqlDataAdapter("SELECT * FROM NewBook", con);
            }
            else
            {
                da = new SqlDataAdapter(
                    "SELECT * FROM NewBook WHERE bName LIKE @name + '%'",
                    con
                );

                da.SelectCommand.Parameters.AddWithValue("@name", txtBookName.Text);
            }

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        // =========================
        // DELETE
        // =========================
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be Deleted. Confirm?",
                "Confirm",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning) == DialogResult.OK)
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM NewBook WHERE bId = @id",
                    con
                );

                cmd.Parameters.AddWithValue("@id", rowid);

                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Deleted Successfully");

                LoadBooks();
            }
        }

        // =========================
        // UPDATE
        // =========================
        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be Updated. Confirm?",
                "Confirm",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.OK)
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    @"UPDATE NewBook 
                      SET bName=@n, 
                          bAuthor=@a, 
                          bPubl=@p, 
                          bPDate=@d, 
                          bPrice=@pr, 
                          bQuan=@q 
                      WHERE bId=@id",
                    con
                );

                cmd.Parameters.AddWithValue("@n", txtBName.Text);
                cmd.Parameters.AddWithValue("@a", txtAuthor.Text);
                cmd.Parameters.AddWithValue("@p", txtPublication.Text);
                cmd.Parameters.AddWithValue("@d", txtPDate.Text);
                cmd.Parameters.AddWithValue("@pr", Convert.ToInt64(txtPrice.Text));
                cmd.Parameters.AddWithValue("@q", Convert.ToInt64(txtQuantity.Text));
                cmd.Parameters.AddWithValue("@id", rowid);

                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Updated Successfully");

                LoadBooks();
            }
        }

        // =========================
        // REFRESH
        // =========================
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtBookName.Clear();
            panel2.Visible = false;
            LoadBooks();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }
    }
}