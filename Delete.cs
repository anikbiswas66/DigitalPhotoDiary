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
            string sql = "SELECT * FROM events WHERE id=" +Convert.ToInt32(textBox3.Text);
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
                textBox1.Text = textBox2.Text = dateTimePicker1.Text = "";
            }
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            connection.Open();
            string sql = "DELETE FROM events WHERE id="+Convert.ToInt32(textBox3.Text);
            SqlCommand command = new SqlCommand(sql, connection);
            //command.Parameters.AddWithValue("@photo", SavePhoto());
            //command.ExecuteNonQuery();
            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                MessageBox.Show("Event Deleted!");

            }
            else
            {
                MessageBox.Show("Error!");
            }
            connection.Close();
        }

        private void Delete_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PhotoDiary photodiary = new PhotoDiary();
            this.Hide();
            photodiary.Show();
        }
    }
}
