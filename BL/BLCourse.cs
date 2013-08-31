using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POCO;
using DAL;

namespace BL
{
    public class BLCourse
    {
        //should pass by the default list ref errors 
        public static List<Course> GetCourseList(ref List<string> errors)
        {
            return (DALCourse.GetCourseList(ref errors));
        }

        public static void InsertCourse(Course course, ref List<string> errors)
        {
            BLCheck.checkCourseErrors(course, ref errors);
            if (errors.Count > 0)
                return;

            DALCourse.InsertCourse(course, ref errors);
        }

        public static void UpdateCourse(Course course, ref List<string> errors)
        {
            BLCheck.checkCourseErrors(course, ref errors);

            if (errors.Count > 0)
            {

                return;
            }
            DALCourse.UpdateCourse(course, ref errors);
        }

        public static Course GetCourse(string coursetitle, ref List<string> errors)
        {
            BLCheck.checkCourseTitle(coursetitle, ref errors);

            if (errors.Count > 0)
                return null;

            return (DALCourse.GetCourseDetail(coursetitle, ref errors));
        }

        public static void DeleteCourse(string coursetitle, ref List<string> errors)
        {
            BLCheck.checkCourseTitle(coursetitle, ref errors);

            if (errors.Count > 0)
                return;

            DALCourse.DeleteCourse(coursetitle, ref errors);
        }

        public static void InsertPrerequisite(int courseid, int pre_course_id, ref List<string> errors)
        {
            BLCheck.checkCourseID(courseid, ref errors);
            BLCheck.checkCoursePreID(pre_course_id, ref errors);
            if (errors.Count > 0)
                return;

            DALCourse.InsertPrerequisite(courseid, pre_course_id, ref errors);
        }

        public static void UpdatePrerequisite(int courseid, int pre_course_id, int change_id, ref List<string> errors)
        {
            BLCheck.checkCourseID(courseid, ref errors);
            BLCheck.checkCoursePreID(pre_course_id, ref errors);
            BLCheck.checkCoursePreID(change_id, ref errors);
            if (errors.Count > 0)
                return;

            DALCourse.UpdatePrerequisite(courseid, pre_course_id, change_id, ref errors);
        }

        public static void DeletePrerequisite(int courseid, int pre_course_id, ref List<string> errors)
        {
            BLCheck.checkCourseID(courseid, ref errors);
            BLCheck.checkCoursePreID(pre_course_id, ref errors);
            if (errors.Count > 0)
                return;

            DALCourse.DeletePrerequisite(courseid, pre_course_id, ref errors);
        }


    }
}
