using System.Linq;

namespace EElections.Helpers
{
    public static class DataValidator
    {
        public static bool IsValidPassword(string password)
        {
            password = password.Trim();
#if !DEBUG

            if (string.IsNullOrEmpty(password))
            {
                return false;
            }

            //  check if password contain a letter a symbol, a number
            if (password.Any(ch => char.IsLetter(ch)) == false)
            {
                return false;
            }

            if (password.Any(ch => char.IsDigit(ch)) == false)
            {
                return false;
            } 
#endif

            return true;
        }

        public static bool IsValidPassword(string password, string passwordConfirm)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(passwordConfirm))
            {
                return false;
            }
            if (password.Length > 25)
            {
                return false;
            }
            if (!password.Equals(passwordConfirm, System.StringComparison.Ordinal))
            {
                return false;
            }
            return true;
        }

        public static bool IsValidUserName(string userName)
        {
            userName = userName.Trim();
            if (string.IsNullOrEmpty(userName))
            {
                return false;
            }
            if (userName.Contains(" "))
            {
                return false;
            }
            // must have atleast one letter.
            if (!userName.Any(c => char.IsLetter(c)))
            {
                return false;
            }
            return true;
        }

        public static bool IsValidFullName(string name)
        {
            name = name.Trim();
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }
            if (name.Length > 25)
            {
                return false;
            }
            return true;
        }
    }
}
