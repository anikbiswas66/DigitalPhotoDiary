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
            }
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

        }
    }
}
