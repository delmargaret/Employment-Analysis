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
            roles.AddRole(roles.CreateRole("programmer"));
            Console.WriteLine();
            roles.ShowRoles();
            #endregion

            Console.WriteLine();

            #region Projects
            Projects projects = new Projects();
            projects.AddProject(projects.CreateProject("project1", DateTimeOffset.Now, new DateTimeOffset(2018, 10, 21, 10, 15, 35, new TimeSpan(3, 0, 0))));
            projects.AddProject(projects.CreateProject("project2", DateTimeOffset.Now, new DateTimeOffset(2018, 12, 5, 13, 30, 0, new TimeSpan(3, 0, 0))));
            projects.ShowProjects();
            #endregion

            Console.WriteLine();

            #region Employees
            Employees employees = new Employees();
            employees.AddEmployee(employees.RegisterEmployee("Margo", "Delikatnaya", "Mihailovna", "hello@mail.ru", "123456"));
            employees.AddEmployee(employees.RegisterEmployee("Vasya", "Ivanov", "Olegovich", "world@mail.ru", "9876543"));
            employees.ShowEmployees();
            var result = employees.GetEmployeeByName("Margo");
            Console.WriteLine(result.Email);
            employees.ChangeEmployeeName(1, "Olya");
            employees.ShowEmployees();
            //employees.AddPhoneNumber(1, "+1254893");
            employees.ShowEmployees();
            #endregion

            Console.WriteLine();

            #region ProjectWork
            ProjectWork work = new ProjectWork();
            work.AddProjectWork(work.CreateProjectWork(projects.GetProjectByName("project1"), employees.GetEmployeeByName("Vasya"), roles.GetRoleByName("manager"), 80));
            work.AddProjectWork(work.CreateProjectWork(projects.GetProjectByName("project1"), employees.GetEmployeeByName("Olya"), roles.GetRoleByName("programmer"), 60));
            work.AddProjectWork(work.CreateProjectWork(projects.GetProjectByName("project2"), employees.GetEmployeeByName("Vasya"), roles.GetRoleByName("designer"), 20));
            work.ShowAllWork();
            foreach (var name in work.GetNamesOnProject("project1"))
            {
                Console.WriteLine(name);
            }
            foreach (var person in work.GetNamesAndLoadOnProject("project1"))
            {
                Console.WriteLine(person.Employee.EmployeeName + " " + person.Role.RoleName + " " + person.WorkLoad+"%");
            }
            foreach (var person in work.GetEmployeeWorkLoad("Vasya"))
            {
                Console.WriteLine(person.Project.ProjectName + " " + person.Role.RoleName + " " + person.WorkLoad + "%");
            }
            #endregion
        }
    }
}
