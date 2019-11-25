using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Module5A.DAL
{
    class DataDAL
    {
        DataTable dt = new DataTable();
        public DataTable GetDataInfo(string query)
        {
            Connection conn = new Connection();
            if (conn.con.State == ConnectionState.Closed)
            {
                conn.con.Open();
            }
            SqlCommand cmd = new SqlCommand(query, conn.con);
            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
                dt.Load(rd);
                return dt;
            }
            catch
            {
                throw;
            }
        }

        public List<string> GetListDataString(string query)
        {
            List<string> ans = new List<string>();
            Connection conn = new Connection();
            if (conn.con.State == ConnectionState.Closed)
            {
                conn.con.Open();
            }
            SqlCommand cmd = new SqlCommand(query, conn.con);
            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    ans.Add(rd.GetInt32(0).ToString());
                }
                return ans;
            }
            catch
            {
                throw;
            }
        }

        public void ExecuteQuery(string query)
        {
            Connection conn = new Connection();
            if (conn.con.State == ConnectionState.Closed)
            {
                conn.con.Open();
            }
            SqlCommand cmd = new SqlCommand(query, conn.con);
            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
            }
            catch
            {
                throw;
            }
        }
    }
}
