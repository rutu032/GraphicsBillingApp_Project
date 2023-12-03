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
    public partial class FrmLinkPendingOrder : Form
    {
        public FrmLinkPendingOrder()
        {
            InitializeComponent();
        }
        ClassConn objcls = new ClassConn();
        DataSet ds = new DataSet();
        string sql;


        public void fillCustomerName()
        {
            sql = "Select CustomerName,Date,TotalAmount,GrandTotal,PaidAmount,BalanceAmount from tbl_Billing1";
            ds = objcls.fillds(sql);
            dgvpendingorders.DataSource = ds.Tables[0];
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                lblCustomerName.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            }
        }
        private void FrmLinkPendingOrder_Load(object sender, EventArgs e)
        {
            fillCustomerName();
            dgvpendingorders.Columns[0].Width = 150;
            dgvpendingorders.Columns[1].Width = 150;
            dgvpendingorders.Columns[2].Width = 150;
            dgvpendingorders.Columns[3].Width = 150;
            dgvpendingorders.Columns[4].Width = 150;
            dgvpendingorders.Columns[5].Width = 150;
        }


        private void dgvpendingorders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Frmbilling frmBL = new Frmbilling();
            frmBL.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            FrmOrderbill frmOB = new FrmOrderbill();
            frmOB.Show();
        }
    }
}
