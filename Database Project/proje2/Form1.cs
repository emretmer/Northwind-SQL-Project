using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace proje2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string id = textBox1.Text;
            //string pw = textBox2.Text;
            //SqlConnection connection = new SqlConnection("Data Source=(localdb)\\Local;Initial Catalog=Northwind;Integrated Security=True");
            //SqlCommand command = new SqlCommand();
            //SqlDataReader reader;
            //connection.Open();
            //command.Connection = connection;
            //command.CommandText = "SELECT* FROM dbo.Employees WHERE FirstName + LastName = '" + id + "'AND Extension = '" + pw + "'";
            //reader = command.ExecuteReader();
            //if (reader.Read())
            //{
            //    Form2 form2 = new Form2();
            //    form2.Show();
            //    this.Hide();
            //}
            //else
            //{
            //    textBox2.Text = "";
            //}
            //connection.Close();
            //--------------------------
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }
    }
}
