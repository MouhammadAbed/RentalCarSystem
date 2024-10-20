using CarRentDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBusinessLayer
{
    public class clsUser:clsPeople
    {
        enum enMode { enUpdate =1 , enAdd = 2}
        enMode _Mode = enMode.enUpdate;
        public int UserID { get; set; } 
        public string userName { get; set; }
        public string Password { get; set; }
        private clsUser(int UserID ,string UserName, string Password,int PersonID,string FirstName,string SecondName,string lastName,string Phone)
        {
            this.UserID = UserID;
            this.userName = UserName;
            this.Password = Password;
            this.PersonID = PersonID;
            this.FirstName= FirstName;
            this.SecondName= SecondName;
            this.LastName= lastName;
            this.Phone= Phone;
           _Mode = enMode.enUpdate;
        }
        public clsUser()
        {
            this.UserID=0;
            this.userName = "";
            this.Password = string.Empty;
            this.PersonID=0;
            this.FirstName= string.Empty;
            this.SecondName= string.Empty;
            this.LastName= string.Empty;
            this.Phone= string.Empty;
            _Mode = enMode.enAdd;
        }
        public static clsUser FindUser(int UserID)
        {
            string userName = ""; string Password = string.Empty; int PersonID = 0;
            if (clsUserData.FindUser(UserID,ref userName,ref Password,ref PersonID))
            {
                 string FirstName = string.Empty;string SecondName = string.Empty; string LastName = string.Empty;
                string Phone = string.Empty;
                clsPeople FindPerson = clsPeople.FindPerson(PersonID);
                if(FindPerson!= null) 
                {
                    FirstName = FindPerson.FirstName;
                    LastName = FindPerson.LastName;
                    SecondName = FindPerson.SecondName;
                    Phone = FindPerson.Phone;
                    return new clsUser(UserID,userName, Password, PersonID, FirstName, SecondName, LastName, Phone);
                }
            }
            return null;
        }
        public static clsUser FindUser(string UserName)
        {
            int userId =0; string Password = string.Empty; int PersonID = 0;
            if (clsUserData.FindUserByUserName(UserName,ref userId,  ref Password, ref PersonID))
            {
                string FirstName = string.Empty; string SecondName = string.Empty; string LastName = string.Empty;
                string Phone = string.Empty;
                clsPeople FindPerson = clsPeople.FindPerson(PersonID);
                if (FindPerson != null)
                {
                    FirstName = FindPerson.FirstName;
                    LastName = FindPerson.LastName;
                    SecondName = FindPerson.SecondName;
                    Phone = FindPerson.Phone;
                    return new clsUser(userId,UserName, Password, PersonID, FirstName, SecondName, LastName, Phone);
                }
            }
            return null;
        }
        public static clsUser FindUserByPersonID(int PersonID )
        {
            string userName = string.Empty; string Password = string.Empty; int UserID = 0;
            if (clsUserData.FindUserbyPersonID(ref UserID,ref userName, ref Password,  PersonID))
            {
                string FirstName = string.Empty; string SecondName = string.Empty; string LastName = string.Empty;
                string Phone = string.Empty;
                clsPeople FindPerson = clsPeople.FindPerson(PersonID);
                if (FindPerson != null)
                {
                    FirstName = FindPerson.FirstName;
                    LastName = FindPerson.LastName;
                    SecondName = FindPerson.SecondName;
                    Phone = FindPerson.Phone;
                    return new clsUser(UserID, userName, Password, PersonID, FirstName, SecondName, LastName, Phone);
                }
            }
            return null;
        }
        private bool _AddNewUser()
        {
            this.UserID = clsUserData.AddNewUser(this.userName, this.Password, this.PersonID);
            return this.UserID != -1;
        }
        private bool _UpdateUser()
        {
            return clsUserData.UpdateUserPassword(this.UserID,this.userName, this.Password);
        }
        public bool Save()
        {
            base.Mode = (clsPeople.enMode)_Mode;
            if(base .Save() )
            {
                switch(_Mode)
                {
                    case enMode.enUpdate:
                        if(_UpdateUser())
                            return true;
                        return false;

                    case enMode.enAdd:
                        if (_AddNewUser())
                        {
                            _Mode = enMode.enUpdate;
                            return true;
                        }
                        return false;
                }
            }return false;
        }
        public static bool UpdateUserPassword(int userID,string userName, string Password)
        {
            return clsUserData.UpdateUserPassword(userID, userName, Password); 
        }
        public static bool isUserExistByUserNameAndPassword(string userName, string Password)
        {
            return clsUserData.isUserExistByIDAndPassword(userName, Password);
        }
        public static DataTable getAllUser()
        {
            return clsUserData.GetAllUsers();
        }
        public static bool DeleteUser(int UserID)
        {
            return clsUserData.DelteUser(UserID);
        }
        public static bool isUserNameExist(string userName)
        {
            return clsUserData.isUserNameExist(userName);
        }
    }
}
