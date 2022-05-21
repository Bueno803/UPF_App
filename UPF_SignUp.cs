using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using UPF_App.Persistence.Domain;

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


        //Rounded edges variables
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );


        public Form1()
        {
            InitializeComponent();

            //Applying rounded edges
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        //Drag top bar
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);

        private void topPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
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
            SendMessage(this.Handle, WM_SETREDRAW, false, 0);

            Form1 UPF_SU = new Form1();
            UPF_SU.Show();
            //Visible = false;

            SendMessage(this.Handle, WM_SETREDRAW, true, 0);
            this.Refresh();
            Hide();
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

        private void FirstNameTxt_TextChanged(object sender, EventArgs e)
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

        private void BackToHP_Click(object sender, EventArgs e)
        {
            SendMessage(this.Handle, WM_SETREDRAW, false, 0);

            UPF_HomePage UPF_SU = new UPF_HomePage();
            UPF_SU.Show();
            //Visible = false;

            SendMessage(this.Handle, WM_SETREDRAW, true, 0);
            this.Hide();
        }

        private void topPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void topPanel_MouseDown_2(object sender, MouseEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void addClientBtn_Click(object sender, EventArgs e)
        {
            int ZipCode = Int32.Parse(txt_ZipAddy.Text);
            DateTime SignUpDate = DateTime.Parse(dateTimePicker1.Text);
            InsertClient(new Client_Space()
            {
                FirstName = FirstNameTxt.Text,
                MiddleName = MiddleNameTxt.Text,
                LastName = LastNameTxt.Text,
                PhoneNumber = PhoneNumTxt.Text,
                HomeNumber = HomeNumTxt.Text,
                Email = EmailTxt.Text,
                StreetAddress = txt_StreetAddy.Text,
                State = StateComboBx.Text,
                City = txt_CityAddy.Text,
                PostalCode = ZipCode,
                Gender = GenderComboBx.Text,
                ClientType = ClientComboBx.Text,
                Location = LocationTxt.Text,
                SignUpDate = SignUpDate
            });

            MessageBox.Show("Successfully added to database!");
        }

        private void streetAddy_enter(object sender, EventArgs e)
        {
            if (txt_StreetAddy.Text == "Street Address")
            {
                txt_StreetAddy.ForeColor = Color.Black;
                txt_StreetAddy.Text = "";
            }

        }
        private void streetAddy_leave(object sender, EventArgs e)
        {
            if (txt_StreetAddy.Text.Length == 0)
            {
                txt_StreetAddy.ForeColor = Color.Black;
                txt_StreetAddy.Text = "Street Address";
            }

        }
        private void cityAddy_enter(object sender, EventArgs e)
        {
            if (txt_CityAddy.Text == "City")
            {
                txt_CityAddy.ForeColor = Color.Black;
                txt_CityAddy.Text = "";
            }
        }

        private void cityAddy_Leave(object sender, EventArgs e)
        {
            if (txt_CityAddy.Text.Length == 0)
            {
                txt_CityAddy.ForeColor = Color.Black;
                txt_CityAddy.Text = "City";
            }
        }

        private void zipAddy_enter(object sender, EventArgs e)
        {
            if (txt_ZipAddy.Text == "ZIP Code")
            {
                txt_ZipAddy.ForeColor = Color.Black;
                txt_ZipAddy.Text = "";
            }
        }

        private void zipAddy_leave(object sender, EventArgs e)
        {
            if (txt_ZipAddy.Text.Length == 0)
            {
                txt_ZipAddy.ForeColor = Color.Black;
                txt_ZipAddy.Text = "ZIP Code";
            }
        }

        private void MiddleNameTxt_TextChanged(object sender, EventArgs e)
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