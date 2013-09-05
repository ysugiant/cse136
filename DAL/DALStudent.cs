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
  public static class DALStudent
  {
    static string connection_string = ConfigurationManager.AppSettings["dsn"];

    public static void InsertStudent(Student student, ref List<string> errors)
    {
      SqlConnection conn = new SqlConnection(connection_string);
      try
      {
        string strSQL = "spInsertStudentInfo";
        
        SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
        mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
        
        //System.Diagnostics.Debug.WriteLine("Student id is: " + student.id);
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@ssn", SqlDbType.VarChar, 9));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@first_name", SqlDbType.VarChar, 50));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@last_name", SqlDbType.VarChar, 50));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 64));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 64));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@shoe_size", SqlDbType.Float));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@weight", SqlDbType.Int));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@major_id", SqlDbType.Int));//JUSTIN ADDED THIS
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@level", SqlDbType.VarChar, 20));//JUSTIN ADDED THIS
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@status", SqlDbType.Int));//JUSTIN ADDED THIS

        mySA.SelectCommand.Parameters["@student_id"].Value = student.id;
        mySA.SelectCommand.Parameters["@ssn"].Value = student.ssn;
        mySA.SelectCommand.Parameters["@first_name"].Value = student.first_name;
        mySA.SelectCommand.Parameters["@last_name"].Value = student.last_name;
        mySA.SelectCommand.Parameters["@email"].Value = student.email;
        mySA.SelectCommand.Parameters["@password"].Value = student.password;
        mySA.SelectCommand.Parameters["@shoe_size"].Value = student.shoe_size;
        mySA.SelectCommand.Parameters["@weight"].Value = student.weight;
        mySA.SelectCommand.Parameters["@major_id"].Value = student.major;//JUSTIN ADDED THIS
        mySA.SelectCommand.Parameters["@level"].Value = student.level;//JUSTIN ADDED THIS
        mySA.SelectCommand.Parameters["@status"].Value = student.status;//JUSTIN ADDED THIS
        

        DataSet myDS = new DataSet();
        mySA.Fill(myDS);

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

    public static void UpdateStudent(Student student, ref List<string> errors)
    {
      //System.Diagnostics.Debug.WriteLine("We are in the UpdateStudent method...");//JUSTIN ADDED THIS
      SqlConnection conn = new SqlConnection(connection_string);
      try
      {
        string strSQL = "spUpdateStudentInfo";

        SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
        mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@ssn", SqlDbType.VarChar, 9));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@first_name", SqlDbType.VarChar, 50));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@last_name", SqlDbType.VarChar, 50));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 64));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 64));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@shoe_size", SqlDbType.Float));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@weight", SqlDbType.Int));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@major_id", SqlDbType.Int));//JUSTIN ADDED THIS
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@level", SqlDbType.VarChar, 20));//JUSTIN ADDED THIS
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@status", SqlDbType.Int));//JUSTIN ADDED THIS

        mySA.SelectCommand.Parameters["@student_id"].Value = student.id;
        mySA.SelectCommand.Parameters["@ssn"].Value = student.ssn;
        mySA.SelectCommand.Parameters["@first_name"].Value = student.first_name;
        mySA.SelectCommand.Parameters["@last_name"].Value = student.last_name;
        mySA.SelectCommand.Parameters["@email"].Value = student.email;
        mySA.SelectCommand.Parameters["@password"].Value = student.password;
        mySA.SelectCommand.Parameters["@shoe_size"].Value = student.shoe_size;
        mySA.SelectCommand.Parameters["@weight"].Value = student.weight;
        mySA.SelectCommand.Parameters["@major_id"].Value = student.major;//JUSTIN ADDED THIS
        mySA.SelectCommand.Parameters["@level"].Value = student.level.ToString();//JUSTIN ADDED THIS
        mySA.SelectCommand.Parameters["@status"].Value = student.status;//JUSTIN ADDED THIS

        //System.Diagnostics.Debug.WriteLine("reached end of update.");//JUSTIN ADDED THIS
        DataSet myDS = new DataSet();
        mySA.Fill(myDS);
        //System.Diagnostics.Debug.WriteLine("Updated the Student with id: " + student.id);//JUSTIN ADDED THIS
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

    public static void DeleteStudent(string id, ref List<string> errors)
    {
      SqlConnection conn = new SqlConnection(connection_string);

      try
      {
        string strSQL = "spDeleteStudentInfo";

        SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
        mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));

        mySA.SelectCommand.Parameters["@student_id"].Value = id;

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

    public static Student GetStudentDetail(string id, ref List<string> errors)
    {
        SqlConnection conn = new SqlConnection(connection_string);
        Student student = null;

        try
        {
            string strSQL = "spGetStudentInfo";

            SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
            mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
            mySA.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));

            mySA.SelectCommand.Parameters["@student_id"].Value = id;

            DataSet myDS = new DataSet();
            mySA.Fill(myDS);

            if (myDS.Tables[0].Rows.Count == 0)
                return null;

            student = new Student();
            student.id = myDS.Tables[0].Rows[0]["student_id"].ToString();
            student.first_name = myDS.Tables[0].Rows[0]["first_name"].ToString();
            student.last_name = myDS.Tables[0].Rows[0]["last_name"].ToString();
            student.ssn = myDS.Tables[0].Rows[0]["ssn"].ToString();
            student.email = myDS.Tables[0].Rows[0]["email"].ToString();
            student.password = myDS.Tables[0].Rows[0]["password"].ToString();
            student.shoe_size = (float)Convert.ToDouble(myDS.Tables[0].Rows[0]["shoe_size"].ToString());
            student.weight = Convert.ToInt32(myDS.Tables[0].Rows[0]["weight"].ToString());
            student.major = Convert.ToInt32(myDS.Tables[0].Rows[0]["major_id"].ToString());//JUSTIN ADDED THIS
            student.level = (StudentLevel)Enum.Parse(typeof(StudentLevel), myDS.Tables[0].Rows[0]["level"].ToString());//JUSTIN ADDED THIS
            student.status = Convert.ToInt32(myDS.Tables[0].Rows[0]["status"].ToString());//JUSTIN ADDED THIS

            if (myDS.Tables[1] != null)
            {
                student.enrolled = new List<ScheduledCourse>();
                ScheduledCourse schedule = new ScheduledCourse();
                Course course = new Course();
                for (int i = 0; i < myDS.Tables[1].Rows.Count; i++)
                {
                    course.id = Convert.ToInt32(myDS.Tables[1].Rows[i]["course_id"]);
                    course.title = myDS.Tables[1].Rows[i]["course_title"].ToString();
                    course.description = myDS.Tables[1].Rows[i]["course_description"].ToString();
                    course.level =  myDS.Tables[0].Rows[0]["level"].ToString();//JUSTIN ADDED THIS
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
            }

        }
        catch (Exception e)
        {
            errors.Add("Error: " + e.ToString());
            System.Diagnostics.Debug.WriteLine("Error retrieving student data..." + e);//JUSTIN ADDED THIS
        }
        finally
        {
            conn.Dispose();
            conn = null;
        }

        return student;
    }

    public static List<Student> GetStudentList(ref List<string> errors)
    {
      SqlConnection conn = new SqlConnection(connection_string);
      Student student = null;
      List<Student> studentList = new List<Student>();

      try
      {
        string strSQL = "spGetStudentList";

        SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
        mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

        DataSet myDS = new DataSet();
        mySA.Fill(myDS);

        if (myDS.Tables[0].Rows.Count == 0)
          return null;

        for (int i = 0; i < myDS.Tables[0].Rows.Count; i++)
        {
          student = new Student();
          student.id = myDS.Tables[0].Rows[i]["student_id"].ToString();
          student.first_name = myDS.Tables[0].Rows[i]["first_name"].ToString();
          student.last_name = myDS.Tables[0].Rows[i]["last_name"].ToString();
          student.ssn = myDS.Tables[0].Rows[i]["ssn"].ToString();
          student.email = myDS.Tables[0].Rows[i]["email"].ToString();
          student.password = myDS.Tables[0].Rows[i]["password"].ToString();
          student.shoe_size = (float)Convert.ToDouble(myDS.Tables[0].Rows[i]["shoe_size"].ToString());
          student.weight = Convert.ToInt32(myDS.Tables[0].Rows[i]["weight"].ToString());
          student.major = Convert.ToInt32(myDS.Tables[0].Rows[i]["major_id"].ToString());//JUSTIN ADDED THIS
          student.level = (StudentLevel)Enum.Parse(typeof(StudentLevel), myDS.Tables[0].Rows[i]["level"].ToString());//JUSTIN ADDED THIS
          student.status = Convert.ToInt32(myDS.Tables[0].Rows[i]["status"].ToString());//JUSTIN ADDED THIS
          studentList.Add(student);
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

      return studentList;
    }

    public static void EnrollSchedule(string student_id, int schedule_id, ref List<string> errors)
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

    public static void DropEnrolledSchedule(string student_id, int schedule_id, ref List<string> errors)
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
  }
}
