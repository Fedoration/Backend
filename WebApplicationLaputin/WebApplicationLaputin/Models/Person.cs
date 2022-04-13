using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationLaputin.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Login { get; set; }
        private byte[] hashPassword;
        public string Password 
        {
            get
            {
                var sb = new StringBuilder();
                foreach (var b in new MD5CryptoServiceProvider().ComputeHash(hashPassword))
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
            set
            {
                hashPassword = Encoding.UTF8.GetBytes(value);
            }
        }
        public string Role { get; set; }
    }
}
