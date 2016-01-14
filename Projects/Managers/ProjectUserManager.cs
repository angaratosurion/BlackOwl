using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackCogs;
using BlackCogs.Data.Models;
using BlackCogs.Managers;
using Microsoft.AspNet.Identity.EntityFramework;
using Projects.Models;

namespace Projects.Managers
{
    public class ProjectUserManager:BlackCogsUserManager
    {

        public Boolean UserHasAccessToProject(ApplicationUser user, Project wk, Boolean isDelete)
        {
            try
            {
                Boolean ap = false;
                if (user != null && UserExists(user.UserName.ToString()) == true)
                {
                    if (isDelete == true)
                    {
                        IdentityRole role = this.GetRole(AdminRoles);
                        if (role != null)
                        {
                            if (role.Users.First(x => x.UserId == user.Id) != null && wk.Admininstrator.UserName == user.UserName)
                            {
                                ap = true;
                            }

                        }
                    }
                    else
                    {
                        if (wk.Admininstrator == user)
                        {
                            ap = true;
                        }
                    }
                }


                return ap;

            }
            catch (Exception ex)
            {

                CommonTools.ErrorReporting(ex);
                return false;
            }
        }
    }
}
