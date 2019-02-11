using System;

namespace EElections.Helpers
{
    public class LoginUserContext
    {
        /// <summary>
        /// User ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        public string Name { get; set; }

        public voteAppEntities VoteDbContext { get; set; }

        public DateTime LoginTime { get; set; }

        // NOT UPDATING IN DATABASE WHEN SAVECHANGES
        //public User User { get; set; }

        public string MachineName { get; set; }

        public LoginUserContext()
        {
            LoginTime = DateTime.Now;
            MachineName = Environment.MachineName;
        }
    }
}
