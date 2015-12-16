using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BlackOwl.Core.Interfaces;

namespace Projects
{
    [Export(typeof(IModuleInfo))]
    public class ModuleInfo : IModuleInfo
    {
        public string Description
        {
            get
            {
                return "";
            }
        }

        public string Name
        {
            get
            {
                return "Projects";
            }
        }

        public string SourceCode
        {
            get
            {
                return "https://github.com/angaratosurion/BlackOwl";
            }
        }

        public string Version
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string WebSite
        {
            get
            {
                return "http://pariskoutsioukis.net/blog/";
            }
        }
    }
}
