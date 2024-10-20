using CarRentDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBusinessLayer
{
    public class clsCustomer : clsPeople
    {
        enum enMode { enUpdate = 1, enAdd = 2 }
        public int CustomerID { get; set; }
        public string DriverLicenseID { get; set; }
        public string FullName()
        {
            return FirstName+" "+SecondName+" "+LastName;
        }

        enMode _Mode = enMode.enUpdate;
        public clsCustomer()
        {
            this.DriverLicenseID = string.Empty;
            this.FirstName = string.Empty;
            this.SecondName = string.Empty;
            this.LastName = string.Empty;
            this.Phone = string.Empty;
            _Mode = enMode.enAdd;
        }
        private clsCustomer(int customerID, string DriverLicenseID, int PersonID, string FirstName, string SecondName, string LastName,
            string phone)
        {
            this.CustomerID = customerID;
            this.DriverLicenseID = DriverLicenseID;
            this.PersonID = PersonID;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.LastName = LastName;
            this.Phone = phone;
            _Mode = enMode.enUpdate;
        }
        public static clsCustomer FindCustomer(int CustomerID)
        {
            string DriverLicenseID = string.Empty; int PersonID = 0;
            if (clsCustomerData.FindCustomer(CustomerID, ref DriverLicenseID, ref PersonID))
            {
                string FirstName = string.Empty; string secondName = string.Empty; string lastName = string.Empty;
                string phone = string.Empty;
                if (clsPeopleDate.FindPersonByID(PersonID, ref FirstName, ref secondName, ref lastName, ref phone))
                {
                    return new clsCustomer(CustomerID, DriverLicenseID, PersonID, FirstName, secondName, lastName, phone);
                }
            }
            return null;
        }
        public static clsCustomer FindCustomer(string DriverLicense)
        {
            int CustomerID = 0; int PersonID = 0;
            if (clsCustomerData.FindCustomer(ref CustomerID,  DriverLicense, ref PersonID))
            {
                string FirstName = string.Empty; string secondName = string.Empty; string lastName = string.Empty;
                string phone = string.Empty;
                if (clsPeopleDate.FindPersonByID(PersonID, ref FirstName, ref secondName, ref lastName, ref phone))
                {
                    return new clsCustomer(CustomerID, DriverLicense, PersonID, FirstName, secondName, lastName, phone);
                }
            }
            return null;
        }
        private bool _AddNewCustomer()
        {
            this.CustomerID = clsCustomerData.AddNewCustomer(this.DriverLicenseID, this.PersonID);
            return this.CustomerID != -1;
        }
        private bool _UpdateCustomerInfo()
        {
            return clsCustomerData.UpdateCustomer(this.CustomerID, this.DriverLicenseID, this.PersonID);
        }
        public bool Save()
        {
            base.Mode = (clsPeople.enMode)_Mode;
            if (base.Save())
            {
                switch (_Mode)
                {
                    case enMode.enAdd:
                        if (_AddNewCustomer())
                        {
                            _Mode = enMode.enUpdate;
                            return true;
                        }
                        return false;

                    case enMode.enUpdate:

                        if (_UpdateCustomerInfo())
                            return true;
                        return false;
                }
            }
            return false;
        }
        public static DataTable getCustomerList()
        {
            return clsCustomerData.GetAllCustomers();
        }
        public static DataTable GetAllCustomerNames()
        {
            return clsCustomerData.GetAllCustomerNames();
        }
        public static int GetCustomerIDByFullName(string fullName)
        {
            return clsCustomerData.GetCustomerIDByName(fullName);
        }
        public static bool DeleteCustomer(int CustomerID)
        {
            return clsCustomerData.DeleteCustomer(CustomerID);
        }
    }
}
