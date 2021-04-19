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

namespace DigitalPhotoDiary
{
    public partial class Delete : Form
    {
        public Delete()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            connection.Open();
            string sql = "SELECT * FROM events WHERE id=" + Convert.ToInt32(textBox3.Text);
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                textBox1.Text = reader["ename"].ToString();
                textBox2.Text = reader["edescription"].ToString();
                dateTimePicker1.Text = reader["date"].ToString();
            }
            else
            {
                MessageBox.Show("Does not match!");
            }
            connection.Close();
        }
    }
}
