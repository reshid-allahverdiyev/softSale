using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace softSale
{
    public partial class frmHesabat : Form
    {
        public frmHesabat()
        {
            InitializeComponent();
        }
        public frmHesabat(Hesabat hesabat)
        {
            InitializeComponent();
            lblAnbar.Text += hesabat.anbar;
            lblMal.Text += hesabat.mal;
            lblBeginDate.Text += hesabat.beginDate;
            lblEndDate.Text += hesabat.endDate;
            lblToplamMiqdar.Text += hesabat.sumMiqdar;
            lblToplamQiymet.Text += hesabat.sumQiymet;
        }
    }
}
