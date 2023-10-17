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
    public partial class TKDSchedule : Form
    {
        private string sqlConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=upf_app;";

        private string lastQuery;
        private string lastQuery2;
        private string lastQuery3;
        private string oldClassValue;
        private int tempID = 0;
        private MySqlDataAdapter Sda;
        private DataSet ds;
        private MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=upf_app;");
        List<Test_Ready> Students_Checklist = new List<Test_Ready>();
        List<Push_Yes> Push_Yes = new List<Push_Yes>();
        List<TKD_Schedule_Info> client = new List<TKD_Schedule_Info>();
        List<TKD_Schedule_Info> clientAdd = new List<TKD_Schedule_Info>();
        List<Class_Progress_Info> classTrackIDs = new List<Class_Progress_Info>();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;

        //Round edges variables
        //[DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        public TKDSchedule()
        {
            InitializeComponent();
            displayGrid();
            checkReadiness();
            //initReadyColoumn();
        }

        private void checkReadiness()
        {
            int i = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                //MessageBox.Show("Name:" + client[i].FirstName + " Ready: " + client[i].FormsRdy + " " + client[i].HandAtksRdy + " " + client[i].BlocksRdy + " " + client[i].KicksRdy);

                if (isReady(int.Parse(row.Cells[0].Value.ToString()), row.Cells[5].Value.ToString()))
                {
                    client[i].Ready = pushYesToDB(client[i].ClientID); ;
                    row.Cells[6].Value = client[i].Ready;
                }
                else
                {
                    pushNoToDB(client[i].ClientID);
                    client[i].Ready = getReadyFromDB(client[i].ClientID); ;
                    row.Cells[6].Value = client[i].Ready;
                }
                /*MessageBox.Show(client[i].Ready);*/
                Students_Checklist.Clear();
                //Push_Yes.Clear();
                i++;
                //string temp = row.Cells[6].Value.ToString();
                //MessageBox.Show(temp);
            }
            dataGridView1.DataSource = client;
        }

        private String pushYesToDB(int clientID)
        {
            lastQuery = "UPDATE `tkd_schedule_info` SET `Ready`= 'Yes' WHERE ClientID = " + clientID;
            using (var connection = new MySqlConnection(sqlConnectionString))
            {
                connection.Open();
                Push_Yes = connection.Query<Push_Yes>(lastQuery).ToList();
                //MessageBox.Show("clientID: " + clientID + " || " + Push_Yes.Count.ToString());
                //MessageBox.Show();
                connection.Close();
            }

            return "Yes";//Push_Yes[0].PushYes;
        }

        private void pushNoToDB(int clientID)
        {
            lastQuery = "UPDATE `tkd_schedule_info` SET `Ready`= 'No' WHERE ClientID = " + clientID;
            using (var connection = new MySqlConnection(sqlConnectionString))
            {
                connection.Open();
                Push_Yes = connection.Query<Push_Yes>(lastQuery).ToList();
                //MessageBox.Show("clientID: " + clientID + " || " + Push_Yes.Count.ToString());
                //MessageBox.Show();
                connection.Close();
            }

            //return "Yes";//Push_Yes[0].PushYes;
        }

        private String getReadyFromDB(int clientID)
        {
            lastQuery = "Select Ready FROM tkd_schedule_info WHERE ClientID = " + clientID;
            using (var connection = new MySqlConnection(sqlConnectionString))
            {
                connection.Open();
                Push_Yes = connection.Query<Push_Yes>(lastQuery).ToList();
                //MessageBox.Show("clientID: " + clientID + " || " + Push_Yes.Count.ToString());
                connection.Close();
            }

            return "No";//Push_Yes[0].PushYes;
        }

        private bool isReady(int clientID, string classTKD)
        {
            if(classTKD == "Lil-Tiger")
                lastQuery = "Select FormsRdy, HandAtksRdy, KicksRdy, BlocksRdy FROM lil_test_ready WHERE ClientID = " + clientID;
            else if(classTKD == "Beginner")
                lastQuery = "Select FormsRdy, HandAtksRdy, KicksRdy, BlocksRdy FROM beg_test_ready WHERE ClientID = " + clientID;
            else if(classTKD == "Advanced")
                lastQuery = "Select FormsRdy, HandAtksRdy, KicksRdy, BlocksRdy FROM adv_test_ready WHERE ClientID = " + clientID;

            using (var connection = new MySqlConnection(sqlConnectionString))
            {
                connection.Open();
                Students_Checklist = connection.Query<Test_Ready>(lastQuery).ToList();
                connection.Close();
            }

            if (Students_Checklist.Count > 0)
            {
                if (Students_Checklist[0].FormsRdy == 0 || Students_Checklist[0].HandAtksRdy == 0 || Students_Checklist[0].BlocksRdy == 0 || Students_Checklist[0].KicksRdy == 0)
                    return false;
            }
            return true;
        }
        private void displayGrid()
        {
            //dataGridView1.ColumnCount = 6;
            //dataGridView1.Columns[0].Name = "ClientID";
            //dataGridView1.Columns[1].Name = "FirstName";
            //dataGridView1.Columns[2].Name = "LastName";
            //dataGridView1.Columns[3].Name = "Age";
            //dataGridView1.Columns[4].Name = "BeltLvl";
            //dataGridView1.Columns[5].Name = "Class";
            //dataGridView1.AutoGenerateColumns = true;
            lastQuery = "Select tkd_schedule_info.ClientID, FirstName, LastName, Age, tkd_schedule_info.BeltLvl, Class, Ready, lil_test_ready.FormsRdy, lil_test_ready.HandAtksRdy, lil_test_ready.KicksRdy, lil_test_ready.BlocksRdy " +
                "FROM tkd_schedule_info, lil_test_ready WHERE tkd_schedule_info.ClientID = lil_test_ready.ClientID";
            lastQuery2 = "Select tkd_schedule_info.ClientID, FirstName, LastName, Age, tkd_schedule_info.BeltLvl, Class, Ready, beg_test_ready.FormsRdy, beg_test_ready.HandAtksRdy, beg_test_ready.KicksRdy, beg_test_ready.BlocksRdy " +
                "FROM tkd_schedule_info, beg_test_ready WHERE tkd_schedule_info.ClientID = beg_test_ready.ClientID";
            lastQuery3 = "Select tkd_schedule_info.ClientID, FirstName, LastName, Age, tkd_schedule_info.BeltLvl, Class, Ready, adv_test_ready.FormsRdy, adv_test_ready.HandAtksRdy, adv_test_ready.KicksRdy, adv_test_ready.BlocksRdy " +
                "FROM tkd_schedule_info, adv_test_ready WHERE tkd_schedule_info.ClientID = adv_test_ready.ClientID";
            /*//"Select ClientID, FirstName, LastName, Age, BeltLvl, Class, Ready, FormsRdy, HandAtksRdy, KicksRdy, BlocksRdy FROM tkd_schedule_info, lil_test_rdy";  //"SELECT * FROM tkd_schedule_info";
            dataGridView1.ColumnCount = 11;
            dataGridView1.ColumnHeadersVisible = true;

            // Set the column header style.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            dataGridView1.Columns[0].Name = "ClientID";
            dataGridView1.Columns[1].Name = "FirstName";
            dataGridView1.Columns[2].Name = "LastName";
            dataGridView1.Columns[3].Name = "Age";
            dataGridView1.Columns[4].Name = "BeltLvl";
            dataGridView1.Columns[5].Name = "Class";
            dataGridView1.Columns[6].Name = "Ready";
            dataGridView1.Columns[7].Name = "FormsRdy";
            dataGridView1.Columns[8].Name = "HandAtksRdy";
            dataGridView1.Columns[9].Name = "KicksRdy";
            dataGridView1.Columns[10].Name = "BlocksRdy";*/


            using (var connection = new MySqlConnection(sqlConnectionString))
            {
                connection.Open();
                client = connection.Query<TKD_Schedule_Info>(lastQuery).ToList();
                //client[0].Ready = "Yes";
                //dataGridView1.Rows.Add(client);

                clientAdd = connection.Query<TKD_Schedule_Info>(lastQuery2).ToList();

                for(int i = 0; i < clientAdd.Count; i++)
                    client.Add(clientAdd[i]);

                clientAdd = connection.Query<TKD_Schedule_Info>(lastQuery3).ToList();

                for (int i = 0; i < clientAdd.Count; i++)
                    client.Add(clientAdd[i]);

                dataGridView1.DataSource = client;

                connection.Close();
            }

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
                dataGridView1.Columns[i].ReadOnly = true;
                dataGridView1.Columns[5].ReadOnly = false;
            //dataGridView1.Columns[7].ReadOnly = false;
            //dataGridView1.Columns[8].ReadOnly = false;
            //dataGridView1.Columns[9].ReadOnly = false;
            //dataGridView1.Columns[10].ReadOnly = false;
            //initReadyColoumn();
        }

        private void BackToAdd_Click(object sender, EventArgs e)
        {
            SendMessage(this.Handle, WM_SETREDRAW, false, 0);

            UPF_HomePage UPF_SU = new UPF_HomePage();
            UPF_SU.Show();
            //Visible = false;

            SendMessage(this.Handle, WM_SETREDRAW, true, 0);
            this.Hide();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            displayClass("Lil-Tiger");
            checkReadiness();
        }

        private void displayClass(String className)
        {
            dataGridView1.Columns.Clear();
            lastQuery = "Select tkd_schedule_info.ClientID, FirstName, LastName, Age, tkd_schedule_info.BeltLvl, Class, Ready, lil_test_ready.FormsRdy, lil_test_ready.HandAtksRdy, lil_test_ready.KicksRdy, lil_test_ready.BlocksRdy " +
                "FROM tkd_schedule_info, lil_test_ready WHERE tkd_schedule_info.Class = '" + className + "' AND tkd_schedule_info.ClientID = lil_test_ready.ClientID";

            // lastQuery = "SELECT ClientID, FirstName, LastName, Age, BeltLvl, Class from tkd_schedule_info WHERE Class = '" + className + "'";
            using (var connection = new MySqlConnection(sqlConnectionString))
            {
                connection.Open();
                client = connection.Query<TKD_Schedule_Info>(lastQuery).ToList();
                //client[0].Ready = "Yes";
                //dataGridView1.Rows.Add(client);


                dataGridView1.DataSource = client;

                connection.Close();
            }

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            { 
                dataGridView1.Columns[i].ReadOnly = true;
            dataGridView1.Columns[5].ReadOnly = false;
            //dataGridView1.Columns[7].ReadOnly = false;
            //dataGridView1.Columns[8].ReadOnly = false;
            //dataGridView1.Columns[9].ReadOnly = false;
            //dataGridView1.Columns[10].ReadOnly = false;
            //initReadyColoumn();
        }
    }

        private void button1_Click(object sender, EventArgs e)
        {
            displayClass("Beginner");
            checkReadiness();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            displayClass("Advanced");
            checkReadiness();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        /**
         * TODO: 
         *      1) check every student class rescedule deletes and inserts into corresponding DB 
         *      2) Check login behind updating YES/NO to datagrid and updating DB table
         *      3) On Review button in ClassInProgress FORM update NO to DB table and revert boolean value on readiness back to 0
         * 
         */
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int tempFormRdy;
            int tempBlockRdy;
            int tempHandAtksRdy;
            int tempKicksRdy;
            //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            if (dataGridView1.Columns[e.ColumnIndex].Index == 5)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Lil-Tiger") ||
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Beginner") ||
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Advanced"))
                {
                    //MessageBox.Show(oldClassValue);
                    try
                    {
                        if (MessageBox.Show("Change class of " + dataGridView1.CurrentRow.Cells["FirstName"].Value + " " + dataGridView1.CurrentRow.Cells["LastName"].Value, "Do you want to move " +
                            dataGridView1.CurrentRow.Cells["FirstName"].Value + " " + dataGridView1.CurrentRow.Cells["LastName"].Value + " from '" + oldClassValue + "' to '" + dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()
                            + "class?", MessageBoxButtons.YesNo) == DialogResult.Yes)

                        {
                            tempID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ClientID"].Value);
                            MessageBox.Show(tempID.ToString());
                            if (oldClassValue.Equals("Lil-Tiger") && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Beginner"))
                            {

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    lastQuery = "UPDATE tkd_schedule_info SET " + dataGridView1.Columns[e.ColumnIndex].Name + " = '"
                                    + dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + "' WHERE ClientID = " + dataGridView1.CurrentRow.Cells["ClientID"].Value;
                                    client = connection.Query<TKD_Schedule_Info>(lastQuery).ToList();

                                    lastQuery = "SELECT FormsTID, HandAtksTID, KicksTID, BlocksTID FROM `lil_tkd_belttest_progress` WHERE ClientID = " + dataGridView1.CurrentRow.Cells["ClientID"].Value;
                                    classTrackIDs = connection.Query<Class_Progress_Info>(lastQuery).ToList();
                                    tempFormRdy = classTrackIDs[0].FormsTID;
                                    tempBlockRdy = classTrackIDs[0].BlocksTID;
                                    tempHandAtksRdy = classTrackIDs[0].HandAtksTID;
                                    tempKicksRdy = classTrackIDs[0].KicksTID;
                                    
                                    lastQuery = "DELETE FROM lil_tkd_belttest_progress WHERE ClientID = " + dataGridView1.CurrentRow.Cells["ClientID"].Value;
                                    client = connection.Query<TKD_Schedule_Info>(lastQuery).ToList();

                                    lastQuery = "INSERT INTO beg_tkd_belttest_progress (ClientID, BeltLvl, Present, FormsTID, HandAtksTID, KicksTID, BlocksTID) VALUES (" + dataGridView1.CurrentRow.Cells["ClientID"].Value + ", '" +
                                    dataGridView1.CurrentRow.Cells["BeltLvl"].Value + "', 0, " + tempFormRdy + ", " + tempBlockRdy + ", " + tempHandAtksRdy + ", " + tempKicksRdy + ")";
                                    client = connection.Query<TKD_Schedule_Info>(lastQuery).ToList();
                                    dataGridView1.DataSource = client;


                                    connection.Close();
                                }
                                testReadyClassChange("lil_test_ready", "beg_test_ready", tempID);
                                deleteTestReady("lil_test_ready", tempID);
                            }
                            else if (oldClassValue.Equals("Lil-Tiger") && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Advanced"))
                            {
                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    lastQuery = "UPDATE tkd_schedule_info SET " + dataGridView1.Columns[e.ColumnIndex].Name + " = '"
                                    + dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + "' WHERE ClientID = " + dataGridView1.CurrentRow.Cells["ClientID"].Value;
                                    client = connection.Query<TKD_Schedule_Info>(lastQuery).ToList();

                                    lastQuery = "SELECT FormsTID, HandAtksTID, KicksTID, BlocksTID FROM `lil_tkd_belttest_progress` WHERE ClientID = " + dataGridView1.CurrentRow.Cells["ClientID"].Value;
                                    classTrackIDs = connection.Query<Class_Progress_Info>(lastQuery).ToList();
                                    tempFormRdy = classTrackIDs[0].FormsTID;
                                    tempBlockRdy = classTrackIDs[0].BlocksTID;
                                    tempHandAtksRdy = classTrackIDs[0].HandAtksTID;
                                    tempKicksRdy = classTrackIDs[0].KicksTID;

                                    lastQuery = "DELETE FROM lil_tkd_belttest_progress WHERE ClientID = " + dataGridView1.CurrentRow.Cells["ClientID"].Value;
                                    client = connection.Query<TKD_Schedule_Info>(lastQuery).ToList();

                                    lastQuery = "INSERT INTO adv_tkd_belttest_progress (ClientID, BeltLvl, Present, FormsTID, HandAtksTID, KicksTID, BlocksTID) VALUES (" + dataGridView1.CurrentRow.Cells["ClientID"].Value + ", '" +
                                    dataGridView1.CurrentRow.Cells["BeltLvl"].Value + "', 0, " + tempFormRdy + ", " + tempBlockRdy + ", " + tempHandAtksRdy + ", " + tempKicksRdy + ")";
                                    client = connection.Query<TKD_Schedule_Info>(lastQuery).ToList();
                                    dataGridView1.DataSource = client;
                                    connection.Close();
                                }
                                testReadyClassChange("lil_test_ready", "adv_test_ready", tempID);
                                deleteTestReady("lil_test_ready", tempID);
                            }
                            else if (oldClassValue.Equals("Beginner") && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Advanced"))
                            {
                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    lastQuery = "UPDATE tkd_schedule_info SET " + dataGridView1.Columns[e.ColumnIndex].Name + " = '"
                                    + dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + "' WHERE ClientID = " + dataGridView1.CurrentRow.Cells["ClientID"].Value;
                                    client = connection.Query<TKD_Schedule_Info>(lastQuery).ToList();

                                    lastQuery = "SELECT FormsTID, HandAtksTID, KicksTID, BlocksTID FROM `beg_tkd_belttest_progress` WHERE ClientID = " + dataGridView1.CurrentRow.Cells["ClientID"].Value;
                                    classTrackIDs = connection.Query<Class_Progress_Info>(lastQuery).ToList();
                                    tempFormRdy = classTrackIDs[0].FormsTID;
                                    tempBlockRdy = classTrackIDs[0].BlocksTID;
                                    tempHandAtksRdy = classTrackIDs[0].HandAtksTID;
                                    tempKicksRdy = classTrackIDs[0].KicksTID;

                                    lastQuery = "DELETE FROM beg_tkd_belttest_progress WHERE ClientID = " + dataGridView1.CurrentRow.Cells["ClientID"].Value;
                                    client = connection.Query<TKD_Schedule_Info>(lastQuery).ToList();

                                    lastQuery = "INSERT INTO adv_tkd_belttest_progress (ClientID, BeltLvl, Present, FormsTID, HandAtksTID, KicksTID, BlocksTID) VALUES (" + dataGridView1.CurrentRow.Cells["ClientID"].Value + ", '" +
                                    dataGridView1.CurrentRow.Cells["BeltLvl"].Value + "', 0, " + tempFormRdy + ", " + tempBlockRdy + ", " + tempHandAtksRdy + ", " + tempKicksRdy + ")";
                                    client = connection.Query<TKD_Schedule_Info>(lastQuery).ToList();
                                    dataGridView1.DataSource = client;
                                    connection.Close();
                                }
                                testReadyClassChange("beg_test_ready", "adv_test_ready", tempID);
                                deleteTestReady("beg_test_ready", tempID);
                            }
                            else if (oldClassValue.Equals("Advanced") && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Beginner"))
                            {
                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    lastQuery = "UPDATE tkd_schedule_info SET " + dataGridView1.Columns[e.ColumnIndex].Name + " = '"
                                    + dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + "' WHERE ClientID = " + dataGridView1.CurrentRow.Cells["ClientID"].Value;
                                    client = connection.Query<TKD_Schedule_Info>(lastQuery).ToList();

                                    lastQuery = "SELECT FormsTID, HandAtksTID, KicksTID, BlocksTID FROM `adv_tkd_belttest_progress` WHERE ClientID = " + dataGridView1.CurrentRow.Cells["ClientID"].Value;
                                    classTrackIDs = connection.Query<Class_Progress_Info>(lastQuery).ToList();
                                    tempFormRdy = classTrackIDs[0].FormsTID;
                                    tempBlockRdy = classTrackIDs[0].BlocksTID;
                                    tempHandAtksRdy = classTrackIDs[0].HandAtksTID;
                                    tempKicksRdy = classTrackIDs[0].KicksTID;

                                    lastQuery = "DELETE FROM adv_tkd_belttest_progress WHERE ClientID = " + dataGridView1.CurrentRow.Cells["ClientID"].Value;
                                    client = connection.Query<TKD_Schedule_Info>(lastQuery).ToList();
                                    lastQuery = "INSERT INTO beg_tkd_belttest_progress (ClientID, BeltLvl, Present, FormsTID, HandAtksTID, KicksTID, BlocksTID) VALUES (" + dataGridView1.CurrentRow.Cells["ClientID"].Value + ", '" +
                                    dataGridView1.CurrentRow.Cells["BeltLvl"].Value + "', 0, " + tempFormRdy + ", " + tempBlockRdy + ", " + tempHandAtksRdy + ", " + tempKicksRdy + ")";
                                    client = connection.Query<TKD_Schedule_Info>(lastQuery).ToList();
                                    dataGridView1.DataSource = client;
                                    connection.Close();
                                }
                                testReadyClassChange("adv_test_ready", "beg_test_ready", tempID);
                                deleteTestReady("adv_test_ready", tempID);
                            }
                            else if (oldClassValue.Equals("Advanced") && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Lil-Tiger"))
                                MessageBox.Show("Client cannot be demoted from an 'Advanced' to a 'Lil-Tiger' class. Seek administrative help for further help.");

                            else if (oldClassValue.Equals("Beginner") && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Lil-Tiger"))
                            {
                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    lastQuery = "UPDATE tkd_schedule_info SET " + dataGridView1.Columns[e.ColumnIndex].Name + " = '"
                                    + dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + "' WHERE ClientID = " + dataGridView1.CurrentRow.Cells["ClientID"].Value;
                                    client = connection.Query<TKD_Schedule_Info>(lastQuery).ToList();

                                    lastQuery = "SELECT FormsTID, HandAtksTID, KicksTID, BlocksTID FROM `beg_tkd_belttest_progress` WHERE ClientID = " + dataGridView1.CurrentRow.Cells["ClientID"].Value;
                                    classTrackIDs = connection.Query<Class_Progress_Info>(lastQuery).ToList();
                                    tempFormRdy = classTrackIDs[0].FormsTID;
                                    tempBlockRdy = classTrackIDs[0].BlocksTID;
                                    tempHandAtksRdy = classTrackIDs[0].HandAtksTID;
                                    tempKicksRdy = classTrackIDs[0].KicksTID;
                                    MessageBox.Show("Rdy: " + tempFormRdy + tempBlockRdy + tempHandAtksRdy + tempKicksRdy);

                                    lastQuery = "DELETE FROM beg_tkd_belttest_progress WHERE ClientID = " + dataGridView1.CurrentRow.Cells["ClientID"].Value;
                                    client = connection.Query<TKD_Schedule_Info>(lastQuery).ToList();

                                    

                                    lastQuery = "INSERT INTO lil_tkd_belttest_progress (ClientID, BeltLvl, Present, FormsTID, HandAtksTID, KicksTID, BlocksTID) VALUES (" + dataGridView1.CurrentRow.Cells["ClientID"].Value + ", '" +
                                    dataGridView1.CurrentRow.Cells["BeltLvl"].Value + "', 0, " + tempFormRdy + ", " + tempBlockRdy + ", " + tempHandAtksRdy + ", " + tempKicksRdy + ")";
                                    client = connection.Query<TKD_Schedule_Info>(lastQuery).ToList();
                                    dataGridView1.DataSource = client;
                                    connection.Close();
                                }
                                testReadyClassChange("beg_test_ready", "lil_test_ready", tempID);
                                deleteTestReady("beg_test_ready", tempID);
                                //MessageBox.Show("Client cannot be demoted from an 'Beginner' to a 'Lil-Tiger' class. Seek administrative help for further help.");
                            }
                            else if (oldClassValue.Equals(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                                MessageBox.Show("No class value has been changed.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
                else
                {
                    MessageBox.Show("Please Enter a Valid Class (Example: 'Lil-Tiger' 'Beginner' 'Advanced'");
                }
            } 
            displayGrid();
        }

        private void testReadyClassChange(String oldClass, String databaseTable, int clientID)
        {
            int tempFormRdy;
            int tempBlockRdy;
            int tempHandAtksRdy;
            int tempKicksRdy;
            using (var connection = new MySqlConnection(sqlConnectionString))
            {
                connection.Open();

                lastQuery = "SELECT FormsRdy, HandAtksRdy, KicksRdy, BlocksRdy FROM " + oldClass + " WHERE ClientID = " + clientID;
                client = connection.Query<TKD_Schedule_Info>(lastQuery).ToList();
                tempFormRdy = client[0].FormsRdy;
                tempBlockRdy = client[0].BlocksRdy;
                tempHandAtksRdy = client[0].HandAtksRdy;
                tempKicksRdy = client[0].KicksRdy;
                //MessageBox.Show("Rdy: " + tempFormRdy + tempBlockRdy + tempHandAtksRdy + tempKicksRdy);


                lastQuery = "INSERT INTO `" + databaseTable + "` (`ClientID`, `FormsRdy`, `HandAtksRdy`, `KicksRdy`, `BlocksRdy`) VALUES ( " + clientID + ", "+ tempFormRdy + ", " + tempHandAtksRdy + ", " + tempKicksRdy + ", " + tempBlockRdy + ")";
                connection.Query<Change_Test_Ready>(lastQuery);
                connection.Close();
            }
        }

        private void deleteTestReady(String databaseTable, int clientID)
        {
            using (var connection = new MySqlConnection(sqlConnectionString))
            {
                connection.Open();
                lastQuery = "DELETE FROM " + databaseTable + " WHERE ClientID = " + clientID;
                connection.Query<Change_Test_Ready>(lastQuery);
                connection.Close();
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            oldClassValue = (string)dataGridView1[e.ColumnIndex, e.RowIndex].Value;
        }
    }
}
