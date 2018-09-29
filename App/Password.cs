using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class Password
    {
        public int PasswordId { get; set; }
        public string PasswordString { get; set; }
        public Employees Employee { get; set; }
        public List<Password> PasswordList = new List<Password>();

        public Password() { }

        public Password(int id, Employees employee, string password)
        {
            this.PasswordId = id;
            this.PasswordString = password;
            this.Employee = employee;
        }

        public Password CreatePassword(int id, int employeeid, string password)
        {
            Password createdpassword = new Password(id, Employees.GetEmployeeById(employeeid), password);
            PasswordList.Add(createdpassword);
            return createdpassword;
        }

        public Password ChangePassword(int id, int employeeid, string newpassword)
        {
            Password oldpassword = PasswordList.FindLast(item => item.Employee.EmployeeId == employeeid);
            if (oldpassword.PasswordString == newpassword)
            {
                Console.WriteLine("This password has already been used");
                return null;
            }
            else
            {
                Password changedpassword = new Password(id, Employees.GetEmployeeById(employeeid), newpassword);
                PasswordList.Add(changedpassword);
                return changedpassword;
            }
        }

        public void ShowPasswords()
        {
            foreach (var password in PasswordList)
            {
                Console.WriteLine("name: " + password.Employee.EmployeeName + " password: " + password.PasswordString);
            }
        }
    }
}
