// Keshan Padayachee
// 20121106
// PROG 6212
// Portfolio Of Evidence
// Task 2
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTimeLibrary
{
    public class PasswordManagement
    {
        // Code Attribution
        // YouTube
        // URL : https://youtu.be/AU-4oLUV5VU

        // Creating a hex string
        public static String convertToHex(byte[] arr)
        {
            StringBuilder hex = new StringBuilder(arr.Length * 2);

            foreach (byte b in arr)
            {
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString();
        }

        // Creating the salt for the password
        public static string CreateSalt(int size)
        {
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

        // Creating the hash of the password using the salt
        public static String generateHash(String input, String salt)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input + salt);
            System.Security.Cryptography.SHA256Managed sHA256Managed = new System.Security.Cryptography.SHA256Managed();
            byte[] hash = sHA256Managed.ComputeHash(bytes);
            return convertToHex(hash);
        }
    }
}
