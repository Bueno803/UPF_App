using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UPF_App.Persistence.Domain;

namespace UPF_App
{
    public partial class StartClass : Form
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private char classState = 'N';
        private const int WM_SETREDRAW = 11;

        private string sqlConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=upf_app;";
        private int intState = 0;
        private string lastQuery;

   
        public StartClass()
        {
            InitializeComponent();
            InitializeLocComboBox();
            //dataGridView1.Columns[0].ReadOnly = true;

        }

        private void InitializeLocComboBox()
        {
            List<Location_Addition> LocationList = new List<Location_Addition>();

            using (var connection = new MySqlConnection(sqlConnectionString))
            {
                connection.Open();
                LocationList = connection.Query<Location_Addition>("SELECT * FROM `upf_locations` WHERE 1").ToList();
                //dataGridView1.DataSource = LocationList;
                connection.Close();
            }
            LocBox.Items.Add("All");
            foreach (var e in LocationList)
            {
                //MessageBox.Show(e.LocationName);
                LocBox.Items.Add(e.LocationName);
            }
            LocBox.SelectedIndex = 0;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StartClass_Load(object sender, EventArgs e)
        {

        }

        private void LilTigers_Click(object sender, EventArgs e)
        {
            classState = 'L';
            displayLilTigers();
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;

        }

        private void displayLilTigers()
        {
            intState = 1;
            if (LocBox.Text != "All")
            {
                lastQuery =
                    "SELECT client_space.ClientID, client_space.FirstName, client_space.LastName, Present " +
                    "FROM lil_tkd_belttest_progress, client_space " +
                    "Where lil_tkd_belttest_progress.ClientID = client_space.ClientID " +
                    "AND Location = '" + LocBox.Text + "'";
                filterSearch();
            } 
            else if (LocBox.Text == "All")
            {
                lastQuery =
                "SELECT lil_tkd_belttest_progress.ClientID, FirstName, LastName, Present " +
                "FROM lil_tkd_belttest_progress, tkd_schedule_info " +
                "Where lil_tkd_belttest_progress.ClientID = tkd_schedule_info.ClientID";
                filterSearch();
            }
        }

        private void displayBeginners()
        {
            intState = 2;
            if (LocBox.Text != "All")
            {
                lastQuery =
                    "SELECT client_space.ClientID, client_space.FirstName, client_space.LastName, Present " +
                    "FROM beg_tkd_belttest_progress, client_space " +
                    "Where beg_tkd_belttest_progress.ClientID = client_space.ClientID " +
                    "AND Location = '" + LocBox.Text + "'";
                filterSearch();
            }
            else if (LocBox.Text == "All")
            {
                lastQuery =
                "SELECT beg_tkd_belttest_progress.ClientID, FirstName, LastName, Present " +
                "FROM beg_tkd_belttest_progress, tkd_schedule_info " +
                "Where beg_tkd_belttest_progress.ClientID = tkd_schedule_info.ClientID";
                filterSearch();
            }
        }

        private void displayAdvanced()
        {
            intState = 3;
            if (LocBox.Text != "All")
            {
                lastQuery =
                    "SELECT client_space.ClientID, client_space.FirstName, client_space.LastName, Present " +
                    "FROM adv_tkd_belttest_progress, client_space " +
                    "Where adv_tkd_belttest_progress.ClientID = client_space.ClientID " +
                    "AND Location = '" + LocBox.Text + "'";
                filterSearch();
            }
            else if (LocBox.Text == "All")
            {
                lastQuery =
                "SELECT adv_tkd_belttest_progress.ClientID, FirstName, LastName, Present " +
                "FROM adv_tkd_belttest_progress, tkd_schedule_info " +
                "Where adv_tkd_belttest_progress.ClientID = tkd_schedule_info.ClientID";
                filterSearch();
            }
        }

        private void BackToAdd_Click(object sender, EventArgs e)
        {
            SendMessage(this.Handle, WM_SETREDRAW, false, 0);
            UPF_HomePage UPF_Home = new UPF_HomePage();
            UPF_Home.Show();

            SendMessage(this.Handle, WM_SETREDRAW, true, 0);
            this.Refresh();
            Hide();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            using (var connection = new MySqlConnection(sqlConnectionString))
            {

                string tkdClass = returnQuery("SELECT Class FROM tkd_schedule_info WHERE tkd_schedule_info.ClientID = " + dataGridView1.CurrentRow.Cells["ClientID"].Value);
                //lastQuery = "SELECT Class FROM tkd_schedule_info WHERE tkd_schedule_info.ClientID = " + dataGridView1.CurrentRow.Cells["ClientID"].Value;
                List<Lil_Roster_Check> clients = new List<Lil_Roster_Check>();
                
                //Test = connection.Query<Lil_Roster_Check>(lastQuery).ToString();

                if (tkdClass == "Lil-Tiger")
                {
                    try
                    {
                        if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.Equals(false))
                        {
                            lastQuery = "UPDATE lil_tkd_belttest_progress SET " + dataGridView1.Columns[e.ColumnIndex].Name + " = 0 WHERE ClientID = " + dataGridView1.CurrentRow.Cells["ClientID"].Value;
                        }
                        else
                        {
                            lastQuery = "UPDATE lil_tkd_belttest_progress SET " + dataGridView1.Columns[e.ColumnIndex].Name + " = 1 WHERE ClientID = " + dataGridView1.CurrentRow.Cells["ClientID"].Value;
                        }
                       
                            connection.Open();
                            clients = connection.Query<Lil_Roster_Check>(lastQuery).ToList();
                            dataGridView1.DataSource = clients;

                            //MessageBox.Show("Information Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            connection.Close();

                       

                        displayLilTigers();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (tkdClass == "Beginner")
                {
                    try
                    {
                        if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.Equals(false))
                        {
                            lastQuery = "UPDATE beg_tkd_belttest_progress SET " + dataGridView1.Columns[e.ColumnIndex].Name + " = 0 WHERE ClientID = " + dataGridView1.CurrentRow.Cells["ClientID"].Value;
                        }
                        else
                        {
                            lastQuery = "UPDATE beg_tkd_belttest_progress SET " + dataGridView1.Columns[e.ColumnIndex].Name + " = 1 WHERE ClientID = " + dataGridView1.CurrentRow.Cells["ClientID"].Value;
                        }
                        connection.Open();
                        clients = connection.Query<Lil_Roster_Check>(lastQuery).ToList();
                        dataGridView1.DataSource = clients;

                        //MessageBox.Show("Information Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connection.Close();

                        displayBeginners();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (tkdClass == "Advanced")
                {
                    try
                    {
                        if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.Equals(false))
                        {
                            lastQuery = "UPDATE adv_tkd_belttest_progress SET " + dataGridView1.Columns[e.ColumnIndex].Name + " = 0 WHERE ClientID = " + dataGridView1.CurrentRow.Cells["ClientID"].Value;
                        }
                        else
                        {
                            lastQuery = "UPDATE adv_tkd_belttest_progress SET " + dataGridView1.Columns[e.ColumnIndex].Name + " = 1 WHERE ClientID = " + dataGridView1.CurrentRow.Cells["ClientID"].Value;
                        }

                        connection.Open();
                        clients = connection.Query<Lil_Roster_Check>(lastQuery).ToList();
                        dataGridView1.DataSource = clients;

                        //MessageBox.Show("Information Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connection.Close();

                        
                        displayAdvanced();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            classState = 'B';
            displayBeginners();
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            classState = 'A';
            displayAdvanced();
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
        }

        private void ClearRoster_Click(object sender, EventArgs e)
        {
            clearLilRoster("Lil-Tiger");
        }

        private void clearLilRoster(String className)
        { 
            List<Client_Space> clients = new List<Client_Space>();
            using (var connection = new MySqlConnection(sqlConnectionString))
            {
                connection.Open();
                lastQuery = "UPDATE lil_tkd_belttest_progress SET Present = 0";
                clients = connection.Query<Client_Space>(lastQuery).ToList();

                lastQuery = "UPDATE beg_tkd_belttest_progress SET Present = 0";
                clients = connection.Query<Client_Space>(lastQuery).ToList();

                lastQuery = "UPDATE adv_tkd_belttest_progress SET Present = 0";
                clients = connection.Query<Client_Space>(lastQuery).ToList();
                dataGridView1.DataSource = clients;

                //MessageBox.Show("Information Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connection.Close();
            }
        }

        private string returnQuery(string Query)
        {
            string x;
            using (var connection = new MySqlConnection(sqlConnectionString))
            {
                
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(Query, connection);
                x = cmd.ExecuteScalar().ToString();
                connection.Close();
            }
            return x;
        }

        private void SearchByFirstNBtn_Click(object sender, EventArgs e)
        {
            if (classState == 'N')
            {
                MessageBox.Show("Please Select a class before starting one");
            }
            else
            {
                ClassInProgress UPF_CIP = new ClassInProgress();

                UPF_CIP.Show();
                UPF_CIP.classType(classState);
                //Visible = false;

                SendMessage(this.Handle, WM_SETREDRAW, true, 0);
                this.Hide();
            }
            
        }

        private void filterSearch()
        {
            List<Lil_Roster_Check> client = new List<Lil_Roster_Check>();
            using (var connection = new MySqlConnection(sqlConnectionString))
            {

                connection.Open();
                client = connection.Query<Lil_Roster_Check>(lastQuery).ToList();
                dataGridView1.DataSource = client;
                connection.Close();
            }
        }
    }
}
