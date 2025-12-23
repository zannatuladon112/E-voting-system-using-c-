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
    public partial class pResult : Form
    {
        string NA = ConfigurationManager.ConnectionStrings["ABC"].ConnectionString;
        public pResult()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            BindGridView();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home x = new Home();
            x.Show();
        }
        void BindGridView()
        {


            using (SqlConnection con = new SqlConnection(NA))
            {

                string query = "SELECT CANDIDATE_NUMBER,  NAME, SUM(VOTE_COUNT) AS TOTAL_VOTES FROM  ADMIN_CONTROL GROUP BY CANDIDATE_NUMBER, NAME; ";

                using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
                {


                    DataTable data = new DataTable();
                    sda.Fill(data);
                    dataGridView1.DataSource = data;
                }
                dataGridView1.RowTemplate.Height = 100;
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.Width = 240;

                }

            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
