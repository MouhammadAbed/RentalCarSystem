using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Security.Policy;

namespace CarRentSystemManagement.Global_Class
{
    public class clsUtil
    {
        public static string GenerateGUID()
        {
            Guid newGuid = Guid.NewGuid();
            return newGuid.ToString();

        }
        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message);
                    return false;
                }
            }

            return true;

        }
        public static string ReplaceFileNameWithGUID(string sourceFile)
        {
            string fileName = sourceFile;
            FileInfo fi = new FileInfo(fileName);
            string extn = fi.Extension;
            return GenerateGUID() + extn;
        }
        public static bool CopyImageToProjectImagesFolder(ref string sourceFile)
        {
            string DestinationFolder = @"C:\CarRentalManagement-Vehicle-Images\";
            if (!CreateFolderIfDoesNotExist(DestinationFolder))
            {
                return false;
            }
            string destinationFile = DestinationFolder + ReplaceFileNameWithGUID(sourceFile);
            try
            {
                File.Copy(sourceFile, destinationFile, true);

            }
            catch (IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            sourceFile = destinationFile;
            return true;
        }
        public static string ComputedHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashByte = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(hashByte).Replace("-", "").ToLower();
            }
        }
    }
}
