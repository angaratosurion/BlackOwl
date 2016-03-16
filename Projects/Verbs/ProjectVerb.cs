using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackCogs.Interfaces;

namespace Projects.Verbs
{
    [Export(typeof(IActionVerb)), ExportMetadata("Category", "Navigation")]
    public class ProjectVerb : IActionVerb
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
                return "Projects";
            }
        }

        public string Description
        {
            get
            {
                return "Handles Modules";
            }
        }

        public bool isAdminPalnel
        {
            get
            {
                return false;
            }
        }

        public string Name
        {
            get
            {
                return "Projects";
            }
        }
    }
}
