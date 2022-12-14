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
    public partial class ListForm : Form
    {
        public ListForm()
        {
            InitializeComponent();
        }

        private void ListForm_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Products")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Categories");
                comboBox2.Items.Add("Suppliers");
                comboBox2.Items.Add("OrderDetails");
            }
            else if (comboBox1.Text == "Orders")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Employees");
                comboBox2.Items.Add("Customers");
                comboBox2.Items.Add("OrderDetails");
                comboBox2.Items.Add("Shippers");
            }
            else if (comboBox1.Text == "Employees")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Orders");
                comboBox2.Items.Add("Customers");
                comboBox2.Items.Add("EmployeeTerritories");
                comboBox2.Items.Add("Territories");
                comboBox2.Items.Add("Region");
            }
            else if (comboBox1.Text == "Customers")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Employees");
                comboBox2.Items.Add("Orders");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Bağlantıyı kur
            SqlConnection connection = new SqlConnection("Data Source=(localdb)\\Local;Initial Catalog=Northwind;Integrated Security=True");
            //Bağlantıyı Aç
            connection.Open();
            //Tablo oluştur
            DataTable table = new DataTable();
            //////////////////////
            //PRODUCTS JOINS
            if (comboBox1.Text == "Products" && comboBox2.Text == "Categories")
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT ProductID, ProductName, CategoryName, QuantityPerUnit, UnitPrice FROM dbo.Products AS p JOIN dbo.Categories AS c ON p.CategoryID = c.CategoryID", connection);
                adapter.Fill(table);
            }
            else if (comboBox1.Text == "Products" && comboBox2.Text == "Suppliers")
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT ProductID, ProductName, QuantityPerUnit, UnitPrice, UnitsInStock, CompanyName as Supplier, ContactTitle, [Address], City FROM dbo.Products AS p JOIN dbo.Suppliers AS s ON p.SupplierID = s.SupplierID", connection);
                adapter.Fill(table);
            }
            else if (comboBox1.Text == "Products" && comboBox2.Text == "OrderDetails")
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT orderID, * FROM dbo.Products AS p JOIN dbo.[Order Details] AS od ON p.ProductID = od.ProductID", connection);
                adapter.Fill(table);
            }
            /////////////////////
            //ORDERS JOINS
            else if (comboBox1.Text == "Orders" && comboBox2.Text == "Employees")
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT OrderID, * FROM dbo.Employees as e JOIN dbo.Orders as o ON e.EmployeeID = o.EmployeeID ORDER BY o.OrderID", connection);
                adapter.Fill(table);
            }
            else if (comboBox1.Text == "Orders" && comboBox2.Text == "Customers")
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT OrderID, * FROM dbo.Customers as c JOIN dbo.Orders as o ON c.CustomerID = o.CustomerID ORDER BY o.OrderID", connection);
                adapter.Fill(table);
            }
            else if (comboBox1.Text == "Orders" && comboBox2.Text == "OrderDetails")
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM dbo.[Order Details] as od JOIN dbo.Orders as o ON od.OrderID = o.OrderID ORDER BY o.OrderID", connection);
                adapter.Fill(table);
            }
            else if (comboBox1.Text == "Orders" && comboBox2.Text == "Shippers")
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM dbo.Shippers as sh CROSS JOIN dbo.Orders as o", connection);
                adapter.Fill(table);
            }
            //////////////////////
            //EMPLOYEES JOINS
            else if (comboBox1.Text == "Employees" && comboBox2.Text == "Orders")
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT OrderID, * FROM dbo.Employees as e JOIN dbo.Orders as o ON e.EmployeeID = o.EmployeeID ORDER BY o.OrderID", connection);
                adapter.Fill(table);
            }
            else if (comboBox1.Text == "Employees" && comboBox2.Text == "Customers")
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT e.EmployeeID, FirstName + ' ' + LastName as EmployeeName, e.Title, o.OrderID, c.CustomerID, c.ContactName, c.ContactTitle FROM dbo.Employees as e LEFT JOIN dbo.Orders as o ON e.EmployeeID = o.EmployeeID RIGHT JOIN dbo.Customers as c ON o.CustomerID = c.CustomerID", connection);
                adapter.Fill(table);
            }
            else if (comboBox1.Text == "Employees" && comboBox2.Text == "EmployeeTerritories")
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT et.TerritoryID, * FROM dbo.Employees AS e JOIN dbo.EmployeeTerritories AS et ON e.EmployeeID = et.EmployeeID ORDER BY et.TerritoryID", connection);
                adapter.Fill(table);
            }
            else if (comboBox1.Text == "Employees" && comboBox2.Text == "Territories")
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT et.TerritoryID, * FROM dbo.Employees AS e JOIN dbo.EmployeeTerritories AS et ON e.EmployeeID = et.EmployeeID JOIN dbo.Territories as t ON et.TerritoryID = t.TerritoryID ORDER BY et.TerritoryID", connection);
                adapter.Fill(table);
            }
            else if (comboBox1.Text == "Employees" && comboBox2.Text == "Region")
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT et.TerritoryID, * FROM dbo.Employees AS e JOIN dbo.EmployeeTerritories AS et ON e.EmployeeID = et.EmployeeID JOIN dbo.Territories as t ON et.TerritoryID = t.TerritoryID JOIN dbo.Region as r ON t.RegionID = r.RegionID ORDER BY et.TerritoryID", connection);
                adapter.Fill(table);
            }
            ///////////////////////
            //CUSTOMERS JOINS
            else if (comboBox1.Text == "Customers" && comboBox2.Text == "Employees")
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT e.EmployeeID, FirstName + ' ' + LastName as EmployeeName, e.Title, o.OrderID, c.CustomerID, c.ContactName, c.ContactTitle FROM dbo.Employees as e LEFT JOIN dbo.Orders as o ON e.EmployeeID = o.EmployeeID RIGHT JOIN dbo.Customers as c ON o.CustomerID = c.CustomerID", connection);
                adapter.Fill(table);
            }
            else if (comboBox1.Text == "Customers" && comboBox2.Text == "Orders")
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT OrderID, * FROM dbo.Customers as c JOIN dbo.Orders as o ON c.CustomerID = o.CustomerID ORDER BY o.OrderID", connection);
                adapter.Fill(table);
            }
            ////////////////////////
            else
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT *FROM [" + comboBox1.Text + "]", connection);
                adapter.Fill(table);
            }
            dataGridView1.DataSource = table;
            connection.Close();
        }
    }
}
