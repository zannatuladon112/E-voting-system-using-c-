using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EVote
{
    public partial class VoterLogin : Form
    {
        string NA = ConfigurationManager.ConnectionStrings["ABC"].ConnectionString;
        public VoterLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != ""&& textBox3.Text !="")
            {

                SqlConnection con = new SqlConnection(NA);
                string query = "select * from VOTER_REGISTRATION where NID = @NID and NAME=@NAME and PASSWORD= @PASSWORD  ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@NID", textBox1.Text);
                cmd.Parameters.AddWithValue("@NAME",textBox2.Text);
                cmd.Parameters.AddWithValue("@PASSWORD", textBox3.Text);
                con.Open();
                SqlDataReader kar = cmd.ExecuteReader();
                if (kar.HasRows == true)
                {
                    MessageBox.Show("login Successful", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Voter x = new Voter();
                    x.Show();
                }
                else
                {
                    MessageBox.Show("login fail", "fail to log in", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("fill the field", "fail to log in", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }




            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            VoterRegistration x = new VoterRegistration();
            x.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || textBox1.Text == "Enter your NID")
            {
                errorProvider1.SetError(textBox1, "NID is required");
                textBox1.Text = "";
                textBox1.Focus();
            }
            else
            {
                errorProvider1.SetError(textBox1, "");
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) || textBox2.Text == "Enter your name")
            {
                errorProvider2.SetError(textBox2, "Name required");
                textBox2.Text = "";
                textBox2.Focus();
            }
            else
            {
                errorProvider2.SetError(textBox2, "");
            }

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox3.Text) || textBox3.Text == "Enter your Password")
            {
                errorProvider2.SetError(textBox3, "Password is required");
                textBox3.Text = "";
                textBox3.Focus();
            }
            else
            {
                errorProvider2.SetError(textBox3, "");
            }

        }
    }
}
