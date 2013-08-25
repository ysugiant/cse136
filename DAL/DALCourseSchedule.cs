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

    public static List<ScheduleCourse> GetScheduleList(string year, string quarter, ref List<string> errors)
    {
      SqlConnection conn = new SqlConnection(connection_string);
      List<ScheduleCourse> scheduleList = new List<ScheduleCourse>();

      try
      {
        string strSQL = "spGetScheduleList";

        SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);

        if (year.Length > 0)
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
          ScheduleCourse schedule = new ScheduleCourse();
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
              id = Convert.ToInt32(myDS.Tables[0].Rows[i]["course_id"]),
              title = myDS.Tables[0].Rows[i]["course_title"].ToString(),
              level = (CourseLevel)Enum.Parse(typeof(CourseLevel), myDS.Tables[0].Rows[i]["course_level"].ToString()),//JUSTIN ADDED THIS
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
