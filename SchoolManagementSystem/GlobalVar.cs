using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem
{
    public static class GlobalVariable
    {
        public static String ConnectionString = ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;
        public static String SchoolYear = ConfigurationManager.AppSettings["SchoolYear"].ToString();
    }
}
