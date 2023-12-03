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
    public partial class FrmgstCollection1 : Form
    {
        public FrmgstCollection1()
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
        public void filldtgstcollection()
        {
            sql = "Select * from tbl_Billing1 Where CompanyID='"+ClassConn.CompanyID+"'";
            ds = objcls.fillds(sql);
            dgvgstcollection.DataSource = ds.Tables[0];
           
        }

        private void dgvgstcollection_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void FrmgstCollection1_Load(object sender, EventArgs e)
        {
            filldtgstcollection();
            dgvgstcollection.Columns[0].Visible = false;
            dgvgstcollection.Columns[16].Visible = false;

        }

        private void dgvgstcollection_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {

            sql = "Select * from tbl_Billing1 Where Date between '" + dtpfromdate.Text + "' and '" + dtptodate.Text + "'";
            ds = objcls.fillds(sql);
            dgvgstcollection.DataSource = ds.Tables[0];
        }
    }
}
