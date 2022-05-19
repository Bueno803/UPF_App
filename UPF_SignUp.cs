using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using UPF_App.Persistence.Domain;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Dapper;

namespace UPF_App
{
    public partial class Form1 : Form
    {
        //private string sqlConnectionString = @"Data Source = localhost;initial catalog=upf databases;user id=rooty;password=password";
        private string sqlConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=test;";

        /* This part is to stop the window from flickering whenver clicking on components.
           In order to stop the window from flickering, import the following code inside the object and
           "using System.Runtime.InteropServices;" and "using Microsoft.Win32;"
              {
               SendMessage(this.Handle, WM_SETREDRAW, false, 0);
               
               // Whatever code you wanna run
               SendMessage(this.Handle, WM_SETREDRAW, true, 0);
               this.Refresh();
              }
           Also copy above the public Form() argument :
            [DllImport("user32.dll")]
            public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
            private const int WM_SETREDRAW = 11;
         */
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;

        public Form1()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            int ZipCode = Int32.Parse(textBox10.Text);
            InsertClient(new Client_Space()
            {
                FirstName = textBox1.Text,
                MiddleName = textBox2.Text,
                LastName = textBox3.Text,
                PhoneNumber = textBox4.Text,
                HomeNumber = textBox5.Text,
                Email = textBox6.Text,
                StreetAddress = textBox7.Text,
                State = comboBox5.Text,
                City = textBox8.Text,
                PostalCode = ZipCode,
                Gender = comboBox4.Text,
                ClientType = comboBox1.Text,
                Location = textBox12.Text,
                SignUpDate = dateTimePicker1.Text
            });

        }

        private void AddToDTBBtn_Click(object sender, EventArgs e)
        {
            SendMessage(this.Handle, WM_SETREDRAW, false, 0);

            UPF_Search UPF_S = new UPF_Search();
            UPF_S.Show();
            Visible = false;

            SendMessage(this.Handle, WM_SETREDRAW, true, 0);
            this.Refresh();
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private List<Client_Space> GetAllClientst()
        {
            List<Client_Space> students = new List<Client_Space>();
            using (var connection = new MySqlConnection(sqlConnectionString))
            {
                connection.Open();
                students = connection.Query<Client_Space>("Select Id, Name, Marks from Client_Space").ToList();
                connection.Close();
            }
            return students;
        }

        //This method inserts a student record in database    
        private int InsertClient(Client_Space client)
        {
            using (MySqlConnection connection = new MySqlConnection(sqlConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute("Insert into client_space (FirstName, MiddleName, LastName, PhoneNumber, HomeNumber, Email, StreetAddress, State, City, PostalCode, Gender," +
                                                                                       " ClientType, Location, SignUpDate) values (@FirstName, @MiddleName, @LastName, @PhoneNumber, @HomeNumber, @Email, @StreetAddress, @State, @City, @PostalCode, @Gender," +
                                                                                       " @ClientType, @Location, @SignUpDate)", new
                                                                                       {
                                                                                           FirstName = client.FirstName,
                                                                                           MiddleName = client.MiddleName,
                                                                                           LastName = client.LastName,
                                                                                           PhoneNumber = client.PhoneNumber
                                                                                       ,
                                                                                           HomeNumber = client.HomeNumber,
                                                                                           Email = client.Email,
                                                                                           StreetAddress = client.StreetAddress,
                                                                                           State = client.State,
                                                                                           City = client.City,
                                                                                           PostalCode = client.PostalCode
                                                                                       ,
                                                                                           Gender = client.Gender,
                                                                                           ClientType = client.ClientType,
                                                                                           Location = client.Location,
                                                                                           SignUpDate = client.SignUpDate
                                                                                       });
                connection.Close();
                return affectedRows;
            }
        }

        //This method update student record in database    
        //private int UpdateClients(Client_Space client)
        //{
        //    using (var connection = new SqlConnection(sqlConnectionString))
        //    {
        //        connection.Open();
        //        var affectedRows = connection.Execute("Update Client_Information set Name = @Name, Marks = @Marks Where Id = @Id", new { Id = studentId, Name = txtName.Text, Marks = txtMarks.Text });
        //        connection.Close();
        //        return affectedRows;
        //    }
        //}

        ////This method deletes a student record from database    
        //private int DeleteClients(Client_Space client)
        //{
        //    using (SqlConnection connection = new SqlConnection(sqlConnectionString))
        //    {
        //        connection.Open();
        //        var affectedRows = connection.Execute("Delete from Client_Information Where Id = @Id", new { First_Name = studentId });
        //        connection.Close();
        //        return affectedRows;
        //    }
        //}
    }
}