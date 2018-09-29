using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class Employees
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string EmployeePatronymic { get; set; }
        public string Email { get; set; } //регулярные выражения?
        public string GitLink { get; set; } 
        public string PhoneNumber { get; set; }
        public Roles Role { get; set; }
        public static List<Employees> EmployeeList = new List<Employees>();

        public Employees() { }

        public Employees(int id, string name, string surname, string patronymic, string email, Roles role, string gitlink, string phonenumber)
        {
            this.EmployeeId = id;
            this.EmployeeName = name;
            this.EmployeeSurname = surname;
            this.EmployeePatronymic = patronymic;
            this.Email = email;
            this.GitLink = gitlink;
            this.PhoneNumber = phonenumber;
            this.Role = role;
        }

        public Employees RegisterEmployee(int id, string name, string surname, string patronymic, string email, int roleid, string gitlink="", string phonenumber="")
        {
            Roles.CreateRoles();
            Employees employee = new Employees(id, name, surname, patronymic, email, Roles.GetRoleById(roleid), gitlink, phonenumber);
            EmployeeList.Add(employee);
            return employee;
        }

        public List<Employees> RemoveEmployeeByName(string name, string surname)
        {
            EmployeeList.RemoveAll(item => item.EmployeeName == name && item.EmployeeSurname == surname);
            return EmployeeList;
        }

        public List<Employees> RemoveEmployeeById(int id)
        {
            EmployeeList.RemoveAll(item => item.EmployeeId == id);
            return EmployeeList;
        }

        public List<Employees> RemoveAllEmployees()
        {
            EmployeeList.RemoveRange(0, EmployeeList.Count());
            return EmployeeList;
        }

        public Employees GetEmployeeByName(string name)
        {
            return EmployeeList.Find(item => item.EmployeeName == name);
        }

        public static Employees GetEmployeeById(int employeeid)
        {
            return EmployeeList.Find(item => item.EmployeeId == employeeid);
        }

        public List<Employees> GetAllEmployees()
        {
            return EmployeeList;
        }

        public void AddPhoneNumber(int employeeid, string phonenumber)
        {
            EmployeeList.Find(item => item.EmployeeId == employeeid).PhoneNumber = phonenumber;
        }

        public void ChangePhoneNumber(int employeeid, string newphonenumber)
        {
            EmployeeList.Find(item => item.EmployeeId == employeeid).PhoneNumber = newphonenumber;
        }

        public void RemovePhoneNumberByEmployeeName(string name, string surname)
        {
            EmployeeList.Find(item => item.EmployeeName == name && item.EmployeeSurname == surname).PhoneNumber = "";
        }

        public void RemovePhoneNumberByEmployeeId(int id)
        {
            EmployeeList.Find(item => item.EmployeeId == id).PhoneNumber = "";
        }

        public void AddGitLink(int employeeid, string gitlink)
        {
            EmployeeList.Find(item => item.EmployeeId == employeeid).GitLink = gitlink;
        }

        public void ChangeGitLink(int employeeid, string newgitlink)
        {
            EmployeeList.Find(item => item.EmployeeId == employeeid).GitLink = newgitlink;
        }

        public void RemoveGitLinkByEmployeeName(string name, string surname)
        {
            EmployeeList.Find(item => item.EmployeeName == name && item.EmployeeSurname == surname).GitLink = "";
        }

        public void RemoveGitLinkByEmployeeId(int id)
        {
            EmployeeList.Find(item => item.EmployeeId == id).GitLink = "";
        }

        public void ChangeEmployeesRole(int employeeid, int roleid)
        {
            EmployeeList.Find(item => item.EmployeeId == employeeid).Role = Roles.GetRoleById(roleid);
        }

        public void ChangeEmployeeName(int employeeid, string newname)
        {
            EmployeeList.Find(item => item.EmployeeId == employeeid).EmployeeName = newname;
        }

        public void ChangeEmployeeSurname(int employeeid, string newsurname)
        {
            EmployeeList.Find(item => item.EmployeeId == employeeid).EmployeeSurname = newsurname;
        }

        public void ChangeEmployeePatronymic(int employeeid, string newpatronymic)
        {
            EmployeeList.Find(item => item.EmployeeId == employeeid).EmployeePatronymic = newpatronymic;
        }

        public void ChangeEmail(int employeeid, string newemail)
        {
            EmployeeList.Find(item => item.EmployeeId == employeeid).Email = newemail;
        }

        public void ShowEmployees()
        {
            foreach(var employee in EmployeeList)
            {
                if (employee.PhoneNumber == "" && employee.GitLink=="")
                {
                    Console.WriteLine("id: " + employee.EmployeeId + " name: " + employee.EmployeeName
                    + " e-mail: " + employee.Email + " role: " + employee.Role.RoleName);
                }
                else if (employee.GitLink == "")
                {
                    Console.WriteLine("id: " + employee.EmployeeId + " name: " + employee.EmployeeName
                    + " e-mail: " + employee.Email + " role: " + employee.Role.RoleName + " phone number: " + employee.PhoneNumber);
                }
                else if (employee.PhoneNumber == "")
                {
                    Console.WriteLine("id: " + employee.EmployeeId + " name: " + employee.EmployeeName + " e-mail: " 
                    + employee.Email + " role: " + employee.Role.RoleName + " git link: " + employee.GitLink);
                }
                else
                {
                    Console.WriteLine("id: " + employee.EmployeeId + " name: " + employee.EmployeeName + " e-mail: "
                    + employee.Email + " role: " + employee.Role.RoleName + " phone number: " + employee.PhoneNumber + " git link: " + employee.PhoneNumber);
                }
            }
        }
    }
}
