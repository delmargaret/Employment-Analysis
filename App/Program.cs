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
            roles.AddRole(roles.CreateRole(1, "manager"));
            roles.AddRole(roles.CreateRole(2, "designer"));
            roles.ShowRoles();
            roles.AddRole(roles.CreateRole(3, "programmer"));
            Console.WriteLine();
            roles.ShowRoles();
            var result = roles.GetRoleByName("programmer");
            Console.WriteLine(result.RoleId);
            #endregion

            Console.WriteLine();

            #region Projects
            Projects projects = new Projects();
            projects.AddProject(projects.CreateProject(1, "project1", DateTimeOffset.Now, new DateTimeOffset(2018, 10, 21, 10, 15, 35, new TimeSpan(3, 0, 0))));
            projects.AddProject(projects.CreateProject(2, "project2", DateTimeOffset.Now, new DateTimeOffset(2018, 12, 5, 13, 30, 0, new TimeSpan(3, 0, 0))));
            projects.ShowProjects();
            var result1 = projects.GetProjectByName("project1");
            Console.WriteLine(result1.ProjectId);
            projects.AddProject(projects.CreateProject(3, "project3", DateTimeOffset.Now, new DateTimeOffset(2018, 11, 18, 12, 0, 0, new TimeSpan(3, 0, 0))));
            #endregion

            Console.WriteLine();

            #region Employees
            Employees employees = new Employees();
            employees.AddEmployee(employees.RegisterEmployee(1, "Margo", "Delikatnaya", "Mihailovna", "hello@mail.ru", "123456"));
            employees.AddEmployee(employees.RegisterEmployee(2, "Vasya", "Ivanov", "Olegovich", "world@mail.ru", "9876543"));
            employees.ShowEmployees();
            var result2 = employees.GetEmployeeByName("Margo");
            Console.WriteLine(result2.Email);
            employees.ChangeEmployeeName(1, "Olya");
            employees.ShowEmployees();
            employees.AddPhoneNumber(1, "+1254893");
            employees.ShowEmployees();
            employees.RemovePhoneNumberByEmployeeName("Olya", "Delikatnaya");
            employees.ShowEmployees();
            #endregion

            Console.WriteLine();

            #region ProjectWork
            ProjectWork work = new ProjectWork();
            work.AddProjectWork(work.CreateProjectWork(1, projects.GetProjectByName("project1"), employees.GetEmployeeByName("Vasya"), roles.GetRoleByName("manager"), 80));
            work.AddProjectWork(work.CreateProjectWork(2, projects.GetProjectByName("project1"), employees.GetEmployeeByName("Olya"), roles.GetRoleByName("programmer"), 60));
            work.AddProjectWork(work.CreateProjectWork(3, projects.GetProjectByName("project2"), employees.GetEmployeeByName("Vasya"), roles.GetRoleByName("designer"), 20));
            work.ShowAllWork();
            foreach (var name in work.GetNamesOnProject("project1"))
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();
            foreach (var person in work.GetNamesAndLoadOnProject("project1"))
            {
                Console.WriteLine(person.Employee.EmployeeName + " " + person.Role.RoleName + " " + person.WorkLoad + "%");
            }
            Console.WriteLine();
            foreach (var person in work.GetEmployeeWorkLoad("Vasya"))
            {
                Console.WriteLine(person.Project.ProjectName + " " + person.Role.RoleName + " " + person.WorkLoad + "%");
            }
            Console.WriteLine();
            work.ChangeProject(1, projects.GetProjectByName("project3"));
            work.ShowAllWork();
            #endregion
        }
    }
}
