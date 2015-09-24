using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using BlackOwl.Core.Data;
using BlackOwl.Core.Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Projects.Models
{
    // public class PluginUser :IdentityUser
    //{ 
    //    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<PluginUser> manager)
    //    {
    //        // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
    //        var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
    //        // Add custom user claims here
    //        return userIdentity;
    //    }
    //}
   

    public class ApplicationDbContext :  IdentityDbContext<ApplicationUser>
    //public class ApplicationDbContext : Context

    {

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Projects.Models.FileReleases>()
                .HasRequired(c => c.UploadedBy)
                .WithMany()
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<Projects.Models.FileReleases>()
               .HasRequired(c => c.UploadedBy)
              .WithRequiredDependent()
               .WillCascadeOnDelete(true);
            modelBuilder.Entity<Projects.Models.FileReleases>()
              .HasRequired(c => c.UploadedBy)
             .WithRequiredPrincipal()
              .WillCascadeOnDelete(true);
            //modelBuilder.Entity<ProjectFiles>()
            //    .HasRequired(c => c.Release)
            //    .WithMany()                
            //    .WillCascadeOnDelete(true);
            //modelBuilder.Entity<ProjectFiles>()
            //    .HasRequired(c => c.Release)
            //    .WithRequiredDependent()
            //    .WillCascadeOnDelete(true);
            //modelBuilder.Entity<ProjectFiles>()
            //    .HasRequired(c => c.Release)
            //    .WithRequiredPrincipal()
            //    .WillCascadeOnDelete(true);
            //modelBuilder.Entity<ProjectFiles>()
            //  .HasRequired(c => c.Release)
            //  .WithOptional()
            //  .WillCascadeOnDelete(true);


           
            
          
            base.OnModelCreating(modelBuilder);
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Project> Projecs { get; set; }
        public System.Data.Entity.DbSet<ProjectNews> ProjecNews { get; set; }
        public System.Data.Entity.DbSet<ProjectFiles> ProjecFiles { get; set; }
        public System.Data.Entity.DbSet<FileReleases> FileReleases { get; set; }
        public DbSet<ChangeLog> ChangeLogs { get; set; }
        public DbSet<Bugs> Bugs { get; set; }

        public System.Data.Entity.DbSet<BlackOwl.Core.Data.Models.Plugin> Plugins { get; set; }
       


    }
}