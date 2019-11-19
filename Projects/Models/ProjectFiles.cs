using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using BlackOwl.Core.Data.Models;

namespace Projects.Models
{
    
    public class ProjectFiles:Files
    {
        [Required]
        public virtual Project Project { get; set; }
      [Required]
        public int ReleaseId { get; set; }
        [Timestamp]
        public Byte[] RowVersion { get; set; }

    }
}