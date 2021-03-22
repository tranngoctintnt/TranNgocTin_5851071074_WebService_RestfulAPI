using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TranNgocTin_5851071074.Models
{
    public class db
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-JHRGK5N\SQLEXPRESS;Initial Catalog=webCrud;Integrated Security=True");


        //select
        public DataSet emGet(Employee emp, out string msg)
        {
            DataSet ds = new DataSet();
            msg = "";
            try
            {
                SqlCommand cmd = new SqlCommand("sp_employee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@sr_no", emp.sr_no);
                cmd.Parameters.AddWithValue("@emp_name", emp.emp_name);
                cmd.Parameters.AddWithValue("@city", emp.city);
                cmd.Parameters.AddWithValue("@state", emp.state);
                cmd.Parameters.AddWithValue("@country", emp.country);
                cmd.Parameters.AddWithValue("@department", emp.department);
                cmd.Parameters.AddWithValue("@flag", emp.flag);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "OK";
                return ds;
                //con.Open();
                //cmd.ExecuteNonQuery();
                //con.Close();
                //msg = "OK";
                //return msg;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return ds;
                //if(con.State == ConnectionState.Open)
                //{
                //    con.Close();

                //}
                //msg = ex.Message;
                //return msg;
            }
        }

        // insert and update
        public string empIU(Employee emp, out string msg)
        {
            
            msg = "";
            try
            {
                SqlCommand cmd = new SqlCommand("sp_employee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@sr_no", emp.sr_no);
                cmd.Parameters.AddWithValue("@emp_name", emp.emp_name);
                cmd.Parameters.AddWithValue("@city", emp.city);
                cmd.Parameters.AddWithValue("@state", emp.state);
                cmd.Parameters.AddWithValue("@country", emp.country);
                cmd.Parameters.AddWithValue("@department", emp.department);
                cmd.Parameters.AddWithValue("@flag", emp.flag);

                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //da.Fill(ds);
                //msg = "OK";
                //return ds;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                msg = "OK";
                return msg;
            }
            catch (Exception ex)
            {
                //msg = ex.Message;
                //return ds;
                if (con.State == ConnectionState.Open)
                {
                    con.Close();

                }
                msg = ex.Message;
                return msg;
            }
        }

    }
}
