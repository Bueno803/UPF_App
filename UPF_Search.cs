using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace UPF_App
{
    public partial class UPF_Search : Form
    {
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

        private void button3_Click(object sender, EventArgs e)
        {
            SendMessage(this.Handle, WM_SETREDRAW, false, 0);

            Form1 UPF_SU = new Form1();
            UPF_SU.Show();
            Visible = false;

            SendMessage(this.Handle, WM_SETREDRAW, true, 0);
            this.Refresh();
        }
    }
}