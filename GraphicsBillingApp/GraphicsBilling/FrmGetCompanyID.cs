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
    public partial class FrmGetCompanyID : Form
    {
        public FrmGetCompanyID()
        {
            InitializeComponent();
        }
        ClassConn objcls = new ClassConn();
        DataSet ds = new DataSet();
        string sql = "";
   

        private void btnGetCompanyID_Click(object sender, EventArgs e)
        {
            if (txtEmailID.Text == "")
            {
                MessageBox.Show("Please Enter Email ID");
                return;
            }
            CompanyID1();
           // Clear();
        }

        private void FrmGetCompanyID_Load(object sender, EventArgs e)
        {
           // CompanyID1();
            //Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void CompanyID1()
        {
            sql = "Select CompanyID from tbl_Registration1 Where EmailID='" + txtEmailID.Text + "' ";
            ds = objcls.fillds(sql);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
             txtCompanyId.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            }
        }   

        private void txtCompanyId_TextChanged(object sender, EventArgs e)
        {
            if (txtCompanyId.Text != "")
            {
                MessageBox.Show("Please Remember Your Company ID...");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FrmGetCompanyID_Shown(object sender, EventArgs e)
        {
            txtEmailID.Focus();
        }
        public void Clear()
        {
            txtEmailID.ResetText();
            txtCompanyId.ResetText();
        }

        private void txtEmailID_KeyDown(object sender, KeyEventArgs e)
       
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGetCompanyID.Focus();
            }
        }

        private void btnGetCompanyID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCompanyId.Focus();
            }
        }
    }
}
