using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlackOwl.Core.Managers;
using Projects.Models;
using System.IO;
using BlackOwl.Core;
using System.Data.Entity;

namespace Projects.Managers
{

    
    public class ProjectFileManager
    {
        ApplicationDbContext db = new ApplicationDbContext();
        FileManager FileManager;// = new FileManager();
        PluginManager plugmanger;
        ReleasesManager relmngr = new ReleasesManager();
        public ProjectFileManager ( )
        {
            FileManager = new FileManager();
            plugmanger = new PluginManager();
        }
        public void Create(ProjectFiles file,HttpPostedFileBase filcnt)
        {
            try
            {
                if ( file!=null && filcnt!=null)
                {
                    int relid = file.ReleaseId;

                    string release = relmngr.GetDetailsById(relid).Version;

                    string path = Path.Combine(plugmanger.GetPluginFilesPthysicalDir("Projects"),file.Project.Name,
                        release,filcnt.FileName);
                  Boolean ap=  FileManager.CreateFile(path, filcnt);
                    file.Path = path;

                    

                    db.ProjecFiles.Add(file);
                    db.SaveChanges();
                    
                    
                    
                    
                }
            }
              catch (Exception ex){CommonTools.ErrorReporting(ex);  }
        }
        public ProjectFiles DetailsById(int ?id)
        {
            try
            {
                return db.ProjecFiles.Find(id);
            }
            catch (Exception ex)
            {
                CommonTools.ErrorReporting(ex);
                return null;
            }
        }
        public List<ProjectFiles> DetailsByReleaseId(int? id)
        {
            try
            {
                return db.ProjecFiles.Where(s => s.ReleaseId == id).ToList();
            }
            catch (Exception ex)
            {
                CommonTools.ErrorReporting(ex);
                return null;
            }
        }
        public void Edit(ProjectFiles projectFiles)
        {
            try
            {
                if (projectFiles !=null)
                {
                    db.Entry(projectFiles).State = EntityState.Modified;
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                CommonTools.ErrorReporting(ex);
                //return null;
            }
        }
        public void Delete(ProjectFiles projectFiles)
        {
            try
            {
                if (projectFiles != null)
                {
                    if (FileManager.FileExists(projectFiles.Path))
                    {
                        FileManager.DeleteFile(projectFiles.Path);
                      
                    }
                    db.ProjecFiles.Remove(projectFiles);
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                CommonTools.ErrorReporting(ex);
                //return null;
            }
        }
    }
}