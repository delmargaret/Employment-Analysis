using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class Roles
    {
        public int RoleId { get; protected set; }
        public string RoleName { get; protected set; }
        public static List<Roles> RolesList = new List<Roles>();

        public Roles() { }

        Roles(int id, string rolename)
        {
            RoleId = id;
            RoleName = rolename;
        }

        public static List<Roles> CreateRoles()
        {
            Roles role1 = new Roles(1, "Resource manager");
            Roles role2 = new Roles(2, "Employee");
            Roles role3 = new Roles(3, "Project manager");
            RolesList.Add(role1);
            RolesList.Add(role2);
            RolesList.Add(role3);
            return RolesList;
        }

        public static Roles GetRoleById(int id)
        {
            return RolesList.Find(item => item.RoleId == id);
        }
    }
}
