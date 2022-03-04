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
    public partial class frmTipAdd : Form
    {
        public frmTipAdd()
        {
            InitializeComponent();
        }
        SqlConnect sqlconnect = new SqlConnect();
        private void frmTipAdd_Load(object sender, EventArgs e)
        {
            if (!frmAdminPanel.tipCreateOrModify)
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
            try
            {
                string query = "insert into tblTip values(@Name,0)";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                cmd.Parameters.AddWithValue("@Name", txtAd.Text); 
                cmd.ExecuteNonQuery();
                sqlconnect.close();
                MessageBox.Show("Məlumatın əlavə edilməsi uğurla tamamlandı");
                frmAdminPanel.tipCreateOrModify = false;
                this.Hide();
                frmAdminPanel.idTip = -1;
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
                string query = "Select * from tblTip where ID=" + frmAdminPanel.idTip;
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                if (dt.Rows.Count != 0)
                {
                    txtAdModify.Text = dt.Rows[0][1].ToString(); 
                }
                else
                {
                    MessageBox.Show("Tip tapılmadı!");
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
                  
                if (query != "")
                {
                    string fullquery = "UPDATE tblTip SET " + query + "  Where ID=" + frmAdminPanel.idTip;
                    try
                    {

                        SqlCommand cmd = new SqlCommand();
                        cmd = new SqlCommand(fullquery, sqlconnect.connect());
                        cmd.ExecuteNonQuery();
                        sqlconnect.close();
                        MessageBox.Show("Düzəliş uğurla tamamlandı");
                        frmAdminPanel.tipCreateOrModify = false;
                        this.Hide();
                        sqlconnect.close();
                        frmAdminPanel.idTip = -1;
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
