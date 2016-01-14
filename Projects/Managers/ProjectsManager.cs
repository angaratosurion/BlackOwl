using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackCogs;
using BlackCogs.Data.Models;
using BlackOwl.Core.Managers;
using MultiPlex.Core.Data.Models;
//using MultiPlex.Core.Managers;
using Projects.Models;

namespace Projects.Managers
{
    public class ProjectsManager
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        ProjectUserManager usrmng = new ProjectUserManager();
        MultiPlex.Core.Managers.WikiManager wkmngr = new MultiPlex.Core.Managers.WikiManager();
        PluginManager plugmanger = new PluginManager();
        BlackOwl.Core.Managers.FileManager filemngr = new BlackOwl.Core.Managers.FileManager();
        ReleasesManager relmngr = new ReleasesManager();
        //ProjectFileManager projfilemngr = new ProjectFileManager();
        BugManager bugmngr = new BugManager();
        ChangeLogManager chgMngr = new ChangeLogManager();
        ProjectNewsManager newMngr = new ProjectNewsManager();
        public List<Project> List()
        {
            try
            {
                List<Project> ap = null;

                ap = db.Projecs.ToList();
                return ap;

            }
            catch (Exception ex)
            {
                return null;

            }

        }
        public void Create(Project project,string  user)
        {
            try
            {

                if (project != null && CommonTools.isEmpty(user) == false
                   && usrmng.UserExists(user) == true)
                {
                    Wiki wk = new Wiki();
                    wk.Name = project.Name;
                    wk.WikiTitle = project.Name;
                    wk.Administrator = usrmng.GetUser(user);
                    wk.Moderators = new List<ApplicationUser>();
                    wk.Moderators.Add(wk.Administrator);
                    wkmngr.CreateWiki(wk);
                    project.Admininstrator= usrmng.GetUser(user);
                    project.Wiki = wk;
                    db.Projecs.Add(project);
                    db.SaveChanges();
                    string path = Path.Combine(plugmanger.GetPluginFilesRelativeDir("Projects"), project.Name);
                    FileManager.CreateDirectory(path);

                }

                

               

            }
            catch (Exception ex)
            {
                CommonTools.ErrorReporting(ex); 

            }



        }
        public Project GetProjectById(int  id)
        {
            try
            {
                Project ap = null;

                 if ( id >=0)
                {
                  ap = db.Projecs.Find(id);
                }


                return ap;

            }
            catch (Exception ex)
            {
                CommonTools.ErrorReporting(ex);
                return null;

            }
        }
        public void Edit(Project project)
        {
            try
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                CommonTools.ErrorReporting(ex);

            }
        }
        public void Delete(int id,string user)
        {
            try
            {
                Project proj;
                Wiki wk;
                if ( id >=0 )
                {
                    proj = this.GetProjectById(id);
                    if ( proj !=null && usrmng.UserHasAccessToProject(usrmng.GetUser(user), proj, true) == true)
                    {
                        string path = Path.Combine(plugmanger.GetPluginFilesRelativeDir("Projects"), proj.Name);
                        if ( proj.Wiki !=null && proj.Wiki.Name !=null)
                        {
                            this.wkmngr.DeleteWiki(proj.Wiki.Name);
                        }
                        this.relmngr.DeleteByProjectId(id);
                        this.bugmngr.DeleteByProjectId(id);
                        this.chgMngr.DeleteByProjectId(id);
                        this.newMngr.DeleteByProjectId(id);

                        db.Projecs.Remove(proj);
                        db.SaveChanges();
                        FileManager.DeleteDirectory(path);
                    }

                }

            }
            catch (Exception ex) { CommonTools.ErrorReporting(ex); }
        }

    }
}
