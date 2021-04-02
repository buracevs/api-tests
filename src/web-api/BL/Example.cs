using System;
using System.Security.Cryptography;
using System.Text;

namespace web_api.BL
{
    internal static class Example
    {
        internal static string HelloName(string name)
        {
            return $"Hello: {name}";
        }
        
        public static string GetHash(string toHash){
            if (string.IsNullOrWhiteSpace(toHash))
            {
                return null;
            }
            var md5 = new MD5CryptoServiceProvider();
            byte[] data = md5.ComputeHash(Encoding.Default.GetBytes(toHash));
            var stringBuilder = new StringBuilder();

            foreach (var character in data)
            {
                stringBuilder.Append(character.ToString("x2"));
            }

            return stringBuilder.ToString();
        }

        public static int Sum(int x, int y)
        {
            return x + y;
        }
    }

    public static class AnotherExample{

        public static string Hello1(string name)
        {
            return $"Hello: {name}";
        }
    }

}
