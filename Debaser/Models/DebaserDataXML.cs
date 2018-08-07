using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Debaser.Models
{
    public class DebaserDataXML
    {

        // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class xml
        {

            private xmlEvent[] eventField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("event")]
            public xmlEvent[] @event
            {
                get
                {
                    return this.eventField;
                }
                set
                {
                    this.eventField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class xmlEvent
        {

            private string eventidField;

            private string eventdateField;

            private string clubField;

            private string eventstatusField;

            private string eventField;

            private string subheadField;

            private string tablebookingField;

            private string descriptionField;

            private string ageField;

            private string openField;

            private string admissionField;

            private string venueField;

            private string venueslugField;

            private string roomField;

            private string imagedimensionsField;

            private string tagsField;

            private string imageurlField;

            private string ticketurlField;

            private string eventurlField;

            /// <remarks/>
            public string eventid
            {
                get
                {
                    return this.eventidField;
                }
                set
                {
                    this.eventidField = value;
                }
            }

            /// <remarks/>
            public string eventdate
            {
                get
                {
                    return this.eventdateField;
                }
                set
                {
                    this.eventdateField = value;
                }
            }

            /// <remarks/>
            public string club
            {
                get
                {
                    return this.clubField;
                }
                set
                {
                    this.clubField = value;
                }
            }

            /// <remarks/>
            public string eventstatus
            {
                get
                {
                    return this.eventstatusField;
                }
                set
                {
                    this.eventstatusField = value;
                }
            }

            /// <remarks/>
            public string @event
            {
                get
                {
                    return this.eventField;
                }
                set
                {
                    this.eventField = value;
                }
            }

            /// <remarks/>
            public string subhead
            {
                get
                {
                    return this.subheadField;
                }
                set
                {
                    this.subheadField = value;
                }
            }

            /// <remarks/>
            public string tablebooking
            {
                get
                {
                    return this.tablebookingField;
                }
                set
                {
                    this.tablebookingField = value;
                }
            }

            /// <remarks/>
            public string description
            {
                get
                {
                    return this.descriptionField;
                }
                set
                {
                    this.descriptionField = value;
                }
            }

            /// <remarks/>
            public string age
            {
                get
                {
                    return this.ageField;
                }
                set
                {
                    this.ageField = value;
                }
            }

            /// <remarks/>
            public string open
            {
                get
                {
                    return this.openField;
                }
                set
                {
                    this.openField = value;
                }
            }

            /// <remarks/>
            public string admission
            {
                get
                {
                    return this.admissionField;
                }
                set
                {
                    this.admissionField = value;
                }
            }

            /// <remarks/>
            public string venue
            {
                get
                {
                    return this.venueField;
                }
                set
                {
                    this.venueField = value;
                }
            }

            /// <remarks/>
            public string venueslug
            {
                get
                {
                    return this.venueslugField;
                }
                set
                {
                    this.venueslugField = value;
                }
            }

            /// <remarks/>
            public string room
            {
                get
                {
                    return this.roomField;
                }
                set
                {
                    this.roomField = value;
                }
            }

            /// <remarks/>
            public string imagedimensions
            {
                get
                {
                    return this.imagedimensionsField;
                }
                set
                {
                    this.imagedimensionsField = value;
                }
            }

            /// <remarks/>
            public string tags
            {
                get
                {
                    return this.tagsField;
                }
                set
                {
                    this.tagsField = value;
                }
            }

            /// <remarks/>
            public string imageurl
            {
                get
                {
                    return this.imageurlField;
                }
                set
                {
                    this.imageurlField = value;
                }
            }

            /// <remarks/>
            public string ticketurl
            {
                get
                {
                    return this.ticketurlField;
                }
                set
                {
                    this.ticketurlField = value;
                }
            }

            /// <remarks/>
            public string eventurl
            {
                get
                {
                    return this.eventurlField;
                }
                set
                {
                    this.eventurlField = value;
                }
            }
        }


    }
}