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
    public partial class LoginSettings : Form
    {
        public LoginSettings()
        {
            InitializeComponent();
        }

        private void LoginSettings_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=(localdb)\\Local;Initial Catalog=Northwind;Integrated Security=True");
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("UPDATE dbo.Employees SET Extension = 2525 WHERE EmployeeID = '25'", connection);
            connection.Close();
            //if (textBox2.Text == textBox3.Text)
            //{
                
            //    //UPDATE dbo.Employees SET Extension = " + textBox2.Text + " WHERE EmployeeID = '" + textBox1.Text + "'
            //}
            //else
            //{
            //    MessageBox.Show("Şifreler Uyuşmuyor");
            //}
            //--------------------------
        }

    }
}
