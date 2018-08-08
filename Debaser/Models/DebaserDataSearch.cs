using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Debaser.Models
{
    public class DebaserDataSearch
    {
        [Required]
        [Display(Name ="Från och med datum:")]
        public DateTime FromDate { get; set; }
        [Required]
        [Display(Name ="Till och med datum:")]
        public DateTime ToDate { get; set; }
        [Required]
        [Display(Name ="Plats:")]
        public string Location { get; set; }
    }
}