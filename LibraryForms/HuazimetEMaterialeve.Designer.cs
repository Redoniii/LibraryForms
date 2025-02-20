namespace LibraryForms
{
    partial class HuazimetEMaterialeve
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HuazimetEMaterialeve));
            this.nudTarifa = new System.Windows.Forms.NumericUpDown();
            this.dtpKthimi = new System.Windows.Forms.DateTimePicker();
            this.dtpHuazimi = new System.Windows.Forms.DateTimePicker();
            this.cmbMateriali = new System.Windows.Forms.ComboBox();
            this.cmbKlienti = new System.Windows.Forms.ComboBox();
            this.dgvHuazimet = new System.Windows.Forms.DataGridView();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpAktuale = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudTarifa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHuazimet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // nudTarifa
            // 
            this.nudTarifa.Location = new System.Drawing.Point(211, 380);
            this.nudTarifa.Name = "nudTarifa";
            this.nudTarifa.Size = new System.Drawing.Size(185, 22);
            this.nudTarifa.TabIndex = 179;
            // 
            // dtpKthimi
            // 
            this.dtpKthimi.Location = new System.Drawing.Point(210, 320);
            this.dtpKthimi.Name = "dtpKthimi";
            this.dtpKthimi.Size = new System.Drawing.Size(184, 22);
            this.dtpKthimi.TabIndex = 178;
            // 
            // dtpHuazimi
            // 
            this.dtpHuazimi.Location = new System.Drawing.Point(210, 281);
            this.dtpHuazimi.Name = "dtpHuazimi";
            this.dtpHuazimi.Size = new System.Drawing.Size(186, 22);
            this.dtpHuazimi.TabIndex = 177;
            // 
            // cmbMateriali
            // 
            this.cmbMateriali.FormattingEnabled = true;
            this.cmbMateriali.Location = new System.Drawing.Point(132, 244);
            this.cmbMateriali.Name = "cmbMateriali";
            this.cmbMateriali.Size = new System.Drawing.Size(265, 24);
            this.cmbMateriali.TabIndex = 176;
            this.cmbMateriali.SelectedIndexChanged += new System.EventHandler(this.cmbMateriali_SelectedIndexChanged);
            // 
            // cmbKlienti
            // 
            this.cmbKlienti.FormattingEnabled = true;
            this.cmbKlienti.Location = new System.Drawing.Point(210, 208);
            this.cmbKlienti.Name = "cmbKlienti";
            this.cmbKlienti.Size = new System.Drawing.Size(187, 24);
            this.cmbKlienti.TabIndex = 175;
            this.cmbKlienti.SelectedIndexChanged += new System.EventHandler(this.cmbKlienti_SelectedIndexChanged);
            // 
            // dgvHuazimet
            // 
            this.dgvHuazimet.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(79)))), ((int)(((byte)(199)))));
            this.dgvHuazimet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHuazimet.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(79)))), ((int)(((byte)(199)))));
            this.dgvHuazimet.Location = new System.Drawing.Point(430, 180);
            this.dgvHuazimet.Name = "dgvHuazimet";
            this.dgvHuazimet.RowHeadersWidth = 51;
            this.dgvHuazimet.RowTemplate.Height = 24;
            this.dgvHuazimet.Size = new System.Drawing.Size(997, 476);
            this.dgvHuazimet.TabIndex = 174;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(96, 30);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(114, 61);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 173;
            this.pictureBox2.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Location = new System.Drawing.Point(191, 437);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 45);
            this.btnSave.TabIndex = 172;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(35, 380);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 20);
            this.label6.TabIndex = 171;
            this.label6.Text = "Tarifa e Denimit";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(32, 322);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 20);
            this.label5.TabIndex = 170;
            this.label5.Text = "Data e Kthimit";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(32, 285);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 20);
            this.label4.TabIndex = 169;
            this.label4.Text = "Data e Huazimit";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(32, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 168;
            this.label3.Text = "Materiali";
            // 
            // txtName
            // 
            this.txtName.AutoSize = true;
            this.txtName.BackColor = System.Drawing.Color.Transparent;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.Color.White;
            this.txtName.Location = new System.Drawing.Point(32, 211);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(55, 20);
            this.txtName.TabIndex = 167;
            this.txtName.Text = "Klienti";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Poor Richard", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(216, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(371, 44);
            this.label1.TabIndex = 166;
            this.label1.Text = "Huazimet e Materialeve";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dtpAktuale
            // 
            this.dtpAktuale.Location = new System.Drawing.Point(262, 350);
            this.dtpAktuale.Name = "dtpAktuale";
            this.dtpAktuale.Size = new System.Drawing.Size(135, 22);
            this.dtpAktuale.TabIndex = 181;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(35, 352);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 20);
            this.label2.TabIndex = 180;
            this.label2.Text = "Data Aktuale e Kthimit";
            // 
            // HuazimetEMaterialeve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1481, 694);
            this.Controls.Add(this.dtpAktuale);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudTarifa);
            this.Controls.Add(this.dtpKthimi);
            this.Controls.Add(this.dtpHuazimi);
            this.Controls.Add(this.cmbMateriali);
            this.Controls.Add(this.cmbKlienti);
            this.Controls.Add(this.dgvHuazimet);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "HuazimetEMaterialeve";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HuazimetEMaterialeve";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.HuazimetEMaterialeve_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudTarifa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHuazimet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudTarifa;
        private System.Windows.Forms.DateTimePicker dtpKthimi;
        private System.Windows.Forms.DateTimePicker dtpHuazimi;
        private System.Windows.Forms.ComboBox cmbMateriali;
        private System.Windows.Forms.ComboBox cmbKlienti;
        private System.Windows.Forms.DataGridView dgvHuazimet;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpAktuale;
        private System.Windows.Forms.Label label2;
    }
}