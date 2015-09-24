using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackOwl.Core.Data.Models
{
   public  class CommentThread
    {
        [Required]
        public int Id { get; set; }
        [DataType(DataType.Text)]
        public string Title { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Published { get; set; }
        [Timestamp]
        public Byte []  RowVersion { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}
