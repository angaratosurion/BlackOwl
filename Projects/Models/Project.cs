using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using BlackOwl.Core.Data.Models;
using MultiPlex.Core.Data.Models;

namespace Projects.Models
{
   
    public class Project
    {
        [Required]
        public int Id { get; set; }
        //   public int revision { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public Wiki WikiName { get; set; }
        [Timestamp]
        public Byte []  RowVersion { get; set; }
        [Required]
        public  String AdmininstratorId { get; set; }
        public virtual List<ApplicationUser> Members { get; set; }
        public virtual List<ProjectNews> News { get; set; }
        public virtual List<FileReleases> Releases { get; set; }
        public virtual List<ChangeLog> ChangeLogs { get; set; }
        public virtual List<Bugs> Bugs { get; set; }

      
     
    }
}