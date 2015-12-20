using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Administration;
using System.Runtime.InteropServices;
using System.IO;
using BlackCogs.Managers;
using System.Web.Hosting;

namespace BlackOwl.Core.Managers
{
   public  class FileManager:FileSystemManager
   {
       CommonTools cmtools = new CommonTools();
      
        //const string   filesdir="files",AppDataDir="App_Data";

        [DllImport("kernel32.dll")]
        static extern bool CreateSymbolicLink(string lpSymlinkFileName, string lpTargetFileName, int dwFlags);

        static int SYMLINK_FLAG_DIRECTORY = 1;

       // public FileManager (HttpServerUtilityBase tul)
       //{
       //    if ( tul !=null)
       //    {
       //        util = tul;
       //    }
       //}
       #region Common
     
       public static string PhysicalPathFromUrl(string path)
       {
           try
           {
               string ap = null;
              
               if (path != null && DirectoryExists(path))
               {
                   
                   ap = HostingEnvironment.MapPath(path);
                }
               return ap;

           }
            catch (Exception ex){CommonTools.ErrorReporting(ex);
               return null;
           }
       }
       #endregion
      
    }
}
