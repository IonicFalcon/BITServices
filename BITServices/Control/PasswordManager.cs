using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITServices.Control
{
    class PasswordManager
    {
        public static string GenerateSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt();
        }

        public static string HashPassword(string pass)
        {
            return BCrypt.Net.BCrypt.HashPassword(pass);
        }

        public static bool VerifyPassword(string knownHash, string unknownHash)
        {
            return BCrypt.Net.BCrypt.Verify(knownHash, unknownHash);
        }

        public static bool CheckPasswordRules(string password, string checkPassword)
        {
            if(password != checkPassword)
            {
                return false;
            }

            if(password == null || checkPassword == null)
            {
                return false;
            }

            if(password.Length < 8)
            {
                return false;
            }
            
            return true;
        }
    }
}
