using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POCO;  // must add this...
using System.Configuration; // must add this... make sure to add "System.Configuration" first
using System.Data.SqlClient; // must add this...
using System.Data; // must add this...


namespace DAL
{
    public static class DALDepartment
    {
        static string connection_string = ConfigurationManager.AppSettings["dsn"];

        public static void InsertDepartment(Department dept, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                string strSQL = "spInsertDepartmentInfo";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@dept_name", SqlDbType.VarChar, 50));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@chair_id", SqlDbType.Int));

                mySA.SelectCommand.Parameters["@dept_name"].Value = dept.deptName;
                mySA.SelectCommand.Parameters["@chair_id"].Value = dept.chairID;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

            }
            catch (Exception e)
            {
                errors.Add("Error: " + e.ToString());
            }
            finally
            {
                conn.Dispose();
                conn = null;
            }
        }

        public static void UpdateDepartment(Department dept, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                string strSQL = "spUpdateDepartmentInfo";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@dept_id", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@dept_name", SqlDbType.VarChar, 50));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@chair_id", SqlDbType.Int));

                mySA.SelectCommand.Parameters["@dept_id"].Value = dept.id;
                mySA.SelectCommand.Parameters["@dept_name"].Value = dept.deptName;
                mySA.SelectCommand.Parameters["@chair_id"].Value = dept.chairID;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

            }
            catch (Exception e)
            {
                errors.Add("Error: " + e.ToString());
            }
            finally
            {
                conn.Dispose();
                conn = null;
            }
        }

        public static Department GetDepartmentDetail(string name, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            Department dept = null;

            try
            {
                string strSQL = "spGetDepartmentInfo";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@dept_name", SqlDbType.VarChar, 50));

                mySA.SelectCommand.Parameters["@dept_name"].Value = name;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

                if (myDS.Tables[0].Rows.Count == 0)
                    return null;

                dept = new Department();
                dept.id = Convert.ToInt32(myDS.Tables[0].Rows[0]["dept_id"].ToString());
                dept.deptName = myDS.Tables[0].Rows[0]["dept_name"].ToString();
                dept.chairID = Convert.ToInt32(myDS.Tables[0].Rows[0]["chair_id"].ToString());

            }
            catch (Exception e)
            {
                errors.Add("Error: " + e.ToString());
            }
            finally
            {
                conn.Dispose();
                conn = null;
            }

            return dept;
        }

        public static List<Department> GetDepartmentList(ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            List<Department> deptList = new List<Department>();

            try
            {
                string strSQL = "spGetDepartmentInfo";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

                if (myDS.Tables[0].Rows.Count == 0)
                    return null;

                for (int i = 0; i < myDS.Tables[0].Rows.Count; i++)
                {
                    Department dept = new Department();
                    dept.id = Convert.ToInt32(myDS.Tables[0].Rows[0]["dept_id"].ToString());
                    dept.deptName = myDS.Tables[0].Rows[0]["dept_name"].ToString();
                    dept.chairID = Convert.ToInt32(myDS.Tables[0].Rows[0]["chair_id"].ToString());
                    deptList.Add(dept);
                }
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e.ToString());
            }
            finally
            {
                conn.Dispose();
                conn = null;
            }

            return deptList;
        }

        public static void DeleteDepartment(int id, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                string strSQL = "spDeleteDepartmentInfo";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                
                mySA.SelectCommand.Parameters["@id"].Value = id;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

            }
            catch (Exception e)
            {
                errors.Add("Error: " + e.ToString());
            }
            finally
            {
                conn.Dispose();
                conn = null;
            }
        }
    }
}
