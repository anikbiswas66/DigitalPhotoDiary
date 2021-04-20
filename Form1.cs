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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                button1.Enabled = true;
            }
            else
                button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Name can not be empty");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Username can not be empty");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Email can not be empty");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Password can not be empty");
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Confirm Password can not be empty");
            }
            else
            {
                if (textBox4.Text != textBox5.Text)
                {
                    MessageBox.Show("Password and Confirm Password does not match!");
                }
                else
                {
                    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
                    connection.Open();
                    string sql = "INSERT INTO users(name,username,email,password) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.ExecuteNonQuery();
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("User Added!");
                        Dashboard dashboard = new Dashboard();
                        this.Hide();
                        dashboard.Show();

                    }
                    else
                    {
                        MessageBox.Show("Error!");
                    }
                    connection.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            this.Hide();
            dashboard.Show();
        }
    }
}
