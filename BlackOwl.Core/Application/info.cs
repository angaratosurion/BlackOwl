using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BlackOwl.Core.Interfaces;

namespace BlackOwl.Core.Application
{
    [Export(typeof(IModuleInfo))]
    public class Info : IModuleInfo
    {
        public string Description
        {
            get
            {
                string description = "A CMS Software extendable by the use of MEF  ";
                return description;
            }
        }

        public string Name
        {
            get
            {
                return "BlackOwl";
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
