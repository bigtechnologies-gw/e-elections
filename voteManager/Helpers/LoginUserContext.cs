using System;

namespace voteManager.Helpers
{
    public class LoginUserContext
    {
        public DateTime LoginTime { get; set; }

        public User User { get; set; }

        public string MachineName { get; set; }

        public LoginUserContext(User user)
        {
            User = user;
            LoginTime = DateTime.Now;
            MachineName = Environment.MachineName;
        }
    }
}
