﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace App
{
    class Roles
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public List<Roles> RolesList = new List<Roles>();

        public Roles() { }

        public Roles(int id, string name)
        {
            this.RoleId = id;
            this.RoleName = name;
        }

        public Roles CreateRole(string rolename)
        {
            RoleId++;
            RoleName = rolename;
            return new Roles(RoleId, RoleName);
        }

        public List<Roles> AddRole(Roles role)
        {
            RolesList.Add(role);
            return RolesList;
        }

        public List<Roles> RemoveRoleByName(string name)
        {
            Roles result = new Roles();
            foreach(var role in RolesList)
            {
                if (role.RoleName == name)
                {
                    result = role;
                    break;
                }
            }
            RolesList.Remove(result);
            return RolesList;
        }

        public List<Roles> RemoveRoleById(int id)
        {
            RolesList.RemoveAt(--id);
            return RolesList;
        }

        public List<Roles> RemoveAllRoles()
        {
            RolesList.RemoveRange(0, RolesList.Count());
            return RolesList;
        }

        public void ChangeRoleName(int roleid, string newname)
        {
            foreach (var role in RolesList)
            {
                if (role.RoleId == roleid)
                {
                    role.RoleName = newname;
                }
            }
        }

        public List<Roles> GetAllRoles()
        {
            return RolesList;
        }

        public Roles GetRoleByName(string name)
        {
            int id = -1;
            foreach (var role in RolesList)
            {
                if (role.RoleName == name)
                {
                    id = role.RoleId;
                }
            }
            if (id == -1)
            {
                return null;
            }
            return RolesList[--id];
        }

        public void ShowRoles()
        {
            foreach(var role in RolesList)
            {
                Console.WriteLine("id: " + role.RoleId + " name: " + role.RoleName);
            }
        }
    }
}
