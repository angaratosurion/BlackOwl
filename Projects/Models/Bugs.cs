using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BlackOwl.Core.Data.Models;

namespace Projects.Models
{
    public class Bugs
    {
       
        [Required]
        public int Id { get; set; }
        //   public int revision { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime ReporedAt { get; set; }
         [DataType(DataType.DateTime)]
        public DateTime EditedAt { get; set; }
        [Timestamp]
        public Byte []  RowVersion { get; set; }
        [Required]
         public virtual BlackOwl.Core.Data.Models.ApplicationUser ReportedBy { get; set; }

        public virtual BlackOwl.Core.Data.Models.ApplicationUser EditedBy { get; set; }
        [Required]
        public virtual Project Project { get; set; }
    }
}