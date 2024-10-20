using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CarRentDataAccess
{
    public class clsConnection
    {
        /// <summary>
        /// connect to database server without using app config class
        /// </summary>
        public static string ConnectionString1 = "Server =.;Database=carRent;User Id=sa;Password = sa123456";

        /// <summary>
        /// access database using app config class
        /// </summary>
        public static string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
    }
}
