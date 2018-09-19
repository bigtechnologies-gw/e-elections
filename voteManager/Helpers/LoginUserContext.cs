using System;

namespace VoteManager.Helpers
{
    public class LoginUserContext
    {
        public voteAppEntities VoteDbContext { get; set; }

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
