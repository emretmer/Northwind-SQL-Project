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
using System.IO;

namespace proje2
{
    public partial class EmployeeOperations : Form
    {
        public EmployeeOperations()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.ResetText();
            textBox2.ResetText();
            textBox3.ResetText();
            dateTimePicker1.ResetText();
            textBox5.ResetText();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=(localdb)\\Local;Initial Catalog=Northwind;Integrated Security=True");
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;
            connection.Open();
            command.Connection = connection;
            command.CommandText = "SET IDENTITY_INSERT Northwind. dbo.Employees ON INSERT INTO dbo.Employees (EmployeeId,LastName,FirstName,BirthDate,City) VALUES ('" + textBox1.Text + "','" + textBox3.Text + "','" + textBox2.Text + "','" + dateTimePicker1.Text.ToString() + "','" + textBox5.Text + "')";
            SqlDataAdapter adapter2 = new SqlDataAdapter("SELECT EmployeeId,LastName,FirstName,BirthDate,City FROM dbo.Employees", connection);
            reader = command.ExecuteReader();
            reader.Close();
            DataTable table = new DataTable();
            adapter2.Fill(table);
            dataGridView2.DataSource = table;
            connection.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=(localdb)\\Local;Initial Catalog=Northwind;Integrated Security=True");
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;
            connection.Open();
            command.Connection = connection;
            command.CommandText = "DELETE FROM dbo.Employees WHERE EmployeeID = " + textBox1.Text;
            SqlDataAdapter adapter2 = new SqlDataAdapter("SELECT EmployeeId,LastName,FirstName,BirthDate,City FROM dbo.Employees", connection);
            reader = command.ExecuteReader();
            reader.Close();
            DataTable table = new DataTable();
            adapter2.Fill(table);
            dataGridView2.DataSource = table;
            connection.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=(localdb)\\Local;Initial Catalog=Northwind;Integrated Security=True");
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("UPDATE dbo.Employees SET LastName = '" + textBox3.Text + "', FirstName = '" + textBox2.Text + "', City = '" + textBox5.Text + "', BirthDate = '" + dateTimePicker1.Text + "' WHERE EmployeeID = '" + textBox1.Text + "' SELECT EmployeeId,LastName,FirstName,BirthDate,City FROM dbo.Employees", connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView2.DataSource = table;
            connection.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=(localdb)\\Local;Initial Catalog=Northwind;Integrated Security=True");
            connection.Open();
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                SqlDataAdapter adapter2 = new SqlDataAdapter("SELECT EmployeeId,LastName,FirstName,BirthDate,City FROM dbo.Employees", connection);
                DataTable table1 = new DataTable();
                adapter2.Fill(table1);
                dataGridView2.DataSource = table1;
            }
            else
            {
                if (string.IsNullOrEmpty(comboBox3.Text))
                {
                    comboBox3.Text = "FirstName";
                }
                else
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT EmployeeId,LastName,FirstName,BirthDate,City FROM dbo.Employees WHERE [" + comboBox3.Text + "] LIKE '%" + textBox4.Text + "%'", connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView2.DataSource = table;
                    connection.Close();
                }

            }
        }

        private void EmployeeOperations_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            SqlConnection connection = new SqlConnection("Data Source=(localdb)\\Local;Initial Catalog=Northwind;Integrated Security=True");
            SqlDataAdapter adapter2 = new SqlDataAdapter("SELECT EmployeeId,LastName,FirstName,BirthDate,City FROM dbo.Employees", connection);
            connection.Open();
            DataTable table = new DataTable();
            adapter2.Fill(table);
            dataGridView2.DataSource = table;
            connection.Close();
        }

        private async void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            await Task.Delay(100);
            textBox1.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            dateTimePicker1.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
        }
    }
}
