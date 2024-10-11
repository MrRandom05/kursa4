using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika4Kurs.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Login {  get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public int RoleRoleId { get; set; }

        public static User Of(string login, string password, Role role) => new User { Login = login, Password = password, Role = role };

    }
}
