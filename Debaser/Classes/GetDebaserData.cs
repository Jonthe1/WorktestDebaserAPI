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
            using (WebClient wc = new WebClient())
            {
                var jsonString = wc.DownloadString("http://debaser.se/debaser/api/?version=2&method=getevents&venue=" + location + "&from=" + fromDate + "&to=" + toDate + "&format=json");

                byte[] bytes = Encoding.Default.GetBytes(jsonString);
                var newJsonString = jsonString = Encoding.UTF8.GetString(bytes);

                var tempDebaserData = JsonConvert.DeserializeObject<IEnumerable<DebaserData>>(newJsonString);

                List<DebaserData> debaserData = new List<DebaserData>();

                if (!Utils.IsAny(tempDebaserData)) // IF there was no data stored in debaserData, send empty list
                    return new List<DebaserData>() { };

                foreach (var spelning in tempDebaserData)
                {
                    if (spelning.Venue.ToLower() != "slussen")
                    {
                        debaserData.Add(spelning);
                    }
                }

                return debaserData = NormalizeCollectedData(debaserData);
            }
        }
        // Method used to normalise data related to each event (Remove html tags from description, Remove redundant special-characters from tags)
        private static List<DebaserData> NormalizeCollectedData(List<DebaserData> collectedData)
        {
            foreach (var item in collectedData)
            {

                item.Description = Utils.ReplaceHTMLMarkup(item.Description); // Removes html markup
                item.Tags = Utils.ReplaceSpecialCharacters(item.Tags.ToString()); // Removes special characters
            }
            return collectedData; // Returns normalized item
        }
    }
}