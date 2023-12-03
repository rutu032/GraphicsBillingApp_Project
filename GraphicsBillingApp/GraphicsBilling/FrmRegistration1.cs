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
    public partial class FrmRegistration1 : Form
    {
        public FrmRegistration1()
        {
            InitializeComponent();
        }
        ClassConn objcls = new ClassConn();
        DataSet ds = new DataSet();
        string sql = "";
        int cnt;
        private string companyID;

        private void txtCustomerName_KeyDown(object sender, KeyEventArgs e)
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
                txtCity.Focus();
            }
        }

        private void txtCity_KeyDown(object sender, KeyEventArgs e)
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
                txtEmailId.Focus();
            }
        }

        private void txtEmaiId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRegister.Focus();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
           // DateTime DTPDate = Convert.ToDateTime(string.Format("{0:MM/dd/yyyy }", dtpDate.Text));
            if (txtCustomerName.Text == "")
            {
                MessageBox.Show("Enter Customer Name");
            }
            else if (txtCompanyName.Text == "")
            {
                MessageBox.Show("Enter Company Name");
            }
            else if (txtCity.Text == "")
            {
                MessageBox.Show("Enter City Name");
            }
            else if (txtMobileNo.Text == "")
            {
                MessageBox.Show("Enter Mobile No.");
            }
            else if (txtEmailId.Text == "")
            {
                MessageBox.Show("Enter EmailID");
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Enter Password");
            }
            string companyID = txtCompanyName.Text + txtCompanyID.Text;

            DateTime Today = DateTime.Now;
            string Date = DateTime.Now.ToString("dd--mm-yyyy");
           


            sql = "Insert into tbl_Registration1(CustomerName,CompanyName,City,MobileNo,EmailID,Password,Date,CompanyID)Values('" + txtCustomerName.Text + "','" + txtCompanyName.Text + "','" + txtCity.Text + "','" + txtMobileNo.Text + "','" + txtEmailId.Text + "','" + txtPassword.Text + "','"+ Today+"','"+ companyID + "')";
            objcls.execute(sql);
            MessageBox.Show("Registerd Successfully");
            Clear();
            Frmlogin frmLN = new Frmlogin();
            frmLN.Show();
            FrmRegistration1 frmRG = new FrmRegistration1();
            this.Hide();


        }
        public void Clear()
        {
            txtCustomerName.ResetText();
            txtCompanyName.ResetText();
            txtCity.ResetText();
            txtMobileNo.ResetText();
            txtEmailId.ResetText();
            txtPassword.ResetText();

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
                    MessageBox.Show(email + " is Valid Email Address");
                }
                else
                {

                    MessageBox.Show(email + " is Invalid Email Address");
                }

            }
        }



        public void filldt()
        {
            //sql = "Select * from tbl_Registration1";
            //ds = objcls.fillds(sql);
        } 

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //txtCustomerName.ResetText();
            //txtCompanyName.ResetText();
            //txtCity.ResetText();
            //txtMobileNo.ResetText();
            //txtEmaiId.ResetText();
            //txtPassword.ResetText();
            this.Close();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void FrmRegistration1_Load(object sender, EventArgs e)
        {
            //filldt();
            txtCompanyID.Text =RandomAlphaNumeric(5);
        }
        public static string RandomAlphaNumeric(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private void txtCity_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMobileNo.Focus();

            }
        }

        private void txtMobileNo_KeyDown_1(object sender, KeyEventArgs e)
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
                txtPassword.Focus();
            }
        }

        private void txtCompanyName_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCity.Focus();
            }
        }

        private void txtPassword_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRegister.Focus();
            }
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

        private void txtCustomerName_Leave(object sender, EventArgs e)
        {
            if (txtCustomerName.Text != "")
            {
                string text = txtCustomerName.Text;
                string firstletterofeachstring = string.Join(" ", text.Split(' ').ToList().ConvertAll(word => word.Substring(0, 1).ToUpper() + word.Substring(1)));
                txtCustomerName.Text = firstletterofeachstring;
            }
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
    }
}

