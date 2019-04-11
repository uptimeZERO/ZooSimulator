namespace Zoo_Simulator
{
    partial class frmZooSimulator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmZooSimulator));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.pnlSimulation = new System.Windows.Forms.Panel();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.dgvSimulator = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlSimulation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimulator)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.Location = new System.Drawing.Point(45, 14);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(109, 22);
            this.lblFormTitle.TabIndex = 1;
            this.lblFormTitle.Text = "Zoo Simulator";
            // 
            // pnlSimulation
            // 
            this.pnlSimulation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSimulation.Controls.Add(this.dgvSimulator);
            this.pnlSimulation.Location = new System.Drawing.Point(12, 46);
            this.pnlSimulation.Name = "pnlSimulation";
            this.pnlSimulation.Size = new System.Drawing.Size(775, 387);
            this.pnlSimulation.TabIndex = 2;
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(690, 18);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(97, 16);
            this.lblAuthor.TabIndex = 3;
            this.lblAuthor.Text = "By Pavilion Sahota";
            // 
            // dgvSimulator
            // 
            this.dgvSimulator.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSimulator.Location = new System.Drawing.Point(3, 29);
            this.dgvSimulator.Name = "dgvSimulator";
            this.dgvSimulator.Size = new System.Drawing.Size(767, 288);
            this.dgvSimulator.TabIndex = 0;
            // 
            // frmZooSimulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(799, 445);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.pnlSimulation);
            this.Controls.Add(this.lblFormTitle);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DeepPink;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmZooSimulator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zoo Simulator";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlSimulation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimulator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel pnlSimulation;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.DataGridView dgvSimulator;
    }
}

