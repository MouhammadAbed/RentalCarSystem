using CarRentDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBusinessLayer
{
    public class clsPeople
    {
        public  enum enMode { enUpdate = 1, enAdd = 2 }
        public int PersonID { get; set; }
        public string FirstName { get; set; }   
        public string SecondName { get; set; }  
        public string LastName { get; set; }
        public string Phone { get; set; }
        public enMode Mode = enMode.enUpdate;
        private clsPeople(int PersonID, string FirstName, string SecondName,string LastName, string Phone)
        {
            this.PersonID=PersonID;
            this.FirstName=FirstName;
            this.SecondName=SecondName;
            this.LastName=LastName;
            this.Phone=Phone;
        }
        public clsPeople()
        {
            this.FirstName = string.Empty;
            this.SecondName = string.Empty;
            this.LastName = string.Empty;
            this.Phone = string.Empty;
            Mode = enMode.enAdd;
        }
        public static clsPeople FindPerson(int PersonID)
        {
            string FirstName=string .Empty;string secondName = string .Empty;string LastName =string .Empty;
            string Phone = string.Empty;
            if(clsPeopleDate.FindPersonByID(PersonID,ref FirstName,ref secondName,ref LastName,ref Phone))
            {
                return new clsPeople(PersonID, FirstName, secondName,LastName, Phone);
            }
            return null;
        }
        public bool _AddNewPerson()
        {
            this.PersonID = clsPeopleDate.AddNewPerson(this.FirstName, this.SecondName, this.LastName, this.Phone);
            return this.PersonID != -1;
        }
        public bool _UpdatePersonInfo()
        {
            if(clsPeopleDate.updatePersonInfo(this.PersonID,this.FirstName,this.SecondName,this.LastName,this.Phone))
               return true; 

            return false;
        }
        public static DataTable GetAllPeople()
        {
            return clsPeopleDate.getAllPeople();
        }
        public static bool isPersonExist(int personID)
        {
            return clsPeopleDate.isPersonExist(personID);
        }
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.enUpdate:

                    if (_UpdatePersonInfo())
                        return true;

                    return false;

                case enMode.enAdd:

                    if (_AddNewPerson())
                    {
                        Mode = enMode.enUpdate;
                        return true;
                    }
                    return false;
            }
            return false;
        }
        public static bool DeletePerson(int PersonID)
        {
            return clsPeopleDate.DeletePerson(PersonID);
        }

    }
}
