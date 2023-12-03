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
    public partial class FrmNewDashboard : Form
    {
        public FrmNewDashboard()
        {
            InitializeComponent();
        }
        ClassConn objcls = new ClassConn();
        DataSet ds = new DataSet();
        string sql = "";
        int cnt;
        private static FrmNewDashboard frmND;
        private object frmLG;
        private static FrmNewDashboard frmDH;

        //[DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        //private static extern IntPtr CreateRoundRectRgn
        //  (
        //      int nLeftRect,     // x-coordinate of upper-left corner
        //      int nTopRect,      // y-coordinate of upper-left corner
        //      int nRightRect,    // x-coordinate of lower-right corner
        //      int nBottomRect,   // y-coordinate of lower-right corner
        //      int nWidthEllipse, // width of ellipse
        //      int nHeightEllipse // height of ellipse
        //  );


        private void picboxhome_Click(object sender, EventArgs e)
        {
            FrmNewDashboard frmND = new FrmNewDashboard();
            frmND.Visible = true;
            //dashpanel.Controls.Add(frmND);
            frmND.BringToFront();
            pnldash.Show();
        }

        private void picboxorderbill_Click(object sender, EventArgs e)
        {
            FrmOrderbill frmOB = new FrmOrderbill();
            //frmOB.TopLevel = false;
            //pnldash.Controls.Add(frmOB);
            //frmOB.BringToFront();
            frmOB.Show();
        }

        private void picboxbilling_Click(object sender, EventArgs e)
        {
            Frmbilling frmBL = new Frmbilling();
            //frmBL.TopLevel = false;
            //pnldash.Controls.Add(frmBL);
            //frmBL.BringToFront();
            frmBL.Show();
        }

        private void picboxprofile_Click(object sender, EventArgs e)
        {

            FrmProfile frmPF = new FrmProfile();
            frmPF.TopLevel = false;
            pnldash.Controls.Add(frmPF);
            frmPF.BringToFront();
            frmPF.Show();
        }

        private void FrmNewDashboard_Load(object sender, EventArgs e)
        {
            GSTCollection();
            todaysCollection();
            todaysOrder();
            BalanceAmt();
            PendingOrder();
            //pnldashrefresh();
        }

        private void pnlgstcollection_Paint(object sender, PaintEventArgs e)
        {
            //Frmgstcollection frmGST = new Frmgstcollection();
            //frmGST.TopLevel = false;
            //pnldash.Controls.Add(frmGST);
            //frmGST.BringToFront();
            //frmGST.Show();


        }

        private void pnltodayscollection_Paint(object sender, PaintEventArgs e)
        {
            //Frmtodayscollection frmTC = new Frmtodayscollection();
            //frmTC.TopLevel = false;
            //pnldash.Controls.Add(frmTC);
            //frmTC.BringToFront();
            //frmTC.Show();

        }

        private void pnlpendingorders_Paint(object sender, PaintEventArgs e)
        {
            //FrmPendingorders frmPO = new FrmPendingorders();
            //frmPO.TopLevel = false;
            //pnldash.Controls.Add(frmPO);
            //frmPO.BringToFront();
            //frmPO.Show();

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            Frmorder frmOR = new Frmorder();
            //frmOR.TopLevel = false;
            //pnldash.Controls.Add(frmOR);
            //frmOR.BringToFront();
            frmOR.Show();

        }

        private void dashpanel_Paint(object sender, PaintEventArgs e)
        {

            //Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 70, 70));
        }

        private void pnldash_Paint(object sender, PaintEventArgs e)
        {
            // Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 70, 70));
        }

        private void btnincreasegraph_Click(object sender, EventArgs e)
        {
            //    FrmReport frmRP = new FrmReport();
            //    frmRP.TopLevel = false;
            //    pnldash.Controls.Add(frmRP);
            //    frmRP.BringToFront();
            //    frmRP.Show();

            FrmChartGraph frmCG = new FrmChartGraph();
            frmCG.TopLevel = false;
            pnldash.Controls.Add(frmCG);
            frmCG.BringToFront();
            frmCG.Show();
        }

        private void pnlgstcollection_Click(object sender, EventArgs e)
        {
            FrmgstCollection1 frmGST = new FrmgstCollection1();
            //frmGST.TopLevel = false;
            //pnldash.Controls.Add(frmGST);
            //frmGST.BringToFront();
            frmGST.Show();

        }

        private void pnltodayscollection_Click(object sender, EventArgs e)
        {
            Frmtodaycollection frmTC = new Frmtodaycollection();
            //frmTC.TopLevel = false;
            //pnldash.Controls.Add(frmTC);
            //frmTC.BringToFront();
            frmTC.Show();
        }

        private void pnlpendingorders_Click(object sender, EventArgs e)
        {
            Frmpendingorders1 frmPO = new Frmpendingorders1();
            //frmPO.TopLevel = false;
            //pnldash.Controls.Add(frmPO);
            //frmPO.BringToFront();
            frmPO.Show();
        }

        private void pnltodaysorders_Click(object sender, EventArgs e)
        {
            // FrmPendingorders frmPO = new FrmPendingorders();
            //frmPO.TopLevel = false;
            //pnldash.Controls.Add(frmPO);
            //frmPO.BringToFront();
            //frmPO.Show();
        }


        private void btnvideolink_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=8v7vJobGWco");
        }
        public void GSTCollection()
        {
            
            try {
                sql = "Select sum(PaidAmount) from tbl_Billing1 Where  CompanyID='"+ClassConn.CompanyID+"'";
                cnt = objcls.executescalar(sql);
                lblGstCollection.Text = Convert.ToString(cnt);
            }
            catch
            {

            }


        }
        public void todaysCollection()
        {

            try
            {
                sql = "Select count(PaidAmount) from tbl_Billing1 Where CompanyID='" + ClassConn.CompanyID + "'";
                cnt = objcls.executescalar(sql);
                lblTodaysCollection.Text = Convert.ToString(cnt);
            }
            catch { }
               
            
          }
        public void todaysOrder()
        {
            try
            {
                sql = "Select count(CustomerName) from tbl_Order Where CompanyID='" + ClassConn.CompanyID + "'";
                cnt = objcls.executescalar(sql);
                lblTodaysOrders.Text = Convert.ToString(cnt);
            }
            catch
            {

            }
        }
        public void BalanceAmt()
        {
            try
            {
                sql = "Select sum(BalanceAmount) from tbl_Billing1 Where CompanyID='" + ClassConn.CompanyID + "'";
                cnt = objcls.executescalar(sql);
                lblBalanceAmt.Text = Convert.ToString(cnt);
            }
            catch
            {

            }
        }
        public void PendingOrder()
        {
            sql = "Select count(CustomerName) from tbl_Billing1 Where CompanyID='" + ClassConn.CompanyID + "'";
            cnt = objcls.executescalar(sql);
            lblPendingOrder.Text = Convert.ToString(cnt);
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnlogin_Click_1(object sender, EventArgs e)
        {
            FrmLogout frmLG = new FrmLogout();
            frmLG.Show();
            //FrmNewDashboard frmND = new FrmNewDashboard();
            //this.Hide();
           

        }

        private void picPaymentHistory_Click(object sender, EventArgs e)
        {
            Paymenthistory frmPH = new Paymenthistory();
            frmPH.TopLevel = false;
            pnldash.Controls.Add(frmPH);
            frmPH.BringToFront();
            frmPH.Show();
        }

        private void lblBalanceAmt_Click(object sender, EventArgs e)
        {
            //BalanceAmt();
        }

        private void lblTodaysCollection_Click(object sender, EventArgs e)
        {

        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            GSTCollection();
            todaysCollection();
            todaysOrder();
            PendingOrder();
            BalanceAmt();
           
        }

        private void lblGstCollection_Click(object sender, EventArgs e)
        {

        }
    }
}

    
