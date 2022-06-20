
namespace UPF_App
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.FirstNameTxt = new System.Windows.Forms.TextBox();
            this.MiddleNameTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LastNameTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PhoneNumTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.HomeNumTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.EmailTxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_StreetAddy = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_CityAddy = new System.Windows.Forms.TextBox();
            this.txt_ZipAddy = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BackToHP = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ClientComboBx = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.GenderComboBx = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.LocationTxt = new System.Windows.Forms.TextBox();
            this.StateComboBx = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.topPanel = new System.Windows.Forms.Panel();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.addClientBtn = new UPF_App.RoundedButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Name = "label1";
            // 
            // FirstNameTxt
            // 
            resources.ApplyResources(this.FirstNameTxt, "FirstNameTxt");
            this.FirstNameTxt.Name = "FirstNameTxt";
            this.FirstNameTxt.TextChanged += new System.EventHandler(this.FirstNameTxt_TextChanged);
            // 
            // MiddleNameTxt
            // 
            resources.ApplyResources(this.MiddleNameTxt, "MiddleNameTxt");
            this.MiddleNameTxt.Name = "MiddleNameTxt";
            this.MiddleNameTxt.TextChanged += new System.EventHandler(this.MiddleNameTxt_TextChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Name = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // LastNameTxt
            // 
            resources.ApplyResources(this.LastNameTxt, "LastNameTxt");
            this.LastNameTxt.Name = "LastNameTxt";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Name = "label3";
            // 
            // PhoneNumTxt
            // 
            resources.ApplyResources(this.PhoneNumTxt, "PhoneNumTxt");
            this.PhoneNumTxt.Name = "PhoneNumTxt";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Name = "label4";
            // 
            // HomeNumTxt
            // 
            resources.ApplyResources(this.HomeNumTxt, "HomeNumTxt");
            this.HomeNumTxt.Name = "HomeNumTxt";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Name = "label5";
            // 
            // EmailTxt
            // 
            resources.ApplyResources(this.EmailTxt, "EmailTxt");
            this.EmailTxt.Name = "EmailTxt";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Name = "label6";
            // 
            // txt_StreetAddy
            // 
            resources.ApplyResources(this.txt_StreetAddy, "txt_StreetAddy");
            this.txt_StreetAddy.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txt_StreetAddy.Name = "txt_StreetAddy";
            this.txt_StreetAddy.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            this.txt_StreetAddy.Enter += new System.EventHandler(this.streetAddy_enter);
            this.txt_StreetAddy.Leave += new System.EventHandler(this.streetAddy_leave);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Name = "label7";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // txt_CityAddy
            // 
            resources.ApplyResources(this.txt_CityAddy, "txt_CityAddy");
            this.txt_CityAddy.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txt_CityAddy.Name = "txt_CityAddy";
            this.txt_CityAddy.Enter += new System.EventHandler(this.cityAddy_enter);
            this.txt_CityAddy.Leave += new System.EventHandler(this.cityAddy_Leave);
            // 
            // txt_ZipAddy
            // 
            resources.ApplyResources(this.txt_ZipAddy, "txt_ZipAddy");
            this.txt_ZipAddy.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txt_ZipAddy.Name = "txt_ZipAddy";
            this.txt_ZipAddy.TextChanged += new System.EventHandler(this.textBox10_TextChanged);
            this.txt_ZipAddy.Enter += new System.EventHandler(this.zipAddy_enter);
            this.txt_ZipAddy.Leave += new System.EventHandler(this.zipAddy_leave);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Name = "label8";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.Name = "label9";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(46)))), ((int)(((byte)(144)))));
            this.panel1.Controls.Add(this.BackToHP);
            this.panel1.Controls.Add(this.exitBtn);
            this.panel1.Controls.Add(this.SearchBtn);
            this.panel1.Controls.Add(this.pictureBox1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // BackToHP
            // 
            resources.ApplyResources(this.BackToHP, "BackToHP");
            this.BackToHP.FlatAppearance.BorderSize = 0;
            this.BackToHP.ForeColor = System.Drawing.SystemColors.Control;
            this.BackToHP.Name = "BackToHP";
            this.BackToHP.UseVisualStyleBackColor = true;
            this.BackToHP.Click += new System.EventHandler(this.BackToHP_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.Firebrick;
            resources.ApplyResources(this.exitBtn, "exitBtn");
            this.exitBtn.FlatAppearance.BorderSize = 0;
            this.exitBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.UseVisualStyleBackColor = false;
            this.exitBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // SearchBtn
            // 
            resources.ApplyResources(this.SearchBtn, "SearchBtn");
            this.SearchBtn.FlatAppearance.BorderSize = 0;
            this.SearchBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label10.Name = "label10";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // ClientComboBx
            // 
            this.ClientComboBx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClientComboBx.FormattingEnabled = true;
            this.ClientComboBx.Items.AddRange(new object[] {
            resources.GetString("ClientComboBx.Items"),
            resources.GetString("ClientComboBx.Items1"),
            resources.GetString("ClientComboBx.Items2"),
            resources.GetString("ClientComboBx.Items3")});
            resources.ApplyResources(this.ClientComboBx, "ClientComboBx");
            this.ClientComboBx.Name = "ClientComboBx";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.ForeColor = System.Drawing.SystemColors.Control;
            this.label11.Name = "label11";
            // 
            // GenderComboBx
            // 
            this.GenderComboBx.FormattingEnabled = true;
            this.GenderComboBx.Items.AddRange(new object[] {
            resources.GetString("GenderComboBx.Items"),
            resources.GetString("GenderComboBx.Items1")});
            resources.ApplyResources(this.GenderComboBx, "GenderComboBx");
            this.GenderComboBx.Name = "GenderComboBx";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.ForeColor = System.Drawing.SystemColors.Control;
            this.label12.Name = "label12";
            // 
            // LocationTxt
            // 
            resources.ApplyResources(this.LocationTxt, "LocationTxt");
            this.LocationTxt.Name = "LocationTxt";
            // 
            // StateComboBx
            // 
            resources.ApplyResources(this.StateComboBx, "StateComboBx");
            this.StateComboBx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StateComboBx.FormattingEnabled = true;
            this.StateComboBx.Items.AddRange(new object[] {
            resources.GetString("StateComboBx.Items"),
            resources.GetString("StateComboBx.Items1"),
            resources.GetString("StateComboBx.Items2"),
            resources.GetString("StateComboBx.Items3"),
            resources.GetString("StateComboBx.Items4"),
            resources.GetString("StateComboBx.Items5"),
            resources.GetString("StateComboBx.Items6"),
            resources.GetString("StateComboBx.Items7"),
            resources.GetString("StateComboBx.Items8"),
            resources.GetString("StateComboBx.Items9"),
            resources.GetString("StateComboBx.Items10"),
            resources.GetString("StateComboBx.Items11"),
            resources.GetString("StateComboBx.Items12"),
            resources.GetString("StateComboBx.Items13"),
            resources.GetString("StateComboBx.Items14"),
            resources.GetString("StateComboBx.Items15"),
            resources.GetString("StateComboBx.Items16"),
            resources.GetString("StateComboBx.Items17"),
            resources.GetString("StateComboBx.Items18"),
            resources.GetString("StateComboBx.Items19"),
            resources.GetString("StateComboBx.Items20"),
            resources.GetString("StateComboBx.Items21"),
            resources.GetString("StateComboBx.Items22"),
            resources.GetString("StateComboBx.Items23"),
            resources.GetString("StateComboBx.Items24"),
            resources.GetString("StateComboBx.Items25"),
            resources.GetString("StateComboBx.Items26"),
            resources.GetString("StateComboBx.Items27"),
            resources.GetString("StateComboBx.Items28"),
            resources.GetString("StateComboBx.Items29"),
            resources.GetString("StateComboBx.Items30"),
            resources.GetString("StateComboBx.Items31"),
            resources.GetString("StateComboBx.Items32"),
            resources.GetString("StateComboBx.Items33"),
            resources.GetString("StateComboBx.Items34"),
            resources.GetString("StateComboBx.Items35"),
            resources.GetString("StateComboBx.Items36"),
            resources.GetString("StateComboBx.Items37"),
            resources.GetString("StateComboBx.Items38"),
            resources.GetString("StateComboBx.Items39"),
            resources.GetString("StateComboBx.Items40"),
            resources.GetString("StateComboBx.Items41"),
            resources.GetString("StateComboBx.Items42"),
            resources.GetString("StateComboBx.Items43"),
            resources.GetString("StateComboBx.Items44"),
            resources.GetString("StateComboBx.Items45"),
            resources.GetString("StateComboBx.Items46"),
            resources.GetString("StateComboBx.Items47"),
            resources.GetString("StateComboBx.Items48"),
            resources.GetString("StateComboBx.Items49")});
            this.StateComboBx.Name = "StateComboBx";
            // 
            // dateTimePicker1
            // 
            resources.ApplyResources(this.dateTimePicker1, "dateTimePicker1");
            this.dateTimePicker1.Name = "dateTimePicker1";
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(32)))), ((int)(((byte)(102)))));
            this.topPanel.Controls.Add(this.CloseBtn);
            resources.ApplyResources(this.topPanel, "topPanel");
            this.topPanel.Name = "topPanel";
            this.topPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.topPanel_Paint);
            this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseDown);
            // 
            // CloseBtn
            // 
            resources.ApplyResources(this.CloseBtn, "CloseBtn");
            this.CloseBtn.FlatAppearance.BorderSize = 0;
            this.CloseBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
            this.CloseBtn.ForeColor = System.Drawing.Color.Snow;
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // addClientBtn
            // 
            this.addClientBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.addClientBtn.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            resources.ApplyResources(this.addClientBtn, "addClientBtn");
            this.addClientBtn.BorderColor = System.Drawing.Color.Transparent;
            this.addClientBtn.BorderRadius = 25;
            this.addClientBtn.BorderSize = 0;
            this.addClientBtn.FlatAppearance.BorderSize = 0;
            this.addClientBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.addClientBtn.Name = "addClientBtn";
            this.addClientBtn.TextColor = System.Drawing.SystemColors.Control;
            this.addClientBtn.UseVisualStyleBackColor = false;
            this.addClientBtn.Click += new System.EventHandler(this.addClientBtn_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(75)))), ((int)(((byte)(150)))));
            this.Controls.Add(this.addClientBtn);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.StateComboBx);
            this.Controls.Add(this.LocationTxt);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.GenderComboBx);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.ClientComboBx);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_ZipAddy);
            this.Controls.Add(this.txt_CityAddy);
            this.Controls.Add(this.txt_StreetAddy);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.EmailTxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.HomeNumTxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PhoneNumTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LastNameTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MiddleNameTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FirstNameTxt);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FirstNameTxt;
        private System.Windows.Forms.TextBox MiddleNameTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LastNameTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PhoneNumTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox HomeNumTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox EmailTxt;
        private System.Windows.Forms.Label label6;

        private System.Windows.Forms.TextBox txt_StreetAddy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_CityAddy;
        private System.Windows.Forms.TextBox txt_ZipAddy;

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.ComboBox ClientComboBx;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox GenderComboBx;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox LocationTxt;
        private System.Windows.Forms.ComboBox StateComboBx;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button BackToHP;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button CloseBtn;
        private RoundedButton addClientBtn;
    }
}

