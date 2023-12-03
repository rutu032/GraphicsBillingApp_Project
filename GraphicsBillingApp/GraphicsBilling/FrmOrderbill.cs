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
    public partial class FrmOrderbill : Form
    {
        public FrmOrderbill()
        {
            InitializeComponent();
        }
        ClassConn objcls = new ClassConn();
        DataSet ds = new DataSet();
        string sql = "";
        int cnt;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void btnclose_Click(object sender, EventArgs e)
        {

        }
        public void filldt()
        {
            sql = "select CustomerName,City from tbl_Billing1 Where CompanyID='"+ClassConn.CompanyID+"' ";
            ds = objcls.fillds(sql);
            dgvorderbill.DataSource = ds.Tables[0];
         }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmOrderbill_Load(object sender, EventArgs e)
        {
          
            filldt();
            dgvorderbill.Columns[0].Width = 300;
            dgvorderbill.Columns[1].Width = 300;
            

        }

        private void dgvorderbill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmLinkPendingOrder frmLP = new FrmLinkPendingOrder();
            frmLP.Show();
        }

        private void txtsearchCustomers_TextChanged(object sender, EventArgs e)
        {
            sql = "Select CustomerName,City from tbl_Billing1 Where CustomerName like '%" + txtsearchCustomers.Text + "%' ";
            ds = objcls.fillds(sql);
            dgvorderbill.DataSource = ds.Tables[0];
         
           
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btnclose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmOrderbill_Shown(object sender, EventArgs e)
        {
            txtsearchCustomers.Focus();
        }
    }
}
