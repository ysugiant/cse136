﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POCO;  // must add this...
using System.Configuration; // must add this... make sure to add "System.Configuration" first
using System.Data.SqlClient; // must add this...
using System.Data; // must add this...

namespace DAL
{
    public static class DALMajor
    {
        static string connection_string = ConfigurationManager.AppSettings["dsn"];

        public static void InsertMajor(Major major, ref List<string> errors, out int ID)
        {
            ID = -1;
            SqlConnection conn = new SqlConnection(connection_string);

            try
            {
                string strSQL = "spInsertMajorInfo";
                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

                mySA.SelectCommand.Parameters.Add(new SqlParameter("@major_name", SqlDbType.VarChar, 50));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@dept_id", SqlDbType.Int));

                mySA.SelectCommand.Parameters["@major_name"].Value = major.majorName;
                mySA.SelectCommand.Parameters["@dept_id"].Value = major.deptId;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);
                ID = Convert.ToInt32(myDS.Tables[0].Rows[0]["autoIncID"].ToString());
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e.ToString());
                System.Diagnostics.Debug.WriteLine(e);
            }
            finally
            {
                conn.Dispose();
                conn = null;
            }
        }

        public static void UpdateMajor(Major major, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                string strSQL = "spUpdateMajorInfo";
                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

                mySA.SelectCommand.Parameters.Add(new SqlParameter("@major_id", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@major_name", SqlDbType.VarChar, 50));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@dept_id", SqlDbType.Int));

                mySA.SelectCommand.Parameters["@major_id"].Value = major.id;
                mySA.SelectCommand.Parameters["@major_name"].Value = major.majorName;
                mySA.SelectCommand.Parameters["@dept_id"].Value = major.deptId;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e.ToString());
                System.Diagnostics.Debug.WriteLine("Error retrieving Update major data..." + e);

            }
            finally
            {
                conn.Dispose();
                conn = null;
            }
        }

        public static void DeleteMajor(int id, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);

            try
            {
                string strSQL = "spDeleteMajorInfo";
                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

                mySA.SelectCommand.Parameters.Add(new SqlParameter("@major_id", SqlDbType.Int));

                mySA.SelectCommand.Parameters["@major_id"].Value = id;

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

        public static Major GetMajorDetail(int id, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            Major major = new Major();

            try
            {
                string strSQL = "spGetMajorInfo";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@major_id", SqlDbType.Int));

                mySA.SelectCommand.Parameters["@major_id"].Value = id;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

                if (myDS.Tables[0].Rows.Count == 0)
                    return null;

                major.id = Convert.ToInt32(myDS.Tables[0].Rows[0]["major_id"].ToString());
                major.majorName = myDS.Tables[0].Rows[0]["major_name"].ToString();
                major.deptId = Convert.ToInt32(myDS.Tables[0].Rows[0]["dept_id"]);
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e.ToString());
                System.Diagnostics.Debug.WriteLine("Error retrieving major data..." + e);
            }
            finally
            {
                conn.Dispose();
                conn = null;
            }

            return major;
        }

        public static List<Major> GetMajorList(ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            //string major = null;
            //string dept = null;
            Major major = null;
            List<Major> majorList = null;

            try 
            {
                string strSQL = "spGetMajorList";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

                if (myDS.Tables[0].Rows.Count == 0)
                    return null;

                majorList = new List<Major>();
                for (int i = 0; i < myDS.Tables[0].Rows.Count; i++)
                {
                    major = new Major();
                    major.id = Convert.ToInt32(myDS.Tables[0].Rows[i]["major_id"].ToString()); 
                    major.majorName = myDS.Tables[0].Rows[i]["major_name"].ToString();
                    major.deptId = Convert.ToInt32(myDS.Tables[0].Rows[i]["dept_id"].ToString());
                    majorList.Add(major);
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

            return majorList;
        }
    }
}
