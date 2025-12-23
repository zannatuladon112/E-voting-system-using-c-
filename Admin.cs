using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EVote
{
    public partial class Admin : Form
    {
        string NA = ConfigurationManager.ConnectionStrings["ABC"].ConnectionString;
        public Admin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            BindGridView();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginAs x = new LoginAs();
            x.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Candidate.Controls.Clear();
            Result res = new Result();
            Candidate.Controls.Add(res);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BindGridView();
            Candidate.Controls.Clear();
            Info inf = new Info();
            Candidate.Controls.Add(inf);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Candidate.Controls.Clear();
            List list = new List();
            Candidate.Controls.Add(list);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           
            this.Hide();
            Admin x = new Admin();
            x.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            //ofd.Filter = "PNG FILE (*.PNG) | *.PNG";
            ofd.Filter = "ALL IMAGE FILE (*.*) | *.*";
            //ofd.ShowDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = new Bitmap(ofd.FileName);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Show();
        }
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            pictureBox2.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[2].Value);
            

        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(NA);
            string query = "delete from ADMIN_CONTROL where CANDIDATE_NUMBER=@CANDIDATE_NUMBER";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@CANDIDATE_NUMBER", textBox1.Text);

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data Deleted Successfully");
                BindGridView();
                ResetControl();
            }
            else
            {
                MessageBox.Show("Data Not Deleted");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }
        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(NA);
            string query = "insert into ADMIN_CONTROL values (@CANDIDATE_NUMBER,@NAME,@PICTURE, @VOTE_COUNT)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@CANDIDATE_NUMBER", textBox1.Text);
            cmd.Parameters.AddWithValue("@NAME", textBox2.Text);

            cmd.Parameters.AddWithValue("@VOTE_COUNT", 0);
            cmd.Parameters.AddWithValue("@PICTURE", SavePhoto());
           

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data Inserted Successfully");
                BindGridView();
                ResetControl();
            }
            else
            {
                MessageBox.Show("Data Not Inserted");
            }
        }
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(NA);
            string query = "select * from ADMIN_CONTROL";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            // Check if there are at least 3 columns before accessing index 2
            if (dataGridView1.Columns.Count >= 3)
            {
                DataGridViewImageColumn dgv = new DataGridViewImageColumn();
                dgv = (DataGridViewImageColumn)dataGridView1.Columns[2];
                dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;
            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.RowTemplate.Height = 40;
        }

        void ResetControl()
        {
            textBox1.Clear();
            textBox2.Clear();
             pictureBox2.Image = Properties.Resources.Man_Icon_02;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ResetControl();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
