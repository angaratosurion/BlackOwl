﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackCogs.Managers;

namespace BlackOwl.Core
{
   public class CommonTools:BlackCogs.CommonTools
    {
        public static BlackCogsUserManager usrmng = new BlackCogsUserManager();
        public static  Boolean isEmpty(string str)
       {
           try
           {
               Boolean ap = true;
               if (str != null && str != String.Empty)
               {
                   ap = false;
               }

               return ap;
           }
           catch (Exception)
           {
               
               throw;
               return true;
           }
       }
       //public static void ErrorReporting (Exception ex)
       //{
       //    throw (ex);
       //}
    }
}
