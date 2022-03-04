namespace softSale
{
    partial class frmHesabat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHesabat));
            this.lblAnbar = new System.Windows.Forms.Label();
            this.lblMal = new System.Windows.Forms.Label();
            this.lblBeginDate = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblToplamMiqdar = new System.Windows.Forms.Label();
            this.lblToplamQiymet = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAnbar
            // 
            this.lblAnbar.AutoSize = true;
            this.lblAnbar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnbar.Location = new System.Drawing.Point(162, 31);
            this.lblAnbar.Name = "lblAnbar";
            this.lblAnbar.Size = new System.Drawing.Size(83, 26);
            this.lblAnbar.TabIndex = 0;
            this.lblAnbar.Text = "Anbar-";
            // 
            // lblMal
            // 
            this.lblMal.AutoSize = true;
            this.lblMal.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMal.Location = new System.Drawing.Point(187, 70);
            this.lblMal.Name = "lblMal";
            this.lblMal.Size = new System.Drawing.Size(58, 26);
            this.lblMal.TabIndex = 1;
            this.lblMal.Text = "Mal-";
            // 
            // lblBeginDate
            // 
            this.lblBeginDate.AutoSize = true;
            this.lblBeginDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBeginDate.Location = new System.Drawing.Point(68, 113);
            this.lblBeginDate.Name = "lblBeginDate";
            this.lblBeginDate.Size = new System.Drawing.Size(177, 26);
            this.lblBeginDate.TabIndex = 2;
            this.lblBeginDate.Text = "Başlanğıc tarix-";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndDate.Location = new System.Drawing.Point(130, 155);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(115, 26);
            this.lblEndDate.TabIndex = 3;
            this.lblEndDate.Text = "Son tarix-";
            // 
            // lblToplamMiqdar
            // 
            this.lblToplamMiqdar.AutoSize = true;
            this.lblToplamMiqdar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToplamMiqdar.Location = new System.Drawing.Point(31, 238);
            this.lblToplamMiqdar.Name = "lblToplamMiqdar";
            this.lblToplamMiqdar.Size = new System.Drawing.Size(216, 31);
            this.lblToplamMiqdar.TabIndex = 4;
            this.lblToplamMiqdar.Text = "Toplam miqdar-";
            // 
            // lblToplamQiymet
            // 
            this.lblToplamQiymet.AutoSize = true;
            this.lblToplamQiymet.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToplamQiymet.Location = new System.Drawing.Point(31, 286);
            this.lblToplamQiymet.Name = "lblToplamQiymet";
            this.lblToplamQiymet.Size = new System.Drawing.Size(214, 31);
            this.lblToplamQiymet.TabIndex = 5;
            this.lblToplamQiymet.Text = "Toplam qiymət-";
            // 
            // frmHesabat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(661, 461);
            this.Controls.Add(this.lblToplamQiymet);
            this.Controls.Add(this.lblToplamMiqdar);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblBeginDate);
            this.Controls.Add(this.lblMal);
            this.Controls.Add(this.lblAnbar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHesabat";
            this.Text = "frmHesabat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAnbar;
        private System.Windows.Forms.Label lblMal;
        private System.Windows.Forms.Label lblBeginDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblToplamMiqdar;
        private System.Windows.Forms.Label lblToplamQiymet;
    }
}