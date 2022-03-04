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
    public partial class frmAnbarAdd : Form
    {
        public frmAnbarAdd()
        {
            InitializeComponent();
        }
        SqlConnect sqlconnect = new SqlConnect();
         
        private void FrmAnbarAdd_Load(object sender, EventArgs e)
        {
            if (!frmAdminPanel.anbarCreateOrModify)
            {
                pnlAnbarModify.Visible = false;
                pnlAnbarAdd.Visible = true;
                cmbAnbar(cmbbxAnbarAdd);
            }
            else
            {
                pnlAnbarAdd.Visible = false;
                pnlAnbarModify.Visible = true;
                cmbAnbar(cmbbxAnbarModify);
                getMalModify();
            }
        }
        private void cmbAnbar(ComboBox cb)
        {
            cb.Items.Clear();
            cb.ResetText();
            cb.DisplayMember = "Text";
            cb.ValueMember = "Value";
            cb.Items.Add(new { Text = "Pərakəndə satış anbarı", Value = 1 });
            cb.Items.Add(new { Text = "Topdan satış anbarı-Mərkəz anbar", Value = 2 });
            cb.SelectedItem = null;
            cb.SelectedText = "Anbar tipi seçin";
        }


        #region regionAnbarAdd
        private void BtnAnbarAddCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BtnAnbarAddApply_Click(object sender, EventArgs e)
        {
            if (txtAnbarNameAdd.Text == "")
            {
                MessageBox.Show("Ad sahəsi boşdur!!!");
                return;
            }
            if (cmbbxAnbarAdd.SelectedItem==null)
            {
                MessageBox.Show("Tip sahəsi sahəsi boşdur!!!");
                return;
            } 
            try
            {
                string query = "insert into tblAnbar values(@Name,@Type, 0)";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                cmd.Parameters.AddWithValue("@Name", txtAnbarNameAdd.Text);
                cmd.Parameters.AddWithValue("@Type", (cmbbxAnbarAdd.SelectedIndex + 1).ToString()); 
                cmd.ExecuteNonQuery();
                sqlconnect.close();
                MessageBox.Show("Məlumatın əlavə edilməsi uğurla tamamlandı");
                frmAdminPanel.anbarCreateOrModify = false;
                this.Hide();
                frmAdminPanel.idAnbar = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
        }

        #endregion


        #region region CarModify

        private void getMalModify()
        {
            try
            {
                string query = "Select * from tblAnbar where ID=" + frmAdminPanel.idAnbar;
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                if (dt.Rows.Count != 0)
                {
                    txtAnbarNameModify.Text = dt.Rows[0][1].ToString();
                    cmbbxAnbarModify.SelectedIndex = Convert.ToInt32(dt.Rows[0][2].ToString()) - 1; 
                }
                else
                {
                    MessageBox.Show("İstifadəçi tapılmadı!");
                }
                sqlconnect.close();
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
        }
        private void BtnAnbarCancelModify_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BtnApplyModify_Click(object sender, EventArgs e)
        {
            if(txtAnbarNameModify.Text == "")
            {
                MessageBox.Show("Ad sahəsi boşdur!!!");
                return;
            }
            if (cmbbxAnbarModify.SelectedItem == null)
            {
                MessageBox.Show("Anbar tipini seçin!!!");
                return;
            }
            string s = MessageBox.Show("Məlumata düzəliş edilməsinə əminsiniz?", "Diqqət", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
            if (s == "Yes")
            {
                string query = "";

                if (txtAnbarNameModify.Text != "")
                {
                    query += " Name=N'" + txtAnbarNameModify.Text + "'";
                }
                

                if (cmbbxAnbarModify.SelectedItem!= null)
                {
                    if (query != "")
                    {
                        query += " , Type='" + (cmbbxAnbarModify.SelectedIndex + 1).ToString() + "'";
                    }
                    else
                    {
                        query += " Type= '" + (cmbbxAnbarModify.SelectedIndex + 1).ToString() + "'";
                    }
                }


                if (query != "")
                {
                    string fullquery = "UPDATE tblAnbar SET " + query + " Where ID=" + frmAdminPanel.idAnbar;
                    try
                    {

                        SqlCommand cmd = new SqlCommand();
                        cmd = new SqlCommand(fullquery, sqlconnect.connect());
                        cmd.ExecuteNonQuery();
                        sqlconnect.close();
                        MessageBox.Show("Düzəliş uğurla tamamlandı");
                        frmAdminPanel.anbarCreateOrModify = false;
                        this.Hide();
                        sqlconnect.close();
                        frmAdminPanel.idAnbar = -1;
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
