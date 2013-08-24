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
        public static Transcript GetEnrollment(string id, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            Transcript trans = new Transcript();

            try
            {
                //fill student info
                trans.student = DALStudent.GetStudentDetail(id, ref errors);
                string strSQL = "spGetEnrollmentList";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);

                mySA.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));
                mySA.SelectCommand.Parameters["@student_id"].Value = id;
                

                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

                if (myDS.Tables[0].Rows.Count == 0)
                    return null;

                for (int i = 0; i < myDS.Tables[0].Rows.Count; i++)
                {
                    Grade gr = new Grade();
                    gr.year = Convert.ToInt32(myDS.Tables[0].Rows[i]["year"].ToString());
                    gr.quarter = myDS.Tables[0].Rows[i]["quarter"].ToString();
                    gr.course =
                      new Course
                      {
                          id = myDS.Tables[0].Rows[i]["course_id"].ToString(),
                          title = myDS.Tables[0].Rows[i]["course_title"].ToString(),
                          description = myDS.Tables[0].Rows[i]["course_description"].ToString(),
                      };
                    trans.grade.Add(gr);
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

            return trans;
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
