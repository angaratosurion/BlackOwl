﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackCogs.Interfaces;
using BlackOwl.Core.Application;

namespace Projects .Verbs
{
    [Export(typeof(IActionVerb)), ExportMetadata("Category", "Navigation")]
    //[Export(typeof(IActionVerb)), ExportMetadata("Category", "Navigation")]
    public class AdminSiteVerb : IActionVerb
    {
        public string Action
        {
            get
            {
                return "Index";
            }
        }

        public string Controller
        {
            get
            {
                return "ProjectAdminSite";
            }
        }

        public string Description
        {
            get
            {
                return "";
            }
        }

        public bool isAdminPalnel
        {
            get
            {
                return true;
            }
        }

        public string Name
        {
            get
            {
                return "Site Administration";
            }
        }
        public string Moduledescription
        {
            get
            {
                Info inf = new Info();
                return inf.Description;
            }
        }

        public string ModuleName
        {
            get
            {
                Info inf = new Info();
                return inf.Name;
            }
        }
    }
}
