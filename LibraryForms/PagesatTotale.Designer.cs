namespace LibraryForms
{
    partial class PagesatTotale
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PagesatTotale));
            this.dgvPagesatTotale = new System.Windows.Forms.DataGridView();
            this.txtSearchTime = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagesatTotale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPagesatTotale
            // 
            this.dgvPagesatTotale.BackgroundColor = System.Drawing.Color.White;
            this.dgvPagesatTotale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPagesatTotale.Location = new System.Drawing.Point(245, 219);
            this.dgvPagesatTotale.Name = "dgvPagesatTotale";
            this.dgvPagesatTotale.RowHeadersWidth = 51;
            this.dgvPagesatTotale.RowTemplate.Height = 24;
            this.dgvPagesatTotale.Size = new System.Drawing.Size(901, 413);
            this.dgvPagesatTotale.TabIndex = 0;
            // 
            // txtSearchTime
            // 
            this.txtSearchTime.Location = new System.Drawing.Point(447, 165);
            this.txtSearchTime.Multiline = true;
            this.txtSearchTime.Name = "txtSearchTime";
            this.txtSearchTime.Size = new System.Drawing.Size(191, 28);
            this.txtSearchTime.TabIndex = 138;
            this.txtSearchTime.TextChanged += new System.EventHandler(this.txtSearchTime_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(242, 165);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(163, 25);
            this.label12.TabIndex = 137;
            this.label12.Text = "Search By Year";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(489, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 140;
            this.label1.Text = "Payment Year";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(53, 24);
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
            this.label2.Location = new System.Drawing.Point(185, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(422, 44);
            this.label2.TabIndex = 158;
            this.label2.Text = "Pagesat Totale te Klienteve";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PagesatTotale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1126, 631);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearchTime);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dgvPagesatTotale);
            this.DoubleBuffered = true;
            this.Name = "PagesatTotale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PagesatTotale";
            this.Load += new System.EventHandler(this.PagesatTotale_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagesatTotale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPagesatTotale;
        private System.Windows.Forms.TextBox txtSearchTime;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
    }
}