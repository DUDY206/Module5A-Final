using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Module5A
{
    public partial class MainOptions : Form
    {
        public MainOptions()
        {
            InitializeComponent();
        }

        private void btnBuyAmenities_Click(object sender, EventArgs e)
        {
            PurchaseAmenities obj = new PurchaseAmenities();
            obj.Show();
        }

        private void btnMakeRp_Click(object sender, EventArgs e)
        {
            MakeReports obj = new MakeReports();
            obj.Show();
        }
    }
}
