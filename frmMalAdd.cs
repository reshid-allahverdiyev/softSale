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
    public partial class frmMalAdd : Form
    {
        public frmMalAdd()
        {
            InitializeComponent();
        }
        SqlConnect sqlconnect = new SqlConnect();
        private void FrmMalAdd_Load(object sender, EventArgs e)
        {
            fillCmbMalTip();
            if (!frmAdminPanel.malCreateOrModify)
            {
                pnlMalModify.Visible = false;
                pnlMalAdd.Visible = true;
            }
            else
            {
                pnlMalAdd.Visible = false;
                pnlMalModify.Visible = true;
                getMalModify();
            }
        }

        #region regionMalAdd
        private void fillCmbMalTip()
        {
            try
            {
                string query = @"Select '0' ID, N'--Tip seçin--' name
                           union
                           Select ID, name    from tblTip where deleted=0";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                cmbbxMalTipAdd.DataSource = ds.Tables[0];
                cmbbxMalTipAdd.DisplayMember = "name";
                cmbbxMalTipAdd.ValueMember = "ID";
                cmbbxMalTipEdit.DataSource = ds.Tables[0];
                cmbbxMalTipEdit.DisplayMember = "name";
                cmbbxMalTipEdit.ValueMember = "ID";
                sqlconnect.close();
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin!");
            }
        }
        private void BtnMalAddCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void BtnMalAddApply_Click(object sender, EventArgs e)
        {
            if (txtAd.Text == "")
            {
                MessageBox.Show("Ad sahəsi boşdur!!!");
                return;
            }
            if (txtQiymet.Text == "")
            {
                MessageBox.Show("Qiymət sahəsi boşdur!!!");
                return;
            }
            if (txtQiymet.Text == "")
            {
                MessageBox.Show("Pərakəndə satış qiyməti sahəsi boşdur!!!");
                return;
            }
            if (txtMalTopQiymet.Text == "")
            {
                MessageBox.Show("Topdan satış qiyməti sahəsi boşdur!!!");
                return;
            }
            if (cmbbxMalTipAdd.SelectedIndex==0)
            {
                MessageBox.Show("Tip seçin!!!");
                return;
            }
            try
            {
                string query = "insert into tblMal values(@Name,@qiymet,0,@tip,@topQiymet)";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                cmd.Parameters.AddWithValue("@Name", txtAd.Text);
                cmd.Parameters.AddWithValue("@qiymet", txtQiymet.Text);
                cmd.Parameters.AddWithValue("@tip", cmbbxMalTipAdd.Text);
                cmd.Parameters.AddWithValue("@topQiymet", txtMalTopQiymet.Text);
                cmd.ExecuteNonQuery();
                sqlconnect.close();
                MessageBox.Show("Məlumatın əlavə edilməsi uğurla tamamlandı");
                frmAdminPanel.malCreateOrModify = false;
                this.Hide();
                frmAdminPanel.idMal = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
        }
        #endregion


        #region region MalModify 
        private void getMalModify()
        {
            try
            {
                string query = "Select * from tblMal where ID=" + frmAdminPanel.idMal;
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                if (dt.Rows.Count != 0)
                {
                    txtAdModify.Text = dt.Rows[0][1].ToString();
                    txtQiymetlModify.Text = dt.Rows[0][2].ToString(); 
                    cmbbxMalTipEdit.Text= dt.Rows[0][4].ToString();
                    txtMalTopQiymet.Text = dt.Rows[0][5].ToString();
                }
                else
                {
                    MessageBox.Show("Mal tapılmadı!");
                }
                sqlconnect.close();
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
        }
        private void BtnMalCancelModify_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BtnMalApplyModify_Click(object sender, EventArgs e)
        {
            string s = MessageBox.Show("Məlumata düzəliş edilməsinə əminsiniz?", "Diqqət", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
            if (s == "Yes")
            {
                string query = "";

                if (txtAdModify.Text != "")
                {
                    query += " Name=N'" + txtAdModify.Text + "'";
                }
                else
                {
                    MessageBox.Show("Ad sahəsi boşdur!!!");
                    return;
                }

                if (txtQiymetlModify.Text != "")
                {
                    if (query != "")
                    {
                        query += " , qiymet=N'" + txtQiymetlModify.Text + "'";
                    }
                    else
                    {
                        query += " qiymet=N'" + txtQiymetlModify.Text + "'";
                    }
                }
                else
                {
                    MessageBox.Show("Qiymət sahəsi boşdur!!!");
                    return;
                }

                if (txtMalTopQiymetEdit.Text != "")
                {
                    if (query != "")
                    {
                        query += " , topdanQiymet=N'" + txtMalTopQiymetEdit.Text + "'";
                    }
                    else
                    {
                        query += " topdanQiymet=N'" + txtMalTopQiymetEdit.Text + "'";
                    }
                }
                else
                {
                    MessageBox.Show("Topdan satis  qiymət sahəsi boşdur!!!");
                    return;
                }

                if (cmbbxMalTipAdd.SelectedIndex!= 0)
                {
                    if (query != "")
                    {
                        query += " , tip=N'" + cmbbxMalTipAdd.Text + "'";
                    }
                    else
                    {
                        query += " tip=N'" + cmbbxMalTipAdd.Text + "'";
                    }
                }
                else
                {
                    MessageBox.Show("Tip sahəsi boşdur!!!");
                    return;
                }
                if (query != "")
                {
                    string fullquery = "UPDATE tblMal SET " + query + "  Where ID=" + frmAdminPanel.idMal;
                    try
                    {

                        SqlCommand cmd = new SqlCommand();
                        cmd = new SqlCommand(fullquery, sqlconnect.connect());
                        cmd.ExecuteNonQuery();
                        sqlconnect.close();
                        MessageBox.Show("Düzəliş uğurla tamamlandı");
                        frmAdminPanel.malCreateOrModify = false;
                        this.Hide();
                        sqlconnect.close();
                        frmAdminPanel.idMal = -1;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
                    }
                }
                else
                {
                    MessageBox.Show("Düzəlişləri daxil edin!");
                }
            }
        }


        #endregion

       
    }
}
