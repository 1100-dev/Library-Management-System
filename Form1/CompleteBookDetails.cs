using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Form1
{
    public partial class CompleteBookDetails : Form
    {
        public CompleteBookDetails()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(
            ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString
        );

        private void CompleteBookDetails_Load(object sender, EventArgs e)
        {
            LoadIssuedBooks();
            LoadReturnedBooks();
        }

        // =========================
        // ISSUED BOOKS (NOT RETURNED)
        // =========================
        private void LoadIssuedBooks()
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT * FROM IRBook WHERE book_return_date IS NULL",
                con
            );

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        // =========================
        // RETURNED BOOKS
        // =========================
        private void LoadReturnedBooks()
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT * FROM IRBook WHERE book_return_date IS NOT NULL",
                con
            );

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView2.DataSource = dt;
        }
    }
}