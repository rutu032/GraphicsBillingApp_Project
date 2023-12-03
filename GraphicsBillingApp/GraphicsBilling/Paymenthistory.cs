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
    public partial class Paymenthistory : Form
    {
        public Paymenthistory()
        {
            InitializeComponent();
        }
        ClassConn objcls = new ClassConn();
        DataSet ds = new DataSet();
        string sql = "";

        private void Paymenthistory_Load(object sender, EventArgs e)
        {

            filldt();
            dgvPaymentHistory.Columns[0].Visible = false;
            dgvPaymentHistory.Columns[2].Visible = false;
            dgvPaymentHistory.Columns[3].Visible = false;
            dgvPaymentHistory.Columns[4].Visible = false;
            dgvPaymentHistory.Columns[5].Visible = false;
            dgvPaymentHistory.Columns[6].Visible = false;
            dgvPaymentHistory.Columns[7].Visible = false;
            dgvPaymentHistory.Columns[8].Visible = false;
            dgvPaymentHistory.Columns[11].Visible = false;
            dgvPaymentHistory.Columns[12].Visible = false;
            dgvPaymentHistory.Columns[14].Visible = false;
            dgvPaymentHistory.Columns[15].Visible = false;
            dgvPaymentHistory.Columns[16].Visible = false;



        }
        public void filldt()
        {
            sql = "Select * from tbl_Billing1 Where CompanyID='"+ClassConn.CompanyID+"'";
            ds = objcls.fillds(sql);
            dgvPaymentHistory.DataSource = ds.Tables[0];
            dgvPaymentHistory.Columns[1].Width = 150;
            dgvPaymentHistory.Columns[9].Width = 150;
            dgvPaymentHistory.Columns[10].Width = 150;
            dgvPaymentHistory.Columns[13].Width = 150;

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnprint_Click(object sender, EventArgs e)
        {

           // btnprint.Enabled = false;
            rdlcReport.FrmPaymentHistory RDLCPA = new rdlcReport.FrmPaymentHistory();
            //RDLCPA.TopLevel = false;
            //pnlpaymenthistory.Controls.Add(RDLCPA);
            //RDLCPA.BringToFront();
            RDLCPA.Show();
           // btnprint.Enabled = true;

        }

        private void btnexcel_Click(object sender, EventArgs e)
        {

            if (dgvPaymentHistory.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
                XcelApp.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dgvPaymentHistory.Columns.Count + 1; i++)
                {
                    XcelApp.Cells[1, i] = dgvPaymentHistory.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dgvPaymentHistory.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvPaymentHistory.Columns.Count; j++)
                    {
                        XcelApp.Cells[i + 2, j + 1] = dgvPaymentHistory.Rows[i].Cells[j].Value.ToString();
                    }
                }
                XcelApp.Columns.AutoFit();
                XcelApp.Visible = true;
            }

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
  


