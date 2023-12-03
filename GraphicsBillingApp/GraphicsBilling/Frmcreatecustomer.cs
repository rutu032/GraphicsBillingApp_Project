using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsBilling
{
    public partial class Frmcreatecustomer : Form
    {
        public Frmcreatecustomer()
        {
            InitializeComponent();
        }
        ClassConn objcls = new ClassConn();
        DataSet ds = new DataSet();
        string sql = "";
        int cnt;
        private void Frmcreatecustomer_Load(object sender, EventArgs e)
        {
            btncreate.Enabled = true;
            btnUpdate.Enabled = false;
            btndelete.Enabled = false;
            filldt();
            cmbfullCustomerName();
           
            dgvallcustomers.Columns[0].Visible = false;
            dgvallcustomers.Columns[7].Visible = false;

            dgvallcustomers.Columns[1].Width = 160; 
            dgvallcustomers.Columns[2].Width = 160;
            dgvallcustomers.Columns[3].Width = 160;
            dgvallcustomers.Columns[4].Width = 160;
            dgvallcustomers.Columns[5].Width = 160;
            dgvallcustomers.Columns[6].Width = 160;



            Clear();
          
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnViewCustomers_Click(object sender, EventArgs e)
        {
           // Frmallcustomers frmAC = new Frmallcustomers();
           //// frmAC.TopLevel = false;
           // frmAC.Show();
           // Frmcreatecustomer frmCR = new Frmcreatecustomer();
           // this.Close();
        }



        private void btncreate_Click(object sender, EventArgs e)

        {
            if (txtCustomerFullName.Text == "")
            {
                MessageBox.Show("Please Enter Customer Full Name");
                return;
            }
           
            if (txtCity.Text == "")
            {
                MessageBox.Show("Please Enter City");
                return;
            }
            if (txtEmailId.Text == "")
            {
                MessageBox.Show("Please Enter EmailID");
                return;
            }
            if (txtCompanyName.Text == "")
            {
                MessageBox.Show("Please Enter Company Name");
                return;
            }
            if (txtMobileNo.Text == "")
            {
                MessageBox.Show("Please Enter MobNo.");
                return;
            }
            if (txtgstNo.Text == "")
            {
                MessageBox.Show("Please Enter GSTNo.");
                return;
            }
            sql = "Select count (*) from tbl_createcustomer Where CustomerName='" + txtCustomerFullName.Text + "' and  CompanyID='"+ClassConn.CompanyID+"'";
            int cnt = objcls.executescalar(sql);
            if (cnt != 0)
            {
                MessageBox.Show("Customer Name Already Available...");
                return;
            }

                sql = "Insert into tbl_createcustomer(CustomerName,City,MobileNo,GSTNo,CompanyName,EmailID,CompanyID)values('" + txtCustomerFullName.Text + "','" + txtCity.Text + "','" + txtMobileNo.Text + "','" + txtgstNo.Text + "','" + txtCompanyName.Text + "','" + txtEmailId.Text + "','"+ClassConn.CompanyID+"')";
                objcls.execute(sql);
                MessageBox.Show("Create Successfully");
                filldt();
                Clear();
                //cmbfullCustomerName();
            
      
           
           
        }    
        
        public void filldt()
        {
            sql = "Select * from tbl_createcustomer where CompanyID='"+ClassConn.CompanyID+"'";
            ds = objcls.fillds(sql);
            dgvallcustomers.DataSource = ds.Tables[0];
            
           
           
        }
        public void PhoneValidation()
        {
            Regex pattern = new Regex("^[6-9][0-9]{9}${10}");
            if (pattern.IsMatch(txtMobileNo.Text))
            {

            }
            else
            {
                MessageBox.Show("Invalid Phone Number");
                txtMobileNo.Focus();
            }
        }
        public void EmailValidation()
        {
            {
                string email = txtEmailId.Text;
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(email);
                if (match.Success)
                {
                    MessageBox.Show( email +" is Valid Email Address");
                }
                else
                {

                    MessageBox.Show(email + " is Invalid Email Address");
                }
                  
            }


        }
        

        public void Clear()
        {
            txtCustomerFullName.ResetText();
            txtCompanyName.ResetText();
            txtCity.ResetText();
            txtMobileNo.ResetText();
            txtEmailId.ResetText();
            txtgstNo.ResetText();
            btncreate.Enabled = true;

        }
     

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            sql = "Update tbl_createcustomer SET CustomerName='" +txtCustomerFullName.Text + "',City='" + txtCity.Text + "',MobileNo='" + txtMobileNo.Text + "',GSTNo='" + txtgstNo.Text + "',CompanyName='" + txtCompanyName.Text + "',EmailID='"+txtEmailId.Text+ "' Where CompanyID='" +ClassConn.CompanyID+ "' ";
            objcls.execute(sql);
            MessageBox.Show("Updated Successfully...");
            filldt();
            Clear();
        }

        private void dgvallcustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btncreate.Enabled = false;
            btnUpdate.Enabled = true;
            btndelete.Enabled = true;

            txtID.Text = dgvallcustomers.SelectedCells[0].Value.ToString();
            txtCustomerFullName.Text = dgvallcustomers.SelectedCells[1].Value.ToString();
            txtCity.Text = dgvallcustomers.SelectedCells[2].Value.ToString();
            txtMobileNo.Text = dgvallcustomers.SelectedCells[3].Value.ToString();
            txtgstNo.Text = dgvallcustomers.SelectedCells[4].Value.ToString();
            txtCompanyName.Text = dgvallcustomers.SelectedCells[5].Value.ToString();
            txtEmailId.Text = dgvallcustomers.SelectedCells[6].Value.ToString();

        }

        private void Frmcreatecustomer_Shown(object sender, EventArgs e)
        {
            txtCustomerFullName.Focus();
        }

        private void txtMobileNo_Leave(object sender, EventArgs e)
        {
            if (txtMobileNo.Text == "")
            {

            }
            else
            {
                PhoneValidation();
            }

        }

        private void txtCustomerName_Leave(object sender, EventArgs e)
        {
            try
            {

                if (txtCustomerFullName.Text != "")
                {
                    string text = txtCustomerFullName.Text;
                    string firstletterofeachstring = string.Join(" ", text.Split(' ').ToList().ConvertAll(word => word.Substring(0, 1).ToUpper() + word.Substring(1)));
                    txtCustomerFullName.Text = firstletterofeachstring;
                }
            }
            
            
            catch { }
        }
        private void btnreset_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtCompanyName_Leave(object sender, EventArgs e)
        {
            if (txtCompanyName.Text != "")
            {
                string text = txtCompanyName.Text;
                string firstletterofeachstring = string.Join(" ", text.Split(' ').ToList().ConvertAll(word => word.Substring(0, 1).ToUpper() + word.Substring(1)));
                txtCompanyName.Text = firstletterofeachstring;
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCllose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    txtCity.Focus();
            //}
        }

        private void txtCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEmailId.Focus();
            }
        }

        private void txtEmailId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCompanyName.Focus();
            }
        }

        private void txtCompanyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMobileNo.Focus();
            }
        }

        private void txtMobileNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtgstNo.Focus();
            }
        }

        private void txtgstNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btncreate.Focus();
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            sql = "Delete from tbl_createcustomer Where ID='" +txtID.Text+ "'";
            ds = objcls.fillds(sql);
            MessageBox.Show("Deleted Successfully...");
            filldt();
            Clear();
        }

        private void txtEmailId_Leave(object sender, EventArgs e)
        {
            if (txtEmailId.Text == "")
            {

            }
            else
            {
                EmailValidation();
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            Frmorder frmOR = new Frmorder();
            frmOR.Show();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (txtCustomerFullName.Text == "")
            {
                MessageBox.Show("Enter CustomerName First ");
                txtCustomerFullName.Focus();
                return;
            }
            else if (txtCity.Text == "")
            {
                MessageBox.Show("Enter City Name");
                txtCity.Focus();
                return;
            }
            
            sql = "Insert into tbl_createcustomer(CustomerName,City,CompanyID)Values('" + txtCustomerFullName.Text + "','" + txtCity.Text + "','"+ClassConn.CompanyID+"')";
            ds = objcls.fillds(sql);
            MessageBox.Show("Inserted Successfully");
            filldt();
            //cmbfullCustomerName();
           
        }
        public void cmbfullCustomerName()
        {
            //sql = "Select * from tbl_createcustomer ";
            //ds = objcls.fillds(sql);
            ////    cmbCustomerName.DataSource = ds.Tables[0];
        }
            

        private void cmbCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            sql = "Select City from tbl_createcustomer Where CustomerName='" + txtCustomerFullName.Text + "'";
            ds = objcls.fillds(sql);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                txtCity.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            }
        }

        private void cmbCustomerName_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Enter)
            {
                txtCity.Focus();
            }
            else if (txtCustomerFullName.Text == "" && txtCity.Text == "")
            {
                MessageBox.Show("Please Add Customer Name and City...");
                return;

            }


        }

        private void cmbCustomerName_Leave(object sender, EventArgs e)
        {
          
        }

        private void dgvallcustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtCustomerFullName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCity.Focus();
            }
        }

        private void txtCustomerFullName_Leave(object sender, EventArgs e)
        {
            if (txtCustomerFullName.Text != "")
            {
                string text = txtCustomerFullName.Text;
                string firstletterofeachstring = string.Join(" ", text.Split(' ').ToList().ConvertAll(word => word.Substring(0, 1).ToUpper() + word.Substring(1)));
                txtCustomerFullName.Text = firstletterofeachstring;
            }
        }

        private void txtMobileNo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
