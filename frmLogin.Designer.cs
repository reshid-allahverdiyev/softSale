namespace softSale
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.lblNote = new System.Windows.Forms.Label();
            this.lblUserPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUserPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pShow = new System.Windows.Forms.PictureBox();
            this.pHide = new System.Windows.Forms.PictureBox();
            this.cmbbxBasa = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pHide)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(219, 178);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(0, 13);
            this.lblNote.TabIndex = 18;
            // 
            // lblUserPassword
            // 
            this.lblUserPassword.AutoSize = true;
            this.lblUserPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserPassword.Location = new System.Drawing.Point(164, 156);
            this.lblUserPassword.Name = "lblUserPassword";
            this.lblUserPassword.Size = new System.Drawing.Size(42, 17);
            this.lblUserPassword.TabIndex = 17;
            this.lblUserPassword.Text = "Şifrə";
            this.lblUserPassword.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(110, 117);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(100, 17);
            this.lblUsername.TabIndex = 16;
            this.lblUsername.Text = "İstifadəçi adı";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.Location = new System.Drawing.Point(216, 155);
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.Size = new System.Drawing.Size(235, 20);
            this.txtUserPassword.TabIndex = 15;
            this.txtUserPassword.Text = "1";
            this.txtUserPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(216, 117);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(235, 20);
            this.txtUsername.TabIndex = 14;
            this.txtUsername.Text = "1";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(216, 210);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(107, 28);
            this.btnLogin.TabIndex = 13;
            this.btnLogin.Text = "Daxil ol";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click_1);
            // 
            // pShow
            // 
            this.pShow.Image = ((System.Drawing.Image)(resources.GetObject("pShow.Image")));
            this.pShow.Location = new System.Drawing.Point(452, 153);
            this.pShow.Name = "pShow";
            this.pShow.Size = new System.Drawing.Size(29, 24);
            this.pShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pShow.TabIndex = 20;
            this.pShow.TabStop = false;
            this.pShow.Click += new System.EventHandler(this.PShow_Click);
            // 
            // pHide
            // 
            this.pHide.Image = ((System.Drawing.Image)(resources.GetObject("pHide.Image")));
            this.pHide.Location = new System.Drawing.Point(452, 154);
            this.pHide.Name = "pHide";
            this.pHide.Size = new System.Drawing.Size(29, 24);
            this.pHide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pHide.TabIndex = 21;
            this.pHide.TabStop = false;
            this.pHide.Click += new System.EventHandler(this.PHide_Click);
            // 
            // cmbbxBasa
            // 
            this.cmbbxBasa.FormattingEnabled = true;
            this.cmbbxBasa.Location = new System.Drawing.Point(216, 12);
            this.cmbbxBasa.Name = "cmbbxBasa";
            this.cmbbxBasa.Size = new System.Drawing.Size(97, 21);
            this.cmbbxBasa.TabIndex = 22;
            this.cmbbxBasa.SelectedIndexChanged += new System.EventHandler(this.CmbbxBasa_SelectedIndexChanged);
            // 
            // frmLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 355);
            this.Controls.Add(this.cmbbxBasa);
            this.Controls.Add(this.pHide);
            this.Controls.Add(this.pShow);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.lblUserPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtUserPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.btnLogin);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Daxil ol";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmLogin_FormClosed);
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pHide)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Label lblUserPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUserPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.PictureBox pShow;
        private System.Windows.Forms.PictureBox pHide;
        private System.Windows.Forms.ComboBox cmbbxBasa;
    }
}

