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
    public partial class Frmtodaycollection : Form
    {
        public Frmtodaycollection()
        {
            InitializeComponent();
        }
        ClassConn objcls = new ClassConn();
        DataSet ds = new DataSet();
        string sql;
        int cnt;

        private void dgvgsttodaycollection_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void todaycollection()
        {
            sql = "Select * from tbl_Billing1 Where CompanyID='"+ClassConn.CompanyID+"'";
            ds = objcls.fillds(sql);
            dgvtodaycollection.DataSource = ds.Tables[0];
        }
     

        

        private void Frmtodaycollection_Load(object sender, EventArgs e)
        {

            dgvtodaycollection.Columns[16].Visible = false;
           // todaycollection();
        }

        private void Frmtodaycollection_Load_1(object sender, EventArgs e)
        {
            todaycollection();
            dgvtodaycollection.Columns[0].Visible = false;
            dgvtodaycollection.Columns[16].Visible = false;

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            sql = "Select * from tbl_Billing1 Where Date between '" + dtpfromDate.Text + "' and '" + dtpToDate.Text + "'";
            ds = objcls.fillds(sql);
            dgvtodaycollection.DataSource = ds.Tables[0];
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
