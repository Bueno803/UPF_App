
namespace UPF_App
{
    partial class StartClass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartClass));
            this.topPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.LilTigers = new System.Windows.Forms.Button();
            this.Header = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BackToAdd = new System.Windows.Forms.Button();
            this.ClearRoster = new System.Windows.Forms.Button();
            this.SearchByFirstNBtn = new System.Windows.Forms.Button();
            this.Locationlbl = new System.Windows.Forms.Label();
            this.LocBox = new System.Windows.Forms.ComboBox();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(32)))), ((int)(((byte)(102)))));
            this.topPanel.Controls.Add(this.button1);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1099, 28);
            this.topPanel.TabIndex = 42;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.button1.ForeColor = System.Drawing.Color.Snow;
            this.button1.Location = new System.Drawing.Point(1042, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 28);
            this.button1.TabIndex = 42;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LilTigers
            // 
            this.LilTigers.FlatAppearance.BorderSize = 0;
            this.LilTigers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LilTigers.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.LilTigers.ForeColor = System.Drawing.SystemColors.Control;
            this.LilTigers.Image = ((System.Drawing.Image)(resources.GetObject("LilTigers.Image")));
            this.LilTigers.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LilTigers.Location = new System.Drawing.Point(0, 139);
            this.LilTigers.Name = "LilTigers";
            this.LilTigers.Size = new System.Drawing.Size(257, 67);
            this.LilTigers.TabIndex = 43;
            this.LilTigers.Text = "Lil Tigers";
            this.LilTigers.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.LilTigers.UseVisualStyleBackColor = true;
            this.LilTigers.Click += new System.EventHandler(this.LilTigers_Click);
            // 
            // Header
            // 
            this.Header.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Header.AutoSize = true;
            this.Header.Font = new System.Drawing.Font("Nirmala UI", 35F, System.Drawing.FontStyle.Bold);
            this.Header.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Header.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Header.Location = new System.Drawing.Point(342, 48);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(370, 62);
            this.Header.TabIndex = 44;
            this.Header.Text = "Login to a Class";
            this.Header.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button2.Location = new System.Drawing.Point(0, 221);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(257, 72);
            this.button2.TabIndex = 45;
            this.button2.Text = "Beginner";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.SystemColors.Control;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button3.Location = new System.Drawing.Point(0, 299);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(257, 75);
            this.button3.TabIndex = 46;
            this.button3.Text = "Advanced";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(263, 161);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(774, 399);
            this.dataGridView1.TabIndex = 47;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
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
            this.BackToAdd.Location = new System.Drawing.Point(0, 486);
            this.BackToAdd.Name = "BackToAdd";
            this.BackToAdd.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.BackToAdd.Size = new System.Drawing.Size(257, 70);
            this.BackToAdd.TabIndex = 48;
            this.BackToAdd.Text = "Return To Home Page";
            this.BackToAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackToAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BackToAdd.UseVisualStyleBackColor = true;
            this.BackToAdd.Click += new System.EventHandler(this.BackToAdd_Click);
            // 
            // ClearRoster
            // 
            this.ClearRoster.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ClearRoster.FlatAppearance.BorderSize = 0;
            this.ClearRoster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearRoster.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.ClearRoster.ForeColor = System.Drawing.SystemColors.Control;
            this.ClearRoster.Image = ((System.Drawing.Image)(resources.GetObject("ClearRoster.Image")));
            this.ClearRoster.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ClearRoster.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ClearRoster.Location = new System.Drawing.Point(0, 410);
            this.ClearRoster.Name = "ClearRoster";
            this.ClearRoster.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.ClearRoster.Size = new System.Drawing.Size(257, 70);
            this.ClearRoster.TabIndex = 49;
            this.ClearRoster.Text = "Clear Roster";
            this.ClearRoster.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ClearRoster.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.ClearRoster.UseVisualStyleBackColor = true;
            this.ClearRoster.Click += new System.EventHandler(this.ClearRoster_Click);
            // 
            // SearchByFirstNBtn
            // 
            this.SearchByFirstNBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SearchByFirstNBtn.BackColor = System.Drawing.Color.ForestGreen;
            this.SearchByFirstNBtn.FlatAppearance.BorderSize = 0;
            this.SearchByFirstNBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchByFirstNBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.SearchByFirstNBtn.Location = new System.Drawing.Point(263, 560);
            this.SearchByFirstNBtn.Name = "SearchByFirstNBtn";
            this.SearchByFirstNBtn.Size = new System.Drawing.Size(245, 41);
            this.SearchByFirstNBtn.TabIndex = 50;
            this.SearchByFirstNBtn.Text = "Start Class";
            this.SearchByFirstNBtn.UseVisualStyleBackColor = false;
            this.SearchByFirstNBtn.Click += new System.EventHandler(this.SearchByFirstNBtn_Click);
            // 
            // Locationlbl
            // 
            this.Locationlbl.AutoSize = true;
            this.Locationlbl.Font = new System.Drawing.Font("Nirmala UI", 8.5F);
            this.Locationlbl.ForeColor = System.Drawing.SystemColors.Control;
            this.Locationlbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Locationlbl.Location = new System.Drawing.Point(260, 117);
            this.Locationlbl.Name = "Locationlbl";
            this.Locationlbl.Size = new System.Drawing.Size(53, 15);
            this.Locationlbl.TabIndex = 51;
            this.Locationlbl.Text = "Location";
            // 
            // LocBox
            // 
            this.LocBox.FormattingEnabled = true;
            this.LocBox.Location = new System.Drawing.Point(264, 139);
            this.LocBox.Name = "LocBox";
            this.LocBox.Size = new System.Drawing.Size(121, 21);
            this.LocBox.TabIndex = 52;
            // 
            // StartClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(46)))), ((int)(((byte)(144)))));
            this.ClientSize = new System.Drawing.Size(1099, 623);
            this.Controls.Add(this.LocBox);
            this.Controls.Add(this.Locationlbl);
            this.Controls.Add(this.SearchByFirstNBtn);
            this.Controls.Add(this.ClearRoster);
            this.Controls.Add(this.BackToAdd);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Header);
            this.Controls.Add(this.LilTigers);
            this.Controls.Add(this.topPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StartClass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Start a Class";
            this.Load += new System.EventHandler(this.StartClass_Load);
            this.topPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button LilTigers;
        private System.Windows.Forms.Label Header;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BackToAdd;
        private System.Windows.Forms.Button ClearRoster;
        private System.Windows.Forms.Button SearchByFirstNBtn;
        private System.Windows.Forms.Label Locationlbl;
        private System.Windows.Forms.ComboBox LocBox;
    }
}