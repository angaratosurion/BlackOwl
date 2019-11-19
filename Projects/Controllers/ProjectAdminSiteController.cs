﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultiPlex.Core.Managers;

namespace ProjectsControllers
{
    [Export("ProjectAdminSite", typeof(IController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class WikiAdminSiteController : Controller
    {
        // GET: Admin
        [Authorize(Roles = "Administrators")]
        public ActionResult Index()
        {
            return View();
        }
    }
}