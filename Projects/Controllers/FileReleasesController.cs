using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projects.Models;
using Projects.Managers;
namespace Projects.Controllers
{

    [Export("FileRelease", typeof(IController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class FileReleasesController : Controller
    {
        private ProjectsDbContext db =Statics.db;
        private ReleasesManager relmngr = Statics.relmngr;

        // GET: FileReleases
        public ActionResult Index( int ? projectid)
        {
            //var fileReleases = db.FileReleases.Include(f => f.ChangeLog);

            var fileReleases = this.relmngr.GetAllReleasesByProjectId(projectid);
            
            return View(fileReleases.ToList());
        }

        // GET: FileReleases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileReleases fileReleases = this.relmngr.GetDetailsById(id);
            if (fileReleases == null)
            {
                return HttpNotFound();
            }
            return View(fileReleases);
        }

        // GET: FileReleases/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.ChangeLogs, "Id", "Title");
            return View();
        }

        // POST: FileReleases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tittle,Version,Published,content")] FileReleases fileReleases)
        {
            if (ModelState.IsValid)
            {
                this.relmngr.CreateNew(fileReleases);
               
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.ChangeLogs, "Id", "Title", fileReleases.Id);
            return View(fileReleases);
        }

        // GET: FileReleases/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileReleases fileReleases = this.relmngr.GetDetailsById(id);
            if (fileReleases == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.ChangeLogs, "Id", "Title", fileReleases.Id);
            return View(fileReleases);
        }

        // POST: FileReleases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tittle,Version,Published,content,RowVersion")] FileReleases fileReleases)
        {
            if (ModelState.IsValid)
            {
                this.relmngr.Edit(fileReleases);
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.ChangeLogs, "Id", "Title", fileReleases.Id);
            return View(fileReleases);
        }

        // GET: FileReleases/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileReleases fileReleases = this.relmngr.GetDetailsById(id);
            if (fileReleases == null)
            {
                return HttpNotFound();
            }
            return View(fileReleases);
        }

        // POST: FileReleases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FileReleases fileReleases = this.relmngr.GetDetailsById(id);

            this.relmngr.Delete(fileReleases);
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
