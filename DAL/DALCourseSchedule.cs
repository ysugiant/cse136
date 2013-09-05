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
  public static class DALCourseSchedule
  {
    static string connection_string = ConfigurationManager.AppSettings["dsn"];

    public static void InsertCourseSchedule(ScheduledCourse sched, ref List<string> errors, out int ID)
    {
        ID = -1;
        SqlConnection conn = new SqlConnection(connection_string);

        try
        {
            string strSQL = "spInsertScheduleInfo";
            SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
            mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

            mySA.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));
            mySA.SelectCommand.Parameters.Add(new SqlParameter("@year", SqlDbType.Int));
            mySA.SelectCommand.Parameters.Add(new SqlParameter("@quarter", SqlDbType.VarChar, 50));
            mySA.SelectCommand.Parameters.Add(new SqlParameter("@session", SqlDbType.VarChar, 50));
            mySA.SelectCommand.Parameters.Add(new SqlParameter("@schedule_day_id", SqlDbType.Int));
            mySA.SelectCommand.Parameters.Add(new SqlParameter("@staff_id", SqlDbType.Int));
            mySA.SelectCommand.Parameters.Add(new SqlParameter("@schedule_time_id", SqlDbType.Int));

            mySA.SelectCommand.Parameters["@course_id"].Value = sched.course.id;
            mySA.SelectCommand.Parameters["@year"].Value = sched.year;
            mySA.SelectCommand.Parameters["@quarter"].Value = sched.quarter;
            mySA.SelectCommand.Parameters["@session"].Value = sched.session;
            mySA.SelectCommand.Parameters["@schedule_day_id"].Value = sched.dayID;
            mySA.SelectCommand.Parameters["@staff_id"].Value = sched.instr_id;
            mySA.SelectCommand.Parameters["@schedule_time_id"].Value = sched.timeID;


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

    public static void UpdateCourseSchedule(ScheduledCourse sched, ref List<string> errors)
    {
        SqlConnection conn = new SqlConnection(connection_string);
        
        try
        {
            string strSQL = "spUpdateScheduleInfo";
            SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
            mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

            mySA.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));
            mySA.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));
            mySA.SelectCommand.Parameters.Add(new SqlParameter("@year", SqlDbType.Int));
            mySA.SelectCommand.Parameters.Add(new SqlParameter("@quarter", SqlDbType.VarChar, 50));
            mySA.SelectCommand.Parameters.Add(new SqlParameter("@session", SqlDbType.VarChar, 50));
            mySA.SelectCommand.Parameters.Add(new SqlParameter("@schedule_day_id", SqlDbType.Int));
            mySA.SelectCommand.Parameters.Add(new SqlParameter("@staff_id", SqlDbType.Int));
            mySA.SelectCommand.Parameters.Add(new SqlParameter("@schedule_time_id", SqlDbType.Int));

            mySA.SelectCommand.Parameters["@schedule_id"].Value = sched.id;
            mySA.SelectCommand.Parameters["@course_id"].Value = sched.course.id;
            mySA.SelectCommand.Parameters["@year"].Value = sched.year;
            mySA.SelectCommand.Parameters["@quarter"].Value = sched.quarter;
            mySA.SelectCommand.Parameters["@session"].Value = sched.session;
            mySA.SelectCommand.Parameters["@schedule_day_id"].Value = sched.dayID;
            mySA.SelectCommand.Parameters["@staff_id"].Value = sched.instr_id;
            mySA.SelectCommand.Parameters["@schedule_time_id"].Value = sched.timeID;

            DataSet myDS = new DataSet();
            mySA.Fill(myDS);
        }
        catch (Exception e)
        {
            errors.Add("Error: " + e.ToString());
            System.Diagnostics.Debug.WriteLine("value of e is: " + e);
        }
        finally
        {
            conn.Dispose();
            conn = null;
        }
    }

    public static void DeleteCourseSchedule(int id, ref List<string> errors)
    {
        SqlConnection conn = new SqlConnection(connection_string);

        try
        {
            string strSQL = "spDeleteScheduleInfo";
            SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
            mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

            mySA.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));

            mySA.SelectCommand.Parameters["@schedule_id"].Value = id;

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

    public static ScheduledCourse GetCourseScheduleDetail(int id, ref List<string> errors)
    {
        SqlConnection conn = new SqlConnection(connection_string);
        ScheduledCourse sCourse = null;

        try
        {
            string strSQL = "spGetScheduleInfo";

            SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
            mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
            mySA.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));

            mySA.SelectCommand.Parameters["@schedule_id"].Value = id;

            DataSet myDS = new DataSet();
            mySA.Fill(myDS);

            if (myDS.Tables[0].Rows.Count == 0)
                return null;

            //sCourse = myDS.Tables[0].Rows[0]["major_name"].ToString();

            sCourse = new ScheduledCourse();
            sCourse.id = Convert.ToInt32(myDS.Tables[0].Rows[0]["schedule_id"].ToString());
            sCourse.year = Convert.ToInt32(myDS.Tables[0].Rows[0]["year"].ToString());
            sCourse.quarter = myDS.Tables[0].Rows[0]["quarter"].ToString();
            sCourse.session = myDS.Tables[0].Rows[0]["session"].ToString();

            Course course = new Course();
            course.id = Convert.ToInt32(myDS.Tables[0].Rows[0]["course_id"].ToString());
            course.units = Convert.ToInt32(myDS.Tables[0].Rows[0]["units"].ToString());
            course.title = myDS.Tables[0].Rows[0]["course_title"].ToString();            
            course.level = myDS.Tables[0].Rows[0]["course_level"].ToString();//JUSTIN ADDED THIS
            course.description = myDS.Tables[0].Rows[0]["course_description"].ToString();
            sCourse.course = course;

            sCourse.timeID = Convert.ToInt32(myDS.Tables[0].Rows[0]["schedule_time_id"].ToString());
            sCourse.dayID = Convert.ToInt32(myDS.Tables[0].Rows[0]["schedule_day_id"].ToString());
            sCourse.instr_id = Convert.ToInt32(myDS.Tables[0].Rows[0]["staff_id"].ToString());
            sCourse.instructor_fName = myDS.Tables[0].Rows[0]["first_name"].ToString();
            sCourse.instructor_lName = myDS.Tables[0].Rows[0]["last_name"].ToString();
            

        }
        catch (Exception e)
        {
            errors.Add("Error: " + e.ToString());
            System.Diagnostics.Debug.WriteLine("Error retrieving course schedule data..." + e);
        }
        finally
        {
            conn.Dispose();
            conn = null;
        }

        return sCourse;
    }

    public static List<ScheduledCourse> GetCourseScheduleList(int year, string quarter, ref List<string> errors)
    {
      SqlConnection conn = new SqlConnection(connection_string);
      List<ScheduledCourse> scheduleList = new List<ScheduledCourse>();

      try
      {
        string strSQL = "spGetScheduleList";

        SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);

        if (year > 0)
        {
          mySA.SelectCommand.Parameters.Add(new SqlParameter("@year", SqlDbType.Int));
          mySA.SelectCommand.Parameters["@year"].Value = year;
        }

        if (quarter.Length > 0)
        {
          mySA.SelectCommand.Parameters.Add(new SqlParameter("@quarter", SqlDbType.VarChar, 25));
          mySA.SelectCommand.Parameters["@quarter"].Value = quarter;
        }

        mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

        DataSet myDS = new DataSet();
        mySA.Fill(myDS);

        if (myDS.Tables[0].Rows.Count == 0)
          return null;

        for (int i = 0; i < myDS.Tables[0].Rows.Count; i++)
        {
          ScheduledCourse schedule = new ScheduledCourse();
          schedule.id = Convert.ToInt32(myDS.Tables[0].Rows[i]["schedule_id"].ToString());
          schedule.year = Convert.ToInt32(myDS.Tables[0].Rows[i]["year"].ToString());
          schedule.quarter = myDS.Tables[0].Rows[i]["quarter"].ToString();
          schedule.session = myDS.Tables[0].Rows[i]["session"].ToString();
          schedule.time = myDS.Tables[0].Rows[i]["schedule_time"].ToString();//JUSTIN ADDED THIS
          schedule.day = myDS.Tables[0].Rows[i]["schedule_day"].ToString();//JUSTIN ADDED THIS
          schedule.instructor_fName = myDS.Tables[0].Rows[i]["instr_fName"].ToString();//JUSTIN ADDED THIS
          schedule.instructor_lName = myDS.Tables[0].Rows[i]["instr_lName"].ToString();//JUSTIN ADDED THIS
          schedule.course =
            new Course
            {
              id = Convert.ToInt32(myDS.Tables[0].Rows[i]["course_id"].ToString()),
              title = myDS.Tables[0].Rows[i]["course_title"].ToString(),
              level =  myDS.Tables[0].Rows[i]["course_level"].ToString(),//JUSTIN ADDED THIS
              description = myDS.Tables[0].Rows[i]["course_description"].ToString(),
              units = Convert.ToInt32(myDS.Tables[0].Rows[i]["units"].ToString())//JUSTIN ADDED THIS
            };
          scheduleList.Add(schedule);
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

      return scheduleList;
    }
  }
}
