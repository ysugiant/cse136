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
    public static class DALStaff
    {
        static string connection_string = ConfigurationManager.AppSettings["dsn"];

        public static void InsertStaff(Staff staffMember, ref List<string> errors, out int newID)
        {
            newID = -1;
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                string strSQL = "spInsertStaffInfo";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

                //System.Diagnostics.Debug.WriteLine("Staff id is: " + staff.id);
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@first_name", SqlDbType.VarChar, 50));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@last_name", SqlDbType.VarChar, 50));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 50));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 50));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@dept_id", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@instructor", SqlDbType.Bit));

                mySA.SelectCommand.Parameters["@first_name"].Value = staffMember.first_name;
                mySA.SelectCommand.Parameters["@last_name"].Value = staffMember.last_name;
                mySA.SelectCommand.Parameters["@email"].Value = staffMember.email;
                mySA.SelectCommand.Parameters["@password"].Value = staffMember.password;
                mySA.SelectCommand.Parameters["@dept_id"].Value = staffMember.dept.id;
                mySA.SelectCommand.Parameters["@instructor"].Value = staffMember.isInstructor;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

                newID = Convert.ToInt32(myDS.Tables[0].Rows[0]["last_id_added"].ToString());

            }
            catch (Exception e)
            {
                errors.Add("Error: " + e.ToString());
                System.Diagnostics.Debug.WriteLine("Error occurred during insertStaff in DAL.\n" + e);//JUSTIN ADDED THIS
            }
            finally
            {
                //newID = Convert.ToInt32(myDS.Tables[0].Rows[0]["last_id_added"].ToString()); ;
                conn.Dispose();
                conn = null;
            }
        }

        public static void UpdateStaff(Staff staffMember, ref List<string> errors)
        {
            //System.Diagnostics.Debug.WriteLine("We are in the UpdateStudent method...");//JUSTIN ADDED THIS
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                string strSQL = "spUpdateStaffInfo";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@staff_id", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@dept_id", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@first_name", SqlDbType.VarChar, 50));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@last_name", SqlDbType.VarChar, 50));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 50));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 50));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@instructor", SqlDbType.Bit));

                mySA.SelectCommand.Parameters["@staff_id"].Value = staffMember.id;
                mySA.SelectCommand.Parameters["@dept_id"].Value = staffMember.dept.id;
                mySA.SelectCommand.Parameters["@first_name"].Value = staffMember.first_name;
                mySA.SelectCommand.Parameters["@last_name"].Value = staffMember.last_name;
                mySA.SelectCommand.Parameters["@email"].Value = staffMember.email;
                mySA.SelectCommand.Parameters["@password"].Value = staffMember.password;
                mySA.SelectCommand.Parameters["@instructor"].Value = staffMember.isInstructor;


                //System.Diagnostics.Debug.WriteLine("reached end of update.");//JUSTIN ADDED THIS
                DataSet myDS = new DataSet();
                mySA.Fill(myDS);
                //System.Diagnostics.Debug.WriteLine("Updated the Student with id: " + student.id);//JUSTIN ADDED THIS
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e.ToString());
                System.Diagnostics.Debug.WriteLine(e);//JUSTIN ADDED THIS
            }
            finally
            {
                conn.Dispose();
                conn = null;
            }
        }

        public static void DeleteStaff(int id, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);

            try
            {
                string strSQL = "spDeleteStaffInfo";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@staff_id", SqlDbType.Int));

                mySA.SelectCommand.Parameters["@staff_id"].Value = id;

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

        public static Staff GetStaffDetail(int id, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            Staff staff = null;

            try
            {
                string strSQL = "spGetStaffInfo";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@staff_id", SqlDbType.Int));

                mySA.SelectCommand.Parameters["@staff_id"].Value = id;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

                if (myDS.Tables[0].Rows.Count == 0)
                    return null;

                staff = new Staff();// NOT SURE ABOUT THIS ONE?????????????????????????????????????????????????
                staff.id = Convert.ToInt32(myDS.Tables[0].Rows[0]["staff_id"].ToString());
                staff.first_name = myDS.Tables[0].Rows[0]["first_name"].ToString();
                staff.last_name = myDS.Tables[0].Rows[0]["last_name"].ToString();
                staff.email = myDS.Tables[0].Rows[0]["email"].ToString();
                staff.password = myDS.Tables[0].Rows[0]["password"].ToString();
                staff.dept = new Department();
                staff.dept.id = Convert.ToInt32(myDS.Tables[0].Rows[0]["dept_id"].ToString());
                staff.isInstructor = Convert.ToBoolean(myDS.Tables[0].Rows[0]["instructor"].ToString());

                /*if (myDS.Tables[1] != null)
                {
                    student.enrolled = new List<ScheduleCourse>();
                    ScheduleCourse schedule = new ScheduleCourse();
                    Course course = new Course();
                    for (int i = 0; i < myDS.Tables[1].Rows.Count; i++)
                    {
                        course.id = myDS.Tables[1].Rows[i]["course_id"].ToString();
                        course.title = myDS.Tables[1].Rows[i]["course_title"].ToString();
                        course.description = myDS.Tables[1].Rows[i]["course_description"].ToString();
                        course.level = (CourseLevel)Enum.Parse(typeof(CourseLevel), myDS.Tables[0].Rows[0]["level"].ToString());//JUSTIN ADDED THIS
                        course.units = Convert.ToInt32(myDS.Tables[1].Rows[i]["units"].ToString());//JUSTIN ADDED THIS
                        schedule.course = course;
                        System.Diagnostics.Debug.WriteLine("Added " + schedule.course.id + " to student schedule");//JUSTIN ADDED THIS

                        schedule.quarter = myDS.Tables[1].Rows[i]["quarter"].ToString();
                        schedule.year = Convert.ToInt32(myDS.Tables[1].Rows[i]["year"].ToString());
                        schedule.session = myDS.Tables[1].Rows[i]["session"].ToString();
                        schedule.id = Convert.ToInt32(myDS.Tables[1].Rows[i]["schedule_id"].ToString());
                        schedule.time = myDS.Tables[1].Rows[i]["schedule_time"].ToString();//JUSTIN ADDED THIS
                        schedule.day = myDS.Tables[1].Rows[i]["schedule_day"].ToString();//JUSTIN ADDED THIS
                        schedule.instructor_fName = myDS.Tables[1].Rows[i]["instr_fName"].ToString();//JUSTIN ADDED THIS
                        schedule.instructor_lName = myDS.Tables[1].Rows[i]["instr_lName"].ToString();//JUSTIN ADDED THIS

                        student.enrolled.Add(schedule);
                    }
                }*/

            }
            catch (Exception e)
            {
                errors.Add("Error: " + e.ToString());
                System.Diagnostics.Debug.WriteLine("Did not successfully build a staff object from getStaffInfo SP.\n" + e);//JUSTIN ADDED THIS
            }
            finally
            {
                conn.Dispose();
                conn = null;
            }

            return staff;
        }

        public static List<Staff> GetStaffList(ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            Staff staffMember = null;
            List<Staff> staffList = new List<Staff>();

            try
            {
                string strSQL = "spGetStaffList";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

                if (myDS.Tables[0].Rows.Count == 0)
                    return null;

                for (int i = 0; i < myDS.Tables[0].Rows.Count; i++)
                {
                    staffMember = new Staff();
                    staffMember.id = Convert.ToInt32(myDS.Tables[0].Rows[i]["staff_id"].ToString());
                    staffMember.first_name = myDS.Tables[0].Rows[i]["first_name"].ToString();
                    staffMember.last_name = myDS.Tables[0].Rows[i]["last_name"].ToString();
                    staffMember.email = myDS.Tables[0].Rows[i]["email"].ToString();
                    staffMember.password = myDS.Tables[0].Rows[i]["password"].ToString();
                    staffMember.dept = new Department();
                    staffMember.dept.id = Convert.ToInt32(myDS.Tables[0].Rows[i]["dept_id"].ToString());
                    staffMember.dept.deptName = myDS.Tables[0].Rows[i]["dept_name"].ToString();
                    staffMember.dept.chairID = Convert.ToInt32(myDS.Tables[0].Rows[i]["chair_id"].ToString());
                    staffMember.isInstructor = Convert.ToBoolean(myDS.Tables[0].Rows[i]["instructor"].ToString());
                    staffList.Add(staffMember);
                }
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e.ToString());
                System.Diagnostics.Debug.WriteLine("Error caught in getStaffList: " + e.ToString());
            }
            finally
            {
                conn.Dispose();
                conn = null;
            }

            return staffList;
        }

        /*public static void EnrollSchedule(string student_id, int schedule_id, ref List<string> errors)
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

        }*/

        /*public static void DropEnrolledSchedule(string student_id, int schedule_id, ref List<string> errors)
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

        }*/

    }
}
