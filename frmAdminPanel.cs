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
    public partial class frmAdminPanel : Form
    {
        bool t;
        public frmAdminPanel(bool t)
        {
            InitializeComponent();
            this.t = t;
        }

        #region regionHeader

        SqlConnect sqlconnect = new SqlConnect();
        GridViewDesignClass g = new GridViewDesignClass();
        bool cmb = false;
        private void FrmAdminPanel_Load(object sender, EventArgs e)
        {
            if (!t)
            {
                foreach (TabPage page in tabControl1.TabPages)
                {
                    tabControl1.TabPages.Remove(page);
                }
                tabControl1.TabPages.Add(tbpgSale);
            }
            cmb = false;
            refreshMalSat();
            refreshMalSatilan();
            lblCurrentUserName.Text = frmLogin.user_name;
        }

        private void FrmAdminPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void TabControl1_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedTab.Name)
            {
                case "tbpgMal": refreshMal(); break;
                case "tbpgAnbar": refreshAnbar(); break;
                case "tbpgAdmin": refreshAdmin(); break;
                case "tbpgAnbarDaxilOlma": refreshMalDaxilolma(); break;
                case "tbpgAnbarQaliqi": refreshAnbarQaligi(); break;
                case "tbpgSale": { refreshMalSat(); refreshMalSatilan(); }; break;
                case "tbpgSatislar": refreshSatislar(); break;
                case "tppgTip": refreshTip(); break;
            }
        }
        private void Label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
        }

        #endregion


        #region regionMal
        public static bool malCreateOrModify = false;
        public static int idMal = -1;
        public void refreshMal()
        {
            fillCmbMalTip();
            try
            {
                grdvwMal.Columns.Clear();
                string query = "Select * from tblMal where deleted=0";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());

                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                if (dt.Rows.Count != 0)
                {
                    grdvwMal.DataSource = dt;
                    g.GridViewDesign(dt.Rows.Count, grdvwMal);
                    grdvwMal.Columns[4].Visible = false;
                }
                else
                {
                    MessageBox.Show("Mal tapılmadı!");
                }

                sqlconnect.close();
                idMal = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
        }
        private void cleanMal()
        {
            txtMalAdi.Text = "";
            txtMalQiymet.Text = "";
            txtMalTopQiymet.Text = "";
        }
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
                cmbbxMalTip.DataSource = ds.Tables[0];
                cmbbxMalTip.DisplayMember = "name";
                cmbbxMalTip.ValueMember = "ID";
                sqlconnect.close();
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin!");
            }
        }
        private void BtnMalRefresh_Click_1(object sender, EventArgs e)
        {
            refreshMal();
            cleanMal();
        }
        private void BtnMalSearch_Click_1(object sender, EventArgs e)
        {
            string query = "";

            if (txtMalAdi.Text != "")
            {
                query += " Name like N'" + txtMalAdi.Text + "'";
            }

            if (txtMalQiymet.Text != "")
            {
                if (query != "")
                {
                    query += " and qiymet=N'" + txtMalQiymet.Text + "'";
                }
                else
                {
                    query += " qiymet=N'" + txtMalQiymet.Text + "'";
                }
            }
            if (txtMalTopQiymet.Text != "")
            {
                if (query != "")
                {
                    query += " and topdanQiymet=N'" + txtMalTopQiymet.Text + "'";
                }
                else
                {
                    query += " topdanQiymet=N'" + txtMalTopQiymet.Text + "'";
                }
            }
            if (cmbbxMalTip.SelectedIndex != 0)
            {
                if (query != "")
                {
                    query += " and tip=N'" + cmbbxMalTip.Text + "'";
                }
                else
                {
                    query += " tip=N'" + cmbbxMalTip.Text + "'";
                }
            }


            string fullquery = "Select * from tblMal where " + query + " and deleted=0";
            if (query != "")
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand(fullquery, sqlconnect.connect());
                    SqlDataReader rd = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(rd);
                    //if (dt.Rows.Count != 0)
                    if (1 == 1)
                    {
                        grdvwMal.Columns.Clear();
                        grdvwMal.DataSource = dt;
                        g.GridViewDesign(dt.Rows.Count, grdvwMal);
                        grdvwMal.Columns[4].Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Uyğun mal tapılmadı!");
                    }
                    sqlconnect.close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
                }
            }
            else
            {
                MessageBox.Show("Axtarış üçün ən azı bir sahə doldurulmalıdır!");
            }
            idMal = -1;
        }
        private void BtnMalDelete_Click_1(object sender, EventArgs e)
        {
            if (idMal != -1)
            {
                string s = MessageBox.Show("Silmək istədiyinizdən əminsiniz?", "Diqqət", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                if (s == "Yes")
                {
                    string query = "update   tblMal set deleted=1 Where ID=" + idMal;
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd = new SqlCommand(query, sqlconnect.connect());
                        cmd.ExecuteNonQuery();
                        sqlconnect.close();
                        MessageBox.Show("Silinmə uğurla tamamlandı");
                        refreshMal();
                        cleanMal();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
                    }
                }
            }
            else
            {
                MessageBox.Show("Məlumat seçilməyib!");
            }
            idMal = -1;
        }

        private void BtnMalAdd_Click_1(object sender, EventArgs e)
        {
            malCreateOrModify = false;
            frmMalAdd frmMalAdd = new frmMalAdd();
            frmMalAdd.Text = "Yeni mal";
            frmMalAdd.ShowDialog();
            refreshMal();
        }

        private void BtnMalEdit_Click_1(object sender, EventArgs e)
        {
            if (idMal != -1)
            {
                malCreateOrModify = true;
                frmMalAdd frmMalAdd = new frmMalAdd();
                frmMalAdd.Text = "Düzəliş";
                frmMalAdd.ShowDialog();
                refreshMal();
            }
            else
            {
                MessageBox.Show("Məlumat seçilməyib!");
            }
        }
        private void GrdvwMal_Sorted_1(object sender, EventArgs e)
        {
            for (int i = 0; i < grdvwMal.Rows.Count; i++)
            {
                grdvwMal.Rows[i].Cells[1].Value = (i + 1).ToString();
            }
        }
        private void GrdvwMal_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)

        {
            cleanMal();
            int index = e.RowIndex;
            DataGridViewRow row = grdvwMal.Rows[index];
            idMal = Int32.Parse(row.Cells[0].Value.ToString());
            txtMalAdi.Text = row.Cells[2].Value.ToString();
            txtMalQiymet.Text = row.Cells[3].Value.ToString();
            txtMalTopQiymet.Text = row.Cells[5].Value.ToString();
        }
        #endregion

        #region regionTip
        public static bool tipCreateOrModify = false;
        public static int idTip = -1;
        public void refreshTip()
        {
            try
            {
                grdTip.Columns.Clear();
                string query = "Select * from tblTip where deleted=0";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());

                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                if (dt.Rows.Count != 0)
                {
                    grdTip.DataSource = dt;
                    g.GridViewDesign(dt.Rows.Count, grdTip);
                    grdTip.Columns[3].Visible = false;
                }
                else
                {
                    MessageBox.Show("Tip tapılmadı!");
                }

                sqlconnect.close();
                idTip = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
        }
        private void cleanTip()
        {
            txtTip.Text = "";
        }

        private void BtnTipYenile_Click(object sender, EventArgs e)
        {
            refreshTip();
            cleanTip();
        }

        private void BtnTipAxtar_Click(object sender, EventArgs e)
        {
            string query = "";

            if (txtTip.Text != "")
            {
                query += " name like N'" + txtTip.Text + "'";
            }

            if (query != "")
            {
                try
                {
                    string fullquery = "Select * from tbltip where " + query + " and deleted=0";
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand(fullquery, sqlconnect.connect());
                    SqlDataReader rd = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(rd);
                    // if (dt.Rows.Count != 0)
                    if (1 == 1)
                    {
                        grdTip.Columns.Clear();
                        grdTip.DataSource = dt;
                        g.GridViewDesign(dt.Rows.Count, grdTip);
                        grdTip.Columns[3].Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Uyğun tip tapılmadı!");
                    }
                    sqlconnect.close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
                }
            }
            else
            {
                MessageBox.Show("Axtarış üçün ən azı bir sahə doldurulmalıdır!");
            }
            idTip = -1;
        }
        private void BtnTipSil_Click(object sender, EventArgs e)
        {
            if (idTip != -1)
            {
                string s = MessageBox.Show("Silmək istədiyinizdən əminsiniz?", "Diqqət", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                if (s == "Yes")
                {
                    string query = "update   tblTip set deleted=1 Where ID=" + idTip;
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd = new SqlCommand(query, sqlconnect.connect());
                        cmd.ExecuteNonQuery();
                        sqlconnect.close();
                        MessageBox.Show("Silinmə uğurla tamamlandı");
                        refreshTip();
                        cleanTip();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
                    }
                }
            }
            else
            {
                MessageBox.Show("Məlumat seçilməyib!");
            }
            idTip = -1;
        }

        private void BtnTipAdd_Click(object sender, EventArgs e)
        {
            tipCreateOrModify = false;
            frmTipAdd frmTipAdd = new frmTipAdd();
            frmTipAdd.Text = "Yeni tip";
            frmTipAdd.ShowDialog();
            refreshTip();
        }

        private void BtnTipEdit_Click(object sender, EventArgs e)
        {
            if (idTip != -1)
            {
                tipCreateOrModify = true;
                frmTipAdd frmTipAdd = new frmTipAdd();
                frmTipAdd.Text = "Düzəliş";
                frmTipAdd.ShowDialog();
                refreshTip();
            }
            else
            {
                MessageBox.Show("Məlumat seçilməyib!");
            }
        }
        private void GrdTip_Sorted(object sender, EventArgs e)
        {
            for (int i = 0; i < grdTip.Rows.Count; i++)
            {
                grdTip.Rows[i].Cells[1].Value = (i + 1).ToString();
            }
        }
        private void GrdTip_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cleanTip();
            int index = e.RowIndex;
            DataGridViewRow row = grdTip.Rows[index];
            idTip = Int32.Parse(row.Cells[0].Value.ToString());
            txtTip.Text = row.Cells[2].Value.ToString();
        }

        #endregion




        #region regionAnbar
        public static bool anbarCreateOrModify = false;
        public static int idAnbar = -1;
        public void refreshAnbar()
        {
            cmbAnbar();
            try
            {
                grdvwAnbar.Columns.Clear();
                string query = @"Select Id,Name,
                        (case when Type=1 then N'Pərakəndə satış anbarı' else N'Topdan satış anbarı-Mərkəz anbar ' end) 'Anbar tipi',
                        Type
                        from tblAnbar where deleted=0 and type!=0";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());

                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                if (dt.Rows.Count != 0)
                {
                    grdvwAnbar.DataSource = dt;
                    g.GridViewDesign(dt.Rows.Count, grdvwAnbar);
                    grdvwAnbar.Columns[4].Visible = false;
                }
                else
                {
                    MessageBox.Show("Anbar tapılmadı!");
                }

                sqlconnect.close();
                idAnbar = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
        }
        private void cleanAnbar()
        {
            txtAnbarName.Text = "";
            cmbbxAnbarType.SelectedItem = null;
            cmbbxAnbarType.SelectedText = "Anbar tipi seçin";
        }
        private void cmbAnbar()
        {
            cmbbxAnbarType.Items.Clear();
            cmbbxAnbarType.ResetText();

            cmbbxAnbarType.DisplayMember = "Text";
            cmbbxAnbarType.ValueMember = "Value";

            cmbbxAnbarType.Items.Add(new { Text = "Pərakəndə satış anbarı", Value = 1 });
            cmbbxAnbarType.Items.Add(new { Text = "Topdan satış anbarı-Mərkəz anbar", Value = 2 });
            cmbbxAnbarType.SelectedItem = null;
            cmbbxAnbarType.SelectedText = "Anbar tipi seçin";
        }
        private void BtnAnbarSearch_Click_1(object sender, EventArgs e)
        {
            string query = "";

            if (txtAnbarName.Text != "")
            {
                query += " name like N'" + txtAnbarName.Text + "'";
            }

            if (cmbbxAnbarType.SelectedItem != null)
            {
                if (query != "")
                {
                    query += " and Type=N'" + (cmbbxAnbarType.SelectedIndex + 1).ToString() + "'";
                }
                else
                {
                    query += " Type=N'" + (cmbbxAnbarType.SelectedIndex + 1).ToString() + "'";
                }
            }



            string fullquery = "Select * from tblAnbar where " + query + " and  deleted=0";
            if (query != "")
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand(fullquery, sqlconnect.connect());
                    SqlDataReader rd = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(rd);
                    // if (dt.Rows.Count != 0)
                    if (1 == 1)
                    {
                        grdvwAnbar.Columns.Clear();
                        grdvwAnbar.DataSource = dt;
                        g.GridViewDesign(dt.Rows.Count, grdvwAnbar);
                        grdvwAnbar.Columns[4].Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Uyğun anbar  tapılmadı!");
                    }
                    sqlconnect.close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
                }
            }
            else
            {
                MessageBox.Show("Axtarış üçün ən azı bir sahə doldurulmalıdır!");
            }
            idAnbar = -1;
        }
        private void BtnAnbarRefresh_Click_1(object sender, EventArgs e)
        {
            refreshAnbar();
            cleanAnbar();
        }
        private void BtnAnbarDelete_Click_1(object sender, EventArgs e)
        {
            if (idAnbar != -1)
            {
                string s = MessageBox.Show("Silmək istədiyinizdən əminsiniz?", "Diqqət", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                if (s == "Yes")
                {
                    string query = "update  tblanbar set deleted=1 Where ID=" + idAnbar;
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd = new SqlCommand(query, sqlconnect.connect());
                        cmd.ExecuteNonQuery();
                        sqlconnect.close();
                        MessageBox.Show("Silinmə uğurla tamamlandı");
                        refreshAnbar();
                        cleanAnbar();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
                    }
                }
            }
            else
            {
                MessageBox.Show("Məlumat seçilməyib!");
            }
            idAnbar = -1;
        }

        private void BtnAnbarAdd_Click_1(object sender, EventArgs e)
        {
            anbarCreateOrModify = false;
            frmAnbarAdd frmAnbarAdd = new frmAnbarAdd();
            frmAnbarAdd.Text = "Yeni anbar";
            frmAnbarAdd.ShowDialog();
            refreshAnbar();
        }

        private void BtnAnbarModify_Click_1(object sender, EventArgs e)
        {
            if (idAnbar != -1)
            {
                anbarCreateOrModify = true;
                frmAnbarAdd frmAnbarAdd = new frmAnbarAdd();
                frmAnbarAdd.Text = "Düzəliş";
                frmAnbarAdd.ShowDialog();
                refreshAnbar();
            }
            else
            {
                MessageBox.Show("Məlumat seçilməyib!");
            }
        }

        private void GrdvwAnbar_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow row = grdvwAnbar.Rows[index];
            idAnbar = Int32.Parse(row.Cells[0].Value.ToString());
            txtAnbarName.Text = row.Cells[2].Value.ToString();
            cmbbxAnbarType.SelectedIndex = Convert.ToInt32(row.Cells[4].Value.ToString()) - 1;
        }

        private void GrdvwAnbar_Sorted(object sender, EventArgs e)
        {
            for (int i = 0; i < grdvwAnbar.Rows.Count; i++)
            {
                grdvwAnbar.Rows[i].Cells[1].Value = (i + 1).ToString();
            }
        }

        #endregion


        #region regionAdmin
        public static bool adminCreateOrModify = false;
        public static int idAdmin = -1;
        public void refreshAdmin()
        {
            try
            {
                grdvwAdmin.Columns.Clear();
                string query = "Select * from tblAdmin";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());

                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                //if (dt.Rows.Count != 0)
                if (1 == 1)
                {
                    grdvwAdmin.DataSource = dt;
                    g.GridViewDesign(dt.Rows.Count, grdvwAdmin);

                }
                else
                {
                    MessageBox.Show("İstifadəçi tapılmadı!");
                }

                sqlconnect.close();
                idAdmin = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
        }
        private void cleanAdmin()
        {
            txtAdminName.Text = "";
            txtAdminSurname.Text = "";
            txtAdminFatherName.Text = "";
            txtAdminFin.Text = "";
            txtAdminUsername.Text = "";
            txtAdminPassword.Text = "";
            dtAdminBirtday.Text = "";

        }
        private void BtnAdminRefresh_Click(object sender, EventArgs e)
        {
            refreshAdmin();
            cleanAdmin();
        }
        private void BtnAdminSearch_Click(object sender, EventArgs e)
        {
            string query = "";

            if (txtAdminName.Text != "")
            {
                query += " name like N'" + txtAdminName.Text + "'";
            }

            if (txtAdminSurname.Text != "")
            {
                if (query != "")
                {
                    query += " and surname like N'" + txtAdminSurname.Text + "'";
                }
                else
                {
                    query += " surname like N'" + txtAdminSurname.Text + "'";
                }
            }


            if (txtAdminFatherName.Text != "")
            {
                if (query != "")
                {
                    query += " and fathername like N'" + txtAdminFatherName.Text + "'";
                }
                else
                {
                    query += " fathername like N'" + txtAdminFatherName.Text + "'";
                }
            }

            if (txtAdminFin.Text != "")
            {
                if (query != "")
                {
                    query += " and fin like N'" + txtAdminFin.Text + "'";
                }
                else
                {
                    query += " fin like N'" + txtAdminFin.Text + "'";
                }
            }

            if (txtAdminUsername.Text != "")
            {
                if (query != "")
                {
                    query += " and username like N'" + txtAdminUsername.Text + "'";
                }
                else
                {
                    query += " username like N'" + txtAdminUsername.Text + "'";
                }
            }

            if (txtAdminPassword.Text != "")
            {
                if (query != "")
                {
                    query += " and password=N'" + txtAdminPassword.Text + "'";
                }
                else
                {
                    query += " password=N'" + txtAdminPassword.Text + "'";
                }
            }



            string fullquery = "Select * from tblAdmin where " + query;
            if (query != "")
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand(fullquery, sqlconnect.connect());
                    SqlDataReader rd = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(rd);
                    if (dt.Rows.Count != 0)
                    {
                        grdvwAdmin.Columns.Clear();
                        grdvwAdmin.DataSource = dt;
                        g.GridViewDesign(dt.Rows.Count, grdvwAdmin);
                    }
                    else
                    {
                        MessageBox.Show("Uyğun istifadəçi  tapılmadı!");
                    }
                    sqlconnect.close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
                }
            }
            else
            {
                MessageBox.Show("Axtarış üçün ən azı bir sahə doldurulmalıdır!");
            }
            idAdmin = -1;
        }
        private void BtnAdminAdd_Click(object sender, EventArgs e)
        {
            adminCreateOrModify = false;
            frmAdminAdd frmAdminAdd = new frmAdminAdd();
            frmAdminAdd.Text = "Yeni İstifadəçi";
            frmAdminAdd.ShowDialog();
            refreshAdmin();
        }
        private void BtnAdminModify_Click(object sender, EventArgs e)
        {
            if (idAdmin != -1)
            {
                adminCreateOrModify = true;
                frmAdminAdd frmAdminAdd = new frmAdminAdd();
                frmAdminAdd.Text = "Düzəliş";
                frmAdminAdd.ShowDialog();
                refreshAdmin();
            }
            else
            {
                MessageBox.Show("Məlumat seçilməyib!");
            }
        }
        private void BtnAdminDelete_Click(object sender, EventArgs e)
        {
            if (idAdmin != -1)
            {
                string s = MessageBox.Show("Silmək istədiyinizdən əminsiniz?", "Diqqət", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                if (s == "Yes")
                {
                    string query = "Delete from tblAdmin Where adminID=" + idAdmin;
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd = new SqlCommand(query, sqlconnect.connect());
                        cmd.ExecuteNonQuery();
                        sqlconnect.close();
                        MessageBox.Show("Silinmə uğurla tamamlandı");
                        refreshAdmin();
                        cleanAdmin();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
                    }
                }
            }
            else
            {
                MessageBox.Show("Məlumat seçilməyib!");
            }
            idAdmin = -1;
        }
        private void GrdvwAdmin_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cleanAdmin();
            int index = e.RowIndex;
            DataGridViewRow row = grdvwAdmin.Rows[index];
            idAdmin = Int32.Parse(row.Cells[0].Value.ToString());
            txtAdminName.Text = row.Cells[2].Value.ToString();
            txtAdminSurname.Text = row.Cells[3].Value.ToString();
            txtAdminFatherName.Text = row.Cells[4].Value.ToString();
            txtAdminFin.Text = row.Cells[5].Value.ToString();
            dtAdminBirtday.Value = Convert.ToDateTime(row.Cells[6].Value);
            txtAdminUsername.Text = row.Cells[7].Value.ToString();
            txtAdminPassword.Text = row.Cells[8].Value.ToString();
        }
        private void GrdvwAdmin_Sorted(object sender, EventArgs e)
        {
            for (int i = 0; i < grdvwAdmin.Rows.Count; i++)
            {
                grdvwAdmin.Rows[i].Cells[1].Value = (i + 1).ToString();
            }
        }

        #endregion


        #region regionAnbarDaxiloma
        public static bool malDaxilolmaCreateOrModify = false;
        public static int idMalDaxilolma = -1;
        public void refreshMalDaxilolma()
        {
            cmbAnbarDaxilolmaFill();
            cmbAnbarDaxilolmaFillBaza();
            dtMalDaxilolma.Checked = false;
            try
            {
                grdvAnbarDaxilOlma.Columns.Clear();
                string query = @"select  d.ID,b.Name 'Hardan', a.Name 'Hara', m.Name 'Mal', d.alisqiymeti,d.miqdar,d.date, b.ID,a.ID, m.qiymet 'Pərkəndə satış qiyməti', m.topdanQiymet 'Topdan satış qiyməti'  from tblAnbarDaxilolma d
                                inner join tblAnbar b  on d.basaID=b.ID
                                inner join tblAnbar a  on d.anbarID=a.ID
                                inner join tblMal m on d.malID=m.ID  order by d.date desc";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());

                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                if (dt.Rows.Count != 0)
                {
                    grdvAnbarDaxilOlma.DataSource = dt;
                    g.GridViewDesign(dt.Rows.Count, grdvAnbarDaxilOlma);
                    grdvAnbarDaxilOlma.Columns[8].Visible = false;
                    grdvAnbarDaxilOlma.Columns[9].Visible = false;

                }
                else
                {
                    MessageBox.Show("Nəticə tapılmadı!");
                }
                sqlconnect.close();
                idMalDaxilolma = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
        }
        private void cleanMalDaxilolma()
        {
            txtAnbarDaxiolmaSelectedMal.Text = "";
            txtDaxilolmaAlisQiymeti.Text = "";
            txtMalDaxilolmaMiqdar.Text = "";
            idMal = -1;
            cmbbxAnbarDaxilolmaBaza.SelectedIndex = 0;
            cmbbxAnbarDaxilolan.SelectedIndex = 0;
            dtMalDaxilolma.Value = DateTime.Now;

        }
        private void cmbAnbarDaxilolmaFillBaza()
        {
            try
            {
                string query = @"Select '-1' ID, N'Hamısı' Anbar
                           union 
                           Select ID, Name+ 
                          (case when TYPE = 1 then N'-Pərakəndə' when TYPE = 2 then N'-Əsas' when type=0 then '' end)
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
                cmb = true;
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
                string query = @"Select '0' ID, N'Hamısı' Anbar
                           union
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
                cmb = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin!");
            }
        }
        private void BtnAnbarDaxilOlmaYenile_Click(object sender, EventArgs e)
        {
            refreshMalDaxilolma();
            cleanMalDaxilolma();
        }
        private void BtnAnbarDaxilOlmaAxtar_Click(object sender, EventArgs e)
        {
            string query = "";

            if (cmbbxAnbarDaxilolmaBaza.SelectedIndex != 0)
            {
                query += " basaId=N'" + cmbbxAnbarDaxilolmaBaza.SelectedValue + "'";
            }
            if (cmbbxAnbarDaxilolan.SelectedIndex != 0)
            {
                if (query != "")
                {
                    query += " and anbarId=N'" + cmbbxAnbarDaxilolan.SelectedValue + "'";
                }
                else
                {
                    query += " anbarId=N'" + cmbbxAnbarDaxilolan.SelectedValue + "'";
                }
            }

            if (txtDaxilolmaAlisQiymeti.Text != "")
            {
                if (query != "")
                {
                    query += " and alisqiymeti=N'" + txtDaxilolmaAlisQiymeti.Text + "'";
                }
                else
                {
                    query += " alisqiymeti=N'" + txtDaxilolmaAlisQiymeti.Text + "'";
                }
            }

            
            if (txtAnbarDaxiolmaSelectedMal.Text != "")
            {
                if (query != "")
                {
                    query += " and malID=N'" + txtAnbarDaxiolmaSelectedMal.Text + "'";
                }
                else
                {
                    query += " malID=N'" + txtAnbarDaxiolmaSelectedMal.Text + "'";
                }
            }
            else if (frmMalFilter.idMalClause!="")
            {
                if (query != "")
                {
                    query += " and malID in " + frmMalFilter.idMalClause;
                }
                else
                {
                    query += " malID in" + frmMalFilter.idMalClause;
                }
            } 



            if (txtMalDaxilolmaMiqdar.Text != "")
            {
                if (query != "")
                {
                    query += " and miqdar=N'" + txtMalDaxilolmaMiqdar.Text + "'";
                }
                else
                {
                    query += " miqdar=N'" + txtMalDaxilolmaMiqdar.Text + "'";
                }
            }

            if (dtMalDaxilolma.Checked)
            {
                if (query != "")
                {
                    query += " and date<='" + dtMalDaxilolma.Value + "'";
                }
                else
                {
                    query += " date<='" + dtMalDaxilolma.Value + "'";
                }
            }




            string fullquery = @"select  d.ID,b.Name 'Hardan', a.Name 'Hara', m.Name 'Mal', d.alisqiymeti,d.miqdar,d.date, b.ID,a.ID, m.qiymet 'Pərkəndə satış qiyməti', m.topdanQiymet 'Topdan satış qiyməti'  from tblAnbarDaxilolma d
                                inner join tblAnbar b  on d.basaID=b.ID
                                inner join tblAnbar a  on d.anbarID=a.ID
                                inner join tblMal m on d.malID=m.ID";
            if (query != "")
            {
                fullquery += " Where " + query + " order by d.date desc";
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand(fullquery, sqlconnect.connect());
                    SqlDataReader rd = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(rd);
                    //if (dt.Rows.Count != 0)
                    if (1 == 1)
                    {
                        grdvAnbarDaxilOlma.Columns.Clear();
                        grdvAnbarDaxilOlma.DataSource = dt;
                        g.GridViewDesign(dt.Rows.Count, grdvAnbarDaxilOlma);
                        grdvAnbarDaxilOlma.Columns[8].Visible = false;
                        grdvAnbarDaxilOlma.Columns[9].Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Melumat  tapılmadı!");
                    }
                    sqlconnect.close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
                }
            }
            else
            {
                MessageBox.Show("Axtarış üçün ən azı bir sahə doldurulmalıdır!");
            }
            idMalDaxilolma = -1;
        }
        private void BtnAnbaraMalDaxilEt_Click(object sender, EventArgs e)
        {
            malDaxilolmaCreateOrModify = false;
            frmAnbaraMalDaxilEt frmAnbaraMalDaxilEt = new frmAnbaraMalDaxilEt();
            frmAnbaraMalDaxilEt.Text = "Anbar daxiloma";
            frmAnbaraMalDaxilEt.ShowDialog();
            refreshMalDaxilolma();
        }
        private void GrdvAnbarDaxilOlma_Sorted(object sender, EventArgs e)
        {
            for (int i = 0; i < grdvAnbarDaxilOlma.Rows.Count; i++)
            {
                grdvAnbarDaxilOlma.Rows[i].Cells[1].Value = (i + 1).ToString();
            }
        }
        private void GrdvAnbarDaxilOlma_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cleanMalDaxilolma();
            int index = e.RowIndex;
            DataGridViewRow row = grdvAnbarDaxilOlma.Rows[index];
            //txtAnbarDaxiolmaSelectedMal.Text = row.Cells[4].Value.ToString();
            txtDaxilolmaAlisQiymeti.Text = row.Cells[5].Value.ToString();
            txtMalDaxilolmaMiqdar.Text = row.Cells[6].Value.ToString();
            dtMalDaxilolma.Value = Convert.ToDateTime(row.Cells[7].Value.ToString());
            cmbbxAnbarDaxilolmaBaza.SelectedValue = Int32.Parse(row.Cells[8].Value.ToString());
            cmbbxAnbarDaxilolan.SelectedValue = Int32.Parse(row.Cells[9].Value.ToString());
        }
        private void LnkMalFilter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmMalFilter frmMalFilter = new frmMalFilter();
            frmMalFilter.ShowDialog();
            if (frmMalFilter.idMal != -1)
            {
                txtAnbarDaxiolmaSelectedMal.Text = frmMalFilter.idMal.ToString();
            }
            if (frmMalFilter.idMalClause != "")
            {
                txtAnbarDaxiolmaSelectedMal.Text = "";
            }
        }



        #endregion



        #region regionAnbarQaliqi
        public static bool anbarQaligiCreateOrModify = false;
        public static int idAnbarQaligi = -1;
        public void refreshAnbarQaligi()
        {
            cmbAnbarQaliqFill();
            try
            {
                grdvwAnbarQaligi.Columns.Clear();
                string query = @"select q.ID, a.Name 'Anbar', m.Name 'Mal', q.miqdar, q.date 'Tarix', m.qiymet 'Pərkəndə satış qiyməti', m.topdanQiymet 'Topdan satış qiyməti' 
                                from tblAnbarQaliqi q
                                inner join tblAnbar a  on a.ID = q.anbarID
                                inner join tblMal m on m.ID = q.malID order by date desc";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());

                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                if (dt.Rows.Count != 0)
                {
                    grdvwAnbarQaligi.DataSource = dt;
                    g.GridViewDesign(dt.Rows.Count, grdvwAnbarQaligi);
                }
                else
                {
                    MessageBox.Show("Nəticə tapılmadı!");
                }
                sqlconnect.close();
                idAnbarQaligi = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
        }
        private void cleanAnbarQaligi()
        {
            cmbbxAnbarQaliq.SelectedIndex = 0;
            dtQaliq.Value = DateTime.Now;
        }
        private void cmbAnbarQaliqFill()
        {
            try
            {
                string query = @"Select '0' ID, N'--Anbar seçin--' Anbar
                           union
                           Select ID, Name+  '-'+
                          (case when TYPE = 1 then N'Pərakəndə' when TYPE = 2 then N'Əsas' end)
                           as Anbar  from tblAnbar where deleted=0 and  type!=0";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                cmbbxAnbarQaliq.DataSource = ds.Tables[0];
                cmbbxAnbarQaliq.DisplayMember = "Anbar";
                cmbbxAnbarQaliq.ValueMember = "ID";
                sqlconnect.close();
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin!");
            }
        }
        private void BtnAnbaqQaliqYenile_Click(object sender, EventArgs e)
        {
            refreshAnbarQaligi();
            cleanAnbarQaligi();
        }
        private void LnklblMalFilterQaliq_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmMalFilter frmMalFilter = new frmMalFilter();
            frmMalFilter.ShowDialog();
            if (frmMalFilter.idMal != -1)
            {
                txtMalFilterKodQaliq.Text = frmMalFilter.idMal.ToString();
            }
            if (frmMalFilter.idMalClause != "")
            {
                txtMalFilterKodQaliq.Text = "";
            }
        }
        private void BtnAnbaqQaliqAxtar_Click(object sender, EventArgs e)
        {
            string query = "";
            if (cmbbxAnbarQaliq.SelectedIndex != 0)
            {
                query += " anbarId=N'" + cmbbxAnbarQaliq.SelectedValue + "'";
            }

            if (txtMalFilterKodQaliq.Text != "")
            {
                if (query != "")
                {
                    query += " and malID=N'" + txtMalFilterKodQaliq.Text + "'";
                }
                else
                {
                    query += " malID=N'" + txtMalFilterKodQaliq.Text + "'";
                }
            }
            else if (frmMalFilter.idMalClause != "")
            {
                if (query != "")
                {
                    query += " and malID in " + frmMalFilter.idMalClause;
                }
                else
                {
                    query += " malID in" + frmMalFilter.idMalClause;
                }
            }



            if (txtMiqdarAnbarQaligi.Text != "")
            {
                if (query != "")
                {
                    query += " and miqdar=N'" + txtMiqdarAnbarQaligi.Text + "'";
                }
                else
                {
                    query += " miqdar=N'" + txtMiqdarAnbarQaligi.Text + "'";
                }
            }


            if (dtQaliq.Checked)
            {
                if (query != "")
                {
                    query += " and q.date<'" + dtQaliq.Value + "'";
                }
                else
                {
                    query += " q.date<='" + dtQaliq.Value + "'";
                }
            }

            string fullquery = @"select q.ID, a.Name 'Anbar', m.Name 'Mal', q.miqdar, q.date 'Tarix' , m.qiymet 'Pərkəndə satış qiyməti', m.topdanQiymet 'Topdan satış qiyməti'
                                from  tblAnbarQaliqi q
                                inner join  tblAnbar a  on a.ID=q.anbarID
                                inner join tblMal m on  m.ID=q.malID ";
            if (query != "")
            {
                fullquery += " where " + query + "  order by  q.date desc";
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand(fullquery, sqlconnect.connect());
                    SqlDataReader rd = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(rd);
                    //if (dt.Rows.Count != 0)
                    if (1 == 1)
                    {
                        grdvwAnbarQaligi.Columns.Clear();
                        grdvwAnbarQaligi.DataSource = dt;
                        g.GridViewDesign(dt.Rows.Count, grdvwAnbarQaligi);
                    }
                    else
                    {
                        MessageBox.Show("Melumat  tapılmadı!");
                    }
                    sqlconnect.close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
                }
            }
            else
            {
                MessageBox.Show("Axtarış üçün ən azı bir sahə doldurulmalıdır!");
            }
            idAnbarQaligi = -1;
        }
        private void GrdvwAnbarQaligi_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
        private void GrdvwAnbarQaligi_Sorted(object sender, EventArgs e)
        {
            for (int i = 0; i < grdvwAnbarQaligi.Rows.Count; i++)
            {
                grdvwAnbarQaligi.Rows[i].Cells[1].Value = (i + 1).ToString();
            }
        }

        #endregion



        #region  regionSat
        public static int idMalSat = 0;
        int index = -1;
        int indexS = -1;
        public void refreshMalSat()
        {
            index = -1;
            txtSatAd.Text = "";
            txtSatAd.Focus();
            txtSatKod.Text = "";
            if (!t)
            {
                txtMalSatQiymet.Enabled = false;
            }
            cmbAnbarSatFill();
            if (t)
            {
                cmbbxSatAnbar.SelectedIndex = 1;
            } 
            try
            {
                grdvwMalSale.Columns.Clear();
                string query = "Select ID,name, tip, qiymet 'Pərakəndə satış qiyməti', topdanQiymet 'Topdan satış qiyməti' from tblMal where deleted=0";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());

                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                if (dt.Rows.Count != 0) 
                {
                    grdvwMalSale.DataSource = dt;
                    // g.GridViewDesign(dt.Rows.Count, grdvwMalSale); 

                }
                else
                {
                    MessageBox.Show("Mal tapılmadı!");
                }
                sqlconnect.close();
                idMalSat = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
        }
        public void refreshMalSatilan()
        {
            try
            {
                string query = "Select ID,name,qiymet,  cast('' as varchar(10))  'Miqdar' , '' 'IDanbar' from tblMal where ID=-1";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());

                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                grdvwSatilan.DataSource = dt;
                sqlconnect.close();
                grdvwSatilan.Columns[4].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
        }
        private void cmbAnbarSatFill()
        {
            try
            {
                string type = "";
                if (!t)
                {
                    type = "=1";
                }
                else
                {
                    type = " in (1,2)";
                }
                string query = @"Select ID, Name+  '-'+
                          (case when TYPE = 1 then N'Pərakəndə' when TYPE = 2 then N'Əsas' end)
                           as Anbar  from tblAnbar  where deleted=0 and type " + type;
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                //if (!t)
                //{
                //    DataTable dt = new DataTable();
                //    da.Fill(dt);
                //    dt.Rows[0].Delete();
                //    dt.AcceptChanges();
                //    ds.Tables.Add(dt);
                //    ds.AcceptChanges();
                //}
                //else
                //{
                //    da.Fill(ds);
                //}
                da.Fill(ds);
                cmbbxSatAnbar.DataSource = ds.Tables[0];
                cmbbxSatAnbar.DisplayMember = "Anbar";
                cmbbxSatAnbar.ValueMember = "ID";
                //cmbbxSatAnbar.SelectedItem = null;
                //cmbbxSatAnbar.Text = "Anbar seçin";
                sqlconnect.close();
                cmb = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin!");
            }
        }
        private bool checkAnbarNov(string id)
        {
            bool t = false;
            try
            {
                string query = "Select type	  Tip  from tblAnbar where id=" + id;
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    t = true;
                }
                else
                {
                    t = false;
                }
                sqlconnect.close();
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
            return t;
        }
        private string calcSumQiymet()
        {
            double sum = 0;
            foreach (DataGridViewRow row in grdvwSatilan.Rows)
            {
                sum += Convert.ToDouble(row.Cells[3].Value.ToString()) * Convert.ToDouble(row.Cells[2].Value.ToString());
            }
            return sum.ToString();
        }
        private double calcSumMiqdar()
        {
            double sumMiqdar = 0;
            foreach (DataGridViewRow row in grdvwSatilan.Rows)
            {
                if (row.Cells[4].Value.ToString() == cmbbxSatAnbar.SelectedValue.ToString())
                {
                    sumMiqdar += Convert.ToDouble(row.Cells[3].Value.ToString());
                }
            }
            return sumMiqdar;
        }
        private void BtnSatYenile_Click(object sender, EventArgs e)
        {
            refreshMalSat();
        }
        private void malAxtar()
        {
            string query = "";

            if (txtSatAd.Text != "")
            {
                query += " Name like N'%" + txtSatAd.Text + "%'";
            }

            if (txtSatKod.Text != "")
            {
                if (query != "")
                {
                    query += " and ID like  N'%" + txtSatKod.Text + "%'";
                }
                else
                {
                    query += " Id like N'%" + txtSatKod.Text + "%'";
                }
            }



            if (query != ""|| frmMalFilter.idMalClause != "")
            {
                string fullquery = "Select * from tblMal where " + query + "and deleted=0";
                if (frmMalFilter.idMalClause != "")
                {
                    fullquery = "Select * from tblMal where Id in" + frmMalFilter.idMalClause + " and deleted=0";
                } 
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand(fullquery, sqlconnect.connect());
                    SqlDataReader rd = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(rd);
                    //if (dt.Rows.Count != 0)
                    if (1 == 1)
                    {
                        grdvwMalSale.Columns.Clear();
                        grdvwMalSale.DataSource = dt;
                        g.GridViewDesign(dt.Rows.Count, grdvwMalSale);
                    }
                    else
                    {
                        MessageBox.Show("Uyğun mal tapılmadı!");
                    }
                    sqlconnect.close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
                }
            }
            else
            {
                //MessageBox.Show("Axtarış üçün ən azı bir sahə doldurulmalıdır!");
            }
            idMalSat = -1;
        }
        private void BtnSatAxtar_Click(object sender, EventArgs e)
        {
            malAxtar();           
        }
        private void TxtSatAd_TextChanged(object sender, EventArgs e)
        {
            malAxtar();
        }

        private void TxtSatKod_TextChanged(object sender, EventArgs e)
        {
            malAxtar();
        }
        private void GrdvwMalSale_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtSatSay.Text = "1";
            index = e.RowIndex;
            DataGridViewRow row = grdvwMalSale.Rows[index];
            idMalSat = Int32.Parse(row.Cells[0].Value.ToString());
            lblSatMalAd.Text = row.Cells[1].Value.ToString();
            if (checkAnbarNov(cmbbxSatAnbar.SelectedValue.ToString()))
            {
                txtMalSatQiymet.Text = row.Cells[3].Value.ToString();
            }
            else
            {
                txtMalSatQiymet.Text = row.Cells[4].Value.ToString();
            }
        }
        private void GrdvwSatilan_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            indexS = e.RowIndex;
        }
        private void GrdvwMalSale_Sorted(object sender, EventArgs e)
        {
            //for (int i = 0; i < grdvwMalSale.Rows.Count; i++)
            //{
            //    grdvwMalSale.Rows[i].Cells[1].Value = (i + 1).ToString();
            //}
        }
        public double getLastMiqdarOfMal()
        {
            double miqdar = 0;
            DataGridViewRow row = grdvwMalSale.Rows[index];
            try
            {
                string query = @"select top 1 miqdar from tblAnbarQaliqi
                                where anbarID=@anbarId and  malID=@MalID 
                                order by  date  desc";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                cmd.Parameters.AddWithValue("@anbarId", cmbbxSatAnbar.SelectedValue);
                cmd.Parameters.AddWithValue("@MalID", row.Cells[0].Value.ToString());
                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                if (dt.Rows.Count != 0)
                {
                    miqdar = Convert.ToDouble(dt.Rows[0][0].ToString());
                }
                sqlconnect.close();
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
            return miqdar;
        }
        private void BtnSatElaveEt_Click(object sender, EventArgs e)
        {
            if (index != -1)
            {
                if (getLastMiqdarOfMal() < (Convert.ToDouble(txtSatSay.Text) + calcSumMiqdar()))
                {
                    MessageBox.Show("Bu maldan " + calcSumMiqdar().ToString() + " miqdarda əvvəlcədən,  " + txtSatSay.Text + "  miqdarda isə indi seçdiniz,   anbarda    bu miqdarların toplamından az miqdarda-" + getLastMiqdarOfMal().ToString() + "  miqdarda mal qalmışdır!!!");
                }
                else
                {
                    DataGridViewRow row = (DataGridViewRow)grdvwMalSale.Rows[index];
                    DataTable dt = new DataTable();
                    dt = (DataTable)grdvwSatilan.DataSource;
                    dt.Rows.Add(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), txtMalSatQiymet.Text != row.Cells[2].Value.ToString() ? txtMalSatQiymet.Text : row.Cells[2].Value.ToString(), txtSatSay.Text, cmbbxSatAnbar.SelectedValue);
                    lblSatSum.Text = calcSumQiymet();
                }
            }
            else
            {
                MessageBox.Show("Mal seçin!!!");
            }
            index = -1;
        }
        private void BtnSatCixart_Click(object sender, EventArgs e)
        {
            if (indexS != -1)
            {
                grdvwSatilan.Rows.Remove(grdvwSatilan.Rows[indexS]);
                lblSatSum.Text = calcSumQiymet();
            }
            else
            {
                MessageBox.Show("Çıxartmaq istədiyiniz satışı seçin!!!");
            }
            indexS = -1;
        }
        private void CmbbxSatAnbar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grdvwMalSale.Rows.Count>index && index>=0)
            {
                DataGridViewRow row = grdvwMalSale.Rows[index];

                if (checkAnbarNov(cmbbxSatAnbar.SelectedValue.ToString()))
                {
                    txtMalSatQiymet.Text = row.Cells[3].Value.ToString();
                }
                else
                {
                    txtMalSatQiymet.Text = row.Cells[4].Value.ToString();
                }
            }           
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            lblSatSum.Text = "0";
            refreshMalSatilan();
        }
        private void insertSatis(string malId, string anbarId, string qiymet, string miqdar)
        {
            try
            {
                string query = @"insert into tblSatis" +
                        " values(@malId,@anbarId,@qiymet,@miqdar,@date)";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                cmd.Parameters.AddWithValue("@malId", malId);
                cmd.Parameters.AddWithValue("@anbarId", anbarId);
                cmd.Parameters.AddWithValue("@qiymet", qiymet);
                cmd.Parameters.AddWithValue("@miqdar", miqdar);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.ExecuteNonQuery();
                sqlconnect.close();
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
        }
        public double getLastMiqdarOfMalGiren(string malId, string anbarId)
        {
            double miqdar = 0;
            try
            {
                string query = @"select top 1 miqdar from tblAnbarQaliqi
                                where anbarID=@anbarId and  malID=@MalID and date<=@date
                                order by  date  desc";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                cmd.Parameters.AddWithValue("@anbarId", anbarId);
                cmd.Parameters.AddWithValue("@MalID", malId);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                if (dt.Rows.Count != 0)
                {
                    miqdar = Convert.ToDouble(dt.Rows[0][0].ToString());
                }
                sqlconnect.close();
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
            return miqdar;
        }
        private void changeGirenAnbarQaligi(string malId, string anbarId, string miqdar)
        {
            try
            {
                string query = "insert  into tblAnbarQaliqi values(@anbarId,@malId,@miqdar,@date)";
                string miqdarYekun = (getLastMiqdarOfMalGiren(malId, anbarId) - Convert.ToDouble(miqdar)).ToString();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                cmd.Parameters.AddWithValue("@anbarId", anbarId);
                cmd.Parameters.AddWithValue("@MalID", malId);
                cmd.Parameters.AddWithValue("@miqdar", miqdarYekun);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.ExecuteNonQuery();
                sqlconnect.close();
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
        }
        private void BtnSat_Click(object sender, EventArgs e)
        {
            if (grdvwSatilan.Rows.Count>0)
            {
                foreach (DataGridViewRow row in grdvwSatilan.Rows)
                {
                    insertSatis(row.Cells[0].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString());
                    changeGirenAnbarQaligi(row.Cells[0].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[3].Value.ToString());
                }
                MessageBox.Show("Satış uğurla tamamlandı");
                refreshMalSat();
                refreshMalSatilan();
            }
            else
            {
                MessageBox.Show("Satış üçün məlumatları  daxil edin");
            }
           
        } 
        private void LblMalFilterSat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmMalFilter frmMalFilter = new frmMalFilter();
            frmMalFilter.ShowDialog();
            if (frmMalFilter.idMal != -1)
            {
                txtSatKod.Text = frmMalFilter.idMal.ToString();
            }
            if (frmMalFilter.idMalClause != "")
            {
                txtSatKod.Text = "";
            }
        }
        #endregion


        #region regionSatislar
        public static bool anbarSatislarCreateOrModify = false;
        public static int idSatislar = -1;
        public void refreshSatislar()
        {
            cmbSatislarFill();
            cleanSatislar();
            try
            {
                grdvwSatislar.Columns.Clear();
                string query = @"select top 1000 s.ID, a.Name 'Anbar', m.Name 'Mal',s.qiymet 'Cari satış qiyməti', s.miqdar, s.date 'Tarix', m.qiymet 'Pərkəndə satış qiyməti', m.topdanQiymet 'Topdan satış qiyməti' 
                                from tblSatis s
                                inner join tblAnbar a  on a.ID = s.anbarID
                                inner join tblMal m on m.ID = s.malID order by date desc";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());

                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                if (dt.Rows.Count != 0)
                {
                    grdvwSatislar.DataSource = dt;
                    g.GridViewDesign(dt.Rows.Count, grdvwSatislar);
                }
                else
                {
                    MessageBox.Show("Nəticə tapılmadı!");
                }
                sqlconnect.close();
                idSatislar = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
            }
        }
        private void cleanSatislar()
        {
            cmbbxCixisAnbariSatislar.SelectedIndex = 0;
            txtMalKodSatislar.Text = "";
            dtEndDateSatislar.Value = DateTime.Now;
            dtEndDateSatislar.Checked = false;
            dtBeginDateSatislar.Value = DateTime.Now;
            dtBeginDateSatislar.Checked = false;
        }
        private void cmbSatislarFill()
        {
            try
            {
                string query = @"Select '0' ID, N'--Anbar seçin--' Anbar
                           union 
                           Select ID, Name+  '-'+
                          (case when TYPE = 1 then N'Pərakəndə' when TYPE = 2 then N'Əsas' end)
                           as Anbar  from tblAnbar where deleted=0 and  type!=0";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, sqlconnect.connect());
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                cmbbxCixisAnbariSatislar.DataSource = ds.Tables[0];
                cmbbxCixisAnbariSatislar.DisplayMember = "Anbar";
                cmbbxCixisAnbariSatislar.ValueMember = "ID";
                sqlconnect.close();
            }
            catch (Exception)
            {
                MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin!");
            }
        }
        private void BtnYenileSatislar_Click(object sender, EventArgs e)
        {
            refreshSatislar();
        }
        private void LnkMalSatislar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmMalFilter frmMalFilter = new frmMalFilter();
            frmMalFilter.ShowDialog();
            if (frmMalFilter.idMal != -1)
            {
                txtMalKodSatislar.Text = frmMalFilter.idMal.ToString();
            }
            if (frmMalFilter.idMalClause != "")
            {
                txtMalKodSatislar.Text = "";
            }
        }
        private void BtnSatislarAxtar_Click(object sender, EventArgs e)
        {
            string query = "";
            if (cmbbxCixisAnbariSatislar.SelectedIndex != 0)
            {
                query += " s.anbarId=N'" + cmbbxCixisAnbariSatislar.SelectedValue + "'";
            }

            if (txtMalKodSatislar.Text != "")
            {
                if (query != "")
                {
                    query += " and s.malID=N'" + txtMalKodSatislar.Text + "'";
                }
                else
                {
                    query += " s.malID=N'" + txtMalKodSatislar.Text + "'";
                }
            }
            else if (frmMalFilter.idMalClause != "")
            {
                if (query != "")
                {
                    query += " and malID in " + frmMalFilter.idMalClause;
                }
                else
                {
                    query += " malID in" + frmMalFilter.idMalClause;
                }
            }



            if (dtBeginDateSatislar.Checked)
            {
                if (query != "")
                {
                    query += " and s.date>='" + dtBeginDateSatislar.Value + "'";
                }
                else
                {
                    query += " s.date>='" + dtBeginDateSatislar.Value + "'";
                }
            }


            if (dtEndDateSatislar.Checked)
            {
                if (query != "")
                {
                    query += " and s.date<='" + dtEndDateSatislar.Value + "'";
                }
                else
                {
                    query += " s.date<='" + dtEndDateSatislar.Value + "'";
                }
            }

            string fullquery = @"select s.ID, a.Name 'Anbar', m.Name 'Mal',s.qiymet 'Cari satış qiyməti', s.miqdar, s.date 'Tarix' , m.qiymet 'Pərkəndə satış qiyməti', m.topdanQiymet 'Topdan satış qiyməti'
                                from tblSatis s
                                inner join tblAnbar a  on a.ID = s.anbarID
                                inner join tblMal m on m.ID = s.malID ";
            if (query != "")
            {
                fullquery += " where " + query + "  order by  s.date desc";
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand(fullquery, sqlconnect.connect());
                    SqlDataReader rd = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(rd);
                    //if (dt.Rows.Count != 0)
                    if (1 == 1)
                    {
                        grdvwSatislar.Columns.Clear();
                        grdvwSatislar.DataSource = dt;
                        g.GridViewDesign(dt.Rows.Count, grdvwSatislar);
                    }
                    else
                    {
                        MessageBox.Show("Melumat  tapılmadı!");
                    }
                    sqlconnect.close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Sistemdə xəta baş verdi, təkrar cəhd edin");
                }
            }
            else
            {
                MessageBox.Show("Axtarış üçün ən azı bir sahə doldurulmalıdır!");
            }
            idSatislar = -1;
        }
        private void GrdvwSatislar_Sorted(object sender, EventArgs e)
        {
            for (int i = 0; i < grdvwAnbarQaligi.Rows.Count; i++)
            {
                grdvwSatislar.Rows[i].Cells[1].Value = (i + 1).ToString();
            }
        }


        #endregion

        #region regionHesabatlar

        private void BtnHesabat_Click(object sender, EventArgs e)
        {
            Hesabat hesabat = new Hesabat();
            double sumQiymet = 0, sumMiqdar = 0;
            if (cmbbxCixisAnbariSatislar.SelectedIndex != 0)
            {
                hesabat.anbar = cmbbxCixisAnbariSatislar.Text;
            }
            if (txtMalKodSatislar.Text != "")
            {
                hesabat.mal = txtMalKodSatislar.Text;
            }
            if (dtBeginDateSatislar.Checked)
            {
                hesabat.beginDate = dtBeginDateSatislar.Value.ToString();
            }
            if (dtEndDateSatislar.Checked)
            {
                hesabat.endDate = dtEndDateSatislar.Value.ToString();
            }

            foreach (DataGridViewRow row in grdvwSatislar.Rows)
            {
                sumQiymet += Convert.ToDouble(row.Cells[4].Value) * Convert.ToDouble(row.Cells[5].Value);
                sumMiqdar += Convert.ToDouble(row.Cells[5].Value);
            }
            hesabat.sumQiymet = sumQiymet.ToString();
            hesabat.sumMiqdar = sumMiqdar.ToString();
            frmHesabat frmHesabat = new frmHesabat(hesabat);
            frmHesabat.ShowDialog();
        }







        #endregion

       
    }
}
