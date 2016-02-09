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
         private ApplicationDbContext db =Statics.db;
        ProjectUserManager usrmng = Statics.usrmng;
        MultiPlex.Core.Managers.WikiManager wkmngr = new MultiPlex.Core.Managers.WikiManager();
        PluginManager plugmanger = Statics.plugmanger;
        BlackOwl.Core.Managers.FileManager filemngr = new BlackOwl.Core.Managers.FileManager();
        ReleasesManager relmngr = Statics.relmngr;
        //ProjectFileManager projfilemngr = new ProjectFileManager();
        BugManager bugmngr = Statics.bugmngr;
        ChangeLogManager chgMngr = Statics.chgMngr;
        ProjectNewsManager newMngr = Statics.newMngr;
        public List<Project> List()
        {
            try
            {
                List<Project> ap = null;

                ap = db.Projects.ToList();
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
                if (usrmng == null)
                {
                    usrmng = new ProjectUserManager();
                }

                if (project != null && CommonTools.isEmpty(user) == false
                   && usrmng.UserExists(user) == true)
                {
                   
                    ApplicationUser admin = usrmng.GetUser(user);
                    if (admin != null)
                    {


                        //Wiki wk = new Wiki();
                        //wk.Name = project.Name;
                        //wk.WikiTitle = project.Name;
                        //wk.Administrator = admin;
                        //wk.Moderators = new List<ApplicationUser>();
                        //wk.Moderators.Add(admin);
                        //wkmngr.CreateWiki(wk);

                        //project.Admininstrator = admin;
                        //project.AdmininstratorId = admin.Id;
                        ApplicationUser owner = new ApplicationUser();

                        //owner.Claims = admin.Claims;
                        owner = admin.Clone();



                        project.WikiName = project.Name;
                       project.News = new List<ProjectNews>();
                        //List<FileReleases> filelst= new List<FileReleases>();
                        //project.Releases = filelst;
                        project.Members = new List<ApplicationUser>();
                        if (db == null)
                        {
                            db = new ApplicationDbContext();
                        }
                        //ProjectUser projusr = new ProjectUser();
                        project.Admininstrator = owner;
                        project.AdmininstratorId = owner.Id;
                        //project.Admininstrator = admin;
                        //  db.Configuration.ValidateOnSaveEnabled = false;
                       // db.Configuration.LazyLoadingEnabled = true;
                        //Statics.usersprojmngr.AddNewProjectToUser(admin, project);
                        db.Projects.Add(project);
                      
                        
                        db.SaveChanges();
                        string path = Path.Combine(plugmanger.GetPluginFilesRelativeDir("Projects"), project.Name);
                        FileManager.CreateDirectory(path);

                    }
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
                  ap = db.Projects.Find(id);
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
                        if ( proj.WikiName !=null )
                        {
                            this.wkmngr.DeleteWiki(proj.WikiName);
                        }
                        this.relmngr.DeleteByProjectId(id);
                        this.bugmngr.DeleteByProjectId(id);
                        this.chgMngr.DeleteByProjectId(id);
                        this.newMngr.DeleteByProjectId(id);

                        db.Projects.Remove(proj);
                        db.SaveChanges();
                        FileManager.DeleteDirectory(path);
                    }

                }

            }
            catch (Exception ex) { CommonTools.ErrorReporting(ex); }
        }

    }
}
