using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace EVote
{
    public partial class VoterRegistration : Form
    {
        string NA = ConfigurationManager.ConnectionStrings["ABC"].ConnectionString;
        public VoterRegistration()
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(NA);
            string query = "insert into VOTER_REGISTRATION values (@NID,@NAME,@PASSWORD,@ADDRESS,@PICTURE)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@NID", textBox1.Text);
            cmd.Parameters.AddWithValue("@NAME", textBox2.Text);
            cmd.Parameters.AddWithValue("@PASSWORD", textBox3.Text);
            cmd.Parameters.AddWithValue("@ADDRESS", textBox6.Text);
            cmd.Parameters.AddWithValue("@PICTURE", SavePhoto());

            con.Open();
            int B = cmd.ExecuteNonQuery();
            if (B > 0)
            {
                MessageBox.Show("Registration Successfully");
                VoterLogin x = new VoterLogin();
                x.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Please try again!");
            }
        }
        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            //ofd.Filter = "PNG FILE (*.PNG) | *.PNG";
            ofd.Filter = "ALL IMAGE FILE (*.*) | *.*";
            //ofd.ShowDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
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
            if (string.IsNullOrEmpty(textBox2.Text) || textBox2.Text == "Enter your Name")
            {
                errorProvider2.SetError(textBox2, "Name is required");
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
                errorProvider3.SetError(textBox3, "Password is required");
                textBox3.Text = "";
                textBox3.Focus();
            }
            else
            {
                errorProvider3.SetError(textBox3, "");
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text) || textBox6.Text == "Enter your Address")
            {
                errorProvider4.SetError(textBox6, "Address is required");
                textBox6.Text = "";
                textBox6.Focus();
            }
            else
            {
                errorProvider4.SetError(textBox6, "");
            }
        }
    }
}
