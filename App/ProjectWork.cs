using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class ProjectWork
    {
        public int ProjectWorkId { get; set; }
        public Projects Project { get; set; }
        public Employees Employee { get; set; }
        public Roles Role { get; set; }
        public int WorkLoad { get; set; }
        public List<ProjectWork> ProjectWorkList = new List<ProjectWork>();

        public ProjectWork() { }

        public ProjectWork(int id, Projects project, Employees employee, Roles role, int workload)
        {
            this.ProjectWorkId = id;
            this.Project = project;
            this.Employee = employee;
            this.Role = role;
            this.WorkLoad = workload;
        }

        public ProjectWork CreateProjectWork(int id, Projects project, Employees employee, Roles role, int workload)
        {
            ProjectWorkId = id;
            Project = project;
            Employee = employee;
            Role = role;
            WorkLoad = workload;
            return new ProjectWork(ProjectWorkId, Project, Employee, Role, WorkLoad);
        }

        public List<ProjectWork> AddProjectWork(ProjectWork work)
        {
            ProjectWorkList.Add(work);
            return ProjectWorkList;
        }

        //+change methods
        //+remove methods

        public List<ProjectWork> GetProjectWork()
        {
            return ProjectWorkList;
        }

        public List<string> GetNamesOnProject(string projectname)
        {
            List<string> ListOfNames = new List<string>();
            foreach(var work in ProjectWorkList)
            {
                if (work.Project.ProjectName == projectname)
                {
                    ListOfNames.Add(work.Employee.EmployeeName);
                }
            }
            return ListOfNames;
        }

        public List<ProjectWork> GetNamesAndLoadOnProject(string projectname)
        {
            List<ProjectWork> ListOfNames = new List<ProjectWork>();
            foreach (var work in ProjectWorkList)
            {
                if (work.Project.ProjectName == projectname)
                {
                    ListOfNames.Add(work);
                }
            }
            return ListOfNames;
        }

        public List<ProjectWork> GetEmployeeWorkLoad(string employeename)
        {
            List<ProjectWork> ListOfProjects = new List<ProjectWork>();
            foreach (var work in ProjectWorkList)
            {
                if (work.Employee.EmployeeName == employeename)
                {
                    ListOfProjects.Add(work);
                }
            }
            return ListOfProjects;

        }

        public void ShowAllWork()
        {
            foreach (var work in ProjectWorkList)
            {
                Console.WriteLine("id: " + work.ProjectWorkId + " Project: " + work.Project.ProjectName
                + " Employee: " + work.Employee.EmployeeName + " Role: " + work.Role.RoleName + " Work Load: " + work.WorkLoad+"%");
            }
        }
    }
}
