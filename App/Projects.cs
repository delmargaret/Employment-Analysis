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
        public List<Projects> ProjectList = new List<Projects>();

        public Projects() { }

        public Projects(int id, string name, DateTimeOffset startdate, DateTimeOffset enddate)
        {
            this.ProjectId = id;
            this.ProjectName = name;
            this.ProjectStartDate = startdate;
            this.ProjectEndDate = enddate;
        }

        public Projects CreateProject(string projectname, DateTimeOffset startdate, DateTimeOffset enddate)
        {
            ProjectId++; //------------?
            ProjectName = projectname;
            ProjectStartDate = startdate;
            if (enddate < DateTimeOffset.Now)
            {
                Console.WriteLine("incorrect end date"); //------------?
                return null;
            }
            if (enddate < startdate)
            {
                Console.WriteLine("incorrect end date");
                return null;
            }
            ProjectEndDate = enddate;
            return new Projects(ProjectId, ProjectName, ProjectStartDate, ProjectEndDate);
        }

        public List<Projects> AddProject(Projects project)
        {
            if (project == null) //------------?
            {
                ProjectId--;
                return ProjectList;
            }
            ProjectList.Add(project);
            return ProjectList;
        }

        public List<Projects> RemoveProjectByName(string name)
        {
            Projects result = new Projects();
            foreach (var project in ProjectList)
            {
                if (project.ProjectName == name)
                {
                    result = project;
                    break;
                }
            }
            ProjectList.Remove(result);
            return ProjectList;
        }

        public List<Projects> RemoveProjectById(int id)
        {
            ProjectList.RemoveAt(--id);
            return ProjectList;

        }

        public void ShowProjects()
        {
            foreach (var project in ProjectList)
            {
                Console.WriteLine("id: " + project.ProjectId + " name: " + project.ProjectName
                + "\nstart date: " + project.ProjectStartDate.ToString() + " end date: " + project.ProjectEndDate.ToString());
            }
        }
    }
}
