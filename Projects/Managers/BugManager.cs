using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BlackOwl.Core;
using Projects.Models;

namespace Projects.Managers
{
    public class BugManager
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<Bugs> BugsByProjectId(int?projectid)
        {
            try
            {
                List<Bugs> ap = null;
                if (projectid > 0)
                {
                    List<Bugs> b = this.db.Bugs.ToList();
                    if (b != null)
                    {
                        ap = new List<Bugs>();
                        foreach (Bugs bg in b)
                        {
                            if (bg.Project.Id == projectid)
                            {
                                ap.Add(bg);
                            }
                        }



                    }

                }
                    return ap;
            }
             catch (Exception ex){CommonTools.ErrorReporting(ex);return null;  }
        }
        public Bugs BugById(int?id)
        {
            try
            {
                 Bugs bugs = db.Bugs.Find(id);
                 return bugs;
            }
              catch (Exception ex){CommonTools.ErrorReporting(ex);return null;  }
        }
        public void Create(Bugs bugs)
        {
            try
            {
                if (bugs != null)
                {
                    db.Bugs.Add(bugs);
                    db.SaveChanges();
                }
            }
              catch (Exception ex){CommonTools.ErrorReporting(ex);  }
        }
        public void Edit(Bugs bugs)
        {
            try
            {
                 if (bugs != null)
                {
                    db.Entry(bugs).State = EntityState.Modified;
                db.SaveChanges();
                }
            }
              catch (Exception ex){CommonTools.ErrorReporting(ex);  }
        }
        public void Delete(Bugs bugs)
        {
            try
            {
                if (bugs != null)
                {
                    db.Bugs.Remove(bugs);
                    db.SaveChanges();
                }

            }
              catch (Exception ex){CommonTools.ErrorReporting(ex);  }
        }
    }
}