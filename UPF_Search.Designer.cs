
namespace UPF_App
{
    partial class UPF_Search
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UPF_Search));
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SearchByL = new System.Windows.Forms.Button();
            this.SearchByPN = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.BackToAdd = new System.Windows.Forms.Button();
            this.SearchByLNBtn = new System.Windows.Forms.Button();
            this.SearchByFNBtn = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Blue;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button2.Location = new System.Drawing.Point(12, 396);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 42);
            this.button2.TabIndex = 26;
            this.button2.Text = "Add Client";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(46)))), ((int)(((byte)(144)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(190, 166);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(46)))), ((int)(((byte)(144)))));
            this.panel1.Controls.Add(this.SearchByL);
            this.panel1.Controls.Add(this.SearchByPN);
            this.panel1.Controls.Add(this.DeleteBtn);
            this.panel1.Controls.Add(this.BackToAdd);
            this.panel1.Controls.Add(this.SearchByLNBtn);
            this.panel1.Controls.Add(this.SearchByFNBtn);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(190, 662);
            this.panel1.TabIndex = 28;
            // 
            // SearchByL
            // 
            this.SearchByL.Dock = System.Windows.Forms.DockStyle.Top;
            this.SearchByL.FlatAppearance.BorderSize = 0;
            this.SearchByL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchByL.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.SearchByL.ForeColor = System.Drawing.SystemColors.Control;
            this.SearchByL.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SearchByL.Location = new System.Drawing.Point(0, 334);
            this.SearchByL.Name = "SearchByL";
            this.SearchByL.Size = new System.Drawing.Size(190, 56);
            this.SearchByL.TabIndex = 3;
            this.SearchByL.Text = "Search By Location";
            this.SearchByL.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.SearchByL.UseVisualStyleBackColor = true;
            this.SearchByL.Click += new System.EventHandler(this.SearchByL_Click);
            // 
            // SearchByPN
            // 
            this.SearchByPN.Dock = System.Windows.Forms.DockStyle.Top;
            this.SearchByPN.FlatAppearance.BorderSize = 0;
            this.SearchByPN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchByPN.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.SearchByPN.ForeColor = System.Drawing.SystemColors.Control;
            this.SearchByPN.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SearchByPN.Location = new System.Drawing.Point(0, 278);
            this.SearchByPN.Name = "SearchByPN";
            this.SearchByPN.Size = new System.Drawing.Size(190, 56);
            this.SearchByPN.TabIndex = 2;
            this.SearchByPN.Text = "Search By Phone Number";
            this.SearchByPN.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.SearchByPN.UseVisualStyleBackColor = true;
            this.SearchByPN.Click += new System.EventHandler(this.SearchByPN_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DeleteBtn.BackColor = System.Drawing.Color.Firebrick;
            this.DeleteBtn.FlatAppearance.BorderSize = 0;
            this.DeleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteBtn.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.DeleteBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.DeleteBtn.Image = ((System.Drawing.Image)(resources.GetObject("DeleteBtn.Image")));
            this.DeleteBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DeleteBtn.Location = new System.Drawing.Point(-1, 607);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(190, 56);
            this.DeleteBtn.TabIndex = 1;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.DeleteBtn.UseVisualStyleBackColor = false;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // BackToAdd
            // 
            this.BackToAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BackToAdd.FlatAppearance.BorderSize = 0;
            this.BackToAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackToAdd.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.BackToAdd.ForeColor = System.Drawing.SystemColors.Control;
            this.BackToAdd.Image = ((System.Drawing.Image)(resources.GetObject("BackToAdd.Image")));
            this.BackToAdd.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BackToAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BackToAdd.Location = new System.Drawing.Point(-2, 549);
            this.BackToAdd.Name = "BackToAdd";
            this.BackToAdd.Size = new System.Drawing.Size(190, 56);
            this.BackToAdd.TabIndex = 1;
            this.BackToAdd.Text = "Back";
            this.BackToAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BackToAdd.UseVisualStyleBackColor = true;
            this.BackToAdd.Click += new System.EventHandler(this.BackToAdd_Click);
            // 
            // SearchByLNBtn
            // 
            this.SearchByLNBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.SearchByLNBtn.FlatAppearance.BorderSize = 0;
            this.SearchByLNBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchByLNBtn.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.SearchByLNBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.SearchByLNBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SearchByLNBtn.Location = new System.Drawing.Point(0, 222);
            this.SearchByLNBtn.Name = "SearchByLNBtn";
            this.SearchByLNBtn.Size = new System.Drawing.Size(190, 56);
            this.SearchByLNBtn.TabIndex = 1;
            this.SearchByLNBtn.Text = "Search By Last Name";
            this.SearchByLNBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.SearchByLNBtn.UseVisualStyleBackColor = true;
            this.SearchByLNBtn.Click += new System.EventHandler(this.SearchByLNBtn_Click);
            // 
            // SearchByFNBtn
            // 
            this.SearchByFNBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.SearchByFNBtn.FlatAppearance.BorderSize = 0;
            this.SearchByFNBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchByFNBtn.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.SearchByFNBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.SearchByFNBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SearchByFNBtn.Location = new System.Drawing.Point(0, 166);
            this.SearchByFNBtn.Name = "SearchByFNBtn";
            this.SearchByFNBtn.Size = new System.Drawing.Size(190, 56);
            this.SearchByFNBtn.TabIndex = 1;
            this.SearchByFNBtn.Text = "Search By First Name";
            this.SearchByFNBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.SearchByFNBtn.UseVisualStyleBackColor = true;
            this.SearchByFNBtn.Click += new System.EventHandler(this.SearchByFNBtn_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(190, 166);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(243, 166);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(803, 455);
            this.dataGridView1.TabIndex = 29;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(498, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(274, 37);
            this.label10.TabIndex = 30;
            this.label10.Text = "Search database";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(240, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 14);
            this.label1.TabIndex = 31;
            this.label1.Text = "First Name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(243, 140);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(165, 20);
            this.textBox1.TabIndex = 32;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(670, 140);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(165, 20);
            this.textBox4.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 8.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(667, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 14);
            this.label4.TabIndex = 35;
            this.label4.Text = "Phone Number";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(465, 140);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(165, 20);
            this.textBox3.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(462, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 14);
            this.label3.TabIndex = 33;
            this.label3.Text = "Last Name";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(873, 140);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(165, 20);
            this.textBox2.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(870, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 37;
            this.label2.Text = "Location";
            // 
            // UPF_Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(75)))), ((int)(((byte)(150)))));
            this.ClientSize = new System.Drawing.Size(1115, 662);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UPF_Search";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button BackToAdd;
        private System.Windows.Forms.Button SearchByLNBtn;
        private System.Windows.Forms.Button SearchByFNBtn;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button SearchByPN;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SearchByL;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
    }
}