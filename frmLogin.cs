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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        public static string user_name = "";
        public static string basa = "";
        SqlConnect sqlconnect = new SqlConnect();
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            pShow.Visible = true;
            pHide.Visible = false;
            cmbbxBasa.Items.Clear();
            cmbbxBasa.ResetText();
            cmbbxBasa.Items.Add("Prod");
            cmbbxBasa.Items.Add("Test");  
            cmbbxBasa.SelectedText = "Prod";
            basa = "Prod";
        }

      
    

        private void BtnLogin_Click_1(object sender, EventArgs e)
        {
            try
            {
                lblNote.Text = "";
                string query = "Select * from tblAdmin a where a.Username=@username and a.Password=@password";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@password", txtUserPassword.Text);
                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                if (dt.Rows.Count != 0)
                {
                    bool t = false;
                    user_name = Convert.ToString(dt.Rows[0]["username"]);
                    if (Convert.ToString(dt.Rows[0]["username"])=="1"&& Convert.ToString(dt.Rows[0]["password"]) == "1")
                    {
                        t = true;
                    }
                    sqlconnect.close();
                    this.Hide();
                    frmAdminPanel frmAdminPanel = new frmAdminPanel(t);
                    frmAdminPanel.Show();
                }
                else
                {
                    lblNote.Text = "İstifadəçi adı və ya parolu yalnışdır!";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
         
        private void PShow_Click(object sender, EventArgs e)
        {
            txtUserPassword.UseSystemPasswordChar = false;
            pShow.Visible = false;
            pHide.Visible = true;
        }

        private void PHide_Click(object sender, EventArgs e)
        {
            txtUserPassword.UseSystemPasswordChar = true;
            pShow.Visible = true;
            pHide.Visible = false;
        }

        private void CmbbxBasa_SelectedIndexChanged(object sender, EventArgs e)
        {
            basa = cmbbxBasa.SelectedItem.ToString();
        }
    }
}
