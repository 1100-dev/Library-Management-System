using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Form1
{
    public partial class AddBooks : Form
    {
        public AddBooks()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(
            ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString
        );

        // =========================
        // SAVE BOOK
        // =========================
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBookName.Text) ||
                string.IsNullOrWhiteSpace(txtAuthor.Text) ||
                string.IsNullOrWhiteSpace(txtPublication.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                MessageBox.Show("Empty Fields Not Allowed", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!long.TryParse(txtPrice.Text, out long price) ||
                !long.TryParse(txtQuantity.Text, out long quan))
            {
                MessageBox.Show("Price and Quantity must be numbers", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            con.Open();

            SqlCommand cmd = new SqlCommand(
                @"INSERT INTO NewBook
                (bName, bAuthor, bPubl, bPDate, bPrice, bQuan)
                VALUES
                (@name, @author, @publ, @date, @price, @quan)",
                con
            );

            cmd.Parameters.AddWithValue("@name", txtBookName.Text);
            cmd.Parameters.AddWithValue("@author", txtAuthor.Text);
            cmd.Parameters.AddWithValue("@publ", txtPublication.Text);
            cmd.Parameters.AddWithValue("@date", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@quan", quan);

            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Book Saved Successfully", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearFields();
        }

        // =========================
        // CLEAR FIELDS
        // =========================
        private void ClearFields()
        {
            txtBookName.Clear();
            txtAuthor.Clear();
            txtPublication.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
        }

        // =========================
        // CANCEL
        // =========================
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will close the form",
                "Confirm",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}