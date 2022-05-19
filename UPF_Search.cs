using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using Dapper;
using MySql.Data.MySqlClient;
using UPF_App.Persistence.Domain;

namespace UPF_App
{
    public partial class UPF_Search : Form
    {
        private string sqlConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=upf_app;";

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;
        public UPF_Search()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void BackToAdd_Click(object sender, EventArgs e)
        {
            SendMessage(this.Handle, WM_SETREDRAW, false, 0);

            Form1 UPF_SU = new Form1();
            UPF_SU.Show();
            //Visible = false;

            SendMessage(this.Handle, WM_SETREDRAW, true, 0);
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //Search by First Name
        private void SearchByFNBtn_Click(object sender, EventArgs e)
        {
            GetClientByFirstName(textBox1.Text);
        }
        //Search by Last Name
        private void SearchByLNBtn_Click(object sender, EventArgs e)
        {
            GetClientByLasttName(textBox3.Text);
        }
        // Search by phone number
        private void SearchByPN_Click(object sender, EventArgs e)
        {
            GetClientByPhoneNumber(textBox4.Text);
        }
        // Search by location
        private void SearchByL_Click(object sender, EventArgs e)
        {
            GetClientByLocation(textBox2.Text);
        }
        // Delete row
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            //int rowIndex = dataGridView1.CurrentCell.RowIndex;
            // dataGridView1.Rows.RemoveAt(rowIndex);
            
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a row to delete!");
                return;
            } 
            else
            {
                DialogResult d;
                d = MessageBox.Show("Are you sure you want to delete Client Id: " + dataGridView1.CurrentRow.Cells["ClientID"].Value + " Client Information?", "Delete Prompt", MessageBoxButtons.YesNo);
                if(d==DialogResult.Yes)
                {
                    int clientID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ClientID"].Value);
                    DeleteClients(new Client_Space() { ClientID = clientID });
                }
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private List<Client_Space> GetClientByFirstName(string firstName)
        {
            List<Client_Space> clients = new List<Client_Space>();
            using (var connection = new MySqlConnection(sqlConnectionString))
            {
                connection.Open();
                clients = connection.Query<Client_Space>("Select ClientID, FirstName, MiddleName, LastName, PhoneNumber, HomeNumber, Email, StreetAddress, State, City, PostalCode, Gender," +
                                                                                       " ClientType, Location, SignUpDate from Client_Space where FirstName ='"+firstName+"'").ToList();
                dataGridView1.DataSource = clients;
                connection.Close();
            }
            return clients;
        }

        private List<Client_Space> GetClientByLasttName(string lastName)
        {
            List<Client_Space> clients = new List<Client_Space>();
            using (var connection = new MySqlConnection(sqlConnectionString))
            {
                connection.Open();
                clients = connection.Query<Client_Space>("Select ClientID, FirstName, MiddleName, LastName, PhoneNumber, HomeNumber, Email, StreetAddress, State, City, PostalCode, Gender," +
                                                         " ClientType, Location, SignUpDate from Client_Space where LastName ='" + lastName + "'").ToList();
                dataGridView1.DataSource = clients;
                connection.Close();
            }
            return clients;
        }

        private List<Client_Space> GetClientByPhoneNumber(string phoneNumber)
        {
            List<Client_Space> clients = new List<Client_Space>();
            using (var connection = new MySqlConnection(sqlConnectionString))
            {
                connection.Open();
                clients = connection.Query<Client_Space>("Select ClientID, FirstName, MiddleName, LastName, PhoneNumber, HomeNumber, Email, StreetAddress, State, City, PostalCode, Gender," +
                                                         " ClientType, Location, SignUpDate from Client_Space where PhoneNumber ='" + phoneNumber + "'").ToList();
                dataGridView1.DataSource = clients;
                connection.Close();
            }
            return clients;
        }

        private List<Client_Space> GetClientByLocation(string location)
        {
            List<Client_Space> clients = new List<Client_Space>();
            using (var connection = new MySqlConnection(sqlConnectionString))
            {
                connection.Open();
                clients = connection.Query<Client_Space>("Select ClientID, FirstName, MiddleName, LastName, PhoneNumber, HomeNumber, Email, StreetAddress, State, City, PostalCode, Gender," +
                                                         " ClientType, Location, SignUpDate from Client_Space where Location ='" + location + "'").ToList();
                dataGridView1.DataSource = clients;
                connection.Close();
            }
            return clients;
        }

        //This method deletes a client record from database    
        private int DeleteClients(Client_Space client)
        {
            using (var connection = new MySqlConnection(sqlConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute("Delete from Client_Space Where ClientID = @ClientID", new { ClientID = client.ClientID });
                this.Refresh();
                connection.Close();
                MessageBox.Show("Delete Successful!");
                return affectedRows;
            }
        }
    }
}