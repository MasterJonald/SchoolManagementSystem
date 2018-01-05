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
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;
    }
}
