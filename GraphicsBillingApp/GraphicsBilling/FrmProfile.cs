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
    public partial class FrmProfile : Form
    {
        public FrmProfile()
        {
            InitializeComponent();
        }
        ClassConn objcls = new ClassConn();
        DataSet ds = new DataSet();
        string sql;
        int cnt;



        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            //Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 70, 70));
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

            //Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 70, 70));
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            //Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 70, 70));
        }

        private void lblCompanyName_Click(object sender, EventArgs e)
        {


        }
        public void fillProfile()
        {
            sql = "Select CustomerName,CompanyName,MobileNo,EmailID,Date from tbl_Registration1";
            ds = objcls.fillds(sql);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                lblComapanyName.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                lblCustomerName.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                lblMobNo.Text = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                lblEmailID.Text = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                lbldate.Text = ds.Tables[0].Rows[i].ItemArray[4].ToString();
                
            }
        }
        public void fillCustomerName()
        {
            //sql = "Select CustomerName from tbl_Registration";
            //ds = objcls.fillds(sql);
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    lblCustomerName.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            }

        private void FrmProfile_Load(object sender, EventArgs e)
        {
            fillProfile();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }




        
        }
    



