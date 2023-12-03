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
    public partial class FrmChartGraph : Form
    {
        public FrmChartGraph()
        {
            InitializeComponent();
        }
        ClassConn objcls = new ClassConn();
        DataSet ds = new DataSet();
        string sql;
        int cnt;

        private void FrmChartGraph_Load(object sender, EventArgs e)
        {
           
            fillgraph();
            // AllCalculation();
            dgvChartGraph.Columns[0].Width = 150;
            dgvChartGraph.Columns[1].Width = 150;
            dgvChartGraph.Columns[2].Width = 150;
            dgvChartGraph.Columns[3].Width = 150;

        }

        public void fillgraph()
        {
            sql = "Select CustomerName,GrandTotal,PaidAmount,BalanceAmount from tbl_Billing1 Where CompanyID='"+ClassConn.CompanyID+"'";
            ds = objcls.fillds(sql);
            //dgvChartGraph.Rows.Clear();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dgvChartGraph.Rows.Add();
                dgvChartGraph.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                dgvChartGraph.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                dgvChartGraph.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                dgvChartGraph.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i].ItemArray[3].ToString();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            chartReport1.Series[0].XValueMember = "CustomerName";
            chartReport1.Series[0].YValueMembers = "CustomerName";

            chartReport1.Series[1].XValueMember = "GrandTotal";
            chartReport1.Series[1].YValueMembers = "GrandTotal";

            chartReport1.Series[2].XValueMember = "PaidAmount";
            chartReport1.Series[2].YValueMembers = "PaidAmount";

            chartReport1.Series[3].XValueMember = "BalanceAmount";
            chartReport1.Series[3].YValueMembers = "BalanceAmount";

            sql = "Select CustomerName,GrandTotal,PaidAmount,BalanceAmount from tbl_Billing1 Where CompanyID='"+ClassConn.CompanyID+"'";
            ds = objcls.fillds(sql);
            chartReport1.DataSource = ds.Tables[0];
            chartReport1.DataBind();
        }
        public void AllCalculation()
        {
            string GSTColl = "";
            string TodaysColl = "";
            string PendingOrd = "";
            string TodaysOrd = "";
            string BalanceAmt = "";

            //Cal GSTColl
             {
                //DateTime DTP;
                //DTP = Convert.ToDateTime(string.Format("{0:MM/dd/yyyy }"));
                sql = "Select sum(PaidAmount) from tbl_Billing1 Where CompanyID='"+ClassConn.CompanyID+"'";
                GSTColl = Convert.ToString(objcls.executescalar(sql));
            }
           

            //Cal TodaysColl
           
            {
                //DateTime DTP;
                //DTP = Convert.ToDateTime(string.Format("{0:MM/dd/yyyy }"));
                sql = "Select sum(PaidAmount) from tbl_Billing1 where Date='"+DateTime.Now+"'";
                TodaysColl = Convert.ToString(objcls.executescalar(sql));
            }

      

            //Cal PendingOrd
          
            {
                //DateTime DTP;
                //DTP = Convert.ToDateTime(string.Format("{0:MM/dd/yyyy }"));
                sql = "Select sum(CustomerName) from tbl_Order Where CompanyID='"+ClassConn.CompanyID+"'";
                PendingOrd = Convert.ToString(objcls.executescalar(sql));
            }
 

            //Cal TodaysOrd
     
            {
                //DateTime DTP;
                //DTP = Convert.ToDateTime(string.Format("{0:MM/dd/yyyy }"));
                sql = "Select sum(BalanceAmount) from tbl_Billing1 where CompanyID='"+ClassConn.CompanyID+"'";
                TodaysOrd = Convert.ToString(objcls.executescalar(sql));
            }
    

            //Cal BalenceAmt


            {
                //DateTime DTP;
                //DTP = Convert.ToDateTime(string.Format("{0:MM/dd/yyyy }"));
                sql = "Select sum(BalanceAmount) from tbl_Billing1 Where CompanyID='"+ClassConn.CompanyID+"' ";
                BalanceAmt = Convert.ToString(objcls.executescalar(sql));
            }

      

            sql = "Insert into tbl_Gharph(GSTCollection,TodaysCollection,PendingOrders,TodaysOrders,BalanceAmount,CompanyID)values('" + GSTColl+"','"+TodaysColl+"','"+PendingOrd+"','"+TodaysOrd+"','"+BalanceAmount+"','"+ClassConn.CompanyID+"') ";
            objcls.execute(sql);
            fillgraph();
  
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
