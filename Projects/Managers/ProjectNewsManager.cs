﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlackCogs.Data.Models;
using BlackOwl.Core;
using BlackOwl.Core.Data.Models;
using Projects.Models;

namespace Projects.Managers
{
    public class ProjectNewsManager
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<ProjectNews> List()
        {
            try
            {
                List<ProjectNews> ap = null;

                ap = db.ProjecNews.ToList();
                return ap;

            }
            catch (Exception ex)
            {
                return null;

            }

        }
        public List<ProjectNews> ListByProjectId(int? id)
        {
            try
            {
                List<ProjectNews> ap = null,news;
                if (id != null)
                { ap = new List<ProjectNews>();
                    news = this.db.ProjecNews.Where(x => x.Project.Id == id).ToList();
                     if ( news !=null)
                    {
                        ap = news;
                    }

                    

                }
               
                return ap;

            }
            catch (Exception ex)
            {
                return null;

            }

        }
        public ProjectNews Create(ProjectNews projectNews,string user)
        {
            try
            {
                ProjectNews ap = null;

            if( projectNews !=null && user!=null)
            {
                ApplicationUser usr=db.Users.First(m => m.UserName == user);
                if (usr != null)
                {
                    projectNews.Author = usr;
                    db.ProjecNews.Add(projectNews);
                    db.SaveChanges();
                    ap = projectNews;
                }
            }
                return ap;
                               
            }
             catch (Exception ex){CommonTools.ErrorReporting(ex);return null;  }
        }

        public ProjectNews Details(int? id)
        {
            try
            {
                ProjectNews ap = null;

                if ( id!=null)
                {
                    ap = db.ProjecNews.Find(id);

                }

                return ap;
            }
             catch (Exception ex){CommonTools.ErrorReporting(ex);return null;  }

        }

        public ProjectNews Edit( ProjectNews projectNews)
        {
            try
            {
                if (projectNews!=null)
                {
                    db.Entry(projectNews).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return projectNews;
            }
             catch (Exception ex){CommonTools.ErrorReporting(ex);return null;  }

        }
        public void Delete(int ?id)
        {
            try
            {
                if (id != null)
                {
                    ProjectNews projectNews = db.ProjecNews.Find(id);
                    db.ProjecNews.Remove(projectNews);
                    db.SaveChanges();  
                }
                
            }
              catch (Exception ex){CommonTools.ErrorReporting(ex);  }

        }
        public void DeleteByProjectId(int? id)
        {
            try
            {
                if (id != null)
                {
                    List<ProjectNews> news = this.ListByProjectId(id);
                     if ( news !=null)
                    {
                        foreach( var n in news )
                        {
                            this.Delete(n.Id);
                        }
                    }
                }

            }
            catch (Exception ex) { CommonTools.ErrorReporting(ex); }

        }
    }
}