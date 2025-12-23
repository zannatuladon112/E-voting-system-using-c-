using System;
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
    public partial class Voter : Form
    {
        string NA = ConfigurationManager.ConnectionStrings["ABC"].ConnectionString;
        public Voter()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            BindGridView();
        }
        
        private string selectedName = string.Empty;
       
        void BindGridView()
        {


            using (SqlConnection con = new SqlConnection(NA))
            {

                string query = "SELECT NAME,PICTURE FROM ADMIN_CONTROL ";

                using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
                {


                    DataTable data = new DataTable();
                    sda.Fill(data);
                    dataGridView1.DataSource = data;
                }
                dataGridView1.RowTemplate.Height = 70;
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.Width = 100;

                }

            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string str;
            try
            {
             
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];


                    str = row.Cells["NAME"].Value.ToString();
                  
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StoreVoteValue(1);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            StoreVoteValue(1);
        }
        private void vote()
        {
            int selectedRowIndex = dataGridView1.CurrentCell?.RowIndex ?? -1;
            if (selectedRowIndex >= 0 && selectedRowIndex < dataGridView1.Rows.Count)
            {
                string name = dataGridView1.Rows[selectedRowIndex].Cells["Name"].Value.ToString();

            
                using (SqlConnection connection = new SqlConnection(NA))
                {
                    connection.Open();

                
                    string query = "UPDATE ADMIN_CONTROL SET VOTE_COUNT = VOTE_COUNT + 1 WHERE Name = @Name";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);

                      
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Voted '{name}'", "Voted successfully.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show($"No rows deleted. Row with name '{name}' not found.", "Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to vote", "Selection Wrong!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            vote();

        }
        private string selectedData = string.Empty;
       
        private void button2_Click(object sender, EventArgs e)
        {
            StoreVoteValue(1);
        }
        private void StoreVoteValue(int value)
        {
            using (SqlConnection con = new SqlConnection(NA))
            {
                con.Open();

               
                string query = "UPDATE ADMIN_CONTROL SET VoteValue = @Value";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Value", value);
                    cmd.ExecuteNonQuery();
                }
            }

   
            BindGridView();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
