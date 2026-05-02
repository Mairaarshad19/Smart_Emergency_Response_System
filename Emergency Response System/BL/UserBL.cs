using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency_Response_System.BL
{
    public class UserBL
    {
        public int user_id { get; set; }
        public string username { get; set; }
        public string password_hash { get; set; }
        public string role { get; set; } // admin/operator 

        public UserBL() { }

        public UserBL(int userId)
        {
            this.user_id = userId;
        }

        public UserBL(string name, string passwordHash, string role)
        {
            this.username = name;
            this.password_hash = passwordHash;
            this.role = role;
        }

        public UserBL(int userId, string name, string passwordHash, string role)
        {
            this.user_id = userId;
            this.username = name;
            this.password_hash = passwordHash;
            this.role = role;
        }
    }

}
