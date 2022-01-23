using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Bll
{
    public static class Extensions
    {
        public static string Md5(this string content)
        {
            return Md5(content, Encoding.UTF8);
        }

        public static string Md5(this string content, Encoding encoding)
        {
            var provider = new MD5CryptoServiceProvider();
            var data = encoding.GetBytes(content);
            var result = provider.ComputeHash(data);
            var sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                sb.Append(result[i].ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
