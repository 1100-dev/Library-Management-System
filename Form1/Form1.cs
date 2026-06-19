using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Form1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUsername_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Clear();
            }
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Clear();
                txtPassword.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxInsta_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com");
        }

        private void pictureBoxfb_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com");

        }

        private void pictureBoxtwitter_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.twitter.com");

        }

        private void Login_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(
    ConfigurationManager.ConnectionStrings["LoginDB"].ConnectionString
);
            con.Open(); // VERY IMPORTANT

                string query = "SELECT * FROM loginTable WHERE username=@u AND pass=@p";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@u", txtUsername.Text);
                cmd.Parameters.AddWithValue("@p", txtPassword.Text);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("✔ Login Successful!");
                     new Dashboard().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("❌ Wrong Username or Password");
                }

                con.Close();
            



        }
    }
}