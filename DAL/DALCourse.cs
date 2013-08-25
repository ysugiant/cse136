using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POCO;  // must add this...
using System.Configuration; // must add this... make sure to add "System.Configuration" first
using System.Data.SqlClient; // must add this...
using System.Data; // must add this...


namespace DAL
{
    public class DALCourse
    {
        static string connection_string = ConfigurationManager.AppSettings["dsn"];
        public static List<Course> GetCourseList(ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            List<Course> courseList = new List<Course>();

            try
            {
                string strSQL = "spGetCourseList";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);

                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

                if (myDS.Tables[0].Rows.Count == 0)
                    return null;

                for (int i = 0; i < myDS.Tables[0].Rows.Count; i++)
                {
                    Course course = new Course();
                    course.id = Convert.ToInt32(myDS.Tables[0].Rows[i]["course_id"]);
                    course.title = myDS.Tables[0].Rows[i]["course_title"].ToString();
                    course.level = (CourseLevel)Enum.Parse(typeof(CourseLevel), myDS.Tables[0].Rows[i]["course_level"].ToString());
                    course.description = myDS.Tables[0].Rows[i]["course_description"].ToString();
                    course.units = Convert.ToInt32(myDS.Tables[0].Rows[i]["units"]);
                    courseList.Add(course);
                }
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e.ToString());
                System.Diagnostics.Debug.WriteLine("GetCourseList error \n " + e.ToString());
            }
            finally
            {
                conn.Dispose();
                conn = null;
            }

