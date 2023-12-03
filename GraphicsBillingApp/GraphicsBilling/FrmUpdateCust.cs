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
    public partial class FrmUpdateCust : Form
    {
        public FrmUpdateCust()
        {
            InitializeComponent();
        }
        ClassConn objcls = new ClassConn();
        DataSet ds = new DataSet();
        string sql = "";




        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            sql = "Update tbl_createcustomer SET CustomerName='" + txtCustomerName.Text + "',City='" + txtCity.Text + "',MobileNo='" + txtMobileNo.Text + "',GSTNo='" + txtgstNo.Text + "'  Where ID='"+txtID.Text+"'";
            objcls.execute(sql);
            MessageBox.Show("Updated Successfully");
            

        }
        public void UpdateCustomers()
        {
            sql = "Select * from tbl_createcustomer ";
            ds = objcls.fillds(sql);

      
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmUpdateCust_Load(object sender, EventArgs e)
        {
            UpdateCustomers();
        }
    }
}
