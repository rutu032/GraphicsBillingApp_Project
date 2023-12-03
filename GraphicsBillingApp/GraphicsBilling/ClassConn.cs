using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsBilling
{
    class ClassConn
    {
        public static string CompanyID = "";

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-71NQN0O\\SQLEXPRESS;Initial Catalog=GraphicsBillingApp;Integrated Security=true;");
        SqlCommand cmd = new SqlCommand();
        DataSet ds;
        SqlDataAdapter adp = new SqlDataAdapter();
        int cnt;

        //for insert update delete
        public void execute(string sql)
        {
            cmd = new SqlCommand(sql, con);
            if (con.State == ConnectionState.Closed) ;
            {
                con.Open();
            }
            cmd.ExecuteNonQuery();
            con.Close();
        }


        //for record fill
        public DataSet fillds(string sql)
        {
            ds = new DataSet();
            adp = new SqlDataAdapter(sql, con);
            if (con.State == ConnectionState.Closed)
            {
                con.Close();
            }
            adp.Fill(ds);
            con.Close();
            return ds;
        }

        // for count 
        public int executescalar(String sql)
        {
            cmd = new SqlCommand(sql, con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }


            cnt = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return cnt;
        }

    }
}
    

