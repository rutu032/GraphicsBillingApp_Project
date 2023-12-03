using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsBilling
{
    public partial class Frmlogin : Form
    {
        public Frmlogin()
        {
            InitializeComponent();
        }
        ClassConn objcls = new ClassConn();
        DataSet ds = new DataSet();
        string sql = "";
        int cnt;
        internal static Frmlogin frmLog;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
          (
              int nLeftRect,     // x-coordinate of upper-left corner
              int nTopRect,      // y-coordinate of upper-left corner
              int nRightRect,    // x-coordinate of lower-right corner
              int nBottomRect,   // y-coordinate of lower-right corner
              int nWidthEllipse, // width of ellipse
              int nHeightEllipse // height of ellipse
          );

        private void btnlogin_Click(object sender, EventArgs e)
        {
          
            if (txtCompanyID.Text == "")
            {
                MessageBox.Show("Please Enter CompanyID");
                return;
            }
            if (txtEmailID.Text == "")
            {
                MessageBox.Show("Please Enter EmailID");
                return;
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Please Enter Password");
                return;
            }
            sql = "Select * from tbl_Registration1 Where EmailID='" + txtEmailID.Text + "'and Password='" + txtPassword.Text + "'and CompanyID='" + txtCompanyID.Text + "'";
            int cnt = objcls.executescalar(sql);
            if (cnt != 0)
            {

                ClassConn.CompanyID = txtCompanyID.Text;
                MessageBox.Show("Login Successfully");
                this.Hide();
                FrmNewDashboard frmDA = new FrmNewDashboard();
                frmDA.Show();
            }
            else
            {
                txtEmailID.ResetText();
                txtPassword.ResetText();
                MessageBox.Show("Login Failed");
            }
            Clear();
        }
    
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblNewAccount_Click(object sender, EventArgs e)
        {
            FrmRegistration1 frmRG = new FrmRegistration1();
            frmRG.Show();
        }
        public void filldt()
        {
            sql = "Select * from tbl_Login";
            ds = objcls.fillds(sql);
        }

        private void Frmlogin_Load(object sender, EventArgs e)
        {
            filldt();
            //Clear();
        }

        private void txtEmailID_KeyDown(object sender, KeyEventArgs e)
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
                btnlogin.Focus();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 70, 70));
        }

        private void checkBoxshowpassword_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (checkBoxshowpassword.Checked)
                {
                    txtPassword.UseSystemPasswordChar = false;
                }
                else
                {
                    txtPassword.UseSystemPasswordChar = true;
                }
            }
        }


        private void lblGetCompanyID_Click(object sender, EventArgs e)
        {
            FrmGetCompanyID frmGC = new FrmGetCompanyID();
            frmGC.Show();
        }

        private void Frmlogin_Shown(object sender, EventArgs e)
        {
            txtCompanyID.Focus();
        }
        public void Clear()
        {
            txtCompanyID.ResetText();
            txtEmailID.ResetText();
            txtPassword.ResetText();
        }

        private void txtCompanyID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEmailID.Focus();
            }
        }
    }
}

