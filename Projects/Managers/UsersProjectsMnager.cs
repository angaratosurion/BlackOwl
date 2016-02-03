using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackCogs;
using BlackCogs.Data.Models;
using Projects.Models;

namespace Projects.Managers
{
    public class UsersProjectsMnager
    {
        ProjectsDbContext db = new ProjectsDbContext();
        public void AddNewProjectToUser(ApplicationUser admin, Project project)
        {
            try
            {
                 if (admin != null && project != null)
                {
                    UsersProjects userporj = new UsersProjects();
                    userporj.UserId = admin.Id;
                    userporj.ProjectsId = project.Id;
                    db.UsersProjects.Add(userporj);
                    db.SaveChanges();
                    
                }
            }
            catch (Exception ex) { CommonTools.ErrorReporting(ex); }
        }
    }
}
