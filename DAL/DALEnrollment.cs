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

        public static Transcript GetScheduleList(string id, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            Transcript trans = new Transcript();

            try
            {
                //fill student info
                //trans.student = DALStudent.GetStudentDetail(id, errors);
                //List<Student> t = DAL.DALStudent.GetStudentList(errors);
                //DALStudent.GetStudentDetail(id, errors);
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
    }
}
