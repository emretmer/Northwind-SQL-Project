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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public void loadform(object Form)
        {
            if (this.panel5.Controls.Count > 0)
            {
                this.panel5.Controls.RemoveAt(0);
            }
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panel5.Controls.Add(f);
            this.panel5.Tag = f;
            f.Show();

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadform(new ListForm());
            //panel3.Hide();
            //panel2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Uygulamayı kapatma tuşu
            Environment.Exit(0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //panel2.Show();
            //panel3.Show();
            /////
            loadform(new EmployeeOperation());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadform(new LoginSettings());
        }
    }
}
