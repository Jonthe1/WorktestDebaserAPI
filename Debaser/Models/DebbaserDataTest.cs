using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Debaser.Models
{
    public class DebbaserDataTest
    {
        public class Rootobject
        {
            public Class1[] Property1 { get; set; }
        }

        public class Class1
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
            public Dictionary<string, string> Tags { get; set; }
            public string ImageUrl { get; set; }
            public string TicketUrl { get; set; }
            public string EventUrl { get; set; }
        }

    }
}