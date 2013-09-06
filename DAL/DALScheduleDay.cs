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
    public static class DALScheduleDay
    {
        static string connection_string = ConfigurationManager.AppSettings["dsn"];

        public static void InsertScheduleDay(string day, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                string strSQL = "spInsertScheduleDayInfo";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@schedule_day", SqlDbType.VarChar, 50));

                mySA.SelectCommand.Parameters["@schedule_day"].Value = day;

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


        public static Dictionary<string, string> GetScheduleDayList(ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            Dictionary<string, string> day = new Dictionary<string, string>();

            try
            {
                string strSQL = "spGetScheduleDayList";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

                if (myDS.Tables[0].Rows.Count == 0)
                    return null;

                for (int i = 0; i < myDS.Tables[0].Rows.Count; i++)
                {
                    day.Add(myDS.Tables[0].Rows[i]["schedule_day_id"].ToString(), myDS.Tables[0].Rows[i]["schedule_day"].ToString());
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

            return day;
        }

        public static void DeleteScheduleDay(int id, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                string strSQL = "spDeleteScheduleDayInfo";

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
