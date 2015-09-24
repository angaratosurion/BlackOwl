using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projects.Managers;
using Projects.Models;

namespace Projects.Controllers
{
    public class BugsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        BugManager bugmngr = new BugManager();
        // GET: Bugs
        public ActionResult Index(int? projectid)
        {
            try
            {

           

            return View(bugmngr.BugsByProjectId(projectid));
        }
             catch (Exception)
            {

                throw;
            }
        }

        // GET: Bugs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bugs bugs = this.bugmngr.BugById(id);
            if (bugs == null)
            {
                return HttpNotFound();
            }
            return View(bugs);
        }

        // GET: Bugs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bugs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,ReporedAt,EditedAt")] Bugs bugs)
        {
            if (ModelState.IsValid)
            {
                this.bugmngr.Create(bugs);
                return RedirectToAction("Index");
            }

            return View(bugs);
        }

        // GET: Bugs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bugs bugs = this.bugmngr.BugById(id);
            if (bugs == null)
            {
                return HttpNotFound();
            }
            return View(bugs);
        }

        // POST: Bugs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,ReporedAt,EditedAt,RowVersion")] Bugs bugs)
        {
            if (ModelState.IsValid)
            {
                this.bugmngr.Edit(bugs);
                return RedirectToAction("Index");
            }
            return View(bugs);
        }

        // GET: Bugs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bugs bugs = this.bugmngr.BugById(id);
            if (bugs == null)
            {
                return HttpNotFound();
            }
            return View(bugs);
        }

        // POST: Bugs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bugs bugs = this.bugmngr.BugById(id);
            this.bugmngr.Delete(bugs);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