            return courseList;

        }

        public static void InsertCourse(Course course, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                string strSQL = "spInsertCourseInfo";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

                // the course_id should be auto increase
                // mySA.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@course_title", SqlDbType.VarChar, 100));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@course_level", SqlDbType.VarChar, 10));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@course_description", SqlDbType.VarChar, -1));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@units", SqlDbType.Int));

                // the course_id should be auto increase
                //mySA.SelectCommand.Parameters["@course_id"].Value = course.id;
                mySA.SelectCommand.Parameters["@course_title"].Value = course.title;
                mySA.SelectCommand.Parameters["@course_level"].Value = course.level;
                mySA.SelectCommand.Parameters["@course_description"].Value = course.description;
                mySA.SelectCommand.Parameters["@units"].Value = course.units;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

            }
            catch (Exception e)
            {
                errors.Add("Error: " + e.ToString());
                System.Diagnostics.Debug.WriteLine("Insertcourseinfo error\n" + e.ToString());
            }
            finally
            {
                conn.Dispose();
                conn = null;
            }

        }
        public static void UpdateCourse(Course course, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                string strSQL = "spUpdateCourseInfo";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

                // the course_id should be auto increase
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@course_title", SqlDbType.VarChar, 100));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@course_level", SqlDbType.VarChar, 10));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@course_description", SqlDbType.VarChar, -1));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@units", SqlDbType.Int));

                // the course_id should be auto increase
                mySA.SelectCommand.Parameters["@course_id"].Value = course.id;
                mySA.SelectCommand.Parameters["@course_title"].Value = course.title;
                mySA.SelectCommand.Parameters["@course_level"].Value = course.level;
                mySA.SelectCommand.Parameters["@course_description"].Value = course.description;
                mySA.SelectCommand.Parameters["@units"].Value = course.units;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

            }
            catch (Exception e)
            {
                errors.Add("Error: " + e.ToString());
                System.Diagnostics.Debug.WriteLine("UpdateCourseInfo error\n" + e.ToString());
            }
            finally
            {
                conn.Dispose();
                conn = null;
            }

        }
        public static void DeleteCourse(string course_title, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                string strSQL = "spDeleteCourseInfo";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

                // the course_id should be auto increase
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@course_title", SqlDbType.VarChar, 100));


                // the course_id should be auto increase
                mySA.SelectCommand.Parameters["@course_title"].Value = course_title;


                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

            }
            catch (Exception e)
            {
                errors.Add("Error: " + e.ToString());
                System.Diagnostics.Debug.WriteLine("DeleteCourseInfo error\n" + e.ToString());
            }
            finally
            {
                conn.Dispose();
                conn = null;
            }

        }
        public static Course GetCourseDetail(string course_title, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            Course course = null;
            try
            {
                string strSQL = "spGetCourseInfo";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

                mySA.SelectCommand.Parameters.Add(new SqlParameter("@course_title", SqlDbType.VarChar, 100));

                mySA.SelectCommand.Parameters["@course_title"].Value = course_title;


                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

                if (myDS.Tables[0].Rows.Count == 0)
                    return null;

                course = new Course();
                course.id = Convert.ToInt32(myDS.Tables[0].Rows[0]["course_id"]);
                course.title = myDS.Tables[0].Rows[0]["course_title"].ToString();
                course.level = (CourseLevel)Enum.Parse(typeof(CourseLevel), myDS.Tables[0].Rows[0]["course_level"].ToString());
                course.description = myDS.Tables[0].Rows[0]["course_description"].ToString();
                course.units = Convert.ToInt32(myDS.Tables[0].Rows[0]["units"]);

                if (myDS.Tables[1] != null)
                {
                    course.prerequisite_list = new List<Prerequisite>();


                    for (int i = 0; i < myDS.Tables[1].Rows.Count; i++)
                    {
                        Prerequisite prerequisite = new Prerequisite();
                        prerequisite.course = new Course();
                        prerequisite.course.id = Convert.ToInt32(myDS.Tables[1].Rows[i]["course_pre_id"]);
                        prerequisite.course.title = myDS.Tables[1].Rows[i]["course_pre_title"].ToString();
                        prerequisite.course.level = (CourseLevel)Enum.Parse(typeof(CourseLevel), myDS.Tables[1].Rows[i]["course_pre_level"].ToString());
                        prerequisite.course.description = myDS.Tables[1].Rows[i]["course_pre_description"].ToString();
                        prerequisite.course.units = Convert.ToInt32(myDS.Tables[1].Rows[i]["course_pre_units"]);

                        course.prerequisite_list.Add(prerequisite);
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine(course.id + " does NOT have a prerequisites.");
                    course.prerequisite_list = new List<Prerequisite>();
                }

            }
            catch (Exception e)
            {
                errors.Add("Error: " + e.ToString());
                System.Diagnostics.Debug.WriteLine("GetCourseDetail error\n" + e.ToString());
            }
            finally
            {
                conn.Dispose();
                conn = null;
            }
            return course;

        }

        public static void InsertPrerequisite(int course_id, int prerequisit_id, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                string strSQL = "spInsertCourseRuleInfo";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

                // the course_id should be auto increase
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@course_pre_id", SqlDbType.Int));

                // the course_id should be auto increase
                mySA.SelectCommand.Parameters["@course_id"].Value = course_id;
                mySA.SelectCommand.Parameters["@course_pre_id"].Value = prerequisit_id;


                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

            }
            catch (Exception e)
            {
                errors.Add("Error: " + e.ToString());
                System.Diagnostics.Debug.WriteLine("InsertCourseRuleInfo error\n" + e.ToString());
            }
            finally
            {
                conn.Dispose();
                conn = null;
            }

        }
        public static void UpdatePrerequisite(int course_id, int prerequisit_id, int pre_change_id, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                string strSQL = "spInsertCourseRuleInfo";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

                // the course_id should be auto increase
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@course_pre_id", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@course_change_pre_id", SqlDbType.Int));

                // the course_id should be auto increase
                mySA.SelectCommand.Parameters["@course_id"].Value = course_id;
                mySA.SelectCommand.Parameters["@course_pre_id"].Value = prerequisit_id;
                mySA.SelectCommand.Parameters["@course_change_pre_id"].Value = pre_change_id;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

            }
            catch (Exception e)
            {
                errors.Add("Error: " + e.ToString());
                System.Diagnostics.Debug.WriteLine("UpdatePrerequisite error\n" + e.ToString());
            }
            finally
            {
                conn.Dispose();
                conn = null;
            }

        }

        public static void DeletePrerequisite(int course_id, int prerequisit_id, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                string strSQL = "spDeleteCourseRuleInfo";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

                // the course_id should be auto increase
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@course_pre_id", SqlDbType.Int));

                // the course_id should be auto increase
                mySA.SelectCommand.Parameters["@course_id"].Value = course_id;
                mySA.SelectCommand.Parameters["@course_pre_id"].Value = prerequisit_id;


                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

            }
            catch (Exception e)
            {
                errors.Add("Error: " + e.ToString());
                System.Diagnostics.Debug.WriteLine("DeletePrerequisite error\n" + e.ToString());
            }
            finally
            {
                conn.Dispose();
                conn = null;
            }
        }


    }
}
