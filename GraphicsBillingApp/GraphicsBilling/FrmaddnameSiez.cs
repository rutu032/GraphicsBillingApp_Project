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
    public partial class FrmaddnameSiez : Form
    {
        public FrmaddnameSiez()
        {
            InitializeComponent();
        }
        ClassConn objcls = new ClassConn();
        DataSet ds = new DataSet();
        string sql = "";
        int cnt;
        private int from;

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ItemName()
        {
            sql = "Select ItemName from tbl_Billing1 Where ID='" + txtID.Text + "' and CompanyID='" + ClassConn.CompanyID + "'";
            cnt = objcls.executescalar(sql);
           
        } 

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        public void filldt()
        {
            sql = "Select * from tbl_itemnameandsize Where CompanyID='"+ClassConn.CompanyID+"'";
            ds = objcls.fillds(sql);
            dgvitemnamendsize.DataSource = ds.Tables[0];
            

        }

        private void FrmaddnameSiez_Load(object sender, EventArgs e)
        {
            btnadditemsize.Enabled = true;
            btnupdate.Enabled = false;
            btndelete.Enabled = false;
            filldt();
            dgvitemnamendsize.Columns[0].Visible = false;
            dgvitemnamendsize.Columns[4].Visible = false;
        
            dgvitemnamendsize.Columns[1].Width = 130;
            dgvitemnamendsize.Columns[2].Width = 130;
            dgvitemnamendsize.Columns[3].Width = 130;


        }

        private void btnadditemsize_Click(object sender, EventArgs e)
        {
            if (txtItemName.Text == "")
            {
                MessageBox.Show("Please Enter ItemName");
                return;
            }
            if (txtItemSize.Text == "")
            {
                MessageBox.Show("Please Enter ItemSize");
                return;
            }
            if (txtGST.Text == "")
            {
                MessageBox.Show("Please Enter GST");
                return;
            }
            sql = "Select count (*) from tbl_itemnameandsize Where ItemName='" + txtItemName.Text + "'and  ItemSize='"+txtItemSize.Text+"'  ";
            int cnt = objcls.executescalar(sql);
            if (cnt != 0)
            {
                MessageBox.Show(" Item Name and Item Size are Already Available ... ");
                return;
            }

            sql = "Insert into tbl_itemnameandsize(ItemName,ItemSize,GST,CompanyID)values('" + txtItemName.Text + "','" + txtItemSize.Text + "','" + txtGST.Text + "','"+ClassConn.CompanyID+"') ";
            objcls.execute(sql);
            MessageBox.Show("Add Successfully");
            filldt();
           // btnadditemsize.Enabled = true;
            Clear();
        }

        private void dgvitemnamendsize_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnadditemsize.Enabled = false;
            btnupdate.Enabled = true;
            btndelete.Enabled = true;
            

            txtID.Text = dgvitemnamendsize.SelectedCells[0].Value.ToString();
            txtItemName.Text = dgvitemnamendsize.SelectedCells[1].Value.ToString();
            txtItemSize.Text = dgvitemnamendsize.SelectedCells[2].Value.ToString();
            txtGST.Text = dgvitemnamendsize.SelectedCells[3].Value.ToString();
        }
        private void FrmaddnameSiez_Shown(object sender, EventArgs e)
        {
            txtItemName.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            txtItemName.ResetText();
            txtItemSize.ResetText();
            txtGST.ResetText();
            btnadditemsize.Enabled = true;
        }

        private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtItemSize.Focus();
            }
        }

        private void txtItemSize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtGST.Focus();
            }
        }

        private void txtGST_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnadditemsize.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            sql = "Update tbl_itemnameandsize SET ItemName='"+txtItemName.Text+ "', ItemSize='"+txtItemSize.Text+ "',GST='"+txtGST.Text+ "'Where CompanyID='" +ClassConn.CompanyID+ "'";
            objcls.execute(sql);
            MessageBox.Show("Updated Successfully");
            filldt();
            Clear();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            sql = "Delete from tbl_itemnameandsize Where CompanyID='" + ClassConn.CompanyID + "'";
            objcls.execute(sql);
            MessageBox.Show("Delete Successfully...");
            filldt();
            Clear();

        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
