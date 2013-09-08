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
        public static List<Enrollment> GetEnrollment(ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            List<Enrollment> grade = null;
            try
            {
                string strSQL = "spGetEnrollmentList";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);

                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

                System.Diagnostics.Debug.WriteLine(myDS.Tables[0].Rows.Count);

                if (myDS.Tables[0].Rows.Count == 0)
                    return null;
                grade = new List<Enrollment>();
               


                for (int i = 0; i < myDS.Tables[0].Rows.Count; i++)
                {
                    Enrollment gr = new Enrollment();
                    ScheduledCourse sc = new ScheduledCourse();
                    sc.id = Convert.ToInt32(myDS.Tables[0].Rows[i]["schedule_id"].ToString());
                    sc.year = Convert.ToInt32(myDS.Tables[0].Rows[i]["year"].ToString());
                    sc.quarter = myDS.Tables[0].Rows[i]["quarter"].ToString();
                    sc.day = myDS.Tables[0].Rows[i]["schedule_day"].ToString();
                    sc.time = myDS.Tables[0].Rows[i]["schedule_time"].ToString();
                    sc.instructor_fName = myDS.Tables[0].Rows[i]["first_name"].ToString();
                    sc.instructor_lName = myDS.Tables[0].Rows[i]["last_name"].ToString();
                    System.Diagnostics.Debug.WriteLine("x");
                    sc.session = myDS.Tables[0].Rows[i]["session"].ToString();
                    sc.instr_id = Convert.ToInt32(myDS.Tables[0].Rows[i]["staff_id"].ToString());
                    sc.timeID = Convert.ToInt32(myDS.Tables[0].Rows[i]["schedule_time_id"].ToString());
                    sc.dayID = Convert.ToInt32(myDS.Tables[0].Rows[i]["schedule_day_id"].ToString());
                    gr.grade = myDS.Tables[0].Rows[i]["grade"].ToString();

                    sc.course =
                      new Course
                      {
                        id = Convert.ToInt32(myDS.Tables[0].Rows[i]["course_id"]),
                        title = myDS.Tables[0].Rows[i]["course_title"].ToString(),
                        level = myDS.Tables[0].Rows[i]["course_level"].ToString(),
                        description = myDS.Tables[0].Rows[i]["course_description"].ToString(),
                        units = Convert.ToInt32(myDS.Tables[0].Rows[i]["units"])
                      };
                    gr.ScheduledCourse = sc;
                    gr.student_id = myDS.Tables[0].Rows[i]["student_id"].ToString();
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
