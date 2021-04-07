using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace JobBoard.Models
{
    public class Candidate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Key]
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
