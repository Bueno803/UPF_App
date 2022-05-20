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
            this.addClientBtn = new UPF_App.RoundedButton();
            this.closeBtn = new UPF_App.RoundedButton();
            this.srchBtn = new UPF_App.RoundedButton();
            this.updateBtn = new UPF_App.RoundedButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(152, 48);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(792, 321);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // addClientBtn
            // 
            this.addClientBtn.BackColor = System.Drawing.Color.White;
            this.addClientBtn.BackgroundColor = System.Drawing.Color.White;
            this.addClientBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addClientBtn.BackgroundImage")));
            this.addClientBtn.BorderColor = System.Drawing.Color.Transparent;
            this.addClientBtn.BorderRadius = 25;
            this.addClientBtn.BorderSize = 0;
            this.addClientBtn.FlatAppearance.BorderSize = 0;
            this.addClientBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addClientBtn.Font = new System.Drawing.Font("Nirmala UI", 20F);
            this.addClientBtn.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.addClientBtn.Location = new System.Drawing.Point(163, 400);
            this.addClientBtn.Name = "addClientBtn";
            this.addClientBtn.Size = new System.Drawing.Size(254, 108);
            this.addClientBtn.TabIndex = 12;
            this.addClientBtn.Text = "Add New Client";
            this.addClientBtn.TextColor = System.Drawing.SystemColors.ActiveBorder;
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
            this.closeBtn.Location = new System.Drawing.Point(454, 551);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(258, 49);
            this.closeBtn.TabIndex = 9;
            this.closeBtn.Text = "Exit Application";
            this.closeBtn.TextColor = System.Drawing.SystemColors.Control;
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click_1);
            // 
            // srchBtn
            // 
            this.srchBtn.BackColor = System.Drawing.Color.White;
            this.srchBtn.BackgroundColor = System.Drawing.Color.White;
            this.srchBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("srchBtn.BackgroundImage")));
            this.srchBtn.BorderColor = System.Drawing.Color.Transparent;
            this.srchBtn.BorderRadius = 25;
            this.srchBtn.BorderSize = 0;
            this.srchBtn.FlatAppearance.BorderSize = 0;
            this.srchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.srchBtn.Font = new System.Drawing.Font("Nirmala UI", 20F);
            this.srchBtn.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.srchBtn.Location = new System.Drawing.Point(454, 400);
            this.srchBtn.Name = "srchBtn";
            this.srchBtn.Size = new System.Drawing.Size(254, 108);
            this.srchBtn.TabIndex = 13;
            this.srchBtn.Text = "Search a Client";
            this.srchBtn.TextColor = System.Drawing.SystemColors.ActiveBorder;
            this.srchBtn.UseVisualStyleBackColor = false;
            this.srchBtn.Click += new System.EventHandler(this.srchBtn_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.BackColor = System.Drawing.Color.White;
            this.updateBtn.BackgroundColor = System.Drawing.Color.White;
            this.updateBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("updateBtn.BackgroundImage")));
            this.updateBtn.BorderColor = System.Drawing.Color.Transparent;
            this.updateBtn.BorderRadius = 25;
            this.updateBtn.BorderSize = 0;
            this.updateBtn.FlatAppearance.BorderSize = 0;
            this.updateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateBtn.Font = new System.Drawing.Font("Nirmala UI", 20F);
            this.updateBtn.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.updateBtn.Location = new System.Drawing.Point(740, 400);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(254, 108);
            this.updateBtn.TabIndex = 14;
            this.updateBtn.Text = "Update Client Information";
            this.updateBtn.TextColor = System.Drawing.SystemColors.ActiveBorder;
            this.updateBtn.UseVisualStyleBackColor = false;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // UPF_HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(46)))), ((int)(((byte)(144)))));
            this.ClientSize = new System.Drawing.Size(1099, 662);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.srchBtn);
            this.Controls.Add(this.addClientBtn);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UPF_HomePage";
            this.Text = "UPF_HomePage";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private RoundedButton closeBtn;
        private RoundedButton addClientBtn;
        private RoundedButton srchBtn;
        private RoundedButton updateBtn;
    }
}