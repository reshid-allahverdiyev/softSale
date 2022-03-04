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
    public partial class frmMalFilter : Form
    {
        public frmMalFilter()
        {
            InitializeComponent();
        }
        SqlConnect sqlconnect = new SqlConnect();
        GridViewDesignClass g = new GridViewDesignClass();
        public static int idMal = -1;
        public static string idMalClause = "";
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
                    grdvwMal.Columns[0].Visible = true;
                    grdvwMal.Columns[1].Visible = false;

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
        private void FrmMalFilter_Load(object sender, EventArgs e)
        {
            refreshMal();
        }
        private void BtnMalSearch_Click_1(object sender, EventArgs e)
        {
            string query = "";

            if (txtMalAdi.Text != "")
            {
                query += " Name like N'" + txtMalAdi.Text + "'";
            }

            if (txtMalKod.Text != "")
            {
                if (query != "")
                {
                    query += " and ID=N'" + txtMalKod.Text + "'";
                }
                else
                {
                    query += " Id=N'" + txtMalKod.Text + "'";
                }
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
                    if (dt.Rows.Count != 0)
                    {
                        grdvwMal.Columns.Clear();
                        grdvwMal.DataSource = dt;
                        g.GridViewDesign(dt.Rows.Count, grdvwMal);
                        grdvwMal.Columns[0].Visible = true;
                        grdvwMal.Columns[1].Visible = false;
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
        private void BtnMalRefresh_Click(object sender, EventArgs e)
        {
            idMal = -1;
            refreshMal();
        }
        private void GrdvwMal_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow row = grdvwMal.Rows[index];
            idMal = Int32.Parse(row.Cells[0].Value.ToString());
        }
        private void GrdvwMal_Sorted_1(object sender, EventArgs e)
        {
            for (int i = 0; i < grdvwMal.Rows.Count; i++)
            {
                grdvwMal.Rows[i].Cells[1].Value = (i + 1).ToString();
            }
        }

        private void BtnMalFilterOk_Click(object sender, EventArgs e)
        {
            idMalClause = "";
            if (idMal==-1)
            {
                MessageBox.Show("Tək bir sətri seçin!");
            }
            else
            {
                this.Hide();
            }
        }

        private void BtnAllMalFilterOK_Click(object sender, EventArgs e)
        {
            idMalClause = "";
            idMal = -1;
            if (grdvwMal.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in grdvwMal.Rows)
                {
                    idMalClause += row.Cells[0].Value.ToString() + ",";
                }
                idMalClause = idMalClause.Substring(0, idMalClause.Length - 1) + ")";
                idMalClause = "(" + idMalClause;
            }
            this.Hide();
        }
    }
}
