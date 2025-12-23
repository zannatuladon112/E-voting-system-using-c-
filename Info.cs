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
    public partial class Info : UserControl
    {
        string NA = ConfigurationManager.ConnectionStrings["ABC"].ConnectionString;
        public Info()
        {
            InitializeComponent();
            BindGridView();
        }
        void BindGridView()
        {


            using (SqlConnection con = new SqlConnection(NA))
            {
               
                string query = "SELECT *  FROM VOTER_REGISTRATION ";

                using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
                {


                    DataTable data = new DataTable();
                    sda.Fill(data);
                    dataGridView1.DataSource = data;
                }
                dataGridView1.RowTemplate.Height = 110;
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.Width = 110; 
                   
                }

            }
        }
            private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
