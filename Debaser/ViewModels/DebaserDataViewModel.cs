using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Debaser.Models;
namespace Debaser.ViewModels
{
    public class DebaserDataViewModel
    {
        public List<DebaserData> EventList { get; set; }
        public DebaserDataSearch SearchData { get; set; }
        public DateTime SearchedFromDate { get; set; }
        public DateTime SearchedToDate { get; set; }
        public string SearchedLocation { get; set; }
    }
}