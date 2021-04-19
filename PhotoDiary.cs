using DigitalPhotoDiary.Properties;
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

namespace DigitalPhotoDiary
{
    public partial class PhotoDiary : Form
    {
        public PhotoDiary()
        {
            InitializeComponent();
        }

        private void PhotoDiary_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Select Photo";
            fileDialog.Filter = "Image File(*.png;*.jpeg;*.jpg;*.bmp)|*.png;.jpeg;*.jpg;*.bmp";
            fileDialog.ShowDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(fileDialog.FileName);
            }
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
                string sql = "INSERT INTO events(ename,edescription,date,photo) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + dateTimePicker1.Text + "','" + pictureBox1.Text + "')";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@photo", SavePhoto());
                command.ExecuteNonQuery();
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Event Added!");

                }
                else
                {
                    MessageBox.Show("Error!");
                }
                connection.Close();
                GetValue();
            }
        }
        private void GetValue()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            DataTable dataTable = new DataTable();
            connection.Open();
            string sql = "Select * From events";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            dataTable.Load(sqlDataReader);
            connection.Close();
            dataGridView1.DataSource = dataTable;

        }
        private byte[] SavePhoto()
        {
            MemoryStream memoryStream = new MemoryStream();
            pictureBox1.Image.Save(memoryStream, pictureBox1.Image.RawFormat);
            return memoryStream.GetBuffer();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PhotoDiary_Load(object sender, EventArgs e)
        {
            GetValue();
            //SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            //connection.Open();
            //string sql = "SELECT = FROM events";
            //SqlCommand command = new SqlCommand(sql, connection);
            //List<events> events = new List<events>();
            //SqlDataReader reader = command.ExecuteReader();
            //while(reader.Read())
            //{
            //    events events1 = new events();
            //    events1.id = (int)reader["id"];
            //    events1.ename = reader["ename"].ToString();
            //    events1.description = reader["edescription"].ToString();
            //    events1.date= reader["date"].ToString();
            //    events1.Add(events1);
            //}
            //connection.Close();
            //dataGridView1.DataSource = events;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            pictureBox1.Image = Resources.img_94880;
        }

        private void PhotoDiary_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if(e.RowIndex>=0)
            //{
            //    //DataGridView row = this.dataGridView1.Rows[e.RowIndex];
            //    //pictureBox1.Image = GetPhoto((byte[])row.Cells[7].Value);
            //}

        }
    }
}
