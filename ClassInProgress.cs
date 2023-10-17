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
    public partial class ClassInProgress : Form
    {
        private string className = "None";
        private int firstStudentIndex;
        private int secondStudentIndex;
        private int thirdStudentIndex;
        private int pageIndex = 0;
       /* private int storeCurrentMean = 0;*/
        private String[] pages = new String[] { "Forms", "Blocks", "Hand Attacks", "Kicks" };
        
        List<Class_Progress_Info> presentStudents = new List<Class_Progress_Info>();
        List<Class_Progress_Info> students = new List<Class_Progress_Info>();
        List<Belt_Requirement> BeltCheck = new List<Belt_Requirement>();
        List<Test_Ready> TestReady = new List<Test_Ready>();
        List<Date_Time_Storage> DateTimeStorage = new List<Date_Time_Storage>();

        List<Student_Info_Forms> MeaningForms = new List<Student_Info_Forms>(); 
        List<Student_Info_Blocks> MeaningBlocks = new List<Student_Info_Blocks>();
        List<Student_Info_HandAttacks> MeaningHandAtks = new List<Student_Info_HandAttacks>();
        List<Student_Info_Kicks> MeaningKicks = new List<Student_Info_Kicks>();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;

        //List<>
        //List<ClassInProgress> clients = new List<ClassInProgress>();
        private string lastQuery;
        private string lastQuery2;
        private string lastQuery3;
        private string sqlConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=upf_app;";
        public ClassInProgress()
        {
            InitializeComponent();
            StudentLbl.MaximumSize = new Size(125, 0);
            StudentLbl.AutoSize = true;
            StudentLbl2.MaximumSize = new Size(125, 0);
            StudentLbl2.AutoSize = true;
            StudentLbl3.MaximumSize = new Size(125, 0);
            StudentLbl3.AutoSize = true;
            PageLbl.MaximumSize = new Size(125, 0);
            PageLbl.AutoSize = true;
        }

        public void classType(char classAcro)
        {
            //MessageBox.Show(classAcro.ToString());
            if (classAcro.Equals('L'))
            {
                className = "Lil-Tiger";
                setClassDateTime(className);
            }
            else if (classAcro.Equals('B'))
            {
                className = "Beginner";
                setClassDateTime(className);
            }
            else if (classAcro.Equals('A'))
            {
                className = "Advanced";
                setClassDateTime(className);
            }
                
            else
                className = "Error, No";
            initializeClass();
        }

        public void setClassDateTime(string aClassName)
        {
            lastQuery =
                "SELECT DateTime, Page FROM last_class_time_stamp WHERE Class = '" + aClassName + "'";

            using (var connection = new MySqlConnection(sqlConnectionString))
            {
                connection.Open();
                DateTimeStorage = connection.Query<Date_Time_Storage>(lastQuery).ToList();
                //dataGridView1.DataSource = clients;
                connection.Close();
            }

            DateAndTime.Text = DateTimeStorage[0].DateTime;
            ClassAndPage.Text = "Last Class Page: " + DateTimeStorage[0].Page;
        }

        public void initializeClass()
        {
            /*MessageBox.Show(className);*/

            lastQuery =
                "SELECT tkd_schedule_info.ClientID, FirstName, LastName, Present, tkd_schedule_info.BeltLvl, FormsTID, HandAtksTID, KicksTID, BlocksTID " +
               "FROM lil_tkd_belttest_progress, tkd_schedule_info " +
               "Where lil_tkd_belttest_progress.ClientID = tkd_schedule_info.ClientID";

               lastQuery2 =
              "SELECT tkd_schedule_info.ClientID, FirstName, LastName, Present, tkd_schedule_info.BeltLvl, FormsTID, HandAtksTID, KicksTID, BlocksTID " +
              "FROM beg_tkd_belttest_progress, tkd_schedule_info " +
              "Where beg_tkd_belttest_progress.ClientID = tkd_schedule_info.ClientID";

                lastQuery3 =
               "SELECT tkd_schedule_info.ClientID, FirstName, LastName, Present, tkd_schedule_info.BeltLvl, FormsTID, HandAtksTID, KicksTID, BlocksTID " +
               "FROM adv_tkd_belttest_progress, tkd_schedule_info " +
               "Where adv_tkd_belttest_progress.ClientID = tkd_schedule_info.ClientID";

            using (var connection = new MySqlConnection(sqlConnectionString))
            {

                connection.Open();
                students = connection.Query<Class_Progress_Info>(lastQuery).ToList();
                /*MessageBox.Show(students[0].FirstName + " Test");*/

                for (int i = 0; i < students.Count; i++)
                {
                    /*MessageBox.Show(students[i].FirstName);*/
                    if (students[i].Present)
                    {
                        presentStudents.Add(students[i]);
                    }
                    else
                    {
                        notPresentList.Items.Add(students[i].ClientID + ". " + students[i].FirstName + " " + students[i].LastName);
                    }
                }

                students = connection.Query<Class_Progress_Info>(lastQuery2).ToList();
                /*MessageBox.Show(students[0].FirstName + " Test");*/

                for (int i = 0; i < students.Count; i++)
                {
                    /*MessageBox.Show(students[i].FirstName);*/
                    if (students[i].Present)
                    {
                        presentStudents.Add(students[i]);
                    }
                    else
                    {
                        notPresentList.Items.Add(students[i].ClientID + ". " + students[i].FirstName + " " + students[i].LastName);
                    }
                }

                students = connection.Query<Class_Progress_Info>(lastQuery3).ToList();
                /*MessageBox.Show(students[0].FirstName + " Test");*/

                for (int i = 0; i < students.Count; i++)
                {
                    /*MessageBox.Show(students[i].FirstName);*/
                    if (students[i].Present)
                    {
                        presentStudents.Add(students[i]);
                    }
                    else
                    {
                        notPresentList.Items.Add(students[i].ClientID + ". " + students[i].FirstName + " " + students[i].LastName);
                    }
                }
                //dataGridView1.DataSource = clients;
                connection.Close();
            }

            //if (className.Equals("Lil-Tiger"))
            //{
            //    lastQuery =
            //   "SELECT tkd_schedule_info.ClientID, FirstName, LastName, Present, tkd_schedule_info.BeltLvl, FormsTID, HandAtksTID, KicksTID, BlocksTID " +
            //   "FROM lil_tkd_belttest_progress, tkd_schedule_info " +
            //   "Where lil_tkd_belttest_progress.ClientID = tkd_schedule_info.ClientID";


            //    using (var connection = new MySqlConnection(sqlConnectionString))
              //  {
              //
              //      connection.Open();
              //      students = connection.Query<Class_Progress_Info>(lastQuery).ToList();
                    /*MessageBox.Show(students[0].FirstName + " Test");*/

              //      for (int i = 0; i < students.Count; i++)
               //     {
               //         /*MessageBox.Show(students[i].FirstName);*/
               //         if (students[i].Present)
               //         {
               //             presentStudents.Add(students[i]);
               //         }
               //         else
               //         {
               //             notPresentList.Items.Add(students[i].ClientID + ". " + students[i].FirstName + " " + students[i].LastName);
               //         }
               //     }
                    //dataGridView1.DataSource = clients;
               //     connection.Close();
               // }

            //}
            //else if (className.Equals("Beginner"))
           // {

             //   lastQuery =
             //  "SELECT tkd_schedule_info.ClientID, FirstName, LastName, Present, tkd_schedule_info.BeltLvl, FormsTID, HandAtksTID, KicksTID, BlocksTID " +
             //  "FROM beg_tkd_belttest_progress, tkd_schedule_info " +
             //  "Where beg_tkd_belttest_progress.ClientID = tkd_schedule_info.ClientID";

             //   using (var connection = new MySqlConnection(sqlConnectionString))
             //   {
             //       connection.Open();
             //       students = connection.Query<Class_Progress_Info>(lastQuery).ToList();
             //       for (int i = 0; i < students.Count; i++)
             //       {
             //           if (students[i].Present == true)
             //               presentStudents.Add(students[i]);
             //           else
             //           {
             //               notPresentList.Items.Add(students[i].ClientID + ". " + students[i].FirstName + " " + students[i].LastName);
             //           }
             //       }
                    //dataGridView1.DataSource = clients;
             //       connection.Close();
             //   }
            //}
            //else if (className.Equals("Advanced"))
            //{
            //    lastQuery =
            //   "SELECT tkd_schedule_info.ClientID, FirstName, LastName, Present, tkd_schedule_info.BeltLvl, FormsTID, HandAtksTID, KicksTID, BlocksTID " +
            //   "FROM adv_tkd_belttest_progress, tkd_schedule_info " +
            //   "Where adv_tkd_belttest_progress.ClientID = tkd_schedule_info.ClientID";

            //    using (var connection = new MySqlConnection(sqlConnectionString))
            //    {
            //        connection.Open();
            //        students = connection.Query<Class_Progress_Info>(lastQuery).ToList();
            //        for (int i = 0; i < students.Count; i++)
            //        {
            //            if (students[i].Present == true)
            //                presentStudents.Add(students[i]);
            //            else
            //            {
            //                notPresentList.Items.Add(students[i].ClientID + ". " + students[i].FirstName + " " + students[i].LastName);
            //            }
            //        }
            //        //dataGridView1.DataSource = clients;
            //        connection.Close();
            //    }
            //}
            firstStudentIndex = -1;
            secondStudentIndex = -1;
            thirdStudentIndex = -1;
            setPage();
            initStudentsIndex();
            initStudents();
            
            // index out of rank on [0]
            /* if(presentStudents[0] != null)
             {
                 StudentLbl.Text = presentStudents[0].FirstName + " " + presentStudents[0].LastNamet;
             }*/
        }
        public void initNextPage()
        {
            firstStudentIndex = -1;
            secondStudentIndex = -1;
            thirdStudentIndex = -1;
            setPage();
            initStudentsIndex();
            initStudents();
        }

       
        public void initStudentsIndex()
        {
            firstStudentIndex = presentStudents.Count - 1;
            organizeList();
        }
        public void organizeList()
        {
            if (pageIndex == 0)
                presentStudents = presentStudents.OrderByDescending(i => i.FormsTID).ToList();
            else if (pageIndex == 1)
                presentStudents = presentStudents.OrderByDescending(i => i.BlocksTID).ToList();
            else if (pageIndex == 2)
                presentStudents = presentStudents.OrderByDescending(i => i.HandAtksTID).ToList();
            else if (pageIndex == 3)
                presentStudents = presentStudents.OrderByDescending(i => i.KicksTID).ToList();
        }
        public void setPage()
        {
            PageLbl.Text = pages[pageIndex];
            /*for (int i = 0; i < presentStudents.Count; i++)
            {
                MessageBox.Show("Index - " + i + " Name : " + presentStudents[i].FirstName + " FormsTID: " + presentStudents[i].FormsTID);
            }*/
        }

        public void nextStudent()
        {
            StudentLbl.Text =StudentLbl2.Text = StudentLbl3.Text =  "";
            /*MessageBox.Show("Student Index3 b4 click: " + thirdStudentIndex);*/
            if (thirdStudentIndex > -1)
            {
                
                firstStudentIndex = thirdStudentIndex;
                /*MessageBox.Show("StudentIndex set 2 3: " + firstStudentIndex);*/
            }
            else if (secondStudentIndex > -1)
            {
                firstStudentIndex = secondStudentIndex;
               /* MessageBox.Show("StudentIndex set 2 2: " + firstStudentIndex);*/
            }
            secondStudentIndex = -1;
            thirdStudentIndex = -1;
            /*MessageBox.Show("Student Index b4 click: " + firstStudentIndex);*/
            if (firstStudentIndex - 1 < 0)
                initStudentsIndex();
            else
                firstStudentIndex--;
            /*MessageBox.Show("Student Index after click: " + firstStudentIndex);*/
            initStudents();
        }

        public void previousStudent()
        {
            /*if (thirdStudentIndex > -1)
            {

                firstStudentIndex = thirdStudentIndex;
                MessageBox.Show("StudentIndex set 2 3: " + firstStudentIndex);
            }
            else if (secondStudentIndex > -1)
            {
                firstStudentIndex = secondStudentIndex;
                MessageBox.Show("StudentIndex set 2 2: " + firstStudentIndex);
            }*/

            secondStudentIndex = -1;
            thirdStudentIndex = -1;

            if (firstStudentIndex == presentStudents.Count - 1)
                firstStudentIndex = 0;
            else
            {
                firstStudentIndex++;
            }

            initStudents();
        }

        public void getProgressInfo()
        {
            hideFirstStudent();
            hideSecondStudent();
            hideThirdStudent();
            if (className.Equals("Lil-Tiger"))
            {
                if(PageLbl.Text.Equals("Forms"))
                {
                    lastQuery =
                    "SELECT IDFormMeaning FROM lil_formstid_info Where IDFormProgress = " + presentStudents[firstStudentIndex].FormsTID;

                    using (var connection = new MySqlConnection(sqlConnectionString))
                    {
                        connection.Open();
                        MeaningForms = connection.Query<Student_Info_Forms>(lastQuery).ToList();
                        //dataGridView1.DataSource = clients;
                        connection.Close();
                    }

                    StudentLbl.Text = presentStudents[firstStudentIndex].FirstName + " " + presentStudents[firstStudentIndex].LastName;
                    TechniqueLbl.Text = MeaningForms[0].IDFormMeaning;
                    showFirstStudent();

                    if (firstStudentIndex - 1 >= 0 && presentStudents[firstStudentIndex].FormsTID == presentStudents[firstStudentIndex - 1].FormsTID)
                    {
                        secondStudentIndex = firstStudentIndex - 1;
                        StudentLbl2.Text = presentStudents[secondStudentIndex].FirstName + " " + presentStudents[secondStudentIndex].LastName;
                        showSecondStudent();
                    }
                    // assigned Next Label Name & Technique label
                    if (secondStudentIndex - 1 >= 0 && presentStudents[secondStudentIndex].FormsTID == presentStudents[secondStudentIndex - 1].FormsTID)
                    {
                        thirdStudentIndex = secondStudentIndex - 1;
                        StudentLbl3.Text = presentStudents[thirdStudentIndex].FirstName + " " + presentStudents[thirdStudentIndex].LastName;
                        showThirdStudent();
                    }
                    MeaningForms.Clear();
                    // assigned Next Label Name & Technique label
                }
                else if(PageLbl.Text.Equals("Blocks"))
                {
                    lastQuery =
                    "SELECT IDBlocksMeaning FROM lil_blockstid_info Where IDBlocksProgress = " + presentStudents[firstStudentIndex].BlocksTID;

                    using (var connection = new MySqlConnection(sqlConnectionString))
                    {
                        connection.Open();
                        MeaningBlocks = connection.Query<Student_Info_Blocks>(lastQuery).ToList();
                        //dataGridView1.DataSource = clients;
                        connection.Close();
                    }

                    StudentLbl.Text = presentStudents[firstStudentIndex].FirstName + " " + presentStudents[firstStudentIndex].LastName;
                    TechniqueLbl.Text = MeaningBlocks[0].IDBlocksMeaning;
                    showFirstStudent();

                    if (firstStudentIndex - 1 >= 0 && presentStudents[firstStudentIndex].BlocksTID == presentStudents[firstStudentIndex - 1].BlocksTID)
                    {
                        
                        secondStudentIndex = firstStudentIndex - 1;
                        StudentLbl2.Text = presentStudents[secondStudentIndex].FirstName + " " + presentStudents[secondStudentIndex].LastName;
                        showSecondStudent();
                    }
                    // assigned Next Label Name & Technique label
                    if (secondStudentIndex - 1 >= 0 && presentStudents[secondStudentIndex].BlocksTID == presentStudents[secondStudentIndex - 1].BlocksTID)
                    {
                        
                        thirdStudentIndex = secondStudentIndex - 1;
                        StudentLbl3.Text = presentStudents[thirdStudentIndex].FirstName + " " + presentStudents[thirdStudentIndex].LastName;
                        showThirdStudent();
                    }
                    MeaningBlocks.Clear();
                    // assigned Next Label Name & Technique label
                }
                else if(PageLbl.Text.Equals("Hand Attacks"))
                {
                    lastQuery =
                    "SELECT IDHandAtksMeaning FROM lil_handatkstid_info Where IDHandAtksProgress = " + presentStudents[firstStudentIndex].HandAtksTID;

                    using (var connection = new MySqlConnection(sqlConnectionString))
                    {
                        connection.Open();
                        MeaningHandAtks = connection.Query<Student_Info_HandAttacks>(lastQuery).ToList();
                        //dataGridView1.DataSource = clients;
                        connection.Close();
                    }

                    StudentLbl.Text = presentStudents[firstStudentIndex].FirstName + " " + presentStudents[firstStudentIndex].LastName;
                    TechniqueLbl.Text = MeaningHandAtks[0].IDHandAtksMeaning;
                    showFirstStudent();

                    if (firstStudentIndex - 1 >= 0 && presentStudents[firstStudentIndex].HandAtksTID == presentStudents[firstStudentIndex - 1].HandAtksTID)
                    {
                        secondStudentIndex = firstStudentIndex - 1;
                        StudentLbl2.Text = presentStudents[secondStudentIndex].FirstName + " " + presentStudents[secondStudentIndex].LastName;
                        showSecondStudent();
                    }
                    // assigned Next Label Name & Technique label
                    if (secondStudentIndex - 1 >= 0 && presentStudents[secondStudentIndex].HandAtksTID == presentStudents[secondStudentIndex - 1].HandAtksTID)
                    {
                        thirdStudentIndex = secondStudentIndex - 1;
                        StudentLbl3.Text = presentStudents[thirdStudentIndex].FirstName + " " + presentStudents[thirdStudentIndex].LastName;
                        showThirdStudent();
                    }
                    MeaningHandAtks.Clear();
                    // assigned Next Label Name & Technique label
                }
                else if(PageLbl.Text.Equals("Kicks"))
                {
                    lastQuery =
                    "SELECT IDKicksMeaning FROM lil_kickstid_info Where IDKicksProgress = " + presentStudents[firstStudentIndex].KicksTID;

                    using (var connection = new MySqlConnection(sqlConnectionString))
                    {
                        connection.Open();
                        MeaningKicks = connection.Query<Student_Info_Kicks>(lastQuery).ToList();
                        //dataGridView1.DataSource = clients;
                        connection.Close();
                    }

                    StudentLbl.Text = presentStudents[firstStudentIndex].FirstName + " " + presentStudents[firstStudentIndex].LastName;
                    TechniqueLbl.Text = MeaningKicks[0].IDKicksMeaning;
                    showFirstStudent();

                    if (firstStudentIndex - 1 >= 0 && presentStudents[firstStudentIndex].KicksTID == presentStudents[firstStudentIndex - 1].KicksTID)
                    {
                        secondStudentIndex = firstStudentIndex - 1;
                        StudentLbl2.Text = presentStudents[secondStudentIndex].FirstName + " " + presentStudents[secondStudentIndex].LastName;
                        showSecondStudent();
                    }
                    // assigned Next Label Name & Technique label
                    if (secondStudentIndex - 1 >= 0 && presentStudents[secondStudentIndex].KicksTID == presentStudents[secondStudentIndex - 1].KicksTID)
                    {
                        thirdStudentIndex = secondStudentIndex - 1;
                        StudentLbl3.Text = presentStudents[thirdStudentIndex].FirstName + " " + presentStudents[thirdStudentIndex].LastName;
                        showThirdStudent();
                    }
                    MeaningKicks.Clear();
                    // assigned Next Label Name & Technique label
                }

                /*MessageBox.Show(lastQuery);*/
            }
            else
            {
                if (PageLbl.Text.Equals("Forms"))
                {
                    lastQuery =
                    "SELECT IDFormMeaning FROM adv_formstid_info Where IDFormProgress = " + presentStudents[firstStudentIndex].FormsTID;

                    using (var connection = new MySqlConnection(sqlConnectionString))
                    {
                        connection.Open();
                        MeaningForms = connection.Query<Student_Info_Forms>(lastQuery).ToList();
                        //dataGridView1.DataSource = clients;
                        connection.Close();
                    }

                    StudentLbl.Text = presentStudents[firstStudentIndex].FirstName + " " + presentStudents[firstStudentIndex].LastName;
                    TechniqueLbl.Text = MeaningForms[0].IDFormMeaning;
                    showFirstStudent();

                    if (firstStudentIndex - 1 >= 0 && presentStudents[firstStudentIndex].FormsTID == presentStudents[firstStudentIndex - 1].FormsTID)
                    {
                        /*MessageBox.Show("Second student same meaning");*/
                        secondStudentIndex = firstStudentIndex - 1;
                        StudentLbl2.Text = presentStudents[secondStudentIndex].FirstName + " " + presentStudents[secondStudentIndex].LastName;
                        showSecondStudent();
                    }
                    // assigned Next Label Name & Technique label
                    if (secondStudentIndex - 1 >= 0 && presentStudents[secondStudentIndex].FormsTID == presentStudents[secondStudentIndex - 1].FormsTID)
                    {
                        thirdStudentIndex = secondStudentIndex - 1;
                        StudentLbl3.Text = presentStudents[thirdStudentIndex].FirstName + " " + presentStudents[thirdStudentIndex].LastName;
                        showThirdStudent();
                    }
                    MeaningForms.Clear();
                    // assigned Next Label Name & Technique label
                }
                else if (PageLbl.Text.Equals("Blocks"))
                {
                    lastQuery =
                    "SELECT IDBlocksMeaning FROM adv_blockstid_info Where IDBlocksProgress = " + presentStudents[firstStudentIndex].BlocksTID;

                    using (var connection = new MySqlConnection(sqlConnectionString))
                    {
                        connection.Open();
                        MeaningBlocks = connection.Query<Student_Info_Blocks>(lastQuery).ToList();
                        //dataGridView1.DataSource = clients;
                        connection.Close();
                    }

                    StudentLbl.Text = presentStudents[firstStudentIndex].FirstName + " " + presentStudents[firstStudentIndex].LastName;
                    TechniqueLbl.Text = MeaningBlocks[0].IDBlocksMeaning;
                    showFirstStudent();

                    if (firstStudentIndex - 1 >= 0 && presentStudents[firstStudentIndex].BlocksTID == presentStudents[firstStudentIndex - 1].BlocksTID)
                    {
                        secondStudentIndex = firstStudentIndex - 1;
                        StudentLbl2.Text = presentStudents[secondStudentIndex].FirstName + " " + presentStudents[secondStudentIndex].LastName;
                        showSecondStudent();
                    }
                    // assigned Next Label Name & Technique label
                    if (secondStudentIndex - 1 >= 0 && presentStudents[secondStudentIndex].BlocksTID == presentStudents[secondStudentIndex - 1].BlocksTID)
                    {
                        thirdStudentIndex = secondStudentIndex - 1;
                        StudentLbl3.Text = presentStudents[thirdStudentIndex].FirstName + " " + presentStudents[thirdStudentIndex].LastName;
                        showThirdStudent();
                    }
                    MeaningBlocks.Clear();
                    // assigned Next Label Name & Technique label
                }
                else if (PageLbl.Text.Equals("Hand Attacks"))
                {
                    lastQuery =
                    "SELECT IDHandAtksMeaning FROM adv_handatkstid_info Where IDHandAtksProgress = " + presentStudents[firstStudentIndex].HandAtksTID;

                    using (var connection = new MySqlConnection(sqlConnectionString))
                    {
                        connection.Open();
                        MeaningHandAtks = connection.Query<Student_Info_HandAttacks>(lastQuery).ToList();
                        //dataGridView1.DataSource = clients;
                        connection.Close();
                    }

                    StudentLbl.Text = presentStudents[firstStudentIndex].FirstName + " " + presentStudents[firstStudentIndex].LastName;
                    TechniqueLbl.Text = MeaningHandAtks[0].IDHandAtksMeaning;
                    showFirstStudent();

                    if (firstStudentIndex - 1 >= 0 && presentStudents[firstStudentIndex].HandAtksTID == presentStudents[firstStudentIndex - 1].HandAtksTID)
                    {
                        secondStudentIndex = firstStudentIndex - 1;
                        StudentLbl2.Text = presentStudents[secondStudentIndex].FirstName + " " + presentStudents[secondStudentIndex].LastName;
                        showSecondStudent();
                    }
                    // assigned Next Label Name & Technique label
                    if (secondStudentIndex - 1 >= 0 && presentStudents[secondStudentIndex].HandAtksTID == presentStudents[secondStudentIndex - 1].HandAtksTID)
                    {
                        thirdStudentIndex = secondStudentIndex - 1;
                        StudentLbl3.Text = presentStudents[thirdStudentIndex].FirstName + " " + presentStudents[thirdStudentIndex].LastName;
                        showThirdStudent();
                    }
                    MeaningHandAtks.Clear();
                    // assigned Next Label Name & Technique label
                }
                else if (PageLbl.Text.Equals("Kicks"))
                {
                    lastQuery =
                    "SELECT IDKicksMeaning FROM adv_kickstid_info Where IDKicksProgress = " + presentStudents[firstStudentIndex].KicksTID;

                    using (var connection = new MySqlConnection(sqlConnectionString))
                    {
                        connection.Open();
                        MeaningKicks = connection.Query<Student_Info_Kicks>(lastQuery).ToList();
                        //dataGridView1.DataSource = clients;
                        connection.Close();
                    }

                    StudentLbl.Text = presentStudents[firstStudentIndex].FirstName + " " + presentStudents[firstStudentIndex].LastName;
                    TechniqueLbl.Text = MeaningKicks[0].IDKicksMeaning;
                    showFirstStudent();

                    if (firstStudentIndex - 1 >= 0 && presentStudents[firstStudentIndex].KicksTID == presentStudents[firstStudentIndex - 1].KicksTID)
                    {
                        secondStudentIndex = firstStudentIndex - 1;
                        StudentLbl2.Text = presentStudents[secondStudentIndex].FirstName + " " + presentStudents[secondStudentIndex].LastName;
                        showSecondStudent();
                    }
                    // assigned Next Label Name & Technique label
                    if (secondStudentIndex - 1 >= 0 && presentStudents[secondStudentIndex].KicksTID == presentStudents[secondStudentIndex - 1].KicksTID)
                    {
                        thirdStudentIndex = secondStudentIndex - 1;
                        StudentLbl3.Text = presentStudents[thirdStudentIndex].FirstName + " " + presentStudents[thirdStudentIndex].LastName;
                        showThirdStudent();
                    }
                    MeaningKicks.Clear();
                    // assigned Next Label Name & Technique label
                }

                /*MessageBox.Show(lastQuery);*/
            }
        }

        public void lilReadyForBeltTest(List<Class_Progress_Info> presentStudent, int index)
        {
            if (className.Equals("Lil-Tiger")) 
            {
                if (PageLbl.Text.Equals("Forms"))
                {
                    lastQuery =
                    "UPDATE `lil_test_ready` SET `FormsRdy`= 1 WHERE ClientID = " + presentStudents[index].ClientID;
                    lastQuery2 =
                    "UPDATE `lil_tkd_belttest_progress` SET `FormsTID`= 1 WHERE ClientID = " + presentStudents[index].ClientID;
                    presentStudents[index].FormsTID = 1;
                }
                else if (PageLbl.Text.Equals("Hand Attacks"))
                {
                    lastQuery =
                    "UPDATE `lil_test_ready` SET `HandAtksRdy`= 1 WHERE ClientID = " + presentStudents[index].ClientID;
                    lastQuery2 =
                    "UPDATE `lil_tkd_belttest_progress` SET `HandAtksTID`= 1 WHERE ClientID = " + presentStudents[index].ClientID;
                    presentStudents[index].HandAtksTID = 1;
                }
                else if (PageLbl.Text.Equals("Blocks"))
                {
                    lastQuery =
                    "UPDATE `lil_test_ready` SET `BlocksRdy`= 1 WHERE ClientID = " + presentStudents[index].ClientID;
                    lastQuery2 =
                    "UPDATE `lil_tkd_belttest_progress` SET `BlocksTID`= 1 WHERE ClientID = " + presentStudents[index].ClientID;
                    presentStudents[index].BlocksTID = 1;
                }
                else
                {
                    lastQuery =
                    "UPDATE `lil_test_ready` SET `KicksRdy`= 1 WHERE ClientID = " + presentStudents[index].ClientID;
                    lastQuery2 =
                    "UPDATE `lil_tkd_belttest_progress` SET `KicksTID`= 1 WHERE ClientID = " + presentStudents[index].ClientID;
                    presentStudents[index].KicksTID = 1;
                }
            }
            else if ((className.Equals("Beginner")))
            {
                if (PageLbl.Text.Equals("Forms"))
                {
                    lastQuery =
                    "UPDATE `beg_test_ready` SET `FormsRdy`= 1 WHERE ClientID = " + presentStudents[index].ClientID;
                    lastQuery2 =
                    "UPDATE `beg_tkd_belttest_progress` SET `FormsTID`= 1 WHERE ClientID = " + presentStudents[index].ClientID;
                    presentStudents[index].FormsTID = 1;
                }
                else if (PageLbl.Text.Equals("Hand Attacks"))
                {
                    lastQuery =
                    "UPDATE `beg_test_ready` SET `HandAtksRdy`= 1 WHERE ClientID = " + presentStudents[index].ClientID;
                    lastQuery2 =
                    "UPDATE `beg_tkd_belttest_progress` SET `HandAtksTID`= 1 WHERE ClientID = " + presentStudents[index].ClientID;
                    presentStudents[index].HandAtksTID = 1;
                }
                else if (PageLbl.Text.Equals("Blocks"))
                {
                    lastQuery =
                    "UPDATE `beg_test_ready` SET `BlocksRdy`= 1 WHERE ClientID = " + presentStudents[index].ClientID;
                    lastQuery2 =
                    "UPDATE `beg_tkd_belttest_progress` SET `BlocksTID`= 1 WHERE ClientID = " + presentStudents[index].ClientID;
                    presentStudents[index].BlocksTID = 1;
                }
                else
                {
                    lastQuery =
                    "UPDATE `beg_test_ready` SET `KicksRdy`= 1 WHERE ClientID = " + presentStudents[index].ClientID;
                    lastQuery2 =
                    "UPDATE `beg_tkd_belttest_progress` SET `KicksTID`= 1 WHERE ClientID = " + presentStudents[index].ClientID;
                    presentStudents[index].KicksTID = 1;
                }
            }
            else
            {
                if (PageLbl.Text.Equals("Forms"))
                {
                    lastQuery =
                    "UPDATE `adv_test_ready` SET `FormsRdy`= 1 WHERE ClientID = " + presentStudents[index].ClientID;
                    lastQuery2 =
                    "UPDATE `adv_tkd_belttest_progress` SET `FormsTID`= 1 WHERE ClientID = " + presentStudents[index].ClientID;
                    presentStudents[index].FormsTID = 1;
                }
                else if (PageLbl.Text.Equals("Hand Attacks"))
                {
                    lastQuery =
                    "UPDATE `adv_test_ready` SET `HandAtksRdy`= 1 WHERE ClientID = " + presentStudents[index].ClientID;
                    lastQuery2 =
                    "UPDATE `adv_tkd_belttest_progress` SET `HandAtksTID`= 1 WHERE ClientID = " + presentStudents[index].ClientID;
                    presentStudents[index].HandAtksTID = 1;
                }
                else if (PageLbl.Text.Equals("Blocks"))
                {
                    lastQuery =
                    "UPDATE `adv_test_ready` SET `BlocksRdy`= 1 WHERE ClientID = " + presentStudents[index].ClientID;
                    lastQuery2 =
                    "UPDATE `adv_tkd_belttest_progress` SET `BlocksTID`= 1 WHERE ClientID = " + presentStudents[index].ClientID;
                    presentStudents[index].BlocksTID = 1;
                }
                else
                {
                    lastQuery =
                    "UPDATE `adv_test_ready` SET `KicksRdy`= 1 WHERE ClientID = " + presentStudents[index].ClientID;
                    lastQuery2 =
                    "UPDATE `adv_tkd_belttest_progress` SET `KicksTID`= 1 WHERE ClientID = " + presentStudents[index].ClientID;
                    presentStudents[index].KicksTID = 1;
                }
            }
                using (var connection = new MySqlConnection(sqlConnectionString))
            {
                connection.Open();
                BeltCheck = connection.Query<Belt_Requirement>(lastQuery).ToList();

                MeaningForms = connection.Query<Student_Info_Forms>(lastQuery2).ToList();
                connection.Close();
            }

            MessageBox.Show(presentStudents[index].FirstName + " is belt test ready for this page!");
        }

        public void notReadyForBeltTest(string clientName, string queryString)
        {
            using (var connection = new MySqlConnection(sqlConnectionString))
            {
                connection.Open();
                BeltCheck = connection.Query<Belt_Requirement>(queryString).ToList();
                //dataGridView1.DataSource = clients;
                connection.Close();
            }
            MessageBox.Show(clientName + " removed from the test list on this page");
        }

        public void moveOnFirst()
        {
            // TO-DO Test Ready on move on all classes
            if(StudentLbl.Visible)
            {
                DialogResult ans = MessageBox.Show("Does " + presentStudents[firstStudentIndex].FirstName + presentStudents[firstStudentIndex].LastName + " Move On?", "Student Move On?", MessageBoxButtons.YesNoCancel);
                if (ans == DialogResult.Yes)
                {

                    if (className.Equals("Lil-Tiger"))
                    {
                        if (PageLbl.Text.Equals("Forms"))
                        {
                            lastQuery =
                            "SELECT BeltReq FROM lil_formstid_info WHERE IDFormProgress = " + (presentStudents[firstStudentIndex].FormsTID + 1);

                            using (var connection = new MySqlConnection(sqlConnectionString))
                            {
                                connection.Open();
                                BeltCheck = connection.Query<Belt_Requirement>(lastQuery).ToList();
                                //dataGridView1.DataSource = clients;
                                connection.Close();
                            }
                            // 10 < 9
                            if (BeltCheck[0].BeltReq >= presentStudents[firstStudentIndex].BeltLvl)
                            {
                                lastQuery =
                                "UPDATE `lil_tkd_belttest_progress` SET `FormsTID`= " + (presentStudents[firstStudentIndex].FormsTID + 1) + " WHERE ClientID = " + presentStudents[firstStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningForms = connection.Query<Student_Info_Forms>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[firstStudentIndex].FormsTID++;
                            }
                            else
                            {
                                lilReadyForBeltTest(presentStudents, firstStudentIndex);
                            }
                            BeltCheck.Clear();
                            MeaningForms.Clear();
                        }
                        else if (PageLbl.Text.Equals("Blocks"))
                        {
                            lastQuery =
                            "SELECT BeltReq FROM lil_blockstid_info WHERE IDBlocksProgress = " + (presentStudents[firstStudentIndex].BlocksTID + 1);

                            using (var connection = new MySqlConnection(sqlConnectionString))
                            {
                                connection.Open();
                                BeltCheck = connection.Query<Belt_Requirement>(lastQuery).ToList();
                                //dataGridView1.DataSource = clients;
                                connection.Close();
                            }
                            // 10 < 9
                            //MessageBox.Show("Beltreq: " + BeltCheck[0].BeltReq);
                            if (BeltCheck[0].BeltReq >= presentStudents[firstStudentIndex].BeltLvl)
                            {
                                lastQuery =
                                "UPDATE `lil_tkd_belttest_progress` SET `BlocksTID`= " + (presentStudents[firstStudentIndex].BlocksTID + 1) + " WHERE ClientID = " + presentStudents[firstStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningBlocks = connection.Query<Student_Info_Blocks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[firstStudentIndex].BlocksTID++;
                            }
                            else
                            {
                                lilReadyForBeltTest(presentStudents, firstStudentIndex);
                            }
                            BeltCheck.Clear();
                            MeaningBlocks.Clear();
                        }
                        else if (PageLbl.Text.Equals("Hand Attacks"))
                        {
                            lastQuery =
                            "SELECT BeltReq FROM lil_handatkstid_info WHERE IDHandAtksProgress = " + (presentStudents[firstStudentIndex].HandAtksTID + 1);

                            using (var connection = new MySqlConnection(sqlConnectionString))
                            {
                                connection.Open();
                                BeltCheck = connection.Query<Belt_Requirement>(lastQuery).ToList();
                                //dataGridView1.DataSource = clients;
                                connection.Close();
                            }

                            if (BeltCheck[0].BeltReq >= presentStudents[firstStudentIndex].BeltLvl)
                            {
                                lastQuery =
                            "UPDATE `lil_tkd_belttest_progress` SET `HandAtksTID`= " + (presentStudents[firstStudentIndex].HandAtksTID + 1) + " WHERE ClientID = " + presentStudents[firstStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningHandAtks = connection.Query<Student_Info_HandAttacks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[firstStudentIndex].HandAtksTID++;
                            }
                            else
                            {
                                lilReadyForBeltTest(presentStudents, firstStudentIndex);
                            }    
                            BeltCheck.Clear();
                            MeaningHandAtks.Clear();
                        }
                        else if (PageLbl.Text.Equals("Kicks"))
                        {
                            lastQuery =
                            "SELECT BeltReq FROM lil_kickstid_info WHERE IDKicksProgress = " + (presentStudents[firstStudentIndex].KicksTID + 1);

                            using (var connection = new MySqlConnection(sqlConnectionString))
                            {
                                connection.Open();
                                BeltCheck = connection.Query<Belt_Requirement>(lastQuery).ToList();
                                //dataGridView1.DataSource = clients;
                                connection.Close();
                            }

                            if (BeltCheck[0].BeltReq >= presentStudents[firstStudentIndex].BeltLvl)
                            {
                                lastQuery =
                                "UPDATE `lil_tkd_belttest_progress` SET `KicksTID`= " + (presentStudents[firstStudentIndex].KicksTID + 1) + " WHERE ClientID = " + presentStudents[firstStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningForms = connection.Query<Student_Info_Forms>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[firstStudentIndex].KicksTID++;
                            }
                            else
                            {
                                lilReadyForBeltTest(presentStudents, firstStudentIndex);
                            }
                            BeltCheck.Clear();
                            MeaningForms.Clear();
                        }
                    }
                    else if (className.Equals("Beginner"))
                    {
                        if (PageLbl.Text.Equals("Forms"))
                        {
                            lastQuery =
                            "SELECT BeltReq FROM adv_formstid_info WHERE IDFormProgress = " + (presentStudents[firstStudentIndex].FormsTID + 1);

                            using (var connection = new MySqlConnection(sqlConnectionString))
                            {
                                connection.Open();
                                BeltCheck = connection.Query<Belt_Requirement>(lastQuery).ToList();
                                //dataGridView1.DataSource = clients;
                                connection.Close();
                            }

                            if (BeltCheck[0].BeltReq >= presentStudents[firstStudentIndex].BeltLvl)
                            {
                                lastQuery =
                                "UPDATE `beg_tkd_belttest_progress` SET `FormsTID`= " + (presentStudents[firstStudentIndex].FormsTID + 1) + " WHERE ClientID = " + presentStudents[firstStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningForms = connection.Query<Student_Info_Forms>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[firstStudentIndex].FormsTID++;
                            }
                            else
                            {
                                lilReadyForBeltTest(presentStudents, firstStudentIndex);
                            }
                            BeltCheck.Clear();
                            MeaningForms.Clear();
                        }
                        else if (PageLbl.Text.Equals("Blocks"))
                        {
                            lastQuery =
                            "SELECT BeltReq FROM adv_blockstid_info WHERE IDBlocksProgress = " + (presentStudents[firstStudentIndex].BlocksTID + 1);

                            using (var connection = new MySqlConnection(sqlConnectionString))
                            {
                                connection.Open();
                                BeltCheck = connection.Query<Belt_Requirement>(lastQuery).ToList();
                                //dataGridView1.DataSource = clients;
                                connection.Close();
                            }

                            if (BeltCheck[0].BeltReq >= presentStudents[firstStudentIndex].BeltLvl)
                            {
                                lastQuery =
                                "UPDATE `beg_tkd_belttest_progress` SET `BlocksTID`= " + (presentStudents[firstStudentIndex].BlocksTID + 1) + " WHERE ClientID = " + presentStudents[firstStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningBlocks = connection.Query<Student_Info_Blocks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[firstStudentIndex].BlocksTID++;
                            }
                            else
                            {
                                lilReadyForBeltTest(presentStudents, firstStudentIndex);
                            }
                            BeltCheck.Clear();
                            MeaningBlocks.Clear();
                        }
                        else if (PageLbl.Text.Equals("Hand Attacks"))
                        {
                            lastQuery =
                            "SELECT BeltReq FROM adv_handatkstid_info WHERE IDHandAtksProgress = " + (presentStudents[firstStudentIndex].HandAtksTID + 1);

                            using (var connection = new MySqlConnection(sqlConnectionString))
                            {
                                connection.Open();
                                BeltCheck = connection.Query<Belt_Requirement>(lastQuery).ToList();
                                //dataGridView1.DataSource = clients;
                                connection.Close();
                            }

                            if (BeltCheck[0].BeltReq >= presentStudents[firstStudentIndex].BeltLvl)
                            {
                                lastQuery =
                            "UPDATE `beg_tkd_belttest_progress` SET `HandAtksTID`= " + (presentStudents[firstStudentIndex].HandAtksTID + 1) + " WHERE ClientID = " + presentStudents[firstStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningHandAtks = connection.Query<Student_Info_HandAttacks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[firstStudentIndex].HandAtksTID++;
                            }
                            else
                            {
                                lilReadyForBeltTest(presentStudents, firstStudentIndex);
                            }
                            BeltCheck.Clear();
                            MeaningHandAtks.Clear();
                        }
                        else if (PageLbl.Text.Equals("Kicks"))
                        {
                            lastQuery =
                            "SELECT BeltReq FROM adv_kickstid_info WHERE IDKicksProgress = " + (presentStudents[firstStudentIndex].KicksTID + 1);

                            using (var connection = new MySqlConnection(sqlConnectionString))
                            {
                                connection.Open();
                                BeltCheck = connection.Query<Belt_Requirement>(lastQuery).ToList();
                                //dataGridView1.DataSource = clients;
                                connection.Close();
                            }

                            if (BeltCheck[0].BeltReq >= presentStudents[firstStudentIndex].BeltLvl)
                            {
                                lastQuery =
                            "UPDATE `beg_tkd_belttest_progress` SET `KicksTID`= " + (presentStudents[firstStudentIndex].KicksTID + 1) + " WHERE ClientID = " + presentStudents[firstStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningKicks = connection.Query<Student_Info_Kicks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[firstStudentIndex].KicksTID++;
                            }
                            else
                            {
                                lilReadyForBeltTest(presentStudents, firstStudentIndex);
                            }
                            BeltCheck.Clear();
                            MeaningKicks.Clear();
                        }
                    }
                    else if (className.Equals("Advanced"))
                    {
                        if (PageLbl.Text.Equals("Forms"))
                        {
                            lastQuery =
                            "SELECT BeltReq FROM adv_formstid_info WHERE IDFormProgress = " + (presentStudents[firstStudentIndex].FormsTID + 1);

                            using (var connection = new MySqlConnection(sqlConnectionString))
                            {
                                connection.Open();
                                BeltCheck = connection.Query<Belt_Requirement>(lastQuery).ToList();
                                //dataGridView1.DataSource = clients;
                                connection.Close();
                            }

                            if (BeltCheck[0].BeltReq >= presentStudents[firstStudentIndex].BeltLvl)
                            {
                                lastQuery =
                                "UPDATE `adv_tkd_belttest_progress` SET `FormsTID`= " + (presentStudents[firstStudentIndex].FormsTID + 1) + " WHERE ClientID = " + presentStudents[firstStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningForms = connection.Query<Student_Info_Forms>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[firstStudentIndex].FormsTID++;
                            }
                            else
                            {
                                lilReadyForBeltTest(presentStudents, firstStudentIndex);
                            }
                            BeltCheck.Clear();
                            MeaningForms.Clear();
                        }
                        else if (PageLbl.Text.Equals("Blocks"))
                        {
                            lastQuery =
                            "SELECT BeltReq FROM adv_blockstid_info WHERE IDBlocksProgress = " + (presentStudents[firstStudentIndex].BlocksTID + 1);

                            using (var connection = new MySqlConnection(sqlConnectionString))
                            {
                                connection.Open();
                                BeltCheck = connection.Query<Belt_Requirement>(lastQuery).ToList();
                                //dataGridView1.DataSource = clients;
                                connection.Close();
                            }

                            if (BeltCheck[0].BeltReq >= presentStudents[firstStudentIndex].BeltLvl)
                            {
                                lastQuery =
                            "UPDATE `adv_tkd_belttest_progress` SET `BlocksTID`= " + (presentStudents[firstStudentIndex].BlocksTID + 1) + " WHERE ClientID = " + presentStudents[firstStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningBlocks = connection.Query<Student_Info_Blocks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[firstStudentIndex].BlocksTID++;
                            }
                            else
                            {
                                lilReadyForBeltTest(presentStudents, firstStudentIndex);
                            }
                            BeltCheck.Clear();
                            MeaningBlocks.Clear();
                        }
                        else if (PageLbl.Text.Equals("Hand Attacks"))
                        {
                            lastQuery =
                            "SELECT BeltReq FROM adv_handatkstid_info WHERE IDHandAtksProgress = " + (presentStudents[firstStudentIndex].HandAtksTID + 1);

                            using (var connection = new MySqlConnection(sqlConnectionString))
                            {
                                connection.Open();
                                BeltCheck = connection.Query<Belt_Requirement>(lastQuery).ToList();
                                //dataGridView1.DataSource = clients;
                                connection.Close();
                            }

                            if (BeltCheck[0].BeltReq >= presentStudents[firstStudentIndex].BeltLvl)
                            {
                                lastQuery =
                            "UPDATE `adv_tkd_belttest_progress` SET `HandAtksTID`= " + (presentStudents[firstStudentIndex].HandAtksTID + 1) + " WHERE ClientID = " + presentStudents[firstStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningHandAtks = connection.Query<Student_Info_HandAttacks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[firstStudentIndex].HandAtksTID++;
                            }
                            else
                            {
                                lilReadyForBeltTest(presentStudents, firstStudentIndex);
                            }
                            BeltCheck.Clear();
                            MeaningHandAtks.Clear();
                        }
                        else if (PageLbl.Text.Equals("Kicks"))
                        {
                            lastQuery =
                            "SELECT BeltReq FROM adv_kickstid_info WHERE IDKicksProgress = " + (presentStudents[firstStudentIndex].KicksTID + 1);

                            using (var connection = new MySqlConnection(sqlConnectionString))
                            {
                                connection.Open();
                                BeltCheck = connection.Query<Belt_Requirement>(lastQuery).ToList();
                                //dataGridView1.DataSource = clients;
                                connection.Close();
                            }

                            if (BeltCheck[0].BeltReq >= presentStudents[firstStudentIndex].BeltLvl)
                            {
                                lastQuery =
                            "UPDATE `adv_tkd_belttest_progress` SET `KicksTID`= " + (presentStudents[firstStudentIndex].KicksTID + 1) + " WHERE ClientID = " + presentStudents[firstStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningKicks = connection.Query<Student_Info_Kicks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[firstStudentIndex].KicksTID++;
                            }
                            else
                            {
                                lilReadyForBeltTest(presentStudents, firstStudentIndex);
                            }
                            BeltCheck.Clear();
                            MeaningKicks.Clear();
                        }
                    }
                }
            }
        }

        // MoveOnFirst is done, finish moveonsecond and third
        public void moveOnSecond()
        {
            if (StudentLbl2.Visible)
            {
                DialogResult ans = MessageBox.Show("Does " + presentStudents[secondStudentIndex].FirstName + presentStudents[secondStudentIndex].LastName + " Move On?", "Student Move On?", MessageBoxButtons.YesNoCancel);
                if (ans == DialogResult.Yes)
                {
                    if (className.Equals("Lil-Tiger"))
                    {
                        if (PageLbl.Text.Equals("Forms"))
                        {
                            lastQuery =
                            "SELECT BeltReq FROM lil_formstid_info WHERE IDFormProgress = " + (presentStudents[secondStudentIndex].FormsTID + 1);

                            using (var connection = new MySqlConnection(sqlConnectionString))
                            {
                                connection.Open();
                                BeltCheck = connection.Query<Belt_Requirement>(lastQuery).ToList();
                                //dataGridView1.DataSource = clients;
                                connection.Close();
                            }

                            if (BeltCheck[0].BeltReq >= presentStudents[secondStudentIndex].BeltLvl)
                            {
                                lastQuery =
                            "UPDATE `lil_tkd_belttest_progress` SET `FormsTID`= " + (presentStudents[secondStudentIndex].FormsTID + 1) + " WHERE ClientID = " + presentStudents[secondStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningForms = connection.Query<Student_Info_Forms>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[secondStudentIndex].FormsTID++;
                            }
                            else
                            {
                                lilReadyForBeltTest(presentStudents, secondStudentIndex);
                            }
                            BeltCheck.Clear();
                            MeaningForms.Clear();
                        }
                        else if (PageLbl.Text.Equals("Blocks"))
                        {
                            lastQuery =
                            "SELECT BeltReq FROM lil_blockstid_info WHERE IDBlocksProgress = " + (presentStudents[secondStudentIndex].BlocksTID + 1);

                            using (var connection = new MySqlConnection(sqlConnectionString))
                            {
                                connection.Open();
                                BeltCheck = connection.Query<Belt_Requirement>(lastQuery).ToList();
                                //dataGridView1.DataSource = clients;
                                connection.Close();
                            }
                            // 10 <= 8
                            
                            if (BeltCheck[0].BeltReq >= presentStudents[secondStudentIndex].BeltLvl)
                            {
                                lastQuery =
                            "UPDATE `lil_tkd_belttest_progress` SET `BlocksTID`= " + (presentStudents[secondStudentIndex].BlocksTID + 1) + " WHERE ClientID = " + presentStudents[secondStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningBlocks = connection.Query<Student_Info_Blocks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[secondStudentIndex].BlocksTID++;
                            }
                            else
                            {
                                lilReadyForBeltTest(presentStudents, secondStudentIndex);
                            }
                            BeltCheck.Clear();
                            MeaningBlocks.Clear();
                        }
                        else if (PageLbl.Text.Equals("Hand Attacks"))
                        {
                            lastQuery =
                            "SELECT BeltReq FROM lil_handatkstid_info WHERE IDHandAtksProgress = " + (presentStudents[secondStudentIndex].HandAtksTID + 1);

                            using (var connection = new MySqlConnection(sqlConnectionString))
                            {
                                connection.Open();
                                BeltCheck = connection.Query<Belt_Requirement>(lastQuery).ToList();
                                //dataGridView1.DataSource = clients;
                                connection.Close();
                            }

                            if (BeltCheck[0].BeltReq >= presentStudents[secondStudentIndex].BeltLvl)
                            {
                                lastQuery =
                            "UPDATE `lil_tkd_belttest_progress` SET `HandAtksTID`= " + (presentStudents[secondStudentIndex].HandAtksTID + 1) + " WHERE ClientID = " + presentStudents[secondStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningHandAtks = connection.Query<Student_Info_HandAttacks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[secondStudentIndex].HandAtksTID++;
                            }
                            else
                            {
                                lilReadyForBeltTest(presentStudents, secondStudentIndex);
                            }
                            BeltCheck.Clear();
                            MeaningHandAtks.Clear();
                        }
                        else if (PageLbl.Text.Equals("Kicks"))
                        {
                            lastQuery =
                            "SELECT BeltReq FROM lil_kickstid_info WHERE IDKicksProgress = " + (presentStudents[secondStudentIndex].KicksTID + 1);

                            using (var connection = new MySqlConnection(sqlConnectionString))
                            {
                                connection.Open();
                                BeltCheck = connection.Query<Belt_Requirement>(lastQuery).ToList();
                                //dataGridView1.DataSource = clients;
                                connection.Close();
                            }

                            if (BeltCheck[0].BeltReq >= presentStudents[secondStudentIndex].BeltLvl)
                            {
                                lastQuery =
                                "UPDATE `lil_tkd_belttest_progress` SET `KicksTID`= " + (presentStudents[secondStudentIndex].KicksTID + 1) + " WHERE ClientID = " + presentStudents[secondStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningKicks = connection.Query<Student_Info_Kicks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[secondStudentIndex].KicksTID++;
                            }
                            else
                            {
                                lilReadyForBeltTest(presentStudents, secondStudentIndex);
                            }
                            BeltCheck.Clear();
                            MeaningKicks.Clear();
                        }
                    }
                    else if (className.Equals("Beginner"))
                    {
                        if (PageLbl.Text.Equals("Forms"))
                        {
                            lastQuery =
                            "SELECT BeltReq FROM adv_formstid_info WHERE IDFormProgress = " + (presentStudents[secondStudentIndex].FormsTID + 1);

                            using (var connection = new MySqlConnection(sqlConnectionString))
                            {
                                connection.Open();
                                BeltCheck = connection.Query<Belt_Requirement>(lastQuery).ToList();
                                //dataGridView1.DataSource = clients;
                                connection.Close();
                            }

                            if (BeltCheck[0].BeltReq >= presentStudents[secondStudentIndex].BeltLvl)
                            {
                                lastQuery =
                            "UPDATE `beg_tkd_belttest_progress` SET `FormsTID`= " + (presentStudents[secondStudentIndex].FormsTID + 1) + " WHERE ClientID = " + presentStudents[secondStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningForms = connection.Query<Student_Info_Forms>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[secondStudentIndex].FormsTID++;
                            }
                            else
                            {
                                lilReadyForBeltTest(presentStudents, secondStudentIndex);
                            }
                            BeltCheck.Clear();
                            MeaningForms.Clear();
                        }
                        else if (PageLbl.Text.Equals("Blocks"))
                        {
                            lastQuery =
                            "SELECT BeltReq FROM adv_blockstid_info WHERE IDBlocksProgress = " + (presentStudents[secondStudentIndex].BlocksTID + 1);

                            using (var connection = new MySqlConnection(sqlConnectionString))
                            {
                                connection.Open();
                                BeltCheck = connection.Query<Belt_Requirement>(lastQuery).ToList();
                                //dataGridView1.DataSource = clients;
                                connection.Close();
                            }

                            if (BeltCheck[0].BeltReq >= presentStudents[secondStudentIndex].BeltLvl)
                            {
                                lastQuery =
                            "UPDATE `beg_tkd_belttest_progress` SET `BlocksTID`= " + (presentStudents[secondStudentIndex].BlocksTID + 1) + " WHERE ClientID = " + presentStudents[secondStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningBlocks = connection.Query<Student_Info_Blocks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[secondStudentIndex].BlocksTID++;
                            }
                            else
                            {
                                lilReadyForBeltTest(presentStudents, secondStudentIndex);
                            }
                            BeltCheck.Clear();
                            MeaningBlocks.Clear();
                        }
                        else if (PageLbl.Text.Equals("Hand Attacks"))
                        {
                            lastQuery =
                            "SELECT BeltReq FROM adv_handatkstid_info WHERE IDHandAtksProgress = " + (presentStudents[secondStudentIndex].HandAtksTID + 1);

                            using (var connection = new MySqlConnection(sqlConnectionString))
                            {
                                connection.Open();
                                BeltCheck = connection.Query<Belt_Requirement>(lastQuery).ToList();
                                //dataGridView1.DataSource = clients;
                                connection.Close();
                            }

                            if (BeltCheck[0].BeltReq >= presentStudents[secondStudentIndex].BeltLvl)
                            {
                                lastQuery =
                            "UPDATE `beg_tkd_belttest_progress` SET `HandAtksTID`= " + (presentStudents[secondStudentIndex].HandAtksTID + 1) + " WHERE ClientID = " + presentStudents[secondStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningHandAtks = connection.Query<Student_Info_HandAttacks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[secondStudentIndex].HandAtksTID++;
                            }
                            else
                            {
                                lilReadyForBeltTest(presentStudents, secondStudentIndex);
                            }    
                            BeltCheck.Clear();
                            MeaningHandAtks.Clear();
                        }
                        else if (PageLbl.Text.Equals("Kicks"))
                        {
                            lastQuery =
                            "SELECT BeltReq FROM adv_kickstid_info WHERE IDKicksProgress = " + (presentStudents[secondStudentIndex].KicksTID + 1);

                            using (var connection = new MySqlConnection(sqlConnectionString))
                            {
                                connection.Open();
                                BeltCheck = connection.Query<Belt_Requirement>(lastQuery).ToList();
                                //dataGridView1.DataSource = clients;
                                connection.Close();
                            }

                            if (BeltCheck[0].BeltReq >= presentStudents[secondStudentIndex].BeltLvl)
                            {
                                lastQuery =
                            "UPDATE `beg_tkd_belttest_progress` SET `KicksTID`= " + (presentStudents[secondStudentIndex].KicksTID + 1) + " WHERE ClientID = " + presentStudents[secondStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningKicks = connection.Query<Student_Info_Kicks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[secondStudentIndex].KicksTID++;
                            }
                            else
                            {
                                lilReadyForBeltTest(presentStudents, secondStudentIndex);
                            }
                            BeltCheck.Clear();
                            MeaningKicks.Clear();
                        }
                    }
                    else if (className.Equals("Advanced"))
                    {
                        if (PageLbl.Text.Equals("Forms"))
                        {
                            lastQuery =
                            "SELECT BeltReq FROM adv_formstid_info WHERE IDFormProgress = " + (presentStudents[secondStudentIndex].FormsTID + 1);

                            using (var connection = new MySqlConnection(sqlConnectionString))
                            {
                                connection.Open();
                                BeltCheck = connection.Query<Belt_Requirement>(lastQuery).ToList();
                                //dataGridView1.DataSource = clients;
                                connection.Close();
                            }

                            if (BeltCheck[0].BeltReq >= presentStudents[secondStudentIndex].BeltLvl)
                            {
                                lastQuery =
                            "UPDATE `adv_tkd_belttest_progress` SET `FormsTID`= " + (presentStudents[secondStudentIndex].FormsTID + 1) + " WHERE ClientID = " + presentStudents[secondStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningForms = connection.Query<Student_Info_Forms>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[secondStudentIndex].FormsTID++;
                            }
                            else
                            {
                                lilReadyForBeltTest(presentStudents, secondStudentIndex);
                            }
                            BeltCheck.Clear();
                            MeaningForms.Clear();
                        }
                        else if (PageLbl.Text.Equals("Blocks"))
                        {
                            lastQuery =
                            "SELECT BeltReq FROM adv_blockstid_info WHERE IDBlocksProgress = " + (presentStudents[secondStudentIndex].BlocksTID + 1);

                            using (var connection = new MySqlConnection(sqlConnectionString))
                            {
                                connection.Open();
                                BeltCheck = connection.Query<Belt_Requirement>(lastQuery).ToList();
                                //dataGridView1.DataSource = clients;
                                connection.Close();
                            }

                            if (BeltCheck[0].BeltReq >= presentStudents[secondStudentIndex].BeltLvl)
                            {
                                lastQuery =
                            "UPDATE `adv_tkd_belttest_progress` SET `BlocksTID`= " + (presentStudents[secondStudentIndex].BlocksTID + 1) + " WHERE ClientID = " + presentStudents[secondStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningBlocks = connection.Query<Student_Info_Blocks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[secondStudentIndex].BlocksTID++;
                            }
                            else
                            {
                                lilReadyForBeltTest(presentStudents, secondStudentIndex);
                            }
                            BeltCheck.Clear();
                            MeaningBlocks.Clear();
                        }
                        else if (PageLbl.Text.Equals("Hand Attacks"))
                        {
                            lastQuery =
                            "SELECT BeltReq FROM adv_handatkstid_info WHERE IDHandAtksProgress = " + (presentStudents[secondStudentIndex].HandAtksTID + 1);

                            using (var connection = new MySqlConnection(sqlConnectionString))
                            {
                                connection.Open();
                                BeltCheck = connection.Query<Belt_Requirement>(lastQuery).ToList();
                                //dataGridView1.DataSource = clients;
                                connection.Close();
                            }

                            if (BeltCheck[0].BeltReq >= presentStudents[secondStudentIndex].BeltLvl)
                            {
                                lastQuery =
                            "UPDATE `adv_tkd_belttest_progress` SET `HandAtksTID`= " + (presentStudents[secondStudentIndex].HandAtksTID + 1) + " WHERE ClientID = " + presentStudents[secondStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningHandAtks = connection.Query<Student_Info_HandAttacks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[secondStudentIndex].HandAtksTID++;
                            }
                            else
                            {
                                lilReadyForBeltTest(presentStudents, secondStudentIndex);
                            }
                            BeltCheck.Clear();
                            MeaningHandAtks.Clear();
                        }
                        else if (PageLbl.Text.Equals("Kicks"))
                        {
                            lastQuery =
                            "SELECT BeltReq FROM adv_kickstid_info WHERE IDKicksProgress = " + (presentStudents[secondStudentIndex].KicksTID + 1);

                            using (var connection = new MySqlConnection(sqlConnectionString))
                            {
                                connection.Open();
                                BeltCheck = connection.Query<Belt_Requirement>(lastQuery).ToList();
                                //dataGridView1.DataSource = clients;
                                connection.Close();
                            }

                            if (BeltCheck[0].BeltReq >= presentStudents[secondStudentIndex].BeltLvl)
                            {
                                lastQuery =
                            "UPDATE `adv_tkd_belttest_progress` SET `KicksTID`= " + (presentStudents[secondStudentIndex].KicksTID + 1) + " WHERE ClientID = " + presentStudents[secondStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningKicks = connection.Query<Student_Info_Kicks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[secondStudentIndex].KicksTID++;
                            }
                            else
                            {
                                lilReadyForBeltTest(presentStudents, secondStudentIndex);
                            }
                            BeltCheck.Clear();
                            MeaningKicks.Clear();
                        }
                    }
                }


            }
        }

        public void moveOnThird()
        {
            if(StudentLbl3.Visible)
            {
                DialogResult ans = MessageBox.Show("Does " + presentStudents[thirdStudentIndex].FirstName + presentStudents[thirdStudentIndex].LastName + " Move On?", "Student Move On?", MessageBoxButtons.YesNoCancel);
                if (ans == DialogResult.Yes)
                {
                    if (className.Equals("Lil-Tiger"))
                    {
                        if (PageLbl.Text.Equals("Forms"))
                        {
                            lastQuery =
                            "SELECT BeltReq FROM lil_formstid_info WHERE IDFormProgress = " + (presentStudents[thirdStudentIndex].FormsTID + 1);

                            using (var connection = new MySqlConnection(sqlConnectionString))
                            {
                                connection.Open();
                                BeltCheck = connection.Query<Belt_Requirement>(lastQuery).ToList();
                                //dataGridView1.DataSource = clients;
                                connection.Close();
                            }

                            if (BeltCheck[0].BeltReq >= presentStudents[thirdStudentIndex].BeltLvl)
                            {
                                lastQuery =
                            "UPDATE `lil_tkd_belttest_progress` SET `FormsTID`= " + (presentStudents[thirdStudentIndex].FormsTID + 1) + " WHERE ClientID = " + presentStudents[thirdStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningForms = connection.Query<Student_Info_Forms>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[thirdStudentIndex].FormsTID++;
                            }
                            else
                            {
                                lilReadyForBeltTest(presentStudents, firstStudentIndex);
                            }
                            BeltCheck.Clear();
                            MeaningForms.Clear();
                        }
                        else if (PageLbl.Text.Equals("Blocks"))
                        {
                            lastQuery =
                            "SELECT BeltReq FROM lil_blockstid_info WHERE IDBlocksProgress = " + (presentStudents[thirdStudentIndex].BlocksTID + 1);

                            using (var connection = new MySqlConnection(sqlConnectionString))
                            {
                                connection.Open();
                                BeltCheck = connection.Query<Belt_Requirement>(lastQuery).ToList();
                                //dataGridView1.DataSource = clients;
                                connection.Close();
                            }

                            if (BeltCheck[0].BeltReq >= presentStudents[thirdStudentIndex].BeltLvl)
                            {
                                lastQuery =
                            "UPDATE `lil_tkd_belttest_progress` SET `BlocksTID`= " + (presentStudents[thirdStudentIndex].BlocksTID + 1) + " WHERE ClientID = " + presentStudents[thirdStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningBlocks = connection.Query<Student_Info_Blocks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[thirdStudentIndex].BlocksTID++;
                            }
                            else
                            {
                                lilReadyForBeltTest(presentStudents, thirdStudentIndex);
                            }
                            BeltCheck.Clear();
                            MeaningBlocks.Clear();
                        }
                        else if (PageLbl.Text.Equals("Hand Attacks"))
                        {
                            lastQuery =
                            "SELECT BeltReq FROM lil_handatkstid_info WHERE IDHandAtksProgress = " + (presentStudents[thirdStudentIndex].HandAtksTID + 1);

                            using (var connection = new MySqlConnection(sqlConnectionString))
                            {
                                connection.Open();
                                BeltCheck = connection.Query<Belt_Requirement>(lastQuery).ToList();
                                //dataGridView1.DataSource = clients;
                                connection.Close();
                            }

                            if (BeltCheck[0].BeltReq >= presentStudents[thirdStudentIndex].BeltLvl)
                            {
                                lastQuery =
                            "UPDATE `lil_tkd_belttest_progress` SET `HandAtksTID`= " + (presentStudents[thirdStudentIndex].HandAtksTID + 1) + " WHERE ClientID = " + presentStudents[thirdStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningHandAtks = connection.Query<Student_Info_HandAttacks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[thirdStudentIndex].HandAtksTID++;
                            }
                            else
                            {
                                lilReadyForBeltTest(presentStudents, thirdStudentIndex);
                            }
                            BeltCheck.Clear();
                            MeaningHandAtks.Clear();
                        }
                        else if (PageLbl.Text.Equals("Kicks"))
                        {
                            lastQuery =
                            "SELECT BeltReq FROM lil_kickstid_info WHERE IDKicksProgress = " + (presentStudents[thirdStudentIndex].KicksTID + 1);

                            using (var connection = new MySqlConnection(sqlConnectionString))
                            {
                                connection.Open();
                                BeltCheck = connection.Query<Belt_Requirement>(lastQuery).ToList();
                                //dataGridView1.DataSource = clients;
                                connection.Close();
                            }

                            if (BeltCheck[0].BeltReq >= presentStudents[thirdStudentIndex].BeltLvl)
                            {
                                lastQuery =
                            "UPDATE `lil_tkd_belttest_progress` SET `KicksTID`= " + (presentStudents[thirdStudentIndex].KicksTID + 1) + " WHERE ClientID = " + presentStudents[thirdStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningKicks = connection.Query<Student_Info_Kicks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[thirdStudentIndex].KicksTID++;
                            }
                            else
                            {
                                lilReadyForBeltTest(presentStudents, thirdStudentIndex);
                            }
                            BeltCheck.Clear();
                            MeaningKicks.Clear();
                        }
                    }
                    else if (className.Equals("Beginner"))
                    {
                        if (PageLbl.Text.Equals("Forms"))
                        {
                            lastQuery =
                            "SELECT BeltReq FROM adv_formstid_info WHERE IDFormProgress = " + (presentStudents[thirdStudentIndex].FormsTID + 1);

                            using (var connection = new MySqlConnection(sqlConnectionString))
                            {
                                connection.Open();
                                BeltCheck = connection.Query<Belt_Requirement>(lastQuery).ToList();
                                //dataGridView1.DataSource = clients;
                                connection.Close();
                            }

                            if (BeltCheck[0].BeltReq >= presentStudents[thirdStudentIndex].BeltLvl)
                            {
                                lastQuery =
                            "UPDATE `beg_tkd_belttest_progress` SET `FormsTID`= " + (presentStudents[thirdStudentIndex].FormsTID + 1) + " WHERE ClientID = " + presentStudents[thirdStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningForms = connection.Query<Student_Info_Forms>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[thirdStudentIndex].FormsTID++;
                            }
                            else
                            {
                                lilReadyForBeltTest(presentStudents, thirdStudentIndex);
                            }
                            BeltCheck.Clear();
                            MeaningForms.Clear();
                        }
                        else if (PageLbl.Text.Equals("Blocks"))
                        {
                            lastQuery =
                            "SELECT BeltReq FROM adv_blockstid_info WHERE IDBlocksProgress = " + (presentStudents[thirdStudentIndex].BlocksTID + 1);

                            using (var connection = new MySqlConnection(sqlConnectionString))
                            {
                                connection.Open();
                                BeltCheck = connection.Query<Belt_Requirement>(lastQuery).ToList();
                                //dataGridView1.DataSource = clients;
                                connection.Close();
                            }

                            if (BeltCheck[0].BeltReq >= presentStudents[thirdStudentIndex].BeltLvl)
                            {
                                lastQuery =
                            "UPDATE `beg_tkd_belttest_progress` SET `BlocksTID`= " + (presentStudents[thirdStudentIndex].BlocksTID + 1) + " WHERE ClientID = " + presentStudents[thirdStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningBlocks = connection.Query<Student_Info_Blocks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[thirdStudentIndex].BlocksTID++;
                            }
                            else
                            {
                                lilReadyForBeltTest(presentStudents, thirdStudentIndex);
                            }
                            BeltCheck.Clear();
                            MeaningBlocks.Clear();
                        }
                        else if (PageLbl.Text.Equals("Hand Attacks"))
                        {
                            lastQuery =
                            "SELECT BeltReq FROM adv_handatkstid_info WHERE IDHandAtksProgress = " + (presentStudents[thirdStudentIndex].HandAtksTID + 1);

                            using (var connection = new MySqlConnection(sqlConnectionString))
                            {
                                connection.Open();
                                BeltCheck = connection.Query<Belt_Requirement>(lastQuery).ToList();
                                //dataGridView1.DataSource = clients;
                                connection.Close();
                            }

                            if (BeltCheck[0].BeltReq >= presentStudents[thirdStudentIndex].BeltLvl)
                            {
                                lastQuery =
                            "UPDATE `beg_tkd_belttest_progress` SET `HandAtksTID`= " + (presentStudents[thirdStudentIndex].HandAtksTID + 1) + " WHERE ClientID = " + presentStudents[thirdStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningHandAtks = connection.Query<Student_Info_HandAttacks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[thirdStudentIndex].HandAtksTID++;
                            }
                            else
                            {
                                lilReadyForBeltTest(presentStudents, thirdStudentIndex);
                            }
                            BeltCheck.Clear();
                            MeaningHandAtks.Clear();
                        }
                        else if (PageLbl.Text.Equals("Kicks"))
                        {
                            lastQuery =
                            "SELECT BeltReq FROM adv_kickstid_info WHERE IDKicksProgress = " + (presentStudents[thirdStudentIndex].KicksTID + 1);

                            using (var connection = new MySqlConnection(sqlConnectionString))
                            {
                                connection.Open();
                                BeltCheck = connection.Query<Belt_Requirement>(lastQuery).ToList();
                                //dataGridView1.DataSource = clients;
                                connection.Close();
                            }

                            if (BeltCheck[0].BeltReq >= presentStudents[thirdStudentIndex].BeltLvl)
                            {
                                lastQuery =
                            "UPDATE `beg_tkd_belttest_progress` SET `KicksTID`= " + (presentStudents[thirdStudentIndex].KicksTID + 1) + " WHERE ClientID = " + presentStudents[thirdStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningKicks = connection.Query<Student_Info_Kicks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[thirdStudentIndex].KicksTID++;
                            }
                            else
                            {
                                lilReadyForBeltTest(presentStudents, thirdStudentIndex);
                            }
                            BeltCheck.Clear();
                            MeaningKicks.Clear();
                        }
                    }
                    else if (className.Equals("Advanced"))
                    {
                        if (PageLbl.Text.Equals("Forms"))
                        {
                            lastQuery =
                            "SELECT BeltReq FROM adv_formstid_info WHERE IDFormProgress = " + (presentStudents[thirdStudentIndex].FormsTID + 1);

                            using (var connection = new MySqlConnection(sqlConnectionString))
                            {
                                connection.Open();
                                BeltCheck = connection.Query<Belt_Requirement>(lastQuery).ToList();
                                //dataGridView1.DataSource = clients;
                                connection.Close();
                            }

                            if (BeltCheck[0].BeltReq >= presentStudents[thirdStudentIndex].BeltLvl)
                            {
                                lastQuery =
                            "UPDATE `adv_tkd_belttest_progress` SET `FormsTID`= " + (presentStudents[thirdStudentIndex].FormsTID + 1) + " WHERE ClientID = " + presentStudents[thirdStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningForms = connection.Query<Student_Info_Forms>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[thirdStudentIndex].FormsTID++;
                            }
                            else
                            {
                                lilReadyForBeltTest(presentStudents, thirdStudentIndex);
                            }
                            BeltCheck.Clear();
                            MeaningForms.Clear();
                        }
                        else if (PageLbl.Text.Equals("Blocks"))
                        {
                            lastQuery =
                            "SELECT BeltReq FROM adv_blockstid_info WHERE IDBlocksProgress = " + (presentStudents[thirdStudentIndex].BlocksTID + 1);

                            using (var connection = new MySqlConnection(sqlConnectionString))
                            {
                                connection.Open();
                                BeltCheck = connection.Query<Belt_Requirement>(lastQuery).ToList();
                                //dataGridView1.DataSource = clients;
                                connection.Close();
                            }

                            if (BeltCheck[0].BeltReq >= presentStudents[thirdStudentIndex].BeltLvl)
                            {
                                lastQuery =
                            "UPDATE `adv_tkd_belttest_progress` SET `BlocksTID`= " + (presentStudents[thirdStudentIndex].BlocksTID + 1) + " WHERE ClientID = " + presentStudents[thirdStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningBlocks = connection.Query<Student_Info_Blocks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[thirdStudentIndex].BlocksTID++;
                            }
                            else
                            {
                                lilReadyForBeltTest(presentStudents, thirdStudentIndex);
                            }
                            BeltCheck.Clear();
                            MeaningBlocks.Clear();
                        }
                        else if (PageLbl.Text.Equals("Hand Attacks"))
                        {
                            lastQuery =
                            "SELECT BeltReq FROM adv_handatkstid_info WHERE IDHandAtksProgress = " + (presentStudents[thirdStudentIndex].HandAtksTID + 1);

                            using (var connection = new MySqlConnection(sqlConnectionString))
                            {
                                connection.Open();
                                BeltCheck = connection.Query<Belt_Requirement>(lastQuery).ToList();
                                //dataGridView1.DataSource = clients;
                                connection.Close();
                            }

                            if (BeltCheck[0].BeltReq >= presentStudents[thirdStudentIndex].BeltLvl)
                            {
                                lastQuery =
                            "UPDATE `adv_tkd_belttest_progress` SET `HandAtksTID`= " + (presentStudents[thirdStudentIndex].HandAtksTID + 1) + " WHERE ClientID = " + presentStudents[thirdStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningHandAtks = connection.Query<Student_Info_HandAttacks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[thirdStudentIndex].HandAtksTID++;
                            }
                            else
                            {
                                lilReadyForBeltTest(presentStudents, thirdStudentIndex);
                            }
                            BeltCheck.Clear();
                            MeaningHandAtks.Clear();
                        }
                        else if (PageLbl.Text.Equals("Kicks"))
                        {
                            lastQuery =
                            "SELECT BeltReq FROM adv_kickstid_info WHERE IDKicksProgress = " + (presentStudents[thirdStudentIndex].KicksTID + 1);

                            using (var connection = new MySqlConnection(sqlConnectionString))
                            {
                                connection.Open();
                                BeltCheck = connection.Query<Belt_Requirement>(lastQuery).ToList();
                                //dataGridView1.DataSource = clients;
                                connection.Close();
                            }

                            if (BeltCheck[0].BeltReq >= presentStudents[thirdStudentIndex].BeltLvl)
                            {
                                lastQuery =
                            "UPDATE `adv_tkd_belttest_progress` SET `KicksTID`= " + (presentStudents[thirdStudentIndex].KicksTID + 1) + " WHERE ClientID = " + presentStudents[thirdStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningKicks = connection.Query<Student_Info_Kicks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[thirdStudentIndex].KicksTID++;
                            }
                            else
                            {
                                lilReadyForBeltTest(presentStudents, thirdStudentIndex);
                            }
                            BeltCheck.Clear();
                            MeaningKicks.Clear();
                        }
                    }
                }
            }
        }

        public void moveBackFirst()
        {
            if (StudentLbl.Visible)
            {
                DialogResult ans = MessageBox.Show("Does " + presentStudents[firstStudentIndex].FirstName + presentStudents[firstStudentIndex].LastName + " Move Back?", "Student Move Back?", MessageBoxButtons.YesNoCancel);
                if (ans == DialogResult.Yes)
                {
                    if (className.Equals("Lil-Tiger"))
                    {
                        if (PageLbl.Text.Equals("Forms"))
                        {
                            if (presentStudents[firstStudentIndex].FormsTID - 1 == 0)
                                MessageBox.Show("Student at first technique of the Page");
                            else
                            {
                                lastQuery =
                                "UPDATE `lil_tkd_belttest_progress` SET `FormsTID`= " + (presentStudents[firstStudentIndex].FormsTID - 1) + " WHERE ClientID = " + presentStudents[firstStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningForms = connection.Query<Student_Info_Forms>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[firstStudentIndex].FormsTID--;
                                MeaningForms.Clear();
                            }
                        }
                        else if (PageLbl.Text.Equals("Blocks"))
                        {
                            if (presentStudents[firstStudentIndex].BlocksTID - 1 == 0)
                                MessageBox.Show("Student at first technique of the Page");
                            else
                            {
                                lastQuery =
                            "UPDATE `lil_tkd_belttest_progress` SET `BlocksTID`= " + (presentStudents[firstStudentIndex].BlocksTID - 1) + " WHERE ClientID = " + presentStudents[firstStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningBlocks = connection.Query<Student_Info_Blocks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[firstStudentIndex].BlocksTID--;
                                MeaningBlocks.Clear();
                            }
                        }
                        else if (PageLbl.Text.Equals("Hand Attacks"))
                        {
                            if (presentStudents[firstStudentIndex].HandAtksTID - 1 == 0)
                                MessageBox.Show("Student at first technique of the Page");
                            else
                            {
                                lastQuery =
                            "UPDATE `lil_tkd_belttest_progress` SET `HandAtksTID`= " + (presentStudents[firstStudentIndex].HandAtksTID - 1) + " WHERE ClientID = " + presentStudents[firstStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningHandAtks = connection.Query<Student_Info_HandAttacks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[firstStudentIndex].HandAtksTID--;
                                MeaningHandAtks.Clear();
                            }
                        }
                        else if (PageLbl.Text.Equals("Kicks"))
                        {
                            if (presentStudents[firstStudentIndex].KicksTID - 1 == 0)
                                MessageBox.Show("Student at first technique of the Page");
                            else
                            {
                                lastQuery =
                            "UPDATE `lil_tkd_belttest_progress` SET `KicksTID`= " + (presentStudents[firstStudentIndex].KicksTID - 1) + " WHERE ClientID = " + presentStudents[firstStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningKicks = connection.Query<Student_Info_Kicks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[firstStudentIndex].KicksTID--;
                                MeaningKicks.Clear();
                            }
                        }
                    }
                    else if (className.Equals("Beginner"))
                    {
                        if (PageLbl.Text.Equals("Forms"))
                        {
                            if (presentStudents[firstStudentIndex].FormsTID - 1 == 0)
                                MessageBox.Show("Student at first technique of the Page");
                            else
                            {
                                lastQuery =
                            "UPDATE `beg_tkd_belttest_progress` SET `FormsTID`= " + (presentStudents[firstStudentIndex].FormsTID - 1) + " WHERE ClientID = " + presentStudents[firstStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningForms = connection.Query<Student_Info_Forms>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[firstStudentIndex].FormsTID--;
                                MeaningForms.Clear();
                            }
                        }
                        else if (PageLbl.Text.Equals("Blocks"))
                        {
                            if (presentStudents[firstStudentIndex].BlocksTID - 1 == 0)
                                MessageBox.Show("Student at first technique of the Page");
                            else
                            {
                                lastQuery =
                            "UPDATE `beg_tkd_belttest_progress` SET `BlocksTID`= " + (presentStudents[firstStudentIndex].BlocksTID - 1) + " WHERE ClientID = " + presentStudents[firstStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningBlocks = connection.Query<Student_Info_Blocks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[firstStudentIndex].BlocksTID--;
                                MeaningBlocks.Clear();
                            }
                        }
                        else if (PageLbl.Text.Equals("Hand Attacks"))
                        {
                            if (presentStudents[firstStudentIndex].HandAtksTID - 1 == 0)
                                MessageBox.Show("Student at first technique of the Page");
                            else
                            {
                                lastQuery =
                            "UPDATE `beg_tkd_belttest_progress` SET `HandAtksTID`= " + (presentStudents[firstStudentIndex].HandAtksTID - 1) + " WHERE ClientID = " + presentStudents[firstStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningHandAtks = connection.Query<Student_Info_HandAttacks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[firstStudentIndex].HandAtksTID--;
                                MeaningHandAtks.Clear();
                            }
                        }
                        else if (PageLbl.Text.Equals("Kicks"))
                        {
                            if (presentStudents[firstStudentIndex].KicksTID - 1 == 0)
                                MessageBox.Show("Student at first technique of the Page");
                            else
                            {
                                lastQuery =
                            "UPDATE `beg_tkd_belttest_progress` SET `KicksTID`= " + (presentStudents[firstStudentIndex].KicksTID - 1) + " WHERE ClientID = " + presentStudents[firstStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningKicks = connection.Query<Student_Info_Kicks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[firstStudentIndex].KicksTID--;
                                MeaningKicks.Clear();
                            }
                        }
                    }
                    else if (className.Equals("Advanced"))
                    {
                        if (PageLbl.Text.Equals("Forms"))
                        {
                            if (presentStudents[firstStudentIndex].FormsTID - 1 == 0)
                                MessageBox.Show("Student at first technique of the Page");
                            else
                            {
                                lastQuery =
                            "UPDATE `adv_tkd_belttest_progress` SET `FormsTID`= " + (presentStudents[firstStudentIndex].FormsTID - 1) + " WHERE ClientID = " + presentStudents[firstStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningForms = connection.Query<Student_Info_Forms>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[firstStudentIndex].FormsTID--;
                                MeaningForms.Clear();
                            }
                        }
                        else if (PageLbl.Text.Equals("Blocks"))
                        {
                            if (presentStudents[firstStudentIndex].BlocksTID - 1 == 0)
                                MessageBox.Show("Student at first technique of the Page");
                            else
                            {
                                lastQuery =
                                "UPDATE `adv_tkd_belttest_progress` SET `BlocksTID`= " + (presentStudents[firstStudentIndex].BlocksTID - 1) + " WHERE ClientID = " + presentStudents[firstStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningBlocks = connection.Query<Student_Info_Blocks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[firstStudentIndex].BlocksTID--;
                                MeaningBlocks.Clear();
                            }
                        }
                        else if (PageLbl.Text.Equals("Hand Attacks"))
                        {
                            if (presentStudents[firstStudentIndex].HandAtksTID - 1 == 0)
                                MessageBox.Show("Student at first technique of the Page");
                            else
                            {
                                lastQuery =
                                "UPDATE `adv_tkd_belttest_progress` SET `HandAtksTID`= " + (presentStudents[firstStudentIndex].HandAtksTID - 1) + " WHERE ClientID = " + presentStudents[firstStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningHandAtks = connection.Query<Student_Info_HandAttacks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[firstStudentIndex].HandAtksTID--;
                                MeaningHandAtks.Clear();
                            }
                        }
                        else if (PageLbl.Text.Equals("Kicks"))
                        {
                            if (presentStudents[firstStudentIndex].KicksTID - 1 == 0)
                                MessageBox.Show("Student at first technique of the Page");
                            else
                            {
                                lastQuery =
                            "UPDATE `adv_tkd_belttest_progress` SET `KicksTID`= " + (presentStudents[firstStudentIndex].KicksTID - 1) + " WHERE ClientID = " + presentStudents[firstStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningKicks = connection.Query<Student_Info_Kicks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[firstStudentIndex].KicksTID--;
                                MeaningKicks.Clear();
                            }
                        }
                    }
                }

            }
        }

        public void moveBackSecond()
        {
            if (StudentLbl2.Visible)
            {

                DialogResult ans = MessageBox.Show("Does " + presentStudents[secondStudentIndex].FirstName + presentStudents[secondStudentIndex].LastName + " Move Back?", "Student Move Back?", MessageBoxButtons.YesNoCancel);
                if (ans == DialogResult.Yes)
                {
                    if (className.Equals("Lil-Tiger"))
                    {
                        if (PageLbl.Text.Equals("Forms"))
                        {
                            if (presentStudents[secondStudentIndex].FormsTID - 1 == 0)
                                MessageBox.Show("Student at first technique of the Page");
                            else
                            {
                                lastQuery =
                                "UPDATE `lil_tkd_belttest_progress` SET `FormsTID`= " + (presentStudents[secondStudentIndex].FormsTID - 1) + " WHERE ClientID = " + presentStudents[secondStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningForms = connection.Query<Student_Info_Forms>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[secondStudentIndex].FormsTID--;
                                MeaningForms.Clear();
                            }
                        }
                        else if (PageLbl.Text.Equals("Blocks"))
                        {
                            if (presentStudents[secondStudentIndex].BlocksTID - 1 == 0)
                                MessageBox.Show("Student at first technique of the Page");
                            else
                            {
                                lastQuery =
                                "UPDATE `lil_tkd_belttest_progress` SET `BlocksTID`= " + (presentStudents[secondStudentIndex].BlocksTID - 1) + " WHERE ClientID = " + presentStudents[secondStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningBlocks = connection.Query<Student_Info_Blocks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[secondStudentIndex].BlocksTID--;
                                MeaningBlocks.Clear();
                            }
                        }
                        else if (PageLbl.Text.Equals("Hand Attacks"))
                        {
                            if (presentStudents[secondStudentIndex].HandAtksTID - 1 == 0)
                                MessageBox.Show("Student at first technique of the Page");
                            else
                            {
                                lastQuery =
                            "UPDATE `lil_tkd_belttest_progress` SET `HandAtksTID`= " + (presentStudents[secondStudentIndex].HandAtksTID - 1) + " WHERE ClientID = " + presentStudents[secondStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningHandAtks = connection.Query<Student_Info_HandAttacks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[secondStudentIndex].HandAtksTID--;
                                MeaningHandAtks.Clear();
                            }
                        }
                        else if (PageLbl.Text.Equals("Kicks"))
                        {
                            if (presentStudents[secondStudentIndex].KicksTID - 1 == 0)
                                MessageBox.Show("Student at first technique of the Page");
                            else
                            {
                                lastQuery =
                            "UPDATE `lil_tkd_belttest_progress` SET `KicksTID`= " + (presentStudents[secondStudentIndex].KicksTID - 1) + " WHERE ClientID = " + presentStudents[secondStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningKicks = connection.Query<Student_Info_Kicks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[secondStudentIndex].KicksTID--;
                                MeaningKicks.Clear();
                            }
                        }
                    }
                    else if (className.Equals("Beginner"))
                    {
                        if (PageLbl.Text.Equals("Forms"))
                        {
                            if (presentStudents[secondStudentIndex].FormsTID - 1 == 0)
                                MessageBox.Show("Student at first technique of the Page");
                            else
                            {
                                lastQuery =
                            "UPDATE `beg_tkd_belttest_progress` SET `FormsTID`= " + (presentStudents[secondStudentIndex].FormsTID - 1) + " WHERE ClientID = " + presentStudents[secondStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningForms = connection.Query<Student_Info_Forms>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[secondStudentIndex].FormsTID--;
                                MeaningForms.Clear();
                            }
                        }
                        else if (PageLbl.Text.Equals("Blocks"))
                        {
                            if (presentStudents[secondStudentIndex].BlocksTID - 1 == 0)
                                MessageBox.Show("Student at first technique of the Page");
                            else
                            {
                                lastQuery =
                            "UPDATE `beg_tkd_belttest_progress` SET `BlocksTID`= " + (presentStudents[secondStudentIndex].BlocksTID - 1) + " WHERE ClientID = " + presentStudents[secondStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningBlocks = connection.Query<Student_Info_Blocks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[secondStudentIndex].BlocksTID--;
                                MeaningBlocks.Clear();
                            }
                        }
                        else if (PageLbl.Text.Equals("Hand Attacks"))
                        {
                            if (presentStudents[secondStudentIndex].HandAtksTID - 1 == 0)
                                MessageBox.Show("Student at first technique of the Page");
                            else
                            {
                                lastQuery =
                            "UPDATE `beg_tkd_belttest_progress` SET `HandAtksTID`= " + (presentStudents[secondStudentIndex].HandAtksTID - 1) + " WHERE ClientID = " + presentStudents[secondStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningHandAtks = connection.Query<Student_Info_HandAttacks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[secondStudentIndex].HandAtksTID--;
                                MeaningHandAtks.Clear();
                            }
                        }
                        else if (PageLbl.Text.Equals("Kicks"))
                        {
                            if (presentStudents[secondStudentIndex].KicksTID - 1 == 0)
                                MessageBox.Show("Student at first technique of the Page");
                            else
                            {
                                lastQuery =
                            "UPDATE `beg_tkd_belttest_progress` SET `KicksTID`= " + (presentStudents[secondStudentIndex].KicksTID - 1) + " WHERE ClientID = " + presentStudents[secondStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningKicks = connection.Query<Student_Info_Kicks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[secondStudentIndex].KicksTID--;
                                MeaningKicks.Clear();
                            }
                        }
                    }
                    else if (className.Equals("Advanced"))
                    {
                        if (PageLbl.Text.Equals("Forms"))
                        {
                            if (presentStudents[secondStudentIndex].FormsTID - 1 == 0)
                                MessageBox.Show("Student at first technique of the Page");
                            else
                            {
                                lastQuery =
                            "UPDATE `adv_tkd_belttest_progress` SET `FormsTID`= " + (presentStudents[secondStudentIndex].FormsTID - 1) + " WHERE ClientID = " + presentStudents[secondStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningForms = connection.Query<Student_Info_Forms>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[secondStudentIndex].FormsTID--;
                                MeaningForms.Clear();
                            }
                        }
                        else if (PageLbl.Text.Equals("Blocks"))
                        {
                            if (presentStudents[secondStudentIndex].BlocksTID - 1 == 0)
                                MessageBox.Show("Student at first technique of the Page");
                            else
                            {
                                lastQuery =
                            "UPDATE `adv_tkd_belttest_progress` SET `BlocksTID`= " + (presentStudents[secondStudentIndex].BlocksTID - 1) + " WHERE ClientID = " + presentStudents[secondStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningBlocks = connection.Query<Student_Info_Blocks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[secondStudentIndex].BlocksTID--;
                                MeaningBlocks.Clear();
                            }
                        }
                        else if (PageLbl.Text.Equals("Hand Attacks"))
                        {
                            if (presentStudents[secondStudentIndex].HandAtksTID - 1 == 0)
                                MessageBox.Show("Student at first technique of the Page");
                            else
                            {
                                lastQuery =
                            "UPDATE `adv_tkd_belttest_progress` SET `HandAtksTID`= " + (presentStudents[secondStudentIndex].HandAtksTID - 1) + " WHERE ClientID = " + presentStudents[secondStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningHandAtks = connection.Query<Student_Info_HandAttacks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[secondStudentIndex].HandAtksTID--;
                                MeaningHandAtks.Clear();
                            }
                        }
                        else if (PageLbl.Text.Equals("Kicks"))
                        {
                            if (presentStudents[secondStudentIndex].KicksTID - 1 == 0)
                                MessageBox.Show("Student at first technique of the Page");
                            else
                            {
                                lastQuery =
                            "UPDATE `adv_tkd_belttest_progress` SET `KicksTID`= " + (presentStudents[secondStudentIndex].KicksTID - 1) + " WHERE ClientID = " + presentStudents[secondStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningKicks = connection.Query<Student_Info_Kicks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[secondStudentIndex].KicksTID--;
                                MeaningKicks.Clear();
                            }
                        }
                    }
                }
            }
        }

        public void moveBackThird()
        {
            if (StudentLbl3.Visible)
            {

                DialogResult ans = MessageBox.Show("Does " + presentStudents[firstStudentIndex].FirstName + presentStudents[firstStudentIndex].LastName + " Move Back?", "Student Move Back?", MessageBoxButtons.YesNoCancel);
                if (ans == DialogResult.Yes)
                {
                    if (className.Equals("Lil-Tiger"))
                    {
                        if (PageLbl.Text.Equals("Forms"))
                        {
                            if (presentStudents[thirdStudentIndex].FormsTID - 1 == 0)
                                MessageBox.Show("Student at first technique of the Page");
                            else
                            {
                                lastQuery =
                            "UPDATE `lil_tkd_belttest_progress` SET `FormsTID`= " + (presentStudents[thirdStudentIndex].FormsTID - 1) + " WHERE ClientID = " + presentStudents[thirdStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningForms = connection.Query<Student_Info_Forms>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[thirdStudentIndex].FormsTID--;
                                MeaningForms.Clear();
                            }
                        }
                        else if (PageLbl.Text.Equals("Blocks"))
                        {
                            if (presentStudents[thirdStudentIndex].BlocksTID - 1 == 0)
                                MessageBox.Show("Student at first technique of the Page");
                            else
                            {
                                lastQuery =
                            "UPDATE `lil_tkd_belttest_progress` SET `BlocksTID`= " + (presentStudents[thirdStudentIndex].BlocksTID - 1) + " WHERE ClientID = " + presentStudents[thirdStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningBlocks = connection.Query<Student_Info_Blocks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[thirdStudentIndex].BlocksTID--;
                                MeaningBlocks.Clear();
                            }
                        }
                        else if (PageLbl.Text.Equals("Hand Attacks"))
                        {
                            if (presentStudents[thirdStudentIndex].HandAtksTID - 1 == 0)
                                MessageBox.Show("Student at first technique of the Page");
                            else
                            {
                                lastQuery =
                            "UPDATE `lil_tkd_belttest_progress` SET `HandAtksTID`= " + (presentStudents[thirdStudentIndex].HandAtksTID - 1) + " WHERE ClientID = " + presentStudents[thirdStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningHandAtks = connection.Query<Student_Info_HandAttacks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[thirdStudentIndex].HandAtksTID--;
                                MeaningHandAtks.Clear();
                            }
                        }
                        else if (PageLbl.Text.Equals("Kicks"))
                        {
                            if (presentStudents[thirdStudentIndex].KicksTID - 1 == 0)
                                MessageBox.Show("Student at first technique of the Page");
                            else
                            {
                                lastQuery =
                            "UPDATE `lil_tkd_belttest_progress` SET `KicksTID`= " + (presentStudents[thirdStudentIndex].KicksTID - 1) + " WHERE ClientID = " + presentStudents[thirdStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningKicks = connection.Query<Student_Info_Kicks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[thirdStudentIndex].KicksTID--;
                                MeaningKicks.Clear();
                            }
                        }
                    }
                    else if (className.Equals("Beginner"))
                    {
                        if (PageLbl.Text.Equals("Forms"))
                        {
                            if (presentStudents[thirdStudentIndex].FormsTID - 1 == 0)
                                MessageBox.Show("Student at first technique of the Page");
                            else
                            {
                                lastQuery =
                            "UPDATE `beg_tkd_belttest_progress` SET `FormsTID`= " + (presentStudents[thirdStudentIndex].FormsTID - 1) + " WHERE ClientID = " + presentStudents[thirdStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningForms = connection.Query<Student_Info_Forms>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[thirdStudentIndex].FormsTID--;
                                MeaningForms.Clear();
                            }
                        }
                        else if (PageLbl.Text.Equals("Blocks"))
                        {
                            if (presentStudents[thirdStudentIndex].BlocksTID - 1 == 0)
                                MessageBox.Show("Student at first technique of the Page");
                            else
                            {
                                lastQuery =
                            "UPDATE `beg_tkd_belttest_progress` SET `BlocksTID`= " + (presentStudents[thirdStudentIndex].BlocksTID - 1) + " WHERE ClientID = " + presentStudents[thirdStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningBlocks = connection.Query<Student_Info_Blocks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[thirdStudentIndex].BlocksTID--;
                                MeaningBlocks.Clear();
                            }
                        }
                        else if (PageLbl.Text.Equals("Hand Attacks"))
                        {
                            if (presentStudents[thirdStudentIndex].HandAtksTID - 1 == 0)
                                MessageBox.Show("Student at first technique of the Page");
                            else
                            {
                                lastQuery =
                            "UPDATE `beg_tkd_belttest_progress` SET `HandAtksTID`= " + (presentStudents[thirdStudentIndex].HandAtksTID - 1) + " WHERE ClientID = " + presentStudents[thirdStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningHandAtks = connection.Query<Student_Info_HandAttacks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[thirdStudentIndex].HandAtksTID--;
                                MeaningHandAtks.Clear();
                            }
                        }
                        else if (PageLbl.Text.Equals("Kicks"))
                        {
                            if (presentStudents[thirdStudentIndex].KicksTID - 1 == 0)
                                MessageBox.Show("Student at first technique of the Page");
                            else
                            {
                                lastQuery =
                            "UPDATE `beg_tkd_belttest_progress` SET `KicksTID`= " + (presentStudents[thirdStudentIndex].KicksTID - 1) + " WHERE ClientID = " + presentStudents[thirdStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningKicks = connection.Query<Student_Info_Kicks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[thirdStudentIndex].KicksTID--;
                            }
                        }
                    }
                    else if (className.Equals("Advanced"))
                    {
                        if (PageLbl.Text.Equals("Forms"))
                        {
                            if (presentStudents[thirdStudentIndex].FormsTID - 1 == 0)
                                MessageBox.Show("Student at first technique of the Page");
                            else
                            {
                                lastQuery =
                            "UPDATE `adv_tkd_belttest_progress` SET `FormsTID`= " + (presentStudents[thirdStudentIndex].FormsTID - 1) + " WHERE ClientID = " + presentStudents[thirdStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningForms = connection.Query<Student_Info_Forms>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[thirdStudentIndex].FormsTID--;
                                MeaningForms.Clear();
                            }
                        }
                        else if (PageLbl.Text.Equals("Blocks"))
                        {
                            if (presentStudents[thirdStudentIndex].BlocksTID - 1 == 0)
                                MessageBox.Show("Student at first technique of the Page");
                            else
                            {
                                lastQuery =
                            "UPDATE `adv_tkd_belttest_progress` SET `BlocksTID`= " + (presentStudents[thirdStudentIndex].BlocksTID - 1) + " WHERE ClientID = " + presentStudents[thirdStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningBlocks = connection.Query<Student_Info_Blocks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[thirdStudentIndex].BlocksTID--;
                                MeaningBlocks.Clear();
                            }
                        }
                        else if (PageLbl.Text.Equals("Hand Attacks"))
                        {
                            if (presentStudents[thirdStudentIndex].HandAtksTID - 1 == 0)
                                MessageBox.Show("Student at first technique of the Page");
                            else
                            {
                                lastQuery =
                            "UPDATE `adv_tkd_belttest_progress` SET `HandAtksTID`= " + (presentStudents[thirdStudentIndex].HandAtksTID - 1) + " WHERE ClientID = " + presentStudents[thirdStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningHandAtks = connection.Query<Student_Info_HandAttacks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[thirdStudentIndex].HandAtksTID--;
                                MeaningHandAtks.Clear();
                            }
                        }
                        else if (PageLbl.Text.Equals("Kicks"))
                        {
                            if (presentStudents[thirdStudentIndex].KicksTID - 1 == 0)
                                MessageBox.Show("Student at first technique of the Page");
                            else
                            {
                                lastQuery =
                            "UPDATE `adv_tkd_belttest_progress` SET `KicksTID`= " + (presentStudents[thirdStudentIndex].KicksTID - 1) + " WHERE ClientID = " + presentStudents[thirdStudentIndex].ClientID;

                                using (var connection = new MySqlConnection(sqlConnectionString))
                                {
                                    connection.Open();
                                    MeaningKicks = connection.Query<Student_Info_Kicks>(lastQuery).ToList();
                                    //dataGridView1.DataSource = clients;
                                    connection.Close();
                                }
                                presentStudents[thirdStudentIndex].KicksTID--;
                                MeaningKicks.Clear();
                            }
                        }
                    }
                }
            }
        }

        private void NextStudents_Click(object sender, EventArgs e)
        {
            nextStudent();
        }

        private void GoBackStudents_Click(object sender, EventArgs e)
        {
            previousStudent();
        }

        public void hideFirstStudent()
        {
            MoveBack1st.Hide();
            StudentLbl.Hide();
            MoveOn1st.Hide();
        }

        public void showFirstStudent()
        {
            MoveBack1st.Show();
            StudentLbl.Show();
            MoveOn1st.Show();
        }

        public void hideSecondStudent()
        {
            MoveBk2nd.Hide();
            StudentLbl2.Hide();
            MoveOn2nd.Hide();
        }

        public void showSecondStudent()
        {
            MoveBk2nd.Show();
            StudentLbl2.Show();
            MoveOn2nd.Show();
        }

        public void hideThirdStudent()
        {
            MoveBk3rd.Hide();
            StudentLbl3.Hide();
            MoveOn3rd.Hide();
        }

        public void showThirdStudent()
        {
            MoveBk3rd.Show();
            StudentLbl3.Show();
            MoveOn3rd.Show();
        }

        public void initStudents()
        {
            if (presentStudents.Count > 0)
            {
                getProgressInfo();
            }
        }

        private void MoveOn1st_Click(object sender, EventArgs e)
        {
            moveOnFirst();
        }

        private void MoveBack1st_Click(object sender, EventArgs e)
        {
            moveBackFirst();
        }

        private void MoveOn2nd_Click(object sender, EventArgs e)
        {
            moveOnSecond();
        }

        private void MoveBk2nd_Click(object sender, EventArgs e)
        {
            moveBackSecond();
        }

        private void MoveBk3rd_Click(object sender, EventArgs e)
        {
            moveBackThird();
        }

        private void MoveOn3rd_Click(object sender, EventArgs e)
        {
            moveOnThird();
        }

        private void AddStudentBtn_Click(object sender, EventArgs e)
        {
            if(notPresentList.SelectedItem == null)
            {
                MessageBox.Show("No Student Selected");
            }
            else
            {
                string[] tokens = notPresentList.SelectedItem.ToString().Split('.');
                int retvet = Int32.Parse(tokens[0]);
                for(int i = 0; i < students.Count(); i++)
                {
                    if(students[i].ClientID == retvet)
                    {
                        presentStudents.Add(students[i]);
                        MessageBox.Show(students[i].FirstName + " " + students[i].LastName + " Added to the class!");
                        notPresentList.Items.Remove(notPresentList.SelectedItem);
                        notPresentList.SelectedIndex = -1;
                    }
                }
            }
        }

        private void EndClass_Click(object sender, EventArgs e)
        {
            DateTime localDate = DateTime.Now;
            if(className.Equals("Lil-Tiger"))
                lastQuery = "UPDATE `last_class_time_stamp` SET `DateTime`= '" + localDate.ToString() + "', `Page` = '" + pages[pageIndex] + "' WHERE Class = 'Lil-Tiger'";
            else if(className.Equals("Beginner"))
                lastQuery = "UPDATE `last_class_time_stamp` SET `DateTime`= '" + localDate.ToString() + "', `Page` = '" + pages[pageIndex] + "' WHERE Class = 'Beginner'";
            else if(className.Equals("Advanced"))
                lastQuery = "UPDATE `last_class_time_stamp` SET `DateTime`= '" + localDate.ToString() + "', `Page` = '" + pages[pageIndex] + "' WHERE Class = 'Advanced'";

            MessageBox.Show(localDate.ToString());

            using (var connection = new MySqlConnection(sqlConnectionString))
            {
                connection.Open();
                connection.Query(lastQuery).ToList();
                //dataGridView1.DataSource = clients;
                connection.Close();
            }

            clearRoster();

            SendMessage(this.Handle, WM_SETREDRAW, false, 0);

            StartClass UPF_SC = new StartClass();
            UPF_SC.Show();
            //Visible = false;

            SendMessage(this.Handle, WM_SETREDRAW, true, 0);
            this.Hide();
        }

        private void clearRoster()
        {
            lastQuery = "UPDATE `lil_tkd_belttest_progress` SET `Present`= 0 WHERE 1";

            using (var connection = new MySqlConnection(sqlConnectionString))
            {
                connection.Open();
                connection.Query(lastQuery);

                lastQuery = "UPDATE `beg_tkd_belttest_progress` SET `Present`= 0 WHERE 1";

                connection.Query(lastQuery);

                lastQuery = "UPDATE `adv_tkd_belttest_progress` SET `Present`= 0 WHERE 1";

                connection.Query(lastQuery);
                connection.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReviewFirst_Click(object sender, EventArgs e)
        {
            if(StudentLbl.Visible)
            {
                DialogResult ans = MessageBox.Show("Remove " + presentStudents[firstStudentIndex].FirstName + " " + presentStudents[firstStudentIndex].LastName + " from belt test on " +
                pages[pageIndex] + " page?", "Remove From Test List", MessageBoxButtons.YesNoCancel);

                if (ans == DialogResult.Yes)
                {
                    MessageBox.Show("Answer is yes");
                    if (className.Equals("Lil-Tiger"))
                    {
                        MessageBox.Show("Class is lil tigers?");
                        if (pageIndex == 0)
                        {
                            MessageBox.Show("index is 0?");
                            lastQuery =
                                "UPDATE `lil_test_ready` SET `FormsRdy` = 0 WHERE ClientID = " + presentStudents[firstStudentIndex].ClientID;
                            notReadyForBeltTest(presentStudents[firstStudentIndex].FirstName, lastQuery);
                        }
                        else if (pageIndex == 1)
                        {
                            lastQuery =
                                "UPDATE `lil_test_ready` SET `BlocksRdy` = 0 WHERE ClientID = " + presentStudents[firstStudentIndex].ClientID;
                            notReadyForBeltTest(presentStudents[firstStudentIndex].FirstName, lastQuery);
                        }
                        else if (pageIndex == 2)
                        {
                            lastQuery =
                                "UPDATE `lil_test_ready` SET `HandAtksRdy` = 0 WHERE ClientID = " + presentStudents[firstStudentIndex].ClientID;
                            notReadyForBeltTest(presentStudents[firstStudentIndex].FirstName, lastQuery);
                        }
                        else if (pageIndex == 3)
                        {
                            lastQuery =
                                "UPDATE `lil_test_ready` SET `KicksRdy` = 0 WHERE ClientID = " + presentStudents[firstStudentIndex].ClientID;
                            notReadyForBeltTest(presentStudents[firstStudentIndex].FirstName, lastQuery);
                        }
                    }
                    else if (className.Equals("Beginner"))
                    {
                        if (pageIndex == 0)
                        {
                            lastQuery =
                                "UPDATE `beg_test_ready` SET `FormsRdy` = 0 WHERE ClientID = " + presentStudents[firstStudentIndex].ClientID;
                            notReadyForBeltTest(presentStudents[firstStudentIndex].FirstName, lastQuery);
                        }
                        else if (pageIndex == 1)
                        {
                            lastQuery =
                                "UPDATE `beg_test_ready` SET `BlocksRdy` = 0 WHERE ClientID = " + presentStudents[firstStudentIndex].ClientID;
                            notReadyForBeltTest(presentStudents[firstStudentIndex].FirstName, lastQuery);
                        }
                        else if (pageIndex == 2)
                        {
                            lastQuery =
                                "UPDATE `beg_test_ready` SET `HandAtksRdy` = 0 WHERE ClientID = " + presentStudents[firstStudentIndex].ClientID;
                            notReadyForBeltTest(presentStudents[firstStudentIndex].FirstName, lastQuery);
                        }
                        else if (pageIndex == 3)
                        {
                            lastQuery =
                                "UPDATE `beg_test_ready` SET `KicksRdy` = 0 WHERE ClientID = " + presentStudents[firstStudentIndex].ClientID;
                            notReadyForBeltTest(presentStudents[firstStudentIndex].FirstName, lastQuery);
                        }
                    }
                    else if (className.Equals("Advanced"))
                    {
                        if (pageIndex == 0)
                        {
                            lastQuery =
                                "UPDATE `adv_test_ready` SET `FormsRdy` = 0 WHERE ClientID = " + presentStudents[firstStudentIndex].ClientID;
                            notReadyForBeltTest(presentStudents[firstStudentIndex].FirstName, lastQuery);
                        }
                        else if (pageIndex == 1)
                        {
                            lastQuery =
                                "UPDATE `adv_test_ready` SET `BlocksRdy` = 0 WHERE ClientID = " + presentStudents[firstStudentIndex].ClientID;
                            notReadyForBeltTest(presentStudents[firstStudentIndex].FirstName, lastQuery);
                        }
                        else if (pageIndex == 2)
                        {
                            lastQuery =
                                "UPDATE `adv_test_ready` SET `HandAtksRdy` = 0 WHERE ClientID = " + presentStudents[firstStudentIndex].ClientID;
                            notReadyForBeltTest(presentStudents[firstStudentIndex].FirstName, lastQuery);

                        }
                        else if (pageIndex == 3)
                        {
                            lastQuery =
                                "UPDATE `adv_test_ready` SET `KicksRdy` = 0 WHERE ClientID = " + presentStudents[firstStudentIndex].ClientID;
                            notReadyForBeltTest(presentStudents[firstStudentIndex].FirstName, lastQuery);
                        }
                    }



                }
            }
            
        }

        private void ReviewSecond_Click(object sender, EventArgs e)
        {
            if (StudentLbl2.Visible)
            {


                DialogResult ans = MessageBox.Show("Remove " + presentStudents[secondStudentIndex].FirstName + " " + presentStudents[secondStudentIndex].LastName + " from belt test on " +
                   pages[pageIndex] + " page?", "Remove From Test List", MessageBoxButtons.YesNoCancel);

                if (ans == DialogResult.Yes)
                {
                    if (className.Equals("Lil-Tiger"))
                    {
                        if (pageIndex == 0)
                        {
                            lastQuery =
                                "UPDATE `lil_test_ready` SET `FormsRdy` = 0 WHERE ClientID = " + presentStudents[secondStudentIndex].ClientID;
                            notReadyForBeltTest(presentStudents[secondStudentIndex].FirstName, lastQuery);
                        }
                        else if (pageIndex == 1)
                        {
                            lastQuery =
                                "UPDATE `lil_test_ready` SET `BlocksRdy` = 0 WHERE ClientID = " + presentStudents[secondStudentIndex].ClientID;
                            notReadyForBeltTest(presentStudents[secondStudentIndex].FirstName, lastQuery);
                        }
                        else if (pageIndex == 2)
                        {
                            lastQuery =
                                "UPDATE `lil_test_ready` SET `HandAtksRdy` = 0 WHERE ClientID = " + presentStudents[secondStudentIndex].ClientID;
                            notReadyForBeltTest(presentStudents[secondStudentIndex].FirstName, lastQuery);
                        }
                        else if (pageIndex == 3)
                        {
                            lastQuery =
                                "UPDATE `lil_test_ready` SET `KicksRdy` = 0 WHERE ClientID = " + presentStudents[secondStudentIndex].ClientID;
                            notReadyForBeltTest(presentStudents[secondStudentIndex].FirstName, lastQuery);
                        }
                    }
                    else if (className.Equals("Beginner"))
                    {
                        if (pageIndex == 0)
                        {
                            lastQuery =
                                "UPDATE `beg_test_ready` SET `FormsRdy` = 0 WHERE ClientID = " + presentStudents[secondStudentIndex].ClientID;
                            notReadyForBeltTest(presentStudents[secondStudentIndex].FirstName, lastQuery);
                        }
                        else if (pageIndex == 1)
                        {
                            lastQuery =
                                "UPDATE `beg_test_ready` SET `BlocksRdy` = 0 WHERE ClientID = " + presentStudents[secondStudentIndex].ClientID;
                            notReadyForBeltTest(presentStudents[secondStudentIndex].FirstName, lastQuery);
                        }
                        else if (pageIndex == 2)
                        {
                            lastQuery =
                                "UPDATE `beg_test_ready` SET `HandAtksRdy` = 0 WHERE ClientID = " + presentStudents[secondStudentIndex].ClientID;
                            notReadyForBeltTest(presentStudents[secondStudentIndex].FirstName, lastQuery);
                        }
                        else if (pageIndex == 3)
                        {
                            lastQuery =
                                "UPDATE `beg_test_ready` SET `KicksRdy` = 0 WHERE ClientID = " + presentStudents[secondStudentIndex].ClientID;
                            notReadyForBeltTest(presentStudents[secondStudentIndex].FirstName, lastQuery);
                        }
                    }
                    else if (className.Equals("Advanced"))
                    {
                        if (pageIndex == 0)
                        {
                            lastQuery =
                                "UPDATE `adv_test_ready` SET `FormsRdy` = 0 WHERE ClientID = " + presentStudents[secondStudentIndex].ClientID;
                            notReadyForBeltTest(presentStudents[secondStudentIndex].FirstName, lastQuery);
                        }
                        else if (pageIndex == 1)
                        {
                            lastQuery =
                                "UPDATE `adv_test_ready` SET `BlocksRdy` = 0 WHERE ClientID = " + presentStudents[secondStudentIndex].ClientID;
                            notReadyForBeltTest(presentStudents[secondStudentIndex].FirstName, lastQuery);
                        }
                        else if (pageIndex == 2)
                        {
                            lastQuery =
                                "UPDATE `adv_test_ready` SET `HandAtksRdy` = 0 WHERE ClientID = " + presentStudents[secondStudentIndex].ClientID;
                            notReadyForBeltTest(presentStudents[secondStudentIndex].FirstName, lastQuery);

                        }
                        else if (pageIndex == 3)
                        {
                            lastQuery =
                                "UPDATE `adv_test_ready` SET `KicksRdy` = 0 WHERE ClientID = " + presentStudents[secondStudentIndex].ClientID;
                            notReadyForBeltTest(presentStudents[secondStudentIndex].FirstName, lastQuery);
                        }
                    }
                }
            }
        }

        private void ReviewThird_Click(object sender, EventArgs e)
        {
            if (StudentLbl3.Visible)
            {
                DialogResult ans = MessageBox.Show("Remove " + presentStudents[thirdStudentIndex].FirstName + " " + presentStudents[thirdStudentIndex].LastName + " from belt test on " +
                   pages[pageIndex] + " page?", "Remove From Test List", MessageBoxButtons.YesNoCancel);

                if (ans == DialogResult.Yes)
                {
                    if (className.Equals("Lil-Tiger"))
                    {
                        if (pageIndex == 0)
                        {
                            lastQuery =
                                "UPDATE `lil_test_ready` SET `FormsRdy` = 0 WHERE ClientID = " + presentStudents[thirdStudentIndex].ClientID;
                            notReadyForBeltTest(presentStudents[thirdStudentIndex].FirstName, lastQuery);
                        }
                        else if (pageIndex == 1)
                        {
                            lastQuery =
                                "UPDATE `lil_test_ready` SET `BlocksRdy` = 0 WHERE ClientID = " + presentStudents[thirdStudentIndex].ClientID;
                            notReadyForBeltTest(presentStudents[thirdStudentIndex].FirstName, lastQuery);
                        }
                        else if (pageIndex == 2)
                        {
                            lastQuery =
                                "UPDATE `lil_test_ready` SET `HandAtksRdy` = 0 WHERE ClientID = " + presentStudents[thirdStudentIndex].ClientID;
                            notReadyForBeltTest(presentStudents[thirdStudentIndex].FirstName, lastQuery);
                        }
                        else if (pageIndex == 3)
                        {
                            lastQuery =
                                "UPDATE `lil_test_ready` SET `KicksRdy` = 0 WHERE ClientID = " + presentStudents[thirdStudentIndex].ClientID;
                            notReadyForBeltTest(presentStudents[thirdStudentIndex].FirstName, lastQuery);
                        }
                    }
                    else if (className.Equals("Beginner"))
                    {
                        if (pageIndex == 0)
                        {
                            lastQuery =
                                "UPDATE `beg_test_ready` SET `FormsRdy` = 0 WHERE ClientID = " + presentStudents[thirdStudentIndex].ClientID;
                            notReadyForBeltTest(presentStudents[thirdStudentIndex].FirstName, lastQuery);
                        }
                        else if (pageIndex == 1)
                        {
                            lastQuery =
                                "UPDATE `beg_test_ready` SET `BlocksRdy` = 0 WHERE ClientID = " + presentStudents[thirdStudentIndex].ClientID;
                            notReadyForBeltTest(presentStudents[thirdStudentIndex].FirstName, lastQuery);
                        }
                        else if (pageIndex == 2)
                        {
                            lastQuery =
                                "UPDATE `beg_test_ready` SET `HandAtksRdy` = 0 WHERE ClientID = " + presentStudents[thirdStudentIndex].ClientID;
                            notReadyForBeltTest(presentStudents[thirdStudentIndex].FirstName, lastQuery);
                        }
                        else if (pageIndex == 3)
                        {
                            lastQuery =
                                "UPDATE `beg_test_ready` SET `KicksRdy` = 0 WHERE ClientID = " + presentStudents[thirdStudentIndex].ClientID;
                            notReadyForBeltTest(presentStudents[thirdStudentIndex].FirstName, lastQuery);
                        }
                    }
                    else if (className.Equals("Advanced"))
                    {
                        if (pageIndex == 0)
                        {
                            lastQuery =
                                "UPDATE `adv_test_ready` SET `FormsRdy` = 0 WHERE ClientID = " + presentStudents[thirdStudentIndex].ClientID;
                            notReadyForBeltTest(presentStudents[thirdStudentIndex].FirstName, lastQuery);
                        }
                        else if (pageIndex == 1)
                        {
                            lastQuery =
                                "UPDATE `adv_test_ready` SET `BlocksRdy` = 0 WHERE ClientID = " + presentStudents[thirdStudentIndex].ClientID;
                            notReadyForBeltTest(presentStudents[thirdStudentIndex].FirstName, lastQuery);
                        }
                        else if (pageIndex == 2)
                        {
                            lastQuery =
                                "UPDATE `adv_test_ready` SET `HandAtksRdy` = 0 WHERE ClientID = " + presentStudents[thirdStudentIndex].ClientID;
                            notReadyForBeltTest(presentStudents[thirdStudentIndex].FirstName, lastQuery);

                        }
                        else if (pageIndex == 3)
                        {
                            lastQuery =
                                "UPDATE `adv_test_ready` SET `KicksRdy` = 0 WHERE ClientID = " + presentStudents[thirdStudentIndex].ClientID;
                            notReadyForBeltTest(presentStudents[thirdStudentIndex].FirstName, lastQuery);
                        }
                    }
                }
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (pageIndex < pages.Count() - 1)
            {
                DialogResult nextPage = MessageBox.Show("Do you want to move to the " + pages[pageIndex + 1] + " Page?", "Next Page?", MessageBoxButtons.YesNoCancel);
                if (nextPage == DialogResult.Yes)
                {
                    pageIndex++;
                    initNextPage();
                }
            }
            else
            {
                DialogResult nextPage = MessageBox.Show("Do you want to move to the " + pages[0] + " Page?", "Next Page?", MessageBoxButtons.YesNoCancel);
                if (nextPage == DialogResult.Yes)
                {
                    pageIndex = 0;
                    initNextPage();
                }
            }
        }

        private void BackOnePage_Click(object sender, EventArgs e)
        {
            if (pageIndex > 0)
            {
                DialogResult nextPage = MessageBox.Show("Do you want to move to the " + pages[pageIndex - 1] + " Page?", "Previous Page?", MessageBoxButtons.YesNoCancel);
                if (nextPage == DialogResult.Yes)
                {
                    pageIndex--;
                    initNextPage();
                }
            }
            else
            {
                DialogResult nextPage = MessageBox.Show("Do you want to move to the " + pages[pages.Count() - 1] + " Page?", "Previous Page?", MessageBoxButtons.YesNoCancel);
                if (nextPage == DialogResult.Yes)
                {
                    pageIndex = pages.Count() - 1;
                    initNextPage();
                }
            }
        }

        /*private void MoveBk2nd_Click(object sender, EventArgs e)
        {
            move
        }*/
    }
}
