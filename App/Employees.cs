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
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public List<Employees> EmployeeList = new List<Employees>();

        public Employees() { }

        public Employees(int id, string name, string surname, string patronymic, string email, string password)
        {
            this.EmployeeId = id;
            this.EmployeeName = name;
            this.EmployeeSurname = surname;
            this.EmployeePatronymic = patronymic;
            this.Email = email;
            this.Password = password;
            this.PhoneNumber = "";
        }

        public Employees(int id, string name, string surname, string patronymic, string email, string password, string phonenumber)
        {
            this.EmployeeId = id;
            this.EmployeeName = name;
            this.EmployeeSurname = surname;
            this.EmployeePatronymic = patronymic;
            this.Email = email;
            this.PhoneNumber = phonenumber;
            this.Password = password;
        }

        public Employees RegisterEmployee(int id, string name, string surname, string patronymic, string email, string password, string phonenumber="")
        {
            EmployeeId = id;
            EmployeeName = name;
            EmployeeSurname = surname;
            EmployeePatronymic = patronymic;
            Email = email;
            Password = password;
            PhoneNumber = phonenumber;
            return new Employees(EmployeeId, EmployeeName, EmployeeSurname, EmployeePatronymic, Email, Password, PhoneNumber);
        }

        public List<Employees> AddEmployee(Employees employee)
        {
            EmployeeList.Add(employee);
            return EmployeeList;
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
            Employees result = new Employees();
            foreach (var employee in EmployeeList)
            {
                if (employee.EmployeeName == name)
                {
                    result = employee;
                }
            }
            return result;
        }

        public List<Employees> GetAllEmployees()
        {
            return EmployeeList;
        }

        public void AddPhoneNumber(int employeeid, string phonenumber)
        {
            foreach (var employee in EmployeeList)
            {
                if (employee.EmployeeId == employeeid)
                {
                    employee.PhoneNumber = phonenumber;
                }
            }
        }

        public void ChangePhoneNumber(int employeeid, string newphonenumber)
        {
            foreach (var employee in EmployeeList)
            {
                if (employee.EmployeeId == employeeid)
                {
                    employee.PhoneNumber = newphonenumber;
                }
            }
        }

        public void RemovePhoneNumberByEmployeeName(string name, string surname)
        {
            foreach (var employee in EmployeeList)
            {
                if (employee.EmployeeName == name && employee.EmployeeSurname == surname)
                {
                    employee.PhoneNumber = "";
                }
            }
        }

        public void RemovePhoneNumberByEmployeeId(int id)
        {
            foreach (var employee in EmployeeList)
            {
                if (employee.EmployeeId == id)
                {
                    employee.PhoneNumber = "";
                }
            }
        }

        public void ChangeEmployeeName(int employeeid, string newname)
        {
            foreach (var employee in EmployeeList)
            {
                if (employee.EmployeeId == employeeid)
                {
                    employee.EmployeeName = newname;
                }
            }
        }

        public void ChangeEmployeeSurname(int employeeid, string newsurname)
        {
            foreach (var employee in EmployeeList)
            {
                if (employee.EmployeeId == employeeid)
                {
                    employee.EmployeeSurname = newsurname;
                }
            }
        }

        public void ChangeEmployeePatronymic(int employeeid, string newpatronymic)
        {
            foreach (var employee in EmployeeList)
            {
                if (employee.EmployeeId == employeeid)
                {
                    employee.EmployeePatronymic = newpatronymic;
                }
            }
        }

        public void ChangeEmail(int employeeid, string newemail)
        {
            foreach (var employee in EmployeeList)
            {
                if (employee.EmployeeId == employeeid)
                {
                    employee.Email = newemail;
                }
            }
        }

        public void ChangePassword(int employeeid, string newpassword)
        {
            foreach (var employee in EmployeeList)
            {
                if (employee.EmployeeId == employeeid)
                {
                    employee.Password = newpassword;
                }
            }
        }

        public void ShowEmployees()
        {
            foreach(var employee in EmployeeList)
            {
                if (employee.PhoneNumber == "")
                {
                    Console.WriteLine("id: " + employee.EmployeeId + " name: " + employee.EmployeeName
                    + " e-mail: " + employee.Email + " password: " + employee.Password);
                }
                else
                {
                    Console.WriteLine("id: " + employee.EmployeeId + " name: " + employee.EmployeeName
                    + " e-mail: " + employee.Email + " password: " + employee.Password + " phone number: " + employee.PhoneNumber);
                }
            }
        }
    }
}
