using System;

namespace Naming.Task2
{
    public class User
    {
        private DateTime dBirth;

        private string sName;

        private bool bAdmin;

        private User[] subordinateArray;

        private int iR;

        public User(string sName)
        {
            this.sName = sName;
        }

        public override string ToString()
        {
            return "User [dBirth=" + dBirth + ", sName=" + sName + ", bAdmin=" + bAdmin + ", subordinateArray="
                   + string.Join<User>(", ", subordinateArray) + ", iRating=" + iR + "]";
        }
    }
}
