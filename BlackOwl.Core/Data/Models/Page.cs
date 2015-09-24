using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BlackOwl.Core.Data.Models
{
   public  class Page
    {
       [Required]
      public int Id { get; set; }
      public string Title { get; set; }
      public string Name { get; set; }
       [DataType(DataType.Html)]
      public string content { get; set; }
      public int revision { get; set; }
      public string controller { get; set; }
      public virtual ApplicationUser Author { get; set; }
        [Timestamp]
        public Byte []  RowVersion { get; set; }

    }
}
