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
    public static class DALScheduleTime
    {
        static string connection_string = ConfigurationManager.AppSettings["dsn"];

        public static void InsertScheduleTime(string time, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                string strSQL = "spInsertScheduleTimeInfo";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@schedule_time", SqlDbType.VarChar, 50));

                mySA.SelectCommand.Parameters["@schedule_time"].Value = time;

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


        public static Dictionary<string, string> GetScheduleTimeList(ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            Dictionary<string, string> time = new Dictionary<string, string>();

            try
            {
                string strSQL = "spGetScheduleTimeList";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

                if (myDS.Tables[0].Rows.Count == 0)
                    return null;

                for (int i = 0; i < myDS.Tables[0].Rows.Count; i++)
                {
                    time.Add(myDS.Tables[0].Rows[i]["schedule_time_id"].ToString(), myDS.Tables[0].Rows[i]["schedule_time"].ToString());
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

            return time;
        }

        public static void DeleteScheduleTime(string time, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                string strSQL = "spDeleteScheduleTimeInfo";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@schedule_time", SqlDbType.VarChar, 50));

                mySA.SelectCommand.Parameters["@schedule_time"].Value = time;

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
