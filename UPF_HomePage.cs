﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace UPF_App
{
    public partial class UPF_HomePage : Form

    {
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



        public UPF_HomePage()
        {
            InitializeComponent();
            //Applying rounded edges
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void addClientBtn_Click(object sender, EventArgs e)
        {
            SendMessage(this.Handle, WM_SETREDRAW, false, 0);

            Form1 UPF_SU = new Form1();
            UPF_SU.Show();
            //Visible = false;

            SendMessage(this.Handle, WM_SETREDRAW, true, 0);
            this.Refresh();
            Hide();
        }
        private void updateBtn_Click(object sender, EventArgs e)
        {
            //TO DO: Change when update page is made

            UPF_Search UPF_S = new UPF_Search();
            UPF_S.Show();

            SendMessage(this.Handle, WM_SETREDRAW, true, 0);
            this.Refresh();
            Hide();
        }
        private void srchBtn_Click(object sender, EventArgs e)
        {
            SendMessage(this.Handle, WM_SETREDRAW, false, 0);

            UPF_Search UPF_S = new UPF_Search();
            UPF_S.Show();

            SendMessage(this.Handle, WM_SETREDRAW, true, 0);
            this.Refresh();
            Hide();

        }
        private void closeBtn_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
