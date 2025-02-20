namespace LibraryForms
{
    partial class HuazimetEVonesuara
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HuazimetEVonesuara));
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchDitVonese = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dgvHuazimetEVonesuara = new System.Windows.Forms.DataGridView();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHuazimetEVonesuara)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(771, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 144;
            this.label1.Text = "Dita e Voneses";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtSearchDitVonese
            // 
            this.txtSearchDitVonese.Location = new System.Drawing.Point(729, 255);
            this.txtSearchDitVonese.Multiline = true;
            this.txtSearchDitVonese.Name = "txtSearchDitVonese";
            this.txtSearchDitVonese.Size = new System.Drawing.Size(191, 28);
            this.txtSearchDitVonese.TabIndex = 143;
            this.txtSearchDitVonese.TextChanged += new System.EventHandler(this.txtSearchTime_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(416, 255);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(265, 25);
            this.label12.TabIndex = 142;
            this.label12.Text = "Search By Dita e Voneses";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // dgvHuazimetEVonesuara
            // 
            this.dgvHuazimetEVonesuara.BackgroundColor = System.Drawing.Color.White;
            this.dgvHuazimetEVonesuara.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHuazimetEVonesuara.Location = new System.Drawing.Point(161, 309);
            this.dgvHuazimetEVonesuara.Name = "dgvHuazimetEVonesuara";
            this.dgvHuazimetEVonesuara.RowHeadersWidth = 51;
            this.dgvHuazimetEVonesuara.RowTemplate.Height = 24;
            this.dgvHuazimetEVonesuara.Size = new System.Drawing.Size(1251, 356);
            this.dgvHuazimetEVonesuara.TabIndex = 141;
            this.dgvHuazimetEVonesuara.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHuazimetEVonesuara_CellContentClick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(81, 34);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(114, 109);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 159;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Poor Richard", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(213, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(349, 44);
            this.label2.TabIndex = 158;
            this.label2.Text = "Huazimet e Vonesuara";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(966, 258);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(177, 22);
            this.dateTimePicker1.TabIndex = 160;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // HuazimetEVonesuara
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1501, 731);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearchDitVonese);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dgvHuazimetEVonesuara);
            this.DoubleBuffered = true;
            this.Name = "HuazimetEVonesuara";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HuazimetEVonesuara";
            this.Load += new System.EventHandler(this.HuazimetEVonesuara_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHuazimetEVonesuara)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearchDitVonese;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dgvHuazimetEVonesuara;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}