using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackOwl.Core.Data.Models
{
   public class FileType
    {
       [Required]
        public int Id { get; set; }
       public string Name { get; set; }
       public string Extention { get; set; }
        [Timestamp]
        public Byte []  RowVersion { get; set; }
    }
}
