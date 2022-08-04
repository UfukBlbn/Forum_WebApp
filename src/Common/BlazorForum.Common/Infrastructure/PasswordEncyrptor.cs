using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForum.Common.Infrastructure
{
    public class PasswordEncyrptor
    {

        public static string Encyrpt(string password)
        {
            using var md5 = MD5.Create();

            //convert to byte array
            byte[] inputBytes = Encoding.ASCII.GetBytes(password);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes);

        }


    }
}
