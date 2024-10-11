using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika4Kurs.Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public static Role Of(string name) => new Role { RoleName = name };
        [NotMapped]
        public List<Role> Roles
        {
            get
            {
                var roles = Navigator.db.Roles.ToList();
                return roles;
            }
        }
    }
}
