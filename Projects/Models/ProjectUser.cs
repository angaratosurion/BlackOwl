using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackCogs.Data.Models;

namespace Projects.Models
{ 
    
    public class ProjectUser:ApplicationUser
    {
        [Required]
        public List<Project> Projects { get; set; }
    }
}
