using CarRentSystemManagement.Customers;
using CarRentSystemManagement.RenatalTransaction;
using CarRentSystemManagement.RentalBooking;
using CarRentSystemManagement.ReturnVehicle;
using CarRentSystemManagement.Users;
using CarRentSystemManagement.Vehilces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentSystemManagement
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }
    }
}
