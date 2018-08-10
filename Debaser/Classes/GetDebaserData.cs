using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Debaser.Models;
using Newtonsoft.Json;

namespace Debaser.Classes
{
    public static class GetDebaserData
    {
        public static List<DebaserData> GetDebaserDataBasedOnParameters(string location, string fromDate, string toDate)
        {
            List<DebaserData> debaserData = new List<DebaserData>();
            using (WebClient wc = new WebClient())
            {
                var jsonString = wc.DownloadString("http://debaser.se/debaser/api/?version=2&method=getevents&venue=" + location + "&from=" + fromDate + "&to=" + toDate + "&format=json");

                var tempDebaserData = JsonConvert.DeserializeObject<IEnumerable<DebaserData>>(jsonString);

                if (!Utils.IsAny(tempDebaserData)) // IF there was no data stored in debaserData, send empty list
                    return (List<DebaserData>)debaserData;

                debaserData = ReturnCorrectSearchedAfterData(location.ToLower(), tempDebaserData); // Populates debaserData with searched after value(s)
                debaserData = NormalizeCollectedDataText(debaserData);
            }
            return (List<DebaserData>)debaserData;
        }

        public static DebaserData GetDebaserDataBasedOnId(string location, string fromDate, string toDate, int id)
        {
            DebaserData debaserData = new DebaserData();
            using (WebClient wc = new WebClient())
            {
                var jsonString = wc.DownloadString("http://debaser.se/debaser/api/?version=2&method=getevents&venue=" + location + "&from=" + fromDate + "&to=" + toDate + "&format=json");

                var tempDebaserData = JsonConvert.DeserializeObject<IEnumerable<DebaserData>>(jsonString);

                if (!Utils.IsAny(tempDebaserData))
                    return debaserData;

               
                foreach(var spelning in tempDebaserData)
                {
                    var idUtanConvert = spelning.EventId;
                    var spelningsId = Convert.ToInt32(spelning.EventId);
                    if(Convert.ToInt32(spelning.EventId) == id)
                    {
                        debaserData = spelning;
                        break;
                    }
                }
            }
            debaserData.Description = Utils.ReplaceHTMLMarkup(debaserData.Description);
            debaserData.Tags = Utils.ReplaceSpecialCharacters(debaserData.Tags.ToString());
            return debaserData;
        }


        // Method used to normalise data related to each event (Remove html tags from description, Remove redundant special-characters from tags)
        private static List<DebaserData> NormalizeCollectedDataText(List<DebaserData> collectedData)
        {
            foreach (var item in (collectedData))
            {
                item.Description = Utils.ReplaceHTMLMarkup(item.Description); // Removes html markup
                item.Tags = Utils.ReplaceSpecialCharacters(item.Tags.ToString()); // Removes special characters
            }
            return collectedData; // Returns normalized item
        }

        // "Strand" can not specificly be searched for via URL parameters, so we have to solve that with a method
        private static List<DebaserData> ReturnCorrectSearchedAfterData(string location, IEnumerable<DebaserData> collectedData)
        {
            List<DebaserData> newDebaserData = new List<DebaserData>();

            if (location == "strand")
            {
                foreach (var spelning in collectedData)
                {
                    if (spelning.Venue.ToLower() == "strand")
                    {
                        newDebaserData.Add(spelning);
                    }
                }
            }
            else
            {
                foreach (var spelning in collectedData)
                {
                    if (spelning.Venue.ToLower() != "slussen")
                    {
                        newDebaserData.Add(spelning);
                    }
                }
            }
            return newDebaserData;
        }
    }
}