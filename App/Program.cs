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
            #region ProjectRoles
            ProjectRoles projectroles = new ProjectRoles();
            projectroles.CreateRole(1, "manager");
            projectroles.CreateRole(2, "designer");
            projectroles.ShowRoles();
            projectroles.CreateRole(3, "programmer");
            Console.WriteLine();
            projectroles.ShowRoles();
            var result = projectroles.GetRoleByName("programmer");
            Console.WriteLine(result.ProjectRoleId);
            #endregion

            Console.WriteLine();

            #region Projects
            Projects projects = new Projects();
            projects.CreateProject(1, "project1", DateTimeOffset.Now, new DateTimeOffset(2018, 10, 21, 10, 15, 35, new TimeSpan(3, 0, 0)), 0);
            projects.CreateProject(2, "project2", DateTimeOffset.Now, new DateTimeOffset(2018, 12, 5, 13, 30, 0, new TimeSpan(3, 0, 0)), 0);
            projects.ShowProjects();
            var result1 = projects.GetProjectByName("project1");
            Console.WriteLine(result1.ProjectId);
            projects.CreateProject(3, "project3", DateTimeOffset.Now, new DateTimeOffset(2018, 11, 18, 12, 0, 0, new TimeSpan(3, 0, 0)), 1);
            #endregion

            Console.WriteLine();

            #region Employees
            Roles.CreateRoles();
            Employees employees = new Employees();
            employees.RegisterEmployee(1, "Margo", "Delikatnaya", "Mihailovna", "hello@mail.ru", 2);
            employees.RegisterEmployee(2, "Vasya", "Ivanov", "Olegovich", "world@mail.ru", 3);
            employees.ShowEmployees();
            var result2 = employees.GetEmployeeByName("Margo");
            Console.WriteLine(result2.Email);
            employees.ChangeEmployeeName(1, "Olya");
            employees.ShowEmployees();
            employees.AddPhoneNumber(1, "+1254893");
            employees.AddGitLink(2, "github.com/Vasya");
            employees.ShowEmployees();
            employees.RemovePhoneNumberByEmployeeName("Olya", "Delikatnaya");
            employees.ShowEmployees();
            #endregion

            Console.WriteLine();

            #region Password
            Password password = new Password();
            password.CreatePassword(1, 1, "12345678");
            password.ShowPasswords();
            #endregion

            Console.WriteLine();

            #region ProjectWork
            ProjectWork work = new ProjectWork();
            work.CreateProjectWorkWithWorkLoad(1, 1, 2, 1, 80);
            work.CreateProjectWorkWithSchedule(2, 1, 1, 3, 1);
            work.CreateProjectWorkWithWorkLoad(3, 2, 2, 2, 20);
            //work.AddDay(1, 1, 2);
            //work.AddDay(2, 1, 4);
            work.ShowAllWork();
            foreach (var name in work.GetNamesOnProject("project1"))
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();
            foreach (var person in work.GetNamesAndLoadOnProject("project1"))
            {
                Console.WriteLine(person.Employee.EmployeeName + " " + person.Role.ProjectRoleName + " " + person.WorkLoad + "%");
            }
            Console.WriteLine();
            foreach (var person in work.GetEmployeesProjects("Vasya"))
            {
                Console.WriteLine(person.Project.ProjectName + " " + person.Role.ProjectRoleName + " " + person.WorkLoad + "%");
            }
            Console.WriteLine();
            work.ChangeProject(1, 3);
            work.ShowAllWork();
            #endregion
        }
    }
}
