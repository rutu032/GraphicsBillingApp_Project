using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsBilling.rdlcReport
{
    public partial class FrmPaymentHistory : Form
    {
        public FrmPaymentHistory()
        {
            InitializeComponent();
        }
        ClassConn objcls = new ClassConn();
        DataSet ds = new DataSet();
        string sql;

        private void FrmPaymentHistory_Load(object sender, EventArgs e)
        {
           
            this.reportViewer1.RefreshReport();
            // this.reportViewer2.RefreshReport();
            CusomtomersBill();
        }

        public void CusomtomersBill()
        {
            sql = "Select CustomerName,City,Quantity,Rate,TotalAmount,CGST,SGST,IGST,GrandTotal,PaidAmount,Date,GSTNo,BalanceAmount,ItemName,ItemSize,CompanyID from tbl_Billing1 ";
            ds = objcls.fillds(sql);
            ds.DataSetName = ("DataTableCustomerBIll");
            ReportDataSource datasource = new ReportDataSource("DSCustomerBilling", ds.Tables[0]);

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);
            this.reportViewer1.RefreshReport();
        }
    }
}
