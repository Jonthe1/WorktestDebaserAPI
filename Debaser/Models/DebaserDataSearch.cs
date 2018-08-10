using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Debaser.Models
{
    public class DebaserDataSearch
    {
        [Required(ErrorMessage = "Du måste skriva in ett datum")]
        [Display(Name ="Från och med datum:")]
        public DateTime FromDate { get; set; }

        [Required(ErrorMessage = "Du måste skriva in ett datum")]
        [Display(Name ="Till och med datum:")]
        public DateTime ToDate { get; set; }

        [Required(ErrorMessage = "Du måste välja en plats (du kan välja båda)")]
        [Display(Name ="Plats:")]
        public string Location { get; set; }
    }
}