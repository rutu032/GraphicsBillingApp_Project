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
    public partial class Frmorder : Form
    {
        public Frmorder()
        {
            InitializeComponent();
        }
        ClassConn objcls = new ClassConn();
        DataSet ds = new DataSet();
        string sql = "";
        int cnt;




        private void Frmorder_Load(object sender, EventArgs e)
        {
            btnadd.Enabled = true;
            btnUpdate.Enabled = false;
            btndelete.Enabled = false;
            filldt();
            dgvOrder.Columns[0].Visible = false;
            dgvOrder.Columns[10].Visible = false;
            CmbCustomerName();
            fillcmbItemName();
            fillcmbItemSize();
            CalculationTotalAmt();
            cmbItemName.SelectedIndex = -1;
            cmbItemSIze.SelectedIndex = -1;
            Clear();




        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (cmbCustomerName.Text == "")
            {
                MessageBox.Show("Please Enter Customer Name");
                return;
            }
            if (txtCity.Text == "")
            {
                MessageBox.Show("Please Enter City");
                return;
            }
            if (txtGSTNo.Text == "")
            {
                MessageBox.Show("Please Enter GST No.");
                return;
            }
            if (cmbItemName.Text == "")
            {
                MessageBox.Show("Please Select Item Name");
                return;
            }
            if (txtQuantity.Text == "")
            {
                MessageBox.Show("Please Enter Quantity");
                return;
            }
            if (txtRate.Text == "")
            {
                MessageBox.Show("Please Enter Rate");
                return;
            }
            if (txtTotal.Text == "")
            {
                MessageBox.Show("Please Enter Total");
                return;
            }

            sql = "Insert into tbl_Order (CustomerName,City,GSTNo,Quantity,Rate,Total,OrderDate,ItemName,ItemSize,CompanyID)Values('" + cmbCustomerName.Text + "','" + txtCity.Text + "','" + txtGSTNo.Text + "','" + txtQuantity.Text + "','" + txtRate.Text + "','" + txtTotal.Text + "','" + dtpDateOrder.Text + "','" + cmbItemName.Text + "','" +cmbItemSIze.Text + "','"+ClassConn.CompanyID+"')";
            objcls.execute(sql);
            MessageBox.Show("Added Successfully");
            filldt();
            Clear();
            //CmbCustomerName();

        }
        public void filldt()
        {
            sql = "Select * from tbl_Order where CompanyID='"+ClassConn.CompanyID+"'";
            ds = objcls.fillds(sql);
            dgvOrder.DataSource = ds.Tables[0];

        }
        public void Clear()
        {
            cmbCustomerName.ResetText();
            txtCity.ResetText();
            txtGSTNo.ResetText();
            txtQuantity.ResetText();
            txtRate.ResetText();
            txtTotal.Text="0";
            cmbItemName.ResetText();
            cmbItemSIze.ResetText();
            btnadd.Enabled = true;
        }

        public void CalculationTotalAmt()
        {
            try
            {
                double Rate, Quantity;
                double TotalAmount = 0;
                Rate = Convert.ToDouble(txtRate.Text);
                Quantity = Convert.ToDouble(txtQuantity.Text);
                TotalAmount = (Rate * Quantity);
                txtTotal.Text = Convert.ToString(TotalAmount);
            }
            catch
            {

            }
            
        }     
        private void dgvorder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //txtID.Text = dgvorder.SelectedCells[0].Value.ToString();
            //txtCustomerName.Text = dgvorder.SelectedCells[1].Value.ToString();
            //txtCity.Text = dgvorder.SelectedCells[2].Value.ToString();
            //txtGSTNo.Text = dgvorder.SelectedCells[3].Value.ToString();
            //txtQuantity.Text = dgvorder.SelectedCells[4].Value.ToString();
            //txtRate.Text = dgvorder.SelectedCells[5].Value.ToString();
            //txtTotal.Text = dgvorder.SelectedCells[6].Value.ToString();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            //sql = "Delete from tbl_Order Where CompanyID='" +ClassConn.CompanyID+ "'";
            //objcls.execute(sql);
            //MessageBox.Show("Deleted Successfully");
            //filldt();
            //Clear();
        }

        private void btnaddmasterOrder_Click(object sender, EventArgs e)
        {
            FrmaddnameSiez frmADS = new FrmaddnameSiez();
            //frmADS.TopLevel = false;
            //frmADS.BringToFront();
            frmADS.Show();

        }

     

        private void btncreatecustomer_Click(object sender, EventArgs e)
        {
            
            
            Frmcreatecustomer frmcc = new Frmcreatecustomer();
            frmcc.Show();

        }

        private void dgvOrder_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //txtID.Text = dgvOrder.SelectedCells[0].Value.ToString();
            //txtCustomerName.Text = dgvOrder.SelectedCells[1].Value.ToString();
            //txtCity.Text = dgvOrder.SelectedCells[2].Value.ToString();
            //txtGSTNo.Text = dgvOrder.SelectedCells[3].Value.ToString();
            //txtQuantity.Text = dgvOrder.SelectedCells[4].Value.ToString();
            //txtRate.Text = dgvOrder.SelectedCells[5].Value.ToString();
            //txtTotal.Text = dgvOrder.SelectedCells[6].Value.ToString();
        }

        private void dgvOrder_CellClick_2(object sender, DataGridViewCellEventArgs e)
        {
            btnadd.Enabled = false;
            btnUpdate.Enabled = true;
            btndelete.Enabled = true;
            txtID.Text = dgvOrder.SelectedCells[0].Value.ToString();
            cmbCustomerName.Text = dgvOrder.SelectedCells[1].Value.ToString();
            txtCity.Text = dgvOrder.SelectedCells[2].Value.ToString();
            txtGSTNo.Text = dgvOrder.SelectedCells[3].Value.ToString();
            txtQuantity.Text = dgvOrder.SelectedCells[4].Value.ToString();
            txtRate.Text = dgvOrder.SelectedCells[5].Value.ToString();
            txtTotal.Text = dgvOrder.SelectedCells[6].Value.ToString();
            dtpDateOrder.Text = dgvOrder.SelectedCells[7].Value.ToString();
            cmbItemName.Text = dgvOrder.SelectedCells[8].Value.ToString();
            cmbItemSIze.Text = dgvOrder.SelectedCells[9].Value.ToString();
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            rdlcReport.FrmOrder RDLCPAY = new rdlcReport.FrmOrder();
            //RDLCPAY.TopLevel = false;
            //pnlOrder.Controls.Add(RDLCPAY);
            //RDLCPAY.BringToFront();
            RDLCPAY.Show();
        }

        private void btnexcel_Click(object sender, EventArgs e)
        {
            if (dgvOrder.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
                XcelApp.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dgvOrder.Columns.Count + 1; i++)
                {
                    XcelApp.Cells[1, i] = dgvOrder.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dgvOrder.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvOrder.Columns.Count; j++)
                    {
                        XcelApp.Cells[i + 2, j + 1] = dgvOrder.Rows[i].Cells[j].Value.ToString();
                    }
                }
                XcelApp.Columns.AutoFit();
                XcelApp.Visible = true;
            }

        }

        private void btndelete_Click_1(object sender, EventArgs e)
        {
            sql = "Delete from tbl_Order Where ID='"+txtID.Text+"' and CompanyID='" + ClassConn.CompanyID+ "'";
            ds = objcls.fillds(sql);
            MessageBox.Show("Deleted Successfully...");
            filldt();
            Clear();
        }


        private void cmbCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {

            sql = "Select City,GSTNo from tbl_createcustomer Where CustomerName='" + cmbCustomerName.Text + "'and CompanyID='"+ClassConn.CompanyID+"'";
            ds = objcls.fillds(sql);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                txtCity.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                txtGSTNo.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();



            }
        }
        public void CmbCustomerName()
        {
            sql = "Select * from tbl_createcustomer Where CompanyID='" + ClassConn.CompanyID + "'";
            ds = objcls.fillds(sql);
            cmbCustomerName.DataSource = ds.Tables[0];
        }


        private void Frmorder_Shown(object sender, EventArgs e)
        {
            cmbCustomerName.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            sql = "Update tbl_Order SET CustomerName='" + cmbCustomerName.Text + "', City='" + txtCity.Text + "',GSTNo='" + txtGSTNo.Text + "',Quantity='" + txtQuantity.Text + "',Rate='" + txtRate.Text + "',Total='" + txtTotal.Text + "',OrderDate='" + dtpDateOrder.Text + "',ItemName='" + cmbItemName.Text + "',ItemSize='" + cmbItemSIze.Text + "' Where CompanyID='" +ClassConn.CompanyID+ "'";
            objcls.execute(sql);
            MessageBox.Show("Updated Successfully...");
            filldt();
            Clear();
        }

        private void cmbItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            sql = "Select ItemSize from tbl_itemnameandsize Where ItemName='" + cmbItemName.Text + "' and CompanyID='" + ClassConn.CompanyID + "'";
            ds = objcls.fillds(sql);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cmbItemSIze.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                //txtGSTNo.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            }

        }
        public void fillcmbItemName()
        {
            sql = "Select * from tbl_itemnameandsize where CompanyID='" + ClassConn.CompanyID + "'";
            ds = objcls.fillds(sql);
            cmbItemName.DataSource = ds.Tables[0];
        }
        public void fillcmbItemSize()
        {
            sql = "Select * from tbl_itemnameandsize where CompanyID='" + ClassConn.CompanyID + "'";
            ds = objcls.fillds(sql);
            cmbItemSIze.DataSource = ds.Tables[0];
        }
        public void Refreshcmbcustname()
        {
            cmbCustomerName.Refresh();
        }     

        private void btnReset_Click(object sender, EventArgs e)
        {
            Clear();
            btnadd.Enabled = true;
        }

       

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            //CmbCustomerName();
            //fillcmbItemName();
            //fillcmbItemSize();
        }

        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            CalculationTotalAmt();
        }

        private void txtRate_Leave(object sender, EventArgs e)
        {
            CalculationTotalAmt();
        }

       

      

        private void cmbCustomerName_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (cmbCustomerName.Text == "")
            {
                MessageBox.Show("Please Create a Customer");
                return;
            }

            if (e.KeyCode == Keys.Enter)
            {
                txtCity.Focus();
            }
        }

        private void txtCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtGSTNo.Focus();
            }
        }

        private void txtGSTNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbItemName.Focus();
            }
        }

        private void cmbItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbItemSIze.Focus();
            }
        }

        private void txtItemSize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtQuantity.Focus();
            }
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRate.Focus();
            }
        }

        private void txtRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTotal.Focus();
            }
        }

        private void txtTotal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnadd.Focus();
            }
        }

     

        private void cmbCustomerName_Click(object sender, EventArgs e)
        {
            
            //CmbCustomerName();
            //Clear();
            
            
        }

        private void cmbCustomerName_Leave(object sender, EventArgs e)
        {
            //sql = "Select count(*) from tbl_createcustomer Where CustomerName='" + cmbCustomerName.Text + "'";
            //int cnt = objcls.executescalar(sql);
            //if (cnt != 0)
            //{
            //    MessageBox.Show("Customer Name Alreadt Available...");
            //    return;

            //}
            //CmbCustomerName();
        }


        private void btnaddbillingmaster_Click(object sender, EventArgs e)
        {
            FrmaddnameSiez frmAN = new FrmaddnameSiez();
            frmAN.Show();
        }

        private void cmbItemSIze_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtQuantity.Focus();
            }
        }

        private void cmbItemName_Click(object sender, EventArgs e)
        {
            fillcmbItemName();
            //Clear();
        }

        private void cmbItemSIze_Click(object sender, EventArgs e)
        {
            fillcmbItemSize();
            //Clear();
        }
    }
}


