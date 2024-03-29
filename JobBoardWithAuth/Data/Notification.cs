﻿using JobBoard.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.Models
{
    public class Notification
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NotificationId { get; set; }
        public String Title { get; set; }
        public String Message { get; set; }
        public String CompanyId { get; set; }
        public String CandidateId { get; set; }
        public Candidate Candidate { get; set; }
    }
}
