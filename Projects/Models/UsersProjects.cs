using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackCogs.Data.Models;

namespace Projects.Models
{
    public class UsersProjects
    { 
       [Required]
        public virtual int ProjectsId { get; set; }
        [Required]
        
        public virtual  string UserId { get; set; }

    }
}
