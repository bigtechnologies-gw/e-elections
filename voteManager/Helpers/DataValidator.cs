namespace voteManager
{
    public static class DataValidator
    {
        public static bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return false;
            }
            return true;
        }

        public static bool IsValidUserName(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                return false;
            }
            return true;
        }

        public static bool IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }
            return true;
        }
    }
}
