namespace LibraryForms
{
    partial class KlientetAktiv
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KlientetAktiv));
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchbyName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dgvKlientetAktiv = new System.Windows.Forms.DataGridView();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKlientetAktiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(561, 227);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 148;
            this.label1.Text = "Name";
            // 
            // txtSearchbyName
            // 
            this.txtSearchbyName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSearchbyName.Location = new System.Drawing.Point(489, 246);
            this.txtSearchbyName.Name = "txtSearchbyName";
            this.txtSearchbyName.Size = new System.Drawing.Size(191, 22);
            this.txtSearchbyName.TabIndex = 147;
            this.txtSearchbyName.TextChanged += new System.EventHandler(this.txtSearchDitVonese_TextChanged);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(265, 246);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(172, 25);
            this.label12.TabIndex = 146;
            this.label12.Text = "Search by Name";
            // 
            // dgvKlientetAktiv
            // 
            this.dgvKlientetAktiv.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgvKlientetAktiv.BackgroundColor = System.Drawing.Color.White;
            this.dgvKlientetAktiv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKlientetAktiv.Location = new System.Drawing.Point(268, 300);
            this.dgvKlientetAktiv.Name = "dgvKlientetAktiv";
            this.dgvKlientetAktiv.RowHeadersWidth = 51;
            this.dgvKlientetAktiv.RowTemplate.Height = 24;
            this.dgvKlientetAktiv.Size = new System.Drawing.Size(896, 356);
            this.dgvKlientetAktiv.TabIndex = 145;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(85, 22);
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
            this.label2.Location = new System.Drawing.Point(217, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 44);
            this.label2.TabIndex = 158;
            this.label2.Text = "Klientet Aktiv";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // KlientetAktiv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1372, 686);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearchbyName);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dgvKlientetAktiv);
            this.DoubleBuffered = true;
            this.Name = "KlientetAktiv";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KlientetAktiv";
            this.Load += new System.EventHandler(this.KlientetAktiv_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKlientetAktiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearchbyName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dgvKlientetAktiv;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
    }
}