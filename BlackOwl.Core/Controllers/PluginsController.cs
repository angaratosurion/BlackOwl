using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlackOwl.Core.Data.Models;
using BlackOwl.Core.Data;


namespace BlackOwl.Core.Controllers
{
    [Export("Plugins", typeof(IController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Authorize(Roles = "Administrators")]
    public class PluginsController : Controller
    {
        private Context db = new Context();

        // GET: Plugins
        public ActionResult Index()
        {
            return View(db.Plugins.ToList());
        }

        // GET: Plugins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plugin plugin = db.Plugins.Find(id);
            if (plugin == null)
            {
                return HttpNotFound();
            }
            return View(plugin);
        }

        // GET: Plugins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Plugins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Enabled,PluginVersion")] Plugin plugin)
        {
            if (ModelState.IsValid)
            {
                db.Plugins.Add(plugin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plugin);
        }

        // GET: Plugins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plugin plugin = db.Plugins.Find(id);
            if (plugin == null)
            {
                return HttpNotFound();
            }
            return View(plugin);
        }

        // POST: Plugins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Enabled,PluginVersion")] Plugin plugin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plugin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plugin);
        }

        // GET: Plugins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plugin plugin = db.Plugins.Find(id);
            if (plugin == null)
            {
                return HttpNotFound();
            }
            return View(plugin);
        }

        // POST: Plugins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plugin plugin = db.Plugins.Find(id);
            db.Plugins.Remove(plugin);
            db.SaveChanges();
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
