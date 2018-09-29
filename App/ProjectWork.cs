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
        public ProjectRoles Role { get; set; }
        public int WorkLoad { get; set; }
        public Schedule schedule { get; set; }
        public ScheduleDays scheduleday { get; set; }
        public List<ProjectWork> ProjectWorkList = new List<ProjectWork>();

        public ProjectWork() { }

        public ProjectWork(int id, Projects project, Employees employee, ProjectRoles role, int workload)
        {
            this.ProjectWorkId = id;
            this.Project = project;
            this.Employee = employee;
            this.Role = role;
            this.WorkLoad = workload;
            this.schedule = null;
        }

        public ProjectWork(int id, Projects project, Employees employee, ProjectRoles role, ScheduleDays scheduleday)
        {
            this.ProjectWorkId = id;
            this.Project = project;
            this.Employee = employee;
            this.Role = role;
            this.scheduleday = scheduleday;
            this.WorkLoad = -1;
        }

        public ProjectWork CreateProjectWorkWithWorkLoad(int id, int projectid, int employeeid, int projectroleid, int workload)
        {
            ProjectWork projectwork = new ProjectWork(id, Projects.GetProjectById(projectid), Employees.GetEmployeeById(employeeid),
            ProjectRoles.GetRoleById(projectroleid), workload);
            ProjectWorkList.Add(projectwork);
            return projectwork;
        }

        public ProjectWork CreateProjectWorkWithSchedule(int id, int projectid, int employeeid, int projectroleid, int scheduleid)
        {
            Schedule schedule = Schedule.CreateSchedule(scheduleid, scheduleid);
            ScheduleDays scheduleday = new ScheduleDays();
            ProjectWork projectwork = new ProjectWork(id, Projects.GetProjectById(projectid), Employees.GetEmployeeById(employeeid),
            ProjectRoles.GetRoleById(projectroleid), scheduleday);
            ProjectWorkList.Add(projectwork);
            return projectwork;
        }

        //public void AddDay(int id, int scheduleid, int dayid)
        //{
        //    ProjectWorkList.Find(item => item.schedule.ScheduleId == scheduleid).scheduleday.CreateScheduleDay(id, scheduleid, dayid); //?????????
        //}

        public void ChangeProject(int workid, int projectid)
        {
            ProjectWorkList.Find(item => item.ProjectWorkId == workid).Project = Projects.GetProjectById(projectid);
        }

        public void ChangeEmployee(int workid, int employeeid)
        {
            ProjectWorkList.Find(item => item.ProjectWorkId == workid).Employee = Employees.GetEmployeeById(employeeid);
        }

        public void ChangeRole(int workid, int roleid)
        {
            ProjectWorkList.Find(item => item.ProjectWorkId == workid).Role = ProjectRoles.GetRoleById(roleid);
        }

        public void ChangeWorkLoad(int workid, int workload)
        {
            ProjectWorkList.Find(item => item.ProjectWorkId == workid).WorkLoad = workload;
        }

        public List<ProjectWork> RemoveWorkById(int workid)
        {
            ProjectWorkList.RemoveAll(item => item.ProjectWorkId == workid);
            return ProjectWorkList;
        }

        public void RemoveSchedule(int scheduleid)
        {
            ProjectWorkList.RemoveAll(item => item.schedule.ScheduleId == scheduleid);
        }

        public List<ProjectWork> RemoveWorkByProjectName(string projectname)
        {
            ProjectWorkList.RemoveAll(item => item.Project.ProjectName == projectname);
            return ProjectWorkList;
        }

        public List<ProjectWork> RemoveEmployeeFromProject(string projectname, int employeeid)
        {
            ProjectWorkList.RemoveAll(item => item.Project.ProjectName == projectname
            && item.Employee.EmployeeId == employeeid);
            return ProjectWorkList;
        }

        public List<ProjectWork> GetAllProjectWork()
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

        public List<ProjectWork> GetEmployeesProjects(string employeename)
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
                if (work.WorkLoad == -1)
                {
                    Console.WriteLine("id: " + work.ProjectWorkId + " Project: " + work.Project.ProjectName
                    + " Employee: " + work.Employee.EmployeeName + " Role: " + work.Role.ProjectRoleName + " Schedule: ");
                    foreach(var day in ScheduleDays.GetAllScheduleDaysById(work.schedule.ScheduleId))
                    {
                        Console.Write(day.days.DayName+" ");
                    }
                }
                else
                {
                    Console.WriteLine("id: " + work.ProjectWorkId + " Project: " + work.Project.ProjectName
                    + " Employee: " + work.Employee.EmployeeName + " Role: " + work.Role.ProjectRoleName + " Work Load: " + work.WorkLoad + "%");
                }
            }
        }
    }
}
