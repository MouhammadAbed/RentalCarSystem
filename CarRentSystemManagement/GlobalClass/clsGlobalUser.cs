using CarRentalBusinessLayer;
using Microsoft.Win32;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CarRentSystemManagement.GlobalClass
{
    public class clsGlobalUser
    {
        public static clsUser CurrentUser;

        /// <summary>
        /// Save user name and Password to the project Directory file 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public static bool RememberUserNamePassword(string userName,string Password)
        {
            try
            {
                string directory = Directory.GetCurrentDirectory();
                string FilePath = directory + "\\Data.txt";

                if (userName == "" && Directory.Exists(directory))
                {
                    File.Delete(directory);
                    return true;
                }

                string DataToSave = userName + "#//#" + Password;
                using(StreamWriter write  = new StreamWriter(FilePath))
                {
                    write.WriteLine(DataToSave);
                }
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                clsEventLogEntry.SaveEventToEventLogEntry(ex.Message, clsEventLogEntry.enEventLogEntry.enError);
                return false;
            }
        }

        /// <summary>
        /// Get stored credential from project directory file
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool getStoredCredential(ref string userName,ref string password)
        {
            try
            {
                string directory = Directory.GetCurrentDirectory();
                string FilePath = directory + "\\Data.txt";
                if (File.Exists(FilePath))
                {
                    using(StreamReader read = new StreamReader(FilePath))
                    {
                        string line = "";
                        while ((line = read.ReadLine()) != null)
                        {
                            string[] Result = line.Split(new string[] { "#//#" }, StringSplitOptions.None);
                            userName = Result[0];
                            password = Result[1];
                        }
                        
                    }
                    return true;
                }
                else
                    return false;
            }
            catch ( Exception ex )
            {
                Console.WriteLine(ex.Message);
                clsEventLogEntry.SaveEventToEventLogEntry(ex.Message, clsEventLogEntry.enEventLogEntry.enError);

                return false;
            }
        }
        /// <summary>
        /// Save user name and password to widnow registry
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool RememberUserNameAndPasswrod(string userName,string password)
        {
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\CarRentalManagementSystem";
            string ValueName = "StoredCredential";
            string ValueData = userName + "#//#"+password;
            try
            {
                if (userName == "")
                {
                    using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                    {
                        string path= @"SOFTWARE\CarRentalManagementSystem";
                        using (RegistryKey key = Registry.CurrentUser.OpenSubKey(path, true))
                        {
                            if (key != null)
                            {
                                key.DeleteValue(ValueName);
                            }
                        }
                    }
                }
                else
                    Registry.SetValue(keyPath, ValueName, ValueData, RegistryValueKind.String);

                return true;
            }
            catch (Exception ex)
            {
                clsEventLogEntry.SaveEventToEventLogEntry(ex.Message, clsEventLogEntry.enEventLogEntry.enError);
                return false;
            }
        }
        public static bool GetSortedCredentialFromWindowRegistry(ref string userName,ref string password)
        {
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\CarRentalManagementSystem";
            string ValueName = "StoredCredential";

            try
            {
                string value= Registry.GetValue(keyPath, ValueName, null)as string;
                if (value == null)
                {
                    userName = "";
                    password = "";

                }
                else
                {
                    string[] Result = value.Split(new string[] { "#//#" }, StringSplitOptions.None);
                    userName = Result[0];
                    password = Result[1];
                }
                return true;
            }
            catch(Exception ex)
            {
                clsEventLogEntry.SaveEventToEventLogEntry(ex.Message, clsEventLogEntry.enEventLogEntry.enError);
                return false;
            }
        }

    }
}
