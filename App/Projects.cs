using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class Projects
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTimeOffset ProjectStartDate { get; set; }
        public DateTimeOffset ProjectEndDate { get; set; }
        public ProjectStatus Status { get; set; }
        public static List<Projects> ProjectList = new List<Projects>();

        public Projects() { }

        public Projects(int id, string name, DateTimeOffset startdate, DateTimeOffset enddate, ProjectStatus projectstatus)
        {
            this.ProjectId = id;
            this.ProjectName = name;
            this.ProjectStartDate = startdate;
            this.ProjectEndDate = enddate;
            this.Status = projectstatus;
        }

        public Projects CreateProject(int id, string projectname, DateTimeOffset startdate, DateTimeOffset enddate, int statusid)
        {
            ProjectStatus.CreateProjectStatus();
            if (enddate < DateTimeOffset.Now)
            {
                Console.WriteLine("incorrect end date");
                return null;
            }
            if (enddate < startdate)
            {
                Console.WriteLine("incorrect end date");
                return null;
            }
            Projects project = new Projects(id, projectname, startdate, enddate, ProjectStatus.GetProjectStatusById(statusid));
            ProjectList.Add(project);
            return project;
        }

        public void ChangeProjectStatus(int projectid, int statusid)
        {
            ProjectList.Find(item => item.ProjectId == projectid).Status = ProjectStatus.GetProjectStatusById(statusid);
        }

        public List<Projects> RemoveProjectByName(string name)
        {
            ProjectList.RemoveAll(item => item.ProjectName == name);
            return ProjectList;
        }

        public List<Projects> RemoveProjectById(int id)
        {
            ProjectList.RemoveAll(item => item.ProjectId == id);
            return ProjectList;
        }

        public List<Projects> RemoveAllProjects()
        {
            ProjectList.RemoveRange(0, ProjectList.Count());
            return ProjectList;
        }

        public void ChangeProjectName(int projectid, string newname)
        {
            ProjectList.Find(item => item.ProjectId == projectid).ProjectName = newname;
        }

        public void ChangeStartDate(int projectid, DateTimeOffset newstartdate)
        {
            ProjectList.Find(item => item.ProjectId == projectid).ProjectStartDate = newstartdate;
        }

        public void ChangeEndDate(int projectid, DateTimeOffset newenddate)
        {
            ProjectList.Find(item => item.ProjectId == projectid).ProjectEndDate = newenddate;
        }

        public Projects GetProjectByName(string name)
        {
            return ProjectList.Find(item => item.ProjectName == name);
        }

        public static Projects GetProjectById(int id)
        {
            return ProjectList.Find(item => item.ProjectId == id);
        }

        public List<Projects> GetAllProjects()
        {
            return ProjectList;
        }

        public void ShowProjects()
        {
            foreach (var project in ProjectList)
            {
                Console.WriteLine("id: " + project.ProjectId + " name: " + project.ProjectName
                + "\nstart date: " + project.ProjectStartDate.ToString() + " end date: " + project.ProjectEndDate.ToString()
                + " status: " + project.Status.ProjectStatusName);
            }
        }
    }
}
