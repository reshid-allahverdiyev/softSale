using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace softSale
{
    class SqlConnect
    {
        //private const String sql_con_string = @"Data source = DESKTOP-0BBABDI;Initial Catalog = taxibolt; Integrated security = true";
        //private SqlConnection con = new SqlConnection(sql_con_string);
        private String sql_con_string;
        private SqlConnection con;


        public void getString()
        {
            string applicationDirectory = Application.StartupPath;
            string pc = "";
            string catalog = "";
            string[] lines = System.IO.File.ReadAllLines(applicationDirectory + @"\constring.txt");
            pc = lines[0];
            if (frmLogin.basa == "Prod")
            {
                catalog = lines[1];
            }
            else
            {
                catalog = lines[2];
            }
            sql_con_string = @"Data source = " + pc + ";Initial Catalog = " + catalog + "; Integrated security = true";
            con = new SqlConnection(sql_con_string);
        }


        public SqlConnection connect()
        {
            getString();
            if (con.State != ConnectionState.Open)
            {
                con.Open();

            }
            return con;
        }

        public void close()
        {
            con.Close();
        }

    }
}
