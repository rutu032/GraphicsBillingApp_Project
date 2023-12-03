using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsBilling
{
    public partial class Frmpendingorders1 : Form
    {
        public Frmpendingorders1()
        {
            InitializeComponent();
        }
        ClassConn objcls = new ClassConn();
        DataSet ds = new DataSet();
        string sql = "";
        int cnt;
        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvpendingorders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Frmbilling frmBL = new Frmbilling();
            //frmBL.TopLevel = false;
            //pnlpendingorders.Controls.Add(frmBL);
            //frmBL.BringToFront();
            //frmBL.Show();

        }
        public void pendingorders()
        {
            sql = "Select * from tbl_Order Where CompanyID='"+ClassConn.CompanyID+"'";
            ds = objcls.fillds(sql);
            dgvpendingorders.DataSource = ds.Tables[0];
        }

        private void Frmpendingorders1_Load(object sender, EventArgs e)
        {
            pendingorders();
            dgvpendingorders.Columns[0].Visible = false;
            dgvpendingorders.Columns[10].Visible = false;
            // dgvpendingorders.Columns[16].Visible = false;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            sql = "Select * from tbl_Billing1 where Date between '" + dtpfromdate.Text+"' and '"+dtptodate.Text+"'";
            ds = objcls.fillds(sql);
            dgvpendingorders.DataSource = ds.Tables[0];
        }
    }
}
