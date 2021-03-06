﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackOwl.Core.Managers;
using Projects.Managers;
using Projects.Models;

namespace Projects
{
    public   class Statics
    {
        public static ApplicationDbContext db = new ApplicationDbContext();
       public static FileManager FileManager = new FileManager();
        public static PluginManager plugmanger= new PluginManager();
        #region Manager of Projects
        public static ReleasesManager relmngr = new ReleasesManager();
        public static BugManager bugmngr = new BugManager();
        public static ProjectsManager mngr = new ProjectsManager();
        public static ProjectFileManager projfilmngr = new ProjectFileManager();
        public static ChangeLogManager chgMngr = new ChangeLogManager();
        public static ProjectNewsManager newMngr = new ProjectNewsManager();
        public static ProjectUserManager usrmng = new ProjectUserManager();
        //public static UsersProjectsMnager usersprojmngr = new UsersProjectsMnager();
        #endregion
    }
}
