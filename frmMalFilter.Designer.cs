namespace softSale
{
    partial class frmMalFilter
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMalFilter));
            this.txtMalAdi = new System.Windows.Forms.TextBox();
            this.lblBrand = new System.Windows.Forms.Label();
            this.txtMalQiymet = new System.Windows.Forms.TextBox();
            this.grdvwMal = new System.Windows.Forms.DataGridView();
            this.btnMalSearch = new System.Windows.Forms.Button();
            this.btnMalRefresh = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnMalFilterOk = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.cmbbxMalTip = new System.Windows.Forms.ComboBox();
            this.txtMalTopQiymet = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMalKod = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAllMalFilterOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdvwMal)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMalAdi
            // 
            this.txtMalAdi.Location = new System.Drawing.Point(83, 79);
            this.txtMalAdi.Name = "txtMalAdi";
            this.txtMalAdi.Size = new System.Drawing.Size(200, 20);
            this.txtMalAdi.TabIndex = 23;
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrand.Location = new System.Drawing.Point(44, 85);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(25, 13);
            this.lblBrand.TabIndex = 22;
            this.lblBrand.Text = "Adı";
            // 
            // txtMalQiymet
            // 
            this.txtMalQiymet.Location = new System.Drawing.Point(83, 174);
            this.txtMalQiymet.Name = "txtMalQiymet";
            this.txtMalQiymet.Size = new System.Drawing.Size(200, 20);
            this.txtMalQiymet.TabIndex = 21;
            // 
            // grdvwMal
            // 
            this.grdvwMal.AllowUserToAddRows = false;
            this.grdvwMal.AllowUserToDeleteRows = false;
            this.grdvwMal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdvwMal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdvwMal.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdvwMal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdvwMal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdvwMal.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdvwMal.Location = new System.Drawing.Point(342, 0);
            this.grdvwMal.Name = "grdvwMal";
            this.grdvwMal.ReadOnly = true;
            this.grdvwMal.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.grdvwMal.Size = new System.Drawing.Size(534, 504);
            this.grdvwMal.TabIndex = 25;
            this.grdvwMal.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GrdvwMal_RowHeaderMouseClick_1);
            this.grdvwMal.Sorted += new System.EventHandler(this.GrdvwMal_Sorted_1);
            // 
            // btnMalSearch
            // 
            this.btnMalSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMalSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMalSearch.Location = new System.Drawing.Point(177, 284);
            this.btnMalSearch.Name = "btnMalSearch";
            this.btnMalSearch.Size = new System.Drawing.Size(144, 50);
            this.btnMalSearch.TabIndex = 26;
            this.btnMalSearch.Text = "Axtar";
            this.btnMalSearch.UseVisualStyleBackColor = true;
            this.btnMalSearch.Click += new System.EventHandler(this.BtnMalSearch_Click_1);
            // 
            // btnMalRefresh
            // 
            this.btnMalRefresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMalRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMalRefresh.Location = new System.Drawing.Point(12, 284);
            this.btnMalRefresh.Name = "btnMalRefresh";
            this.btnMalRefresh.Size = new System.Drawing.Size(137, 50);
            this.btnMalRefresh.TabIndex = 27;
            this.btnMalRefresh.Text = "Yenilə";
            this.btnMalRefresh.UseVisualStyleBackColor = true;
            this.btnMalRefresh.Click += new System.EventHandler(this.BtnMalRefresh_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Location = new System.Drawing.Point(0, 510);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(876, 25);
            this.panel2.TabIndex = 28;
            // 
            // btnMalFilterOk
            // 
            this.btnMalFilterOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMalFilterOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMalFilterOk.Location = new System.Drawing.Point(12, 385);
            this.btnMalFilterOk.Name = "btnMalFilterOk";
            this.btnMalFilterOk.Size = new System.Drawing.Size(137, 50);
            this.btnMalFilterOk.TabIndex = 29;
            this.btnMalFilterOk.Text = "Tək birini seçin";
            this.btnMalFilterOk.UseVisualStyleBackColor = true;
            this.btnMalFilterOk.Click += new System.EventHandler(this.BtnMalFilterOk_Click);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(41, 122);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(28, 13);
            this.label30.TabIndex = 31;
            this.label30.Text = "Tipi";
            // 
            // cmbbxMalTip
            // 
            this.cmbbxMalTip.FormattingEnabled = true;
            this.cmbbxMalTip.Location = new System.Drawing.Point(83, 116);
            this.cmbbxMalTip.Name = "cmbbxMalTip";
            this.cmbbxMalTip.Size = new System.Drawing.Size(200, 21);
            this.cmbbxMalTip.TabIndex = 30;
            // 
            // txtMalTopQiymet
            // 
            this.txtMalTopQiymet.Location = new System.Drawing.Point(83, 227);
            this.txtMalTopQiymet.Name = "txtMalTopQiymet";
            this.txtMalTopQiymet.Size = new System.Drawing.Size(200, 20);
            this.txtMalTopQiymet.TabIndex = 34;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(80, 211);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(123, 13);
            this.label34.TabIndex = 33;
            this.label34.Text = "Topdan satış qiyməti";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(80, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Pərakəndə satış  qiyməti";
            // 
            // txtMalKod
            // 
            this.txtMalKod.Location = new System.Drawing.Point(83, 40);
            this.txtMalKod.Name = "txtMalKod";
            this.txtMalKod.Size = new System.Drawing.Size(200, 20);
            this.txtMalKod.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(42, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Kodu";
            // 
            // btnAllMalFilterOK
            // 
            this.btnAllMalFilterOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAllMalFilterOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAllMalFilterOK.Location = new System.Drawing.Point(184, 385);
            this.btnAllMalFilterOK.Name = "btnAllMalFilterOK";
            this.btnAllMalFilterOK.Size = new System.Drawing.Size(137, 50);
            this.btnAllMalFilterOK.TabIndex = 37;
            this.btnAllMalFilterOK.Text = "Hamısını seçin";
            this.btnAllMalFilterOK.UseVisualStyleBackColor = true;
            this.btnAllMalFilterOK.Click += new System.EventHandler(this.BtnAllMalFilterOK_Click);
            // 
            // frmMalFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(876, 535);
            this.Controls.Add(this.btnAllMalFilterOK);
            this.Controls.Add(this.txtMalKod);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMalTopQiymet);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.cmbbxMalTip);
            this.Controls.Add(this.btnMalFilterOk);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnMalRefresh);
            this.Controls.Add(this.btnMalSearch);
            this.Controls.Add(this.grdvwMal);
            this.Controls.Add(this.txtMalAdi);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.txtMalQiymet);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMalFilter";
            this.Text = "Mal seçin";
            this.Load += new System.EventHandler(this.FrmMalFilter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdvwMal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMalAdi;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.TextBox txtMalQiymet;
        private System.Windows.Forms.DataGridView grdvwMal;
        private System.Windows.Forms.Button btnMalSearch;
        private System.Windows.Forms.Button btnMalRefresh;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnMalFilterOk;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ComboBox cmbbxMalTip;
        private System.Windows.Forms.TextBox txtMalTopQiymet;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMalKod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAllMalFilterOK;
    }
}