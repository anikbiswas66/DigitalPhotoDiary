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
    public partial class Modify : Form
    {
        public Modify()
        {
            InitializeComponent();
        }

        private void Modify_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            connection.Open();
            string sql = "SELECT * FROM events WHERE id="+Convert.ToInt32(textBox3.Text);
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                textBox1.Text= reader["ename"].ToString();
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Event Name can not be empty");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Description can not be empty");
            }
            else if (dateTimePicker1.Text == "")
            {
                MessageBox.Show("Date can not be empty");
            }
            else
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
                connection.Open();
                string sql = "UPDATE events SET ename='"+textBox1.Text+"',edescription='"+textBox2.Text+"',date='"+dateTimePicker1.Text+"' WHERE id="+ Convert.ToInt32(textBox3.Text);
                SqlCommand command = new SqlCommand(sql, connection);
                //command.Parameters.AddWithValue("@photo", SavePhoto());
                command.ExecuteNonQuery();
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Event Updated!");

                }
                else
                {
                    MessageBox.Show("Error!");
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            PhotoDiary photoDiary = new PhotoDiary();
            this.Hide();
            photoDiary.Show();
        }
    }
}
