using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace App
{
    class ProjectRoles
    {
        public int ProjectRoleId { get; set; }
        public string ProjectRoleName { get; set; }
        public static List<ProjectRoles> ProjectRolesList = new List<ProjectRoles>();

        public ProjectRoles() { }

        public ProjectRoles(int id, string name)
        {
            this.ProjectRoleId = id;
            this.ProjectRoleName = name;
        }

        public ProjectRoles CreateRole(int id, string rolename)
        {
            ProjectRoles role = new ProjectRoles(id, rolename);
            ProjectRolesList.Add(role);
            return role;
        }

        public List<ProjectRoles> RemoveRoleByName(string name)
        {
            ProjectRolesList.RemoveAll(item => item.ProjectRoleName == name);
            return ProjectRolesList;
        }

        public List<ProjectRoles> RemoveRoleById(int id)
        {
            ProjectRolesList.RemoveAll(item => item.ProjectRoleId == id);
            return ProjectRolesList;
        }

        public List<ProjectRoles> RemoveAllRoles()
        {
            ProjectRolesList.RemoveRange(0, ProjectRolesList.Count());
            return ProjectRolesList;
        }

        public void ChangeRoleName(int roleid, string newname)
        {
            ProjectRolesList.Find(item => item.ProjectRoleId == roleid).ProjectRoleName = newname;
        }

        public List<ProjectRoles> GetAllRoles()
        {
            return ProjectRolesList;
        }

        public ProjectRoles GetRoleByName(string name)
        {
            return ProjectRolesList.Find(item => item.ProjectRoleName == name);
        }

        public static ProjectRoles GetRoleById(int projectroleid)
        {
            return ProjectRolesList.Find(item => item.ProjectRoleId == projectroleid);
        }

        public void ShowRoles()
        {
            foreach(var role in ProjectRolesList)
            {
                Console.WriteLine("id: " + role.ProjectRoleId + " name: " + role.ProjectRoleName);
            }
        }
    }
}
