namespace softSale
{
    partial class frmAnbarAdd
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
            System.Windows.Forms.Button btnAnbarAddCancel;
            System.Windows.Forms.Button btnAnbarAddApply;
            System.Windows.Forms.Button btnAnbarCancelModify;
            System.Windows.Forms.Button btnApplyModify;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAnbarAdd));
            this.pnlAnbarAdd = new System.Windows.Forms.Panel();
            this.pnlAnbarModify = new System.Windows.Forms.Panel();
            this.txtAnbarNameModify = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAnbarNameAdd = new System.Windows.Forms.TextBox();
            this.lblDriverName = new System.Windows.Forms.Label();
            this.lblDriverSurname = new System.Windows.Forms.Label();
            this.cmbbxAnbarAdd = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbbxAnbarModify = new System.Windows.Forms.ComboBox();
            btnAnbarAddCancel = new System.Windows.Forms.Button();
            btnAnbarAddApply = new System.Windows.Forms.Button();
            btnAnbarCancelModify = new System.Windows.Forms.Button();
            btnApplyModify = new System.Windows.Forms.Button();
            this.pnlAnbarAdd.SuspendLayout();
            this.pnlAnbarModify.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAnbarAddCancel
            // 
            btnAnbarAddCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            btnAnbarAddCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnAnbarAddCancel.Location = new System.Drawing.Point(51, 290);
            btnAnbarAddCancel.Name = "btnAnbarAddCancel";
            btnAnbarAddCancel.Size = new System.Drawing.Size(153, 37);
            btnAnbarAddCancel.TabIndex = 52;
            btnAnbarAddCancel.Text = "İmtina et";
            btnAnbarAddCancel.UseVisualStyleBackColor = true;
            btnAnbarAddCancel.Click += new System.EventHandler(this.BtnAnbarAddCancel_Click);
            // 
            // btnAnbarAddApply
            // 
            btnAnbarAddApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            btnAnbarAddApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnAnbarAddApply.Location = new System.Drawing.Point(237, 290);
            btnAnbarAddApply.Name = "btnAnbarAddApply";
            btnAnbarAddApply.Size = new System.Drawing.Size(153, 37);
            btnAnbarAddApply.TabIndex = 50;
            btnAnbarAddApply.Text = "Əlavə et";
            btnAnbarAddApply.UseVisualStyleBackColor = true;
            btnAnbarAddApply.Click += new System.EventHandler(this.BtnAnbarAddApply_Click);
            // 
            // btnAnbarCancelModify
            // 
            btnAnbarCancelModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            btnAnbarCancelModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnAnbarCancelModify.Location = new System.Drawing.Point(48, 285);
            btnAnbarCancelModify.Name = "btnAnbarCancelModify";
            btnAnbarCancelModify.Size = new System.Drawing.Size(153, 37);
            btnAnbarCancelModify.TabIndex = 52;
            btnAnbarCancelModify.Text = "İmtina et";
            btnAnbarCancelModify.UseVisualStyleBackColor = true;
            btnAnbarCancelModify.Click += new System.EventHandler(this.BtnAnbarCancelModify_Click);
            // 
            // btnApplyModify
            // 
            btnApplyModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            btnApplyModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnApplyModify.Location = new System.Drawing.Point(234, 285);
            btnApplyModify.Name = "btnApplyModify";
            btnApplyModify.Size = new System.Drawing.Size(153, 37);
            btnApplyModify.TabIndex = 50;
            btnApplyModify.Text = "Düzəlişi təstiq et";
            btnApplyModify.UseVisualStyleBackColor = true;
            btnApplyModify.Click += new System.EventHandler(this.BtnApplyModify_Click);
            // 
            // pnlAnbarAdd
            // 
            this.pnlAnbarAdd.Controls.Add(this.cmbbxAnbarAdd);
            this.pnlAnbarAdd.Controls.Add(this.txtAnbarNameAdd);
            this.pnlAnbarAdd.Controls.Add(this.lblDriverName);
            this.pnlAnbarAdd.Controls.Add(this.lblDriverSurname);
            this.pnlAnbarAdd.Controls.Add(btnAnbarAddCancel);
            this.pnlAnbarAdd.Controls.Add(btnAnbarAddApply);
            this.pnlAnbarAdd.Location = new System.Drawing.Point(12, 4);
            this.pnlAnbarAdd.Name = "pnlAnbarAdd";
            this.pnlAnbarAdd.Size = new System.Drawing.Size(409, 339);
            this.pnlAnbarAdd.TabIndex = 55;
            // 
            // pnlAnbarModify
            // 
            this.pnlAnbarModify.Controls.Add(this.cmbbxAnbarModify);
            this.pnlAnbarModify.Controls.Add(this.txtAnbarNameModify);
            this.pnlAnbarModify.Controls.Add(this.label1);
            this.pnlAnbarModify.Controls.Add(this.label5);
            this.pnlAnbarModify.Controls.Add(btnAnbarCancelModify);
            this.pnlAnbarModify.Controls.Add(btnApplyModify);
            this.pnlAnbarModify.Location = new System.Drawing.Point(12, 6);
            this.pnlAnbarModify.Name = "pnlAnbarModify";
            this.pnlAnbarModify.Size = new System.Drawing.Size(406, 334);
            this.pnlAnbarModify.TabIndex = 56;
            // 
            // txtAnbarNameModify
            // 
            this.txtAnbarNameModify.Location = new System.Drawing.Point(116, 49);
            this.txtAnbarNameModify.Name = "txtAnbarNameModify";
            this.txtAnbarNameModify.Size = new System.Drawing.Size(245, 20);
            this.txtAnbarNameModify.TabIndex = 72;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(85, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 71;
            this.label1.Text = "Ad";
            // 
            // txtAnbarNameAdd
            // 
            this.txtAnbarNameAdd.Location = new System.Drawing.Point(114, 52);
            this.txtAnbarNameAdd.Name = "txtAnbarNameAdd";
            this.txtAnbarNameAdd.Size = new System.Drawing.Size(245, 20);
            this.txtAnbarNameAdd.TabIndex = 62;
            // 
            // lblDriverName
            // 
            this.lblDriverName.AutoSize = true;
            this.lblDriverName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDriverName.Location = new System.Drawing.Point(84, 56);
            this.lblDriverName.Name = "lblDriverName";
            this.lblDriverName.Size = new System.Drawing.Size(22, 13);
            this.lblDriverName.TabIndex = 61;
            this.lblDriverName.Text = "Ad";
            // 
            // lblDriverSurname
            // 
            this.lblDriverSurname.AutoSize = true;
            this.lblDriverSurname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDriverSurname.Location = new System.Drawing.Point(84, 91);
            this.lblDriverSurname.Name = "lblDriverSurname";
            this.lblDriverSurname.Size = new System.Drawing.Size(25, 13);
            this.lblDriverSurname.TabIndex = 53;
            this.lblDriverSurname.Text = "Tip";
            // 
            // cmbbxAnbarAdd
            // 
            this.cmbbxAnbarAdd.FormattingEnabled = true;
            this.cmbbxAnbarAdd.Location = new System.Drawing.Point(114, 90);
            this.cmbbxAnbarAdd.Name = "cmbbxAnbarAdd";
            this.cmbbxAnbarAdd.Size = new System.Drawing.Size(245, 21);
            this.cmbbxAnbarAdd.TabIndex = 63;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(81, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 63;
            this.label5.Text = "Tip";
            // 
            // cmbbxAnbarModify
            // 
            this.cmbbxAnbarModify.FormattingEnabled = true;
            this.cmbbxAnbarModify.Location = new System.Drawing.Point(116, 85);
            this.cmbbxAnbarModify.Name = "cmbbxAnbarModify";
            this.cmbbxAnbarModify.Size = new System.Drawing.Size(245, 21);
            this.cmbbxAnbarModify.TabIndex = 73;
            // 
            // frmAnbarAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 355);
            this.Controls.Add(this.pnlAnbarAdd);
            this.Controls.Add(this.pnlAnbarModify);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAnbarAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yeni anbar";
            this.Load += new System.EventHandler(this.FrmAnbarAdd_Load);
            this.pnlAnbarAdd.ResumeLayout(false);
            this.pnlAnbarAdd.PerformLayout();
            this.pnlAnbarModify.ResumeLayout(false);
            this.pnlAnbarModify.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAnbarAdd;
        private System.Windows.Forms.Panel pnlAnbarModify;
        private System.Windows.Forms.TextBox txtAnbarNameAdd;
        private System.Windows.Forms.Label lblDriverName;
        private System.Windows.Forms.Label lblDriverSurname;
        private System.Windows.Forms.TextBox txtAnbarNameModify;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbbxAnbarAdd;
        private System.Windows.Forms.ComboBox cmbbxAnbarModify;
        private System.Windows.Forms.Label label5;
    }
}