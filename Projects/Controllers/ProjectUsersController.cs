﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using BlackCogs;
using BlackCogs.Data.Models;
using MultiPlex.Core.Data.Models;
using Projects.Managers;
using Projects.ViewModels;
using MultiPlex.Core.Managers;
using System.Net;

namespace Projects.Controllers
{
    [Export("ProjectsUser", typeof(IController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Authorize]
   public class ProjectUsersController :  BlackCogs.Controllers.UserController    
    {
        ProjectUserManager usremngr = new ProjectUserManager();
        WikiManager wkmngr = MultiPlex.Core.CommonTools.wkmngr;
        ProjectsManager promgnr = new ProjectsManager();
        #region AdminPanel
        [Authorize(Roles = "Administrators")]
        public ActionResult FullDetails(string username)
        {
            try
            {
               

                if (CommonTools.isEmpty(username) == true)
                {
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
                }

                ApplicationUser adm = this.usremngr.GetUser(username);
                if (adm == null)
                {
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
                }

                ViewProjectFullUserDetails fulusr = new ViewProjectFullUserDetails();
                fulusr.UserDetails = adm;
                fulusr.Roles = this.usremngr.GetRolesOfUser(username);
                fulusr.WikisAsAdmin = this.wkmngr.ListWikiByAdmUser(username);
                var wkmods = this.wkmngr.ListWikiByModUser(username);
                if (wkmods == null)
                {
                    wkmods = new List<Wiki>();
                }
                fulusr.WikisAsMod = wkmods;
                fulusr.ProjectAsAdmin = this.promgnr.ListProjectByAdmUser(username);
                var projbymembs = this.promgnr.ListWikiByUser(username);
                if ( projbymembs==null)
                {
                    projbymembs = new List<Models.Project>();
                }
                fulusr.ProjectAsMember = projbymembs;

                return View(fulusr);
            }
            catch (Exception ex)
            {

                CommonTools.ErrorReporting(ex);
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError);
            }
        }

        [Authorize(Roles = "Administrators")]
        public ActionResult DeleteUser(string username)
        {
            try
            {
                if (CommonTools.isEmpty(username) == true)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ApplicationUser user = this.usremngr.GetUser(username);
                if (user == null)
                {
                    return HttpNotFound();
                }
                ViewProjectFullUserDetails fulusr = new ViewProjectFullUserDetails();
                fulusr.UserDetails = user;
                fulusr.Roles = this.usremngr.GetRolesOfUser(username);
                fulusr.WikisAsAdmin = this.wkmngr.ListWikiByAdmUser(username);
                fulusr.WikisAsMod = this.wkmngr.ListWikiByModUser(username);

                fulusr.ProjectAsAdmin = this.promgnr.ListProjectByAdmUser(username);
                var projbymembs = this.promgnr.ListWikiByUser(username);
                if (projbymembs == null)
                {
                    projbymembs = new List<Models.Project>();
                }
                fulusr.ProjectAsMember = projbymembs;
                return View(fulusr);
            }
            catch (Exception ex)
            {

                CommonTools.ErrorReporting(ex);
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError);
            }
        }
        // POST: ProjectNews/Delete/5
        [HttpPost, ActionName("DeleteUser")]
        [Authorize(Roles = "Administrators")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteUserConfirmed(string username)
        {

            try
            {
                int cat = 0;
                if (CommonTools.isEmpty(username) == true)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ApplicationUser user = this.usremngr.GetUser(username);
                if (user != null)
                {
                    // this.wkmngr.DeleteWikiByAdm(user.UserName);
                    this.promgnr.DeletebyAdm(username, User.Identity.Name);                   
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                CommonTools.ErrorReporting(ex);
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError);
            }
        }


        #endregion
        #region ProjectUserEdit
        public ActionResult Details(string username)
        {
            try
            {


                if (CommonTools.isEmpty(username) == true)
                {
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
                }

                ApplicationUser adm = this.usremngr.GetUser(username);
                if (adm == null)
                {
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
                }


                return View(adm);
            }
            catch (Exception ex)
            {

                CommonTools.ErrorReporting(ex);
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError);
            }
        }
        #endregion
    }
}
