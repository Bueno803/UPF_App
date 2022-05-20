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
        private string sqlConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=upf_app;";

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

        private void AddBtn_Click(object sender, EventArgs e)
        {
            int ZipCode = Int32.Parse(ZipTxt.Text);
            DateTime SignUpDate = DateTime.Parse(dateTimePicker1.Text);
            InsertClient(new Client_Space()
            {

                FirstName = FirstNameTxt.Text,
                MiddleName = MiddleNameTxt.Text,
                LastName = LastNameTxt.Text,
                PhoneNumber = PhoneNumTxt.Text,
                HomeNumber = HomeNumTxt.Text,
                Email = EmailTxt.Text,
                StreetAddress = StAddressTxt.Text,
                State = StateComboBx.Text,
                City = CityTxt.Text,
                PostalCode = ZipCode,
                Gender = GenderComboBx.Text,
                ClientType = ClientComboBx.Text,
                Location = LocationTxt.Text,
                SignUpDate = SignUpDate
            });

            MessageBox.Show("Successfully added to database!", "Add Prompt");

        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            SendMessage(this.Handle, WM_SETREDRAW, false, 0);

            UPF_Search UPF_S = new UPF_Search();
            UPF_S.Show();

            SendMessage(this.Handle, WM_SETREDRAW, true, 0);
            this.Refresh();
            Hide();

        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
                                                                                           client.FirstName,
                                                                                           client.MiddleName,
                                                                                           client.LastName,
                                                                                           client.PhoneNumber
                                                                                       ,
                                                                                           client.HomeNumber,
                                                                                           client.Email,
                                                                                           client.StreetAddress,
                                                                                           client.State,
                                                                                           client.City,
                                                                                           client.PostalCode
                                                                                       ,
                                                                                           client.Gender,
                                                                                           client.ClientType,
                                                                                           client.Location,
                                                                                           client.SignUpDate
                                                                                       });
                connection.Close();
                return affectedRows;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        //This method update client record in database    
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
    }
}