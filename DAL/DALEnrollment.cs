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
    public static class DALEnrollment
    {
        static string connection_string = ConfigurationManager.AppSettings["dsn"];

        //Done By student
        public static List<Grade> GetEnrollment(string id, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            List<Grade> grade = null;
            try
            {
                string strSQL = "spGetEnrollmentList";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);

                mySA.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));
                mySA.SelectCommand.Parameters["@student_id"].Value = id;
                

                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

                if (myDS.Tables[0].Rows.Count == 0)
                    return null;
                grade = new List<Grade>();

                for (int i = 0; i < myDS.Tables[0].Rows.Count; i++)
                {
                    Grade gr = new Grade();
                    gr.year = Convert.ToInt32(myDS.Tables[0].Rows[i]["year"].ToString());
                    gr.quarter = myDS.Tables[0].Rows[i]["quarter"].ToString();
                    gr.grade = myDS.Tables[0].Rows[i]["grade"].ToString();
                    gr.course =
                      new Course
                      {
                        id = Convert.ToInt32(myDS.Tables[0].Rows[i]["course_id"]),
                        title = myDS.Tables[0].Rows[i]["course_title"].ToString(),
                        level = (CourseLevel)Enum.Parse(typeof(CourseLevel), myDS.Tables[0].Rows[i]["course_level"].ToString()),
                        description = myDS.Tables[0].Rows[i]["course_description"].ToString(),
                        units = Convert.ToInt32(myDS.Tables[0].Rows[i]["units"])
                      };
                    grade.Add(gr);
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

            return grade;
        }

        //Done by student
        public static void InsertEnrollment(string student_id, int schedule_id, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);

            string strSQL = "spInsertStudentSchedule";

            try
            {
                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));

                mySA.SelectCommand.Parameters["@student_id"].Value = student_id;
                mySA.SelectCommand.Parameters["@schedule_id"].Value = schedule_id;

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

        //Done by student
        public static void DeleteEnrollment(string student_id, int schedule_id, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);

            string strSQL = "spDeleteStudentSchedule";

            try
            {
                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));

                mySA.SelectCommand.Parameters["@student_id"].Value = student_id;
                mySA.SelectCommand.Parameters["@schedule_id"].Value = schedule_id;

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

        public static void UpdateEnrollment(string student_id, int schedule_id, string grade, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);

            string strSQL = "spUpdateEnrollmentInfo";

            try
            {
                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@grade", SqlDbType.VarChar, 10));

                mySA.SelectCommand.Parameters["@student_id"].Value = student_id;
                mySA.SelectCommand.Parameters["@schedule_id"].Value = schedule_id;
                mySA.SelectCommand.Parameters["@grade"].Value = grade;

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
