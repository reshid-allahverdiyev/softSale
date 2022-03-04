using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace softSale
{
    public partial class frmAnbaraMalDaxilEt : Form
    {
        public frmAnbaraMalDaxilEt()
        {
            InitializeComponent();
        }
        SqlConnect sqlconnect = new SqlConnect();
        Random random = new Random();
        private void FrmAnbaraMalDaxilEt_Load(object sender, EventArgs e)
        {
            cmbAnbarDaxilolmaFillBaza();
            cmbAnbarDaxilolmaFill();
            dtMalDaxilolma.Checked = false;
            if (!frmAdminPanel.malDaxilolmaCreateOrModify)
            { 
                pnlAdminAdd.Visible = true; 
            }
            else
            { 
                pnlAdminAdd.Visible = false; 
            }
        } 
      
        
        #region regionMalDaxilEtAdd
        private void cmbAnbarDaxilolmaFillBaza()
        {
            try
            {
                string query = @"  
                           Select ID, Name+   
                            (case when TYPE = 1 then  N'-Pərakəndə' when TYPE = 2 then N'-Əsas'  when type=0 then '' end)
                            as Anbar  from tblAnbar where deleted=0"; 
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                cmbbxAnbarDaxilolmaBaza.DataSource = ds.Tables[0];
                cmbbxAnbarDaxilolmaBaza.DisplayMember = "Anbar";
                cmbbxAnbarDaxilolmaBaza.ValueMember = "ID";
                sqlconnect.close(); 
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin!");
            }
        }
        private void cmbAnbarDaxilolmaFill()
        {
            try
            {
                string query = @" 
                           Select ID, Name+  '-'+
                          (case when TYPE = 1 then N'Pərakəndə' when TYPE = 2 then N'Əsas' end)
                           as Anbar  from tblAnbar where deleted=0 and  type!=0";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                cmbbxAnbarDaxilolan.DataSource = ds.Tables[0];
                cmbbxAnbarDaxilolan.DisplayMember = "Anbar";
                cmbbxAnbarDaxilolan.ValueMember = "ID";
                sqlconnect.close(); 
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin!");
            }
        }
        public double getLastMiqdarOfMalCixan()
        {
            double miqdar = 0;
            try
            {
                string query = @"select top 1 miqdar from tblAnbarQaliqi
                                where anbarID=@anbarId and  malID=@MalID and date<=@date
                                order by  date  desc";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                cmd.Parameters.AddWithValue("@anbarId", cmbbxAnbarDaxilolmaBaza.SelectedValue);
                cmd.Parameters.AddWithValue("@MalID", txtAnbarDaxiolmaSelectedMal.Text);
                cmd.Parameters.AddWithValue("@miqdar", txtMalDaxilolmaMiqdar.Text);
                cmd.Parameters.AddWithValue("@date", dtMalDaxilolma.Value);
                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                if (dt.Rows.Count != 0)
                {
                    miqdar = Convert.ToDouble(dt.Rows[0][0].ToString());
                }
                else
                {
                    MessageBox.Show("Nəticə tapılmadı!");
                }
                sqlconnect.close();
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
            return miqdar;
        }
        public double getLastMiqdarOfMalGiren()
        {
            double miqdar = 0;
            try
            { 
                string query = @"select top 1 miqdar from tblAnbarQaliqi
                                where anbarID=@anbarId and  malID=@MalID and date<=@date
                                order by  date  desc";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());  
                cmd.Parameters.AddWithValue("@anbarId", cmbbxAnbarDaxilolan.SelectedValue);
                cmd.Parameters.AddWithValue("@MalID", txtAnbarDaxiolmaSelectedMal.Text);
                cmd.Parameters.AddWithValue("@miqdar", txtMalDaxilolmaMiqdar.Text);
                cmd.Parameters.AddWithValue("@date", dtMalDaxilolma.Value); 
                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                if (dt.Rows.Count != 0)
                {
                    miqdar = Convert.ToDouble(dt.Rows[0][0].ToString());
                }
                else
                {
                    MessageBox.Show("Nəticə tapılmadı!");
                }
                sqlconnect.close(); 
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
            return miqdar;
        }
        private void changeCixanAnbarQaligi()
        {
            try
            {
                string query = "insert  into tblAnbarQaliqi values(@anbarId,@malId,@miqdar,@date)";
                string miqdar = (getLastMiqdarOfMalCixan()-Convert.ToDouble(txtMalDaxilolmaMiqdar.Text)).ToString();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                cmd.Parameters.AddWithValue("@anbarId", cmbbxAnbarDaxilolmaBaza.SelectedValue);
                cmd.Parameters.AddWithValue("@MalID", txtAnbarDaxiolmaSelectedMal.Text);
                cmd.Parameters.AddWithValue("@miqdar", miqdar);
                cmd.Parameters.AddWithValue("@date", dtMalDaxilolma.Value);
                cmd.ExecuteNonQuery();
                sqlconnect.close();
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
        }
        private void changeGirenAnbarQaligi()
        {
            try
            {
                string query = "insert  into tblAnbarQaliqi values(@anbarId,@malId,@miqdar,@date)";
                string miqdar = (Convert.ToDouble(txtMalDaxilolmaMiqdar.Text) + getLastMiqdarOfMalGiren()).ToString();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                cmd.Parameters.AddWithValue("@anbarId", cmbbxAnbarDaxilolan.SelectedValue); 
                cmd.Parameters.AddWithValue("@MalID", txtAnbarDaxiolmaSelectedMal.Text);
                cmd.Parameters.AddWithValue("@miqdar", miqdar);
                cmd.Parameters.AddWithValue("@date", dtMalDaxilolma.Value); 
                cmd.ExecuteNonQuery();
                sqlconnect.close();
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
        }
        private void BtnAnbarDaxilolmaCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void BtnAnbarDaxilolmaAddApply_Click(object sender, EventArgs e)
        { 
            if (txtAnbarDaxiolmaSelectedMal.Text=="")
            {
                MessageBox.Show("Mal seçin!!!");
                return;
            }
            if (cmbbxAnbarDaxilolmaBaza.SelectedIndex==0)
            {
                if (txtDaxilolmaAlisQiymeti.Text == "")
                {
                    MessageBox.Show("Alış qiyməti boşdur!!!");
                    return;
                } 
            }
            if (txtMalDaxilolmaMiqdar.Text == "")
            {
                MessageBox.Show("Miqdar sahəsi boşdur!!!");
                return;
            }
            if (!dtMalDaxilolma.Checked)
            {
                MessageBox.Show("Tarix seçin!!!");
                return;
            } 
            try
            {
                if (cmbbxAnbarDaxilolmaBaza.SelectedIndex!=0)
                {
                    if (getLastMiqdarOfMalCixan() >= Convert.ToDouble(txtMalDaxilolmaMiqdar.Text))
                    {
                        string query = "insert into tblAnbarDaxilolma values(@basaId,@anbarId,@MalID,@alisqiymeti,@miqdar,@date)";
                        SqlCommand cmd = new SqlCommand();
                        cmd = new SqlCommand(query, sqlconnect.connect());
                        cmd.Parameters.AddWithValue("@basaId", cmbbxAnbarDaxilolmaBaza.SelectedValue);
                        cmd.Parameters.AddWithValue("@anbarId", cmbbxAnbarDaxilolan.SelectedValue);
                        cmd.Parameters.AddWithValue("@MalID", txtAnbarDaxiolmaSelectedMal.Text);
                        cmd.Parameters.AddWithValue("@miqdar", txtMalDaxilolmaMiqdar.Text);
                        cmd.Parameters.AddWithValue("@date", dtMalDaxilolma.Value);
                        cmd.Parameters.AddWithValue("@alisqiymeti", txtDaxilolmaAlisQiymeti.Text);
                        cmd.ExecuteNonQuery();
                        sqlconnect.close();
                        MessageBox.Show("Məlumatın əlavə edilməsi uğurla tamamlandı");
                        frmAdminPanel.malDaxilolmaCreateOrModify = false;
                        this.Hide();
                        frmAdminPanel.idMalDaxilolma = -1;
                        changeGirenAnbarQaligi();
                        changeCixanAnbarQaligi();
                    }
                    else
                    {
                        MessageBox.Show("Bu maldan seçilmiş anbarda  " + txtMalDaxilolmaMiqdar.Text + "-dan az miqdarda qalmışdır!!!");
                    }
                }
                else
                {
                    string query = "insert into tblAnbarDaxilolma values(@basaId,@anbarId,@MalID,@alisqiymeti,@miqdar,@date)";
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand(query, sqlconnect.connect());
                    cmd.Parameters.AddWithValue("@basaId", cmbbxAnbarDaxilolmaBaza.SelectedValue);
                    cmd.Parameters.AddWithValue("@anbarId", cmbbxAnbarDaxilolan.SelectedValue);
                    cmd.Parameters.AddWithValue("@MalID", txtAnbarDaxiolmaSelectedMal.Text);
                    cmd.Parameters.AddWithValue("@miqdar", txtMalDaxilolmaMiqdar.Text);
                    cmd.Parameters.AddWithValue("@date", dtMalDaxilolma.Value);
                    cmd.Parameters.AddWithValue("@alisqiymeti", txtDaxilolmaAlisQiymeti.Text);
                    cmd.ExecuteNonQuery();
                    sqlconnect.close();
                    MessageBox.Show("Məlumatın əlavə edilməsi uğurla tamamlandı");
                    frmAdminPanel.malDaxilolmaCreateOrModify = false;
                    this.Hide();
                    frmAdminPanel.idMalDaxilolma = -1;
                    changeGirenAnbarQaligi(); 
                }     
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
        }
        private void CmbbxAnbarDaxilolmaBaza_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbbxAnbarDaxilolmaBaza.SelectedIndex!=0)
            {
                txtDaxilolmaAlisQiymeti.Enabled = false;
            }
            else
            {
                txtDaxilolmaAlisQiymeti.Enabled = true;
            }
        }
        private void LnkMalFilter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmMalFilter frmMalFilter = new frmMalFilter();
            frmMalFilter.ShowDialog();
            if (frmMalFilter.idMal != -1)
            {
                txtAnbarDaxiolmaSelectedMal.Text = frmMalFilter.idMal.ToString();
            }
            else
            {
                txtAnbarDaxiolmaSelectedMal.Text = "";
            }
        }


        #endregion


    }
}
