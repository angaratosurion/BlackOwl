namespace BlackOwl.Core.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BlackCogs.Data.Models;
    using BlackOwl.Core.Data.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class Configuration : DbMigrationsConfiguration<BlackOwl.Core.Data.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
          
            
           
        }

        protected override void Seed(BlackOwl.Core.Data.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
           

            //IdentityRole Adminrole = new IdentityRole();
            //Adminrole.Name = "Administrators";

            var userStore = new UserStore<ApplicationUser>(context);
            var mngr= new UserManager<ApplicationUser>(userStore);

       //     if (!context.Users.Any(u => u.UserName == "admin"))
            {

                var admin = new ApplicationUser { UserName = "admin", Email = "admin@loclahost"  };
               


                mngr.Create(admin, "Adm!n0");

                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "Administrators" });
                //context.Users.AddOrUpdate(admin);

                context.SaveChanges();

            }

            context.Configuration.AutoDetectChangesEnabled = true;
            FileType image = new FileType();
            image.Name = "Images";
            image.Extention = "jpg;png";
            context.FileTypes.AddOrUpdate(image);
            FileType AppType = new FileType();
            AppType.Name = "Executable";
            AppType.Extention = "exe";
            context.FileTypes.AddOrUpdate(AppType);
            context.SaveChanges();
            

           
           


        }
       
    }
}
