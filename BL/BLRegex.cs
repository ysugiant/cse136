using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BL
{
    public class BLRegex
    {
        public static bool checkStudentId(string st_id)
        {
            if (st_id == null || st_id == "")
                return false;
            else
            {
                string strRegex = @"^A[0-9]{8}";
                return Regex.IsMatch(st_id, strRegex);
            }
        }

        public static bool checkEmail(string email)
        {
            if (email != null && )
            {
                string strRegex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
                return Regex.IsMatch(email, strRegex);
            }
            else
                return false;
        }

        public static 
    }
}
