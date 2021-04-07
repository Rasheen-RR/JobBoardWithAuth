using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.Models
{
    public class Resume
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Key]
        public string Email { get; set; }
        public ICollection<Experience> experience { get; set; }
        public string CoverLetter { get; set; }
        public ICollection<Education> education { get; set; }
    }
}
