using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Modules
{
    class HashCoder
    {
        public static string GetHashCode(string value)
        {
            if (value.Length == 0)
                return null;

            var coder = MD5.Create();
            return BitConverter.ToString(coder.ComputeHash(Encoding.UTF8.GetBytes(value)));
        }

    }
}
