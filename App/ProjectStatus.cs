using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class ProjectStatus
    {
        public int ProjectStatusId { get; protected set; }
        public string ProjectStatusName { get; protected set; }
        public static List<ProjectStatus> ProjectStatusList = new List<ProjectStatus>();

        public ProjectStatus() { }

        ProjectStatus(int id, string rolename)
        {
            ProjectStatusId = id;
            ProjectStatusName = rolename;
        }

        public static List<ProjectStatus> CreateProjectStatus()
        {
            ProjectStatus opened = new ProjectStatus(0, "Opened");
            ProjectStatus closed = new ProjectStatus(1, "Closed");
            ProjectStatusList.Add(opened);
            ProjectStatusList.Add(closed);
            return ProjectStatusList;
        }

        public static ProjectStatus GetProjectStatusById(int id)
        {
            return ProjectStatusList.Find(item => item.ProjectStatusId == id);
        }
    }
}
