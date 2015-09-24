using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BlackOwl.Core;
using Projects.Models;

namespace Projects.Managers
{
    public class ReleasesManager
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public  void CreateNew (FileReleases release)
        {
            try
            {
                if (release !=null )
                {
                    db.FileReleases.Add(release);
                    db.SaveChanges();
                }

            }
              catch (Exception ex){CommonTools.ErrorReporting(ex);  }
        }
      
        public void Edit(FileReleases release)
        {
            try
            {
                if ( release !=null)
                {
                    db.Entry(release).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
              catch (Exception ex){CommonTools.ErrorReporting(ex);  }
        }
        public void Delete(FileReleases fileReleases)
        {
            try
            {
                if ( fileReleases !=null)
                {
                    db.FileReleases.Remove(fileReleases);
                    db.SaveChanges();
                }

            }
              catch (Exception ex){CommonTools.ErrorReporting(ex);  }
        }
        
        public FileReleases GetDetailsById(int?  id)
        {
            try
            {
                FileReleases ap = null;
                if ( id>0)
                {
                    ap = db.FileReleases.Find(id);
                }

                return ap;

            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        public List<FileReleases> GetAllReleases()
        {
            try
            {
                List<FileReleases> ap = null;
                ap = db.FileReleases.Include(f => f.ChangeLog).ToList();


                return ap;

            }
            catch (Exception)
            {
                
                throw;
                return null;
            }
        }
        public List<FileReleases> GetAllReleasesByProjectId(int? id)
        {
            try
            {
                List<FileReleases> ap = null;

               var q = db.FileReleases.Include(f => f.ChangeLog).ToList();
                if (q != null)
                {
                    
                    ap = q.FindAll(s => s.Project.Id == id);
                }



                return ap; 
            }
            catch (Exception)
            {
                
                throw;
                return null;
            }
        }
    }
}