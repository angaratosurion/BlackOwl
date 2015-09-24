﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BlackOwl.Core.Data.Models
{
   public class News
    {
       [Required]       
        public int Id { get; set; }
    //   public int revision { get; set; }
       public string Title { get; set; }
       [DataType(DataType.DateTime)]   
       public DateTime Published { get; set; }
       [DataType(DataType.Html)]
       public string content { get; set; }
       public virtual ApplicationUser Author { get; set; }
     
       public virtual List<Category> Categories { get; set; }
       public virtual List<Tag> Tags { get; set; }
        [Timestamp]
        public Byte []  RowVersion { get; set; }

    }
}
