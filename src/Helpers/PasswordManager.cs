using System;
using System.Security.Cryptography;
using System.Text;

namespace CarServiceApp.Helpers
{
    public static class PasswordManager
    {
        public static string GetPassHash(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                throw new Exception("Login or password is null or empty.");
            }

            using (MD5CryptoServiceProvider hasher = new MD5CryptoServiceProvider())
            {
                byte[] dataBytes = Encoding.Unicode.GetBytes(login + password);
                byte[] byteHash = hasher.ComputeHash(dataBytes);

                string resultHash = string.Empty;

                foreach (byte b in byteHash)
                    resultHash += string.Format("{0:x2}", b);

                return resultHash;
            }
        }
    }
}
