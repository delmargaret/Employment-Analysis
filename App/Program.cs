using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Roles
            Roles roles = new Roles();
            roles.AddRole(roles.CreateRole("manager"));
            roles.AddRole(roles.CreateRole("designer"));
            roles.ShowRoles();
            roles.RemoveRoleByName("designer");
            Console.WriteLine();
            roles.ShowRoles();
            #endregion
        }
    }
}
