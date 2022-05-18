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

namespace UPF_App
{
    public partial class Form1 : Form
    {
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
    }
}