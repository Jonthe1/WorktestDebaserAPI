using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Debaser.Models
{
    public class DebaserData
    {
        public string EventId { get; set; }
        public string EventDate { get; set; }
        public string Club { get; set; }
        public string EventStatus { get; set; }
        public string Event { get; set; }
        public string SubHead { get; set; }
        public string TableBooking { get; set; }
        public string Description { get; set; }
        public string Age { get; set; }
        public string Open { get; set; }
        public string Admission { get; set; }
        public string Venue { get; set; }
        public string VenueSlug { get; set; }
        public string Room { get; set; }
        public string ImageDimensions { get; set; }
        public object Tags { get; set; }
        public string ImageUrl { get; set; }
        public string TicketUrl { get; set; }
        public string EventUrl { get; set; }
    }
}