using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Projects.Managers;
using Projects.Models;

namespace Projects.Controllers
{
    [Export("Projects", typeof(IController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ProjectsController : Controller
    {
        // private ApplicationDbContext db = new ApplicationDbContext();
        ProjectsManager mngr = Statics.mngr;

        // GET: Projects
        public ActionResult Index()
        {
            return View(mngr.List());
        }

        // GET: Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = this.mngr.GetProjectById(Convert.ToInt32(id));
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Projects/Create
        [Authorize]
        public ActionResult Create()
        {
            //Project proj= new Project();
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] Project project)
        {
            //if (ModelState.IsValid)
            {  //project.Admininstrator = Statics.usrmng.GetUser(this.User.Identity.Name);

                this.mngr.Create(project, this.User.Identity.Name);
                RouteValueDictionary vals = new RouteValueDictionary();
                vals.Add("newwikiname", project.Name);
               return RedirectToAction("Create", "HomeWiki",vals);
                //return RedirectToAction("Index");
            }

            //return View(project);
        }

        // GET: Projects/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = this.mngr.GetProjectById(Convert.ToInt32(id));
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,RowVersion")] Project project)
        {
            if (ModelState.IsValid)
            {
                this.mngr.Edit(project);
                return RedirectToAction("Index");
            }
            return View(project);
        }

        // GET: Projects/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = this.mngr.GetProjectById(Convert.ToInt32(id));
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
                this.mngr.Delete(id, this.User.Identity.Name);
            
            return RedirectToAction("Index");
        }

       
    }
}
