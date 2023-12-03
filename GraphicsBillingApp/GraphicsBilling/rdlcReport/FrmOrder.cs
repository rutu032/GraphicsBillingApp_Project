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
    public partial class FrmOrder : Form
    {
        public FrmOrder()
        {
            InitializeComponent();
        }
        ClassConn objcls = new ClassConn();
        DataSet ds = new DataSet();
        string sql = "";
            
        private void FrmOrder_Load(object sender, EventArgs e)
        {
            Order();
            //this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
           
        }
        public void Order()
        {
            sql = "Select ID,CustomerName,City,GSTNo,Quantity,Rate,Total from tbl_Order ";
            ds = objcls.fillds(sql);
            ds.DataSetName = ("DataTableOrder"); 
             ReportDataSource datasource = new ReportDataSource("DSOrder", ds.Tables[0]);

            this.reportViewer2.LocalReport.DataSources.Clear();
            this.reportViewer2.LocalReport.DataSources.Add(datasource);
            this.reportViewer2.RefreshReport();
        }
    }
}
