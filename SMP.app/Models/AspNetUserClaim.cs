using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class AspNetUserClaim
    {
        public int Id { get; set; }
        public int taskid { get; set; }
        [Display(Name = "User")]
        public string UserId { get; set; }
        [Display(Name = "Claim Type")]
        public string ClaimType { get; set; }
        [Display(Name = "Claim Value")]
        public string ClaimValue { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}