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
    public partial class Frmbilling : Form
    {
        public Frmbilling()
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

        private void Frmbilling_Load(object sender, EventArgs e)
        {
            btnaddbilliing.Enabled = true;
            btnUpdate.Enabled = false;
            btndelete.Enabled = false;
            filldt();
            fillCustomerName();
            fillcmbItemName();
            fillcmbItemSize();
            calculationTotalAmt();
            CalculationCGST();
            CalculationSGST();
            CalculationIGST();
            CalculationGrandTotal();
            CalculationShowTotal();
            CheckCGST_SGST();
            Check_IGST();
            dgvbilling.Columns[0].Visible = false;
            cmbItemName.SelectedIndex = -1;
            cmbItemSIze.SelectedIndex = -1;
            dgvbilling.Columns[16].Visible = false;
          // dgvbilling.Columns[10].Visible = false;
           

           Clear();

        }

        private void btnaddbilling_Click(object sender, EventArgs e)
        {
            FrmaddnameSiez frmADS = new FrmaddnameSiez();
            frmADS.Show();
        }

        private void btnaddbilliing_Click(object sender, EventArgs e)
        {
            ////if (txtPaidAmount.Text == "")
            ////{
            ////    MessageBox.Show("Enter Paid Amount");
            ////    return;
            ////}

            //if (cmbCustomerName.Text == "")
            //{
            //    MessageBox.Show("Please Enter Customer Name");
            //    return;

            //}
            //if (txtCity.Text == "")
            //{
            //    MessageBox.Show("Please Enter City");
            //    return;
            //}
            //if (cmbItemName.Text == "")
            //{
            //    MessageBox.Show("Please Select Item Name");
            //    return;
            //}
            //if (txtGSTNo.Text == "")
            //{
            //    MessageBox.Show("Please Enter GST No.");
            //    return;
            //}
            //if (txtQuantity.Text == "")
            //{
            //    MessageBox.Show("Please Enter Quantity");
            //    return;
            //}
            //if (txtRate.Text == "")
            //{
            //    MessageBox.Show("Please Enter Rate");
            //    return;
            //}
            //if (txtGrandTotal.Text == "")
            //{
            //    MessageBox.Show("Please Enter GrandTotal");
            //    return;
            //}
            //if (txtPaidAmount.Text == "")
            //{
            //    //MessageBox.Show("Please Enter PaidAmount");
            //    //return;
            //}
            //if (txtBalanceAmt.Text == "")
            //{
            //    MessageBox.Show("Please Enter BalanceAmount");
            //    return;
            //}

            //if (radiobtncgstndsgst.Checked == true)
            //{
            //    sql = "Insert into tbl_Billing1(CustomerName,City,Quantity,Rate,TotalAmount,CGST,SGST,IGST,GrandTotal,PaidAmount,ItemSize,ItemName,Date,GSTNo,BalanceAmount,CompanyID)values('" + cmbCustomerName.Text + "','" + txtCity.Text + "','" + txtQuantity.Text + "','" + txtRate.Text + "','" + txtTotalAmount.Text + "','" + txtCalCGST2.Text + "','" + txtCalSGST2.Text + "','0','" + txtGrandTotal.Text + "','"+txtPaidAmount.Text+"','" + cmbItemSIze.Text + "','" + cmbItemName.Text + "','" + dtpDate.Text + "','" + txtGSTNo.Text + "','" + txtBalanceAmt.Text + "','" + ClassConn.CompanyID + "')";
            //    objcls.execute(sql);
            //    MessageBox.Show("Add Successfully");

            //}
            //else if (radiobtnigst.Checked == true)
            //{
            //    sql = "Insert into tbl_Billing1(CustomerName,City,Quantity,Rate,TotalAmount,CGST,SGST,IGST,GrandTotal,PaidAmount,ItemSize,ItemName,Date,GSTNo,BalanceAmount,CompanyID)values('" + cmbCustomerName.Text + "','" + txtCity.Text + "','" + txtQuantity.Text + "','" + txtRate.Text + "','" + txtTotalAmount.Text + "','0','0','" + txtCalIGST2.Text + "','" + txtGrandTotal.Text + "','"+txtPaidAmount.Text+"','" + cmbItemSIze.Text + "','" + cmbItemName.Text + "','" + dtpDate.Text + "','" + txtGSTNo.Text + "','" + txtBalanceAmt.Text + "','" + ClassConn.CompanyID + "')";
            //    objcls.execute(sql);
            //    MessageBox.Show("Add Successfully");
            //}

            //filldt();
            //Clear();
        }
        public void filldt()
        {
            sql = "Select * from tbl_Billing1 Where CompanyID='"+ClassConn.CompanyID+"' ";
            ds = objcls.fillds(sql);
            dgvbilling.DataSource = ds.Tables[0];
            //dgvbilling.Columns[0].Visible = false;
            //dgvbilling.Columns[1].Visible = false;
            //dgvbilling.Columns[2].Visible = false;
            //dgvbilling.Columns[6].Visible = false;
            //dgvbilling.Columns[7].Visible = false;
            //dgvbilling.Columns[8].Visible = false;
            //dgvbilling.Columns[9].Visible = false;
            //dgvbilling.Columns[10].Visible = false;
            //dgvbilling.Columns[17].Visible = false;

        }

        private void dgvItemsbilling_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //txtID.Text = dgvbilling.SelectedCells[0].Value.ToString();
            //txtCustomerName.Text = dgvbilling.SelectedCells[1].Value.ToString();
            //txtCity.Text = dgvbilling.SelectedCells[2].Value.ToString();
            //// txtGSTNo.Text = dgvItemsbilling.SelectedCells[3].Value.ToString();
            //txtQuantity.Text = dgvbilling.SelectedCells[3].Value.ToString();
            //txtRate.Text = dgvbilling.SelectedCells[4].Value.ToString();
            //txtTotalAmount.Text = dgvbilling.SelectedCells[5].Value.ToString();
            //txtCalCGST2.Text = dgvbilling.SelectedCells[6].Value.ToString();
            //txtCalSGST2.Text = dgvbilling.SelectedCells[7].Value.ToString();
            //txtCalIGST2.Text = dgvbilling.SelectedCells[8].Value.ToString();
            //txtGrandTotal.Text = dgvbilling.SelectedCells[9].Value.ToString();
            //txtPaidAmount.Text = dgvbilling.SelectedCells[10].Value.ToString();
            //dtpDate.Text = dgvbilling.SelectedCells[11].Value.ToString();
            //txtGSTNo.Text = dgvbilling.SelectedCells[12].Value.ToString();
            //txtBalanceAmt.Text = dgvbilling.SelectedCells[13].Value.ToString();
            //cmbItemName.Text = dgvbilling.SelectedCells[14].Value.ToString();
            //txtItemSize.Text = dgvbilling.SelectedCells[15].Value.ToString();

        }



        private void cmbItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            sql = "Select ItemSize from tbl_itemnameandsize Where ItemName='" + cmbItemName.Text + "'and CompanyID='" + ClassConn.CompanyID + "'";
            ds = objcls.fillds(sql);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cmbItemSIze.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                //txtGSTNo.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            }
        }

        private void cmbItemSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            //sql = "Select ItemName from tbl_itemnameandsize Where ItemName='" + cmbItemName.Text + "'";
            //ds = objcls.fillds(sql);

            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    txtItemSize.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            //}
            // ItemName();
        }

        public void fillcmbItemName()
        {
            sql = "Select * from tbl_itemnameandsize Where CompanyID='"+ClassConn.CompanyID+"'";
            ds = objcls.fillds(sql);
            cmbItemName.DataSource = ds.Tables[0];
        }

        public void fillcmbItemSize()
        {
            sql = "Select * from tbl_itemnameandsize Where CompanyID='" + ClassConn.CompanyID + "'";
            ds = objcls.fillds(sql);
            cmbItemSIze.DataSource = ds.Tables[0];


        }
        public void fillCustomerName()
        {
            sql = "Select * from tbl_createcustomer Where CompanyID='" + ClassConn.CompanyID + "'";
            ds = objcls.fillds(sql);
            cmbCustomerName.DataSource = ds.Tables[0];
        }
        

        public void calculationTotalAmt()
        {
            try
            {
                int Rate, Quantity;
                double TotalAmount = 0;
                Rate = Convert.ToInt32(txtRate.Text);
                Quantity = Convert.ToInt32(txtQuantity.Text);
                TotalAmount = (Rate * Quantity);
                txtTotalAmount.Text = Convert.ToString(TotalAmount);
            }
            catch
            {

            }

        }
        public void CalculationCGST()
        {
            try
            {
                //int TotAmt = 0;
                //int CGST = 0;
                double CalCGST = 0;
                txtCGST1.Text = "9";
                txtCalCGST2.Text = "0";

                //TotAmt = Convert.ToInt32(txtTotalAmount.Text);
                //CGST = Convert.ToInt32(txtCGST1.Text);

                CalCGST = Convert.ToDouble((Convert.ToDouble(txtTotalAmount.Text) * ((Convert.ToDouble(txtCGST1.Text)) / 100)));
                txtCalCGST2.Text = Convert.ToString(CalCGST);
            }
            catch { }
            
        }
        public void CalculationSGST()
        {
            try
            {
                //int TotalAmt = 0;
                //int SGST = 0;
                double CalSGST = 0;
                txtSGST1.Text = "9";
                //txtCalCGST2.Text = "0";

                CalSGST = Convert.ToDouble((Convert.ToDouble(txtTotalAmount.Text) * ((Convert.ToDouble(txtSGST1.Text)) / 100)));
                txtCalSGST2.Text = Convert.ToString(CalSGST);

            }
            catch { }

        }
        public void CalculationIGST()
        {
            try
            {
                double CalIGST = 0;
                txtIGST1.Text = "18";
                txtCalIGST2.Text = "0";
                CalIGST = Convert.ToDouble((Convert.ToDouble(txtTotalAmount.Text) * ((Convert.ToDouble(txtIGST1.Text)) / 100)));
                txtCalIGST2.Text = Convert.ToString(CalIGST);
                //GrandTotal = Convert.ToDouble((Convert.ToDouble(txtCalIGST2.Text) + ((Convert.ToDouble(txtTotalAmount.Text)))));


            }
            catch { }

        }
        public void CalculationGrandTotal()
        {
            try
            {
                if (radiobtncgstndsgst.Checked == true)
                {
                    double CalGrandTotal = 0;
                    CalGrandTotal = Convert.ToDouble((Convert.ToDouble(txtCalCGST2.Text)) + (Convert.ToDouble(txtCalSGST2.Text)) + ((Convert.ToDouble(txtTotalAmount.Text))));
                    txtGrandTotal.Text = Convert.ToString(CalGrandTotal);
                }
                else if (radiobtnigst.Checked == true)
                {

                    double CalGrandTotal = 0;
                    CalGrandTotal = Convert.ToDouble((Convert.ToDouble(txtCalIGST2.Text)) + ((Convert.ToDouble(txtTotalAmount.Text))));
                    txtGrandTotal.Text = Convert.ToString(CalGrandTotal);
                }
            }

            catch { }
            
        }
        public void CalculationShowTotal()
        {
            double CalShowTotalIGST = 0;
            if (radiobtncgstndsgst.Checked == true)
            {
                CalShowTotalIGST = Convert.ToDouble((Convert.ToDouble(txtCGST1.Text) + ((Convert.ToDouble(txtSGST1.Text)))));
                txtShowtotal.Text = Convert.ToString(CalShowTotalIGST);
            }

            else
            {
                txtShowtotal.Text = "18";
            }

        }
        private void txtQuantity_Leave(object sender, EventArgs e)
        {
           // calculationTotalAmt();
        }

        private void txtRate_Leave(object sender, EventArgs e)
        {
           // calculationTotalAmt();
        }

        private void txtCGST1_Leave(object sender, EventArgs e)
        {

        }

        private void txtSGST1_Leave(object sender, EventArgs e)
        {
            calculationTotalAmt();
        }

        private void checkIncludeGST_CheckedChanged(object sender, EventArgs e)
        {
            radiobtncgstndsgst.Checked = true;
            CalculationCGST();
            CalculationSGST();
            CalculationGrandTotal();
            CalculationShowTotal();
            txtIGST1.ResetText();
            txtCalIGST2.ResetText();
            //txtCGST1.Text = "0";
            //txtCalCGST2.Text = "0";
            //txtSGST1.Text = "0";
            //txtCalSGST2.Text = "0";
            //txtIGST1.Text = "0";
            //txtCalIGST2.Text = "0";
            //radiobtnigst.Checked = true;



        }

        private void radiobtncgstndsgst_CheckedChanged(object sender, EventArgs e)
        {
            CheckCGST_SGST();
            txtIGST1.Text = "0";
            txtCalIGST2.Text = "0";
        }

        public void Check_IGST()
        {
            CalculationIGST();


        }
        public void CheckCGST_SGST()
        {

            CalculationCGST();
            CalculationSGST();

            txtIGST1.ResetText();
            txtCalIGST2.ResetText();

        }

        private void radiobtnigst_CheckedChanged(object sender, EventArgs e)
        {
            txtCGST1.ResetText();
            txtCalCGST2.ResetText();

            txtSGST1.ResetText();
            txtCalSGST2.ResetText();

            Check_IGST();
            txtCGST1.Text = "0";
            txtCalCGST2.Text = "0";
            txtSGST1.Text = "0";
            txtCalSGST2.Text = "0";

        }

        private void btnPaid_Click(object sender, EventArgs e)
        {

            //sql = "Insert into tbl_Billing1(GrandTotal,PaidAmount,BalanceAmount)values('" + txtGrandTotal.Text + "','" + txtPaidAmount.Text + "','"+txtBalanceAmt.Text+"')";
            //objcls.execute(sql);
            //MessageBox.Show("Paid Successfully");
            //filldt();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            sql = "Delete from tbl_Billing1 Where ID='"+txtID.Text+"' and CompanyID='" +ClassConn.CompanyID+ "'";
            ds = objcls.fillds(sql);
            MessageBox.Show("Delete Successfully...");
            filldt();
            Clear();
       
       



        }


        private void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double TotAmt = Convert.ToDouble(txtTotalAmount.Text);
                double PaidAmt = Convert.ToDouble(txtPaidAmount.Text);
                double BalanceAmt = TotAmt - PaidAmt;
                txtBalanceAmt.Text = Convert.ToString(BalanceAmt);

            }
            catch { }


        }

        private void Frmbilling_Shown(object sender, EventArgs e)
        {
            cmbCustomerName.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           // if (radiobtncgstndsgst.Checked == true)
            {
                sql = "Update tbl_Billing1 SET CustomerName='" + cmbCustomerName.Text + "',City='" + txtCity.Text + "',Quantity='" + txtQuantity.Text + "',Rate='" + txtRate.Text + "',TotalAmount='" + txtTotalAmount.Text + "',CGST='" + txtCalCGST2.Text + "',SGST='" + txtCalSGST2.Text + "',IGST='0',GrandTotal='" + txtGrandTotal.Text + "',PaidAmount='" + txtPaidAmount.Text + "',Date='" + dtpDate.Text + "',GSTNo='" + txtGSTNo.Text + "',BalanceAmount='" + txtBalanceAmt.Text + "',ItemName='" + cmbItemName.Text + "',ItemSize='" + cmbItemSIze.Text + "' Where ID='" +txtID.Text+ "' and CompanyID='"+ClassConn.CompanyID+"'";
                objcls.execute(sql);
                MessageBox.Show("Updated Successfully");

            }
            //else if (radiobtnigst.Checked == true)
            //{
            //    sql = "Update tbl_Billing1 SET CustomerName='" + cmbCustomerName.Text + "',City='" + txtCity.Text + "',Quantity='" + txtQuantity.Text + "',Rate='" + txtRate.Text + "',TotalAmount='" + txtTotalAmount.Text + "',CGST='0',SGST='0', ,IGST='" + txtCalIGST2.Text + "',GrandTotal='" + txtGrandTotal.Text + "',PaidAmount='" + txtPaidAmount.Text + "',Date='" + dtpDate.Text + "',GSTNo='" + txtGSTNo.Text + "',BalanceAmount='" + txtBalanceAmt.Text + "',ItemName='" + cmbItemName.Text + "',ItemSize='" +cmbItemSIze.Text + "' Where  ID='" +txtID.Text+ "' and CompanyID='" + ClassConn.CompanyID + "' ";
            //    objcls.execute(sql);
            //    MessageBox.Show("Updated Successfully");

           // }

            filldt();
            Clear();
         
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            cmbCustomerName.ResetText();
            txtCity.ResetText();
            txtQuantity.ResetText();
            txtRate.ResetText();
            txtTotalAmount.Text="0";
            txtCalCGST2.ResetText();
            txtCalIGST2.ResetText();
            txtCalSGST2.ResetText();
            txtGrandTotal.Text="0";
            txtPaidAmount.Text="0";
            txtGSTNo.ResetText();
            txtBalanceAmt.Text="0";
            cmbItemName.ResetText();
            cmbItemSIze.ResetText();
            btnaddbilliing.Enabled = true;
        }



        private void dgvbilling_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnaddbilliing.Enabled = false;
            btnUpdate.Enabled = true;
            btndelete.Enabled = true;
            txtID.Text = dgvbilling.SelectedCells[0].Value.ToString();
            cmbCustomerName.Text = dgvbilling.SelectedCells[1].Value.ToString();
            txtCity.Text = dgvbilling.SelectedCells[2].Value.ToString();
            // txtGSTNo.Text = dgvItemsbilling.SelectedCells[3].Value.ToString();
            txtQuantity.Text = dgvbilling.SelectedCells[3].Value.ToString();
            txtRate.Text = dgvbilling.SelectedCells[4].Value.ToString();
            txtTotalAmount.Text = dgvbilling.SelectedCells[5].Value.ToString();
            txtCalCGST2.Text = dgvbilling.SelectedCells[6].Value.ToString();
            txtCalSGST2.Text = dgvbilling.SelectedCells[7].Value.ToString();
            txtCalIGST2.Text = dgvbilling.SelectedCells[8].Value.ToString();
            txtGrandTotal.Text = dgvbilling.SelectedCells[9].Value.ToString();
            txtPaidAmount.Text = dgvbilling.SelectedCells[10].Value.ToString();
            dtpDate.Text = dgvbilling.SelectedCells[11].Value.ToString();
            txtGSTNo.Text = dgvbilling.SelectedCells[12].Value.ToString();
            txtBalanceAmt.Text = dgvbilling.SelectedCells[13].Value.ToString();
            cmbItemName.Text = dgvbilling.SelectedCells[14].Value.ToString();
            cmbItemSIze.Text = dgvbilling.SelectedCells[15].Value.ToString();
        }

        private void txtCustomerName_Leave(object sender, EventArgs e)
        {
            //if (txtCustomerName.Text != "")
            //{
            //    string text = txtCustomerName.Text;
            //    string firstletterofeachstring = string.Join(" ", text.Split(' ').ToList().ConvertAll(word => word.Substring(0, 1).ToUpper() + word.Substring(1)));
            //    txtCustomerName.Text = firstletterofeachstring;
            //}
        }

        private void txtCity_Leave(object sender, EventArgs e)
        {
            if (txtCity.Text != "")
            {
                string text = txtCity.Text;
                string firstletterofeachstring = string.Join(" ", text.Split(' ').ToList().ConvertAll(word => word.Substring(0, 1).ToUpper() + word.Substring(1)));
                txtCity.Text = firstletterofeachstring;
            }
        }

        private void txtCustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCity.Focus();
            }
        }

        private void txtCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbItemName.Focus();
            }
        }

        private void cmbItemName_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    .Focus();
            //}
        }

        private void txtItemSize_KeyDown(object sender, KeyEventArgs e)
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
                txtQuantity.Focus();
            }
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    txtRate.Focus();
            //}
        }

        private void txtRate_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    txtTotalAmount.Focus();
            //}
        }

        private void txtTotalAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtGrandTotal.Focus();
            }
        }

        private void txtGrandTotal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPaidAmount.Focus();
            }
        }

        private void txtPaidAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBalanceAmt.Focus();
            }
        }

        private void txtCustomerName_Leave_1(object sender, EventArgs e)
        {
            if (cmbCustomerName.Text != "")
            {
                string text = cmbCustomerName.Text;
                string firstletterofeachstring = string.Join(" ", text.Split(' ').ToList().ConvertAll(word => word.Substring(0, 1).ToUpper() + word.Substring(1)));
                cmbCustomerName.Text = firstletterofeachstring;
            }
        }

        private void txtRate_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTotalAmount.Focus();
            }
        }

        private void txtQuantity_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRate.Focus();
            }
        }

        private void txtRate_Leave_1(object sender, EventArgs e)
        {
            calculationTotalAmt();
        }

        private void txtQuantity_Leave_1(object sender, EventArgs e)
        {
            calculationTotalAmt();
        }

        private void txtBalanceAmt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPaid.Focus();
            }
        }

        private void clsbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPaid_Click_1(object sender, EventArgs e)

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
            if (cmbItemName.Text == "")
            {
                MessageBox.Show("Please Select Item Name");
                return;
            }
            if (txtGSTNo.Text == "")
            {
                MessageBox.Show("Please Enter GST No.");
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
            if (txtGrandTotal.Text == "")
            {
                MessageBox.Show("Please Enter GrandTotal");
                return;
            }
            if (txtPaidAmount.Text == "")
            {
                //MessageBox.Show("Please Enter PaidAmount");
                //return;
            }
            if (txtBalanceAmt.Text == "")
            {
                MessageBox.Show("Please Enter BalanceAmount");
                return;
            }

            if (radiobtncgstndsgst.Checked == true)
            {
                sql = "Insert into tbl_Billing1(CustomerName,City,Quantity,Rate,TotalAmount,CGST,SGST,IGST,GrandTotal,PaidAmount,ItemSize,ItemName,Date,GSTNo,BalanceAmount,CompanyID)values('" + cmbCustomerName.Text + "','" + txtCity.Text + "','" + txtQuantity.Text + "','" + txtRate.Text + "','" + txtTotalAmount.Text + "','" + txtCalCGST2.Text + "','" + txtCalSGST2.Text + "','0','" + txtGrandTotal.Text + "','" + txtPaidAmount.Text + "','" + cmbItemSIze.Text + "','" + cmbItemName.Text + "','" + dtpDate.Text + "','" + txtGSTNo.Text + "','" + txtBalanceAmt.Text + "','" + ClassConn.CompanyID + "')";
                //objcls.execute(sql);
               // MessageBox.Show("Add Successfully");

            }
            else if (radiobtnigst.Checked == true)
            {
                sql = "Insert into tbl_Billing1(CustomerName,City,Quantity,Rate,TotalAmount,CGST,SGST,IGST,GrandTotal,PaidAmount,ItemSize,ItemName,Date,GSTNo,BalanceAmount,CompanyID)values('" + cmbCustomerName.Text + "','" + txtCity.Text + "','" + txtQuantity.Text + "','" + txtRate.Text + "','" + txtTotalAmount.Text + "','0','0','" + txtCalIGST2.Text + "','" + txtGrandTotal.Text + "','" + txtPaidAmount.Text + "','" + cmbItemSIze.Text + "','" + cmbItemName.Text + "','" + dtpDate.Text + "','" + txtGSTNo.Text + "','" + txtBalanceAmt.Text + "','" + ClassConn.CompanyID + "')";
                //objcls.execute(sql);
                //MessageBox.Show("Add Successfully");
            }
          
        
          
            {
                sql = "Insert into tbl_Billing1(CustomerName,City,Quantity,Rate,TotalAmount,CGST,SGST,IGST,GrandTotal,PaidAmount,ItemSize,ItemName,Date,GSTNo,BalanceAmount,CompanyID)values('" + cmbCustomerName.Text + "','" + txtCity.Text + "','" + txtQuantity.Text + "','" + txtRate.Text + "','" + txtTotalAmount.Text + "','" + txtCalCGST2.Text + "','" + txtCalSGST2.Text + "','0','" + txtGrandTotal.Text + "','" + txtPaidAmount.Text + "','" + cmbItemSIze.Text + "','" + cmbItemName.Text + "','" + dtpDate.Text + "','" + txtGSTNo.Text + "','" + txtBalanceAmt.Text + "','" + ClassConn.CompanyID + "')";
                objcls.execute(sql);
                MessageBox.Show("Paid Successfully");
                filldt();


            }

            PaidAmountClear();
            txtPaidAmount.Text = "0";
           // filldt();
            Clear();



        }
        public void PaidAmountClear()
        {
            txtPaidAmount.ResetText();
        }

        private void cmbItemName_Leave(object sender, EventArgs e)
        {
            //if (cmbItemName.Text == "")
            //{
            //    MessageBox.Show("Enter Item Name First ");
            //    cmbItemName.Focus();
            //    return;
            //}
            //else if (cmbItemSIze.Text == "")
            //{
            //    MessageBox.Show("Enter Item Size ");
            //    cmbItemSIze.Focus();
            //    return;
            //}
            //sql = "Select count (*) from tbl_itemnameandsize Where ItemName='" + cmbItemName.Text + "' and ItemSize='" + txtItemSize.Text + "' ";
            //int cnt = objcls.executescalar(sql);
            //if (cnt != 0)
            //{
            //    MessageBox.Show(" Item Name Already Available Please Add... ");
            //    return;
            //}
           
          
            //sql = "Insert into tbl_createcustomer(CustomerName,City)Values('" + cmbCustomerName.Text + "','" + txtCity.Text + "')";
            //ds = objcls.fillds(sql);
            //MessageBox.Show("Inserted Successfully");
            //filldt();
            //cmbfullCustomerName();

        }

        private void cmbItemName_Click(object sender, EventArgs e)
        {
       
            fillcmbItemName();
           

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            sql = "Select City,GSTNo from tbl_createcustomer Where CustomerName='" + cmbCustomerName.Text + "' and CompanyID='" + ClassConn.CompanyID + "'";
            ds = objcls.fillds(sql);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                txtCity.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                txtGSTNo.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            }
            
        }

        private void cmbCustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCity.Focus();
            }
        }

        private void cmbItemSIze_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtQuantity.Focus();
            }
        }

        private void cmbCustomerName_Click(object sender, EventArgs e)
        {
            fillCustomerName();
      

        }

      
        private void cmbItemSIze_Click(object sender, EventArgs e)
        {
            fillcmbItemSize();
            

        }

        private void txtPaidAmount_Leave(object sender, EventArgs e)
        {
            
        }

        private void btnPaid_KeyDown(object sender, KeyEventArgs e)
        {
            sql = "Insert into tbl_Billing1(CustomerName,City,Quantity,Rate,TotalAmount,CGST,SGST,IGST,GrandTotal,PaidAmount,ItemSize,ItemName,Date,GSTNo,BalanceAmount,CompanyID)values('" + cmbCustomerName.Text + "','" + txtCity.Text + "','" + txtQuantity.Text + "','" + txtRate.Text + "','" + txtTotalAmount.Text + "','" + txtCalCGST2.Text + "','" + txtCalSGST2.Text + "','0','" + txtGrandTotal.Text + "','" + txtPaidAmount.Text + "','" + cmbItemSIze.Text + "','" + cmbItemName.Text + "','" + dtpDate.Text + "','" + txtGSTNo.Text + "','" + txtBalanceAmt.Text + "','" + ClassConn.CompanyID + "')";
            objcls.execute(sql);
            MessageBox.Show("Add Successfully");
        }

        private void txtBalanceAmt_TextChanged(object sender, EventArgs e)
        {

        }
    }
        }
  

