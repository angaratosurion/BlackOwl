using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackOwl.Core.Data.Models
{
 public   class Plugin
    {

        [Required]
        public int Id { get; set; }
     [Required]
     
        public string Name { get; set; }
     public Boolean Enabled { get; set; }
     public String  PluginVersion { get; set; }
        [Timestamp]
        public Byte []  RowVersion { get; set; }

    }
}
