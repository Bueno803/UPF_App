namespace UPF_App
{
    partial class UPF_HomePage
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UPF_HomePage));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.topPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.updateBtn = new UPF_App.RoundedButton();
            this.srchBtn = new UPF_App.RoundedButton();
            this.addClientBtn = new UPF_App.RoundedButton();
            this.closeBtn = new UPF_App.RoundedButton();
            this.StartClass = new UPF_App.RoundedButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(162, 59);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(792, 321);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(32)))), ((int)(((byte)(102)))));
            this.topPanel.Controls.Add(this.button1);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1115, 28);
            this.topPanel.TabIndex = 41;
            this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseDown);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.button1.ForeColor = System.Drawing.Color.Snow;
            this.button1.Location = new System.Drawing.Point(1058, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 28);
            this.button1.TabIndex = 42;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.updateBtn.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.updateBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("updateBtn.BackgroundImage")));
            this.updateBtn.BorderColor = System.Drawing.Color.Transparent;
            this.updateBtn.BorderRadius = 25;
            this.updateBtn.BorderSize = 0;
            this.updateBtn.FlatAppearance.BorderSize = 0;
            this.updateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateBtn.Font = new System.Drawing.Font("Nirmala UI", 20F);
            this.updateBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.updateBtn.Location = new System.Drawing.Point(331, 400);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(254, 93);
            this.updateBtn.TabIndex = 14;
            this.updateBtn.Text = "Class Schedule";
            this.updateBtn.TextColor = System.Drawing.SystemColors.Control;
            this.updateBtn.UseVisualStyleBackColor = false;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // srchBtn
            // 
            this.srchBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.srchBtn.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.srchBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("srchBtn.BackgroundImage")));
            this.srchBtn.BorderColor = System.Drawing.Color.Transparent;
            this.srchBtn.BorderRadius = 25;
            this.srchBtn.BorderSize = 0;
            this.srchBtn.FlatAppearance.BorderSize = 0;
            this.srchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.srchBtn.Font = new System.Drawing.Font("Nirmala UI", 20F);
            this.srchBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.srchBtn.Location = new System.Drawing.Point(12, 557);
            this.srchBtn.Name = "srchBtn";
            this.srchBtn.Size = new System.Drawing.Size(254, 93);
            this.srchBtn.TabIndex = 13;
            this.srchBtn.Text = "Search a Client";
            this.srchBtn.TextColor = System.Drawing.SystemColors.Control;
            this.srchBtn.UseVisualStyleBackColor = false;
            this.srchBtn.Click += new System.EventHandler(this.srchBtn_Click);
            // 
            // addClientBtn
            // 
            this.addClientBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.addClientBtn.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.addClientBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addClientBtn.BackgroundImage")));
            this.addClientBtn.BorderColor = System.Drawing.Color.Transparent;
            this.addClientBtn.BorderRadius = 25;
            this.addClientBtn.BorderSize = 0;
            this.addClientBtn.FlatAppearance.BorderSize = 0;
            this.addClientBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addClientBtn.Font = new System.Drawing.Font("Nirmala UI", 20F);
            this.addClientBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.addClientBtn.Location = new System.Drawing.Point(12, 400);
            this.addClientBtn.Name = "addClientBtn";
            this.addClientBtn.Size = new System.Drawing.Size(254, 93);
            this.addClientBtn.TabIndex = 12;
            this.addClientBtn.Text = "Add New Client";
            this.addClientBtn.TextColor = System.Drawing.SystemColors.Control;
            this.addClientBtn.UseVisualStyleBackColor = false;
            this.addClientBtn.Click += new System.EventHandler(this.addClientBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.Firebrick;
            this.closeBtn.BackgroundColor = System.Drawing.Color.Firebrick;
            this.closeBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.closeBtn.BorderRadius = 20;
            this.closeBtn.BorderSize = 0;
            this.closeBtn.FlatAppearance.BorderSize = 0;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Font = new System.Drawing.Font("Nirmala UI", 15F);
            this.closeBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.closeBtn.Location = new System.Drawing.Point(849, 601);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(254, 49);
            this.closeBtn.TabIndex = 9;
            this.closeBtn.Text = "Exit Application";
            this.closeBtn.TextColor = System.Drawing.SystemColors.Control;
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click_1);
            // 
            // StartClass
            // 
            this.StartClass.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.StartClass.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.StartClass.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("StartClass.BackgroundImage")));
            this.StartClass.BorderColor = System.Drawing.Color.Transparent;
            this.StartClass.BorderRadius = 25;
            this.StartClass.BorderSize = 0;
            this.StartClass.FlatAppearance.BorderSize = 0;
            this.StartClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartClass.Font = new System.Drawing.Font("Nirmala UI", 20F);
            this.StartClass.ForeColor = System.Drawing.SystemColors.Control;
            this.StartClass.Location = new System.Drawing.Point(331, 557);
            this.StartClass.Name = "StartClass";
            this.StartClass.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartClass.Size = new System.Drawing.Size(254, 93);
            this.StartClass.TabIndex = 42;
            this.StartClass.Text = "Start a Class";
            this.StartClass.TextColor = System.Drawing.SystemColors.Control;
            this.StartClass.UseVisualStyleBackColor = false;
            this.StartClass.Click += new System.EventHandler(this.StartClass_Click);
            // 
            // UPF_HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(46)))), ((int)(((byte)(144)))));
            this.ClientSize = new System.Drawing.Size(1115, 662);
            this.Controls.Add(this.StartClass);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.srchBtn);
            this.Controls.Add(this.addClientBtn);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UPF_HomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UPF_HomePage";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private RoundedButton closeBtn;
        private RoundedButton addClientBtn;
        private RoundedButton srchBtn;
        private RoundedButton updateBtn;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button button1;
        private RoundedButton StartClass;
    }
}