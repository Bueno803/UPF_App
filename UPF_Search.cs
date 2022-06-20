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

        //Round edges variables
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

        private string lastQuery;
        private MySqlDataAdapter Sda;
        private DataSet ds;
        private MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=upf_app;");

        public UPF_Search()
        {
            InitializeComponent();
            displayGrid();
            //Applying rounded edges
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        //Drag top bar
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void BackToAdd_Click(object sender, EventArgs e)
        {
            //SendMessage(this.Handle, WM_SETREDRAW, false, 0);

            //Form1 UPF_SU = new Form1();
            //UPF_SU.Show();
            //Visible = false;

            //SendMessage(this.Handle, WM_SETREDRAW, true, 0);
            //this.Hide();

            SendMessage(this.Handle, WM_SETREDRAW, false, 0);

            UPF_HomePage UPF_SU = new UPF_HomePage();
            UPF_SU.Show();
            //Visible = false;

            SendMessage(this.Handle, WM_SETREDRAW, true, 0);
            this.Hide();
        }

        private void FirstNameTxt_TextChanged(object sender, EventArgs e)
        {

        }

        StringBuilder stringy(List<TextBox> textBox, int index)
        {
            StringBuilder query = new StringBuilder();
            if (textBox.ElementAt(index) == FirstNameTxt)
            {
                query.Append("FirstName='").Append(FirstNameTxt.Text);
            }

            else if (textBox.ElementAt(index) == LastNameTxt)
            {
                query.Append("LastName='").Append(LastNameTxt.Text);
            }

            else if (textBox.ElementAt(index) == PhoneNumTxt)
            {
                query.Append("PhoneNumber='").Append(PhoneNumTxt.Text);
            }

            else if (textBox.ElementAt(index) == MiddleNameTxt)
            {
                query.Append("Location='").Append(MiddleNameTxt.Text);
            }

            if (textBox.Last() != textBox.ElementAt(index))
                query.Append("' and ");

            return query;

        }

        private string queryBuilder()
        {
            StringBuilder builder = new StringBuilder();
            var textBoxCollection = new List<TextBox>() { FirstNameTxt, LastNameTxt, PhoneNumTxt, MiddleNameTxt };
            textBoxCollection = textBoxCollection.Where(s => !string.IsNullOrWhiteSpace(s.Text)).Distinct().ToList();

            for (int i = 0;i < textBoxCollection.Count; i++)
            
                builder.Append(stringy(textBoxCollection, i));
            

            return builder.ToString();
        }
        // TODO when we make the one search button, set a 
        //Search by First Name
        private void SearchByFNBtn_Click(object sender, EventArgs e)
        {
            displayGrid();
        }


        //Search by Last Name
        private void SearchByLNBtn_Click(object sender, EventArgs e)
        {
            

        }
        // Search by phone number
        private void SearchByPN_Click(object sender, EventArgs e)
        {
            if (FirstNameTxt.Text != "")
                GetClients(FirstNameTxt.Text, "FirstName");
            if (LastNameTxt.Text != "")
                GetClients(LastNameTxt.Text, "LastName");
            if (PhoneNumTxt.Text != "")
                GetClients(PhoneNumTxt.Text, "PhoneNumber");
            if (MiddleNameTxt.Text != "")
                GetClients(MiddleNameTxt.Text, "Location");
        }
        // Search by location
        private void SearchByL_Click(object sender, EventArgs e)
        {
            
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
                    DeleteClient(new Client_Space() { ClientID = clientID });
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //This method deletes a client record from database    
        private int DeleteClient(Client_Space client)
        {
            using (var connection = new MySqlConnection(sqlConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute("Delete from Client_Space Where ClientID = @ClientID", new { ClientID = client.ClientID });
                GetLastClients();
                connection.Close();
                MessageBox.Show("Delete Successful!");
                return affectedRows;
            }
        }

        // This method searches the database depending on which method 
        private List<Client_Space> GetClients(string query, string column)
        {
            lastQuery =
                "Select ClientID, FirstName, MiddleName, LastName, PhoneNumber, HomeNumber, Email, StreetAddress, State, City, PostalCode, Gender," +
                " ClientType, Location, SignUpDate from Client_Space where " + queryBuilder() + "'";
            List<Client_Space> clients = new List<Client_Space>();
            using (var connection = new MySqlConnection(sqlConnectionString))
            {
                connection.Open();
                clients = connection.Query<Client_Space>(lastQuery).ToList();
                dataGridView1.DataSource = clients;
                connection.Close();
            }
            return clients;
        }

        private List<Client_Space> GetLastClients()
        {
            List<Client_Space> clients = new List<Client_Space>();
            using (var connection = new MySqlConnection(sqlConnectionString))
            {
                clients = connection.Query<Client_Space>(lastQuery).ToList();
                dataGridView1.DataSource = clients;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void topPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void topPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void label10_Click(object sender, EventArgs e)
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
            if (FirstNameTxt.Text != "")
                GetClients(FirstNameTxt.Text, "FirstName");
            if (LastNameTxt.Text != "")
                GetClients(LastNameTxt.Text, "LastName");
            if (PhoneNumTxt.Text != "")
                GetClients(PhoneNumTxt.Text, "PhoneNumber");
            if (MiddleNameTxt.Text != "")
                GetClients(MiddleNameTxt.Text, "Location");
        }

        private void displayGrid()
        {
            lastQuery = "SELECT * FROM Client_Space";
            List<Client_Space> clients = new List<Client_Space>();
            using (var connection = new MySqlConnection(sqlConnectionString))
            {
                connection.Open();
                clients = connection.Query<Client_Space>(lastQuery).ToList();
                dataGridView1.DataSource = clients;
                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Change Row Value?", "Do you want to save the changes?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    //MessageBox.Show(dataGridView1.CurrentRow.Cells["ClientID"].Value.ToString());
                    lastQuery = "UPDATE Client_Space SET " + dataGridView1.Columns[e.ColumnIndex].Name + " = '"
                        + dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + "' WHERE ClientID = " + dataGridView1.CurrentRow.Cells["ClientID"].Value;
                    List<Client_Space> clients = new List<Client_Space>();
                    using (con)
                    {
                        con.Open();
                        clients = con.Query<Client_Space>(lastQuery).ToList();
                        dataGridView1.DataSource = clients;

                        //MessageBox.Show("Information Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                catch(Exception ex)
                {
                   MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No changes have been submited");
            }
            displayGrid();
            
        }
    }
}