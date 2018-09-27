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

            Console.WriteLine();

            #region Projects
            Projects projects = new Projects();
            projects.AddProject(projects.CreateProject("project1", DateTimeOffset.Now, new DateTimeOffset(2018, 10, 21, 10, 15, 35, new TimeSpan(3, 0, 0))));
            projects.AddProject(projects.CreateProject("project2", DateTimeOffset.Now, new DateTimeOffset(2018, 12, 5, 13, 30, 0, new TimeSpan(3, 0, 0))));
            projects.ShowProjects();
            projects.RemoveProjectByName("project2");
            Console.WriteLine();
            projects.ShowProjects();
            #endregion
        }
    }
}
