
namespace UPF_App
{
    partial class TKDSchedule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TKDSchedule));
            this.topPanel = new System.Windows.Forms.Panel();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.BackToAdd = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.topPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(32)))), ((int)(((byte)(102)))));
            this.topPanel.Controls.Add(this.CloseBtn);
            this.topPanel.Location = new System.Drawing.Point(-9, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1116, 28);
            this.topPanel.TabIndex = 41;
            // 
            // CloseBtn
            // 
            this.CloseBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseBtn.FlatAppearance.BorderSize = 0;
            this.CloseBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
            this.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.CloseBtn.ForeColor = System.Drawing.Color.Snow;
            this.CloseBtn.Location = new System.Drawing.Point(1059, 0);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(57, 28);
            this.CloseBtn.TabIndex = 41;
            this.CloseBtn.Text = "X";
            this.CloseBtn.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(46)))), ((int)(((byte)(144)))));
            this.panel1.Controls.Add(this.SearchBtn);
            this.panel1.Controls.Add(this.AddBtn);
            this.panel1.Controls.Add(this.exitBtn);
            this.panel1.Controls.Add(this.BackToAdd);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(190, 623);
            this.panel1.TabIndex = 42;
            // 
            // SearchBtn
            // 
            this.SearchBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.SearchBtn.FlatAppearance.BorderSize = 0;
            this.SearchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchBtn.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.SearchBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.SearchBtn.Image = ((System.Drawing.Image)(resources.GetObject("SearchBtn.Image")));
            this.SearchBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SearchBtn.Location = new System.Drawing.Point(0, 165);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(190, 56);
            this.SearchBtn.TabIndex = 4;
            this.SearchBtn.Text = "Add New Client";
            this.SearchBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.SearchBtn.UseVisualStyleBackColor = true;
            // 
            // AddBtn
            // 
            this.AddBtn.FlatAppearance.BorderSize = 0;
            this.AddBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddBtn.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.AddBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.AddBtn.Image = ((System.Drawing.Image)(resources.GetObject("AddBtn.Image")));
            this.AddBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AddBtn.Location = new System.Drawing.Point(0, 165);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(190, 56);
            this.AddBtn.TabIndex = 5;
            this.AddBtn.Text = "Add";
            this.AddBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.AddBtn.UseVisualStyleBackColor = true;
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.Firebrick;
            this.exitBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.exitBtn.FlatAppearance.BorderSize = 0;
            this.exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitBtn.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.exitBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.exitBtn.Image = ((System.Drawing.Image)(resources.GetObject("exitBtn.Image")));
            this.exitBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exitBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.exitBtn.Location = new System.Drawing.Point(0, 567);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.exitBtn.Size = new System.Drawing.Size(190, 56);
            this.exitBtn.TabIndex = 2;
            this.exitBtn.Text = "Exit Application";
            this.exitBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exitBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.exitBtn.UseVisualStyleBackColor = false;
            // 
            // BackToAdd
            // 
            this.BackToAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BackToAdd.FlatAppearance.BorderSize = 0;
            this.BackToAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackToAdd.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.BackToAdd.ForeColor = System.Drawing.SystemColors.Control;
            this.BackToAdd.Image = ((System.Drawing.Image)(resources.GetObject("BackToAdd.Image")));
            this.BackToAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BackToAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BackToAdd.Location = new System.Drawing.Point(-2, 507);
            this.BackToAdd.Name = "BackToAdd";
            this.BackToAdd.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.BackToAdd.Size = new System.Drawing.Size(190, 56);
            this.BackToAdd.TabIndex = 1;
            this.BackToAdd.Text = "Return To Home Page";
            this.BackToAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackToAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BackToAdd.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(190, 165);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Nirmala UI", 35F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(482, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(291, 62);
            this.label10.TabIndex = 43;
            this.label10.Text = "Class Roster";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TKDSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(46)))), ((int)(((byte)(144)))));
            this.ClientSize = new System.Drawing.Size(1099, 623);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TKDSchedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TKDSchedule";
            this.topPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Button BackToAdd;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label10;
    }
}