namespace voteManager
{
    public static class DataValidator
    {
        public static bool IsValidPassword(string password)
        {
            password = password.Trim();
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }
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
            return true;
        }

        public static bool IsValidName(string name)
        {
            name = name.Trim();
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }
            return true;
        }
    }
}
