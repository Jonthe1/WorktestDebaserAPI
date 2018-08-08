using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Debaser.Models;
using System.Text;
using Debaser.Classes;
using System.IO;

namespace Debaser.Controllers
{
    public class DebaserController : Controller
    {
        // GET: Debaser
        public ActionResult Index()
        {
            var debaserData = GetData();
            return View(debaserData);

        }

        private IEnumerable<DebaserData> GetData()
        {
            using (WebClient wc = new WebClient())
            {
                //var staticString = "[{\"EventId\":\"10024\",\"EventDate\":\"2013 - 01 - 04\",\"Club\":\"\",\"EventStatus\":\"\",\"Event\":\"The Royal Concept\",\"SubHead\":\" + Hyper Heart + Frida Sundemo\",\"TableBooking\":\"\",\"Description\":\"Det \u00e4r snart ett \u00e5r sedan The Royal Concept underh\u00f6ll tv\u00e5 fullsatta Debaser i Stockholm och Malm\u00f6.Sedan dess har bandet spelat \"Way out West\" och turnerat andra sidan atlanten hela h\u00f6sten. \r\n\r\nMusiken \u00e4r energisk, gitarrdriven, dansant, elektronisk pop som m\u00e5nga g\u00e5nger f\u00f6rknippats med band som \"Phoenix\" och \"The Strokes\". Med singlar som \"Damn\", \"World on fire\", \"Gimme Twice\" och \"Dddance\" har de h\u00f6rts frekvent p\u00e5 P3 under \u00e5ret som g\u00e5tt och hyllats bland annat tidningen Filter, Rolling Stone, MTV, Perez Hilton och inte minst av Will Smith. \r\n\r\nI somras var singeln \"Gimme Twice\" under tv\u00e5 veckor den mest adderade l\u00e5ten p\u00e5 radio i USA och musiken har under h\u00f6sten g\u00e5tt att h\u00f6ras i bland annat \"Greys Anatomy\", \"Grimm!\", \"FIFA 13\" och Tim Burtons film \"Frankenweenie\". \r\n\r\nEP:n finns att h\u00f6ra h\u00e4r: (The Royal Concept \u2013 The Royal Concept EP) och det efterl\u00e4ngtade debutalbumet sl\u00e4pps i v\u00e5r. The Royal Concept \u00e4r en liveakt du inte vill missa!\r\n\r\nBOKA BORD! Har ni biljett till spelningen och bokar bord i v\u00e5r restaurang s\u00e5 smiter ni \u00e4ven f\u00f6re i k\u00f6n!\r\n\r\n<iframe src=\"http:\/\/www.tinybooking.com\/booking\/index\/debaser-medis?lang=english\" framborder=\"0\" border=\"0\" scrolling=\"no\" width=\"335\" height=\"330\"  \/><\/iframe>","Age":"20 \u00e5r","Open":"19-03","Admission":"125 kr + f\u00f6rk\u00f6psavgift. Biljetter finns hos Tickster, Bengans, Sound Pollution, Record Hunter, Kulturhuset\/Kulturdirekt.","Venue":"Medis","VenueSlug":"medis","Room":"Stora scenen","ImageDimensions":"618x412","Tags":[],"ImageUrl":"http:\/\/debaser.se\/img\/5744.jpg","TicketUrl":"https:\/\/secure.tickster.com\/Intro.aspx?ERC=LEPYHXKAJ3RG3HX","EventUrl":"http:\/\/debaser.se\/kalender\/10024\/"}]"
                var jsonString = wc.DownloadString("http://debaser.se/debaser/api/?version=2&method=getevents&venue=medis&from=20100101&to=20180201&format=json");
                byte[] bytes = Encoding.Default.GetBytes(jsonString);

                var newJsonString = jsonString = Encoding.UTF8.GetString(bytes);
                // List<string> errors = new List<string>();
                var debaserData = JsonConvert.DeserializeObject<IEnumerable<DebaserData>>(newJsonString);
                
                if (!Utils.IsAny(debaserData)) // IF there was no data stored in debaserData, send empty list
                    return new List<DebaserData>() { };

                return debaserData;
            }
        }

        [HttpPost]
        public ViewResult Search(DebaserDataSearch searchedData)
        {
            var location = searchedData.Location;
            var fromDate = Convert.ToDateTime(searchedData.FromDate).ToString("yyyy-MM-dd");
            var toDate = Convert.ToDateTime(searchedData.ToDate).ToString("yyyy-MM-dd");

            using (WebClient wc = new WebClient())
            {
                var jsonString = wc.DownloadString("http://debaser.se/debaser/api/?version=2&method=getevents&venue=" + location + "&from=" + fromDate + "&to=" + toDate + "&format=json");
                byte[] bytes = Encoding.Default.GetBytes(jsonString);

                var newJsonString = jsonString = Encoding.UTF8.GetString(bytes);

                var debaserData = JsonConvert.DeserializeObject<IEnumerable<DebaserData>>(newJsonString);

                if (!Utils.IsAny(debaserData)) // IF there was no data stored in debaserData, send empty list
                    return View("Index", new List<DebaserData>() { });

                return View("Index", debaserData);
            }
        }

        public ActionResult Details(int id, DebaserData data)
        {
            DebaserData detailData = data;
            return View(detailData);
        }

        public ActionResult Search()
        {
            return View();
        }
    }
}
/*
 * Old code
private static T _download_serialized_json_data<T>(string url) where T : new()
{
    using (var w = new WebClient())
    {
        var json_data = string.Empty;
        // attempt to download JSON data as a string
        try
        {
            json_data = w.DownloadString(url);
        }
        catch (Exception) { }
        // if string with JSON data is not empty, deserialize it to class and return its instance 
        return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
    }
}
*/