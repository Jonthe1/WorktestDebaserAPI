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
using Debaser.ViewModels;
using System.Globalization;

namespace Debaser.Controllers
{
    public class DebaserController : Controller
    {
        // Loaded when application starts
        // Some values initiated with null so that the correct information will be displayd for the user in the view
        public ActionResult Index()
        {
            var debaserData = new DebaserDataViewModel()
            {
                EventList = new List<DebaserData>(),
                SearchData = new DebaserDataSearch() { FromDate = DateTime.Today, ToDate = DateTime.Today.AddMonths(1) },
                SearchedFromDate = null,
                SearchedToDate = null
            };
            return View(debaserData);

        }

        // Method run when user searches for an event
        [HttpPost]
        public ViewResult Search(DebaserDataViewModel searchedData)
        {
            if (!ModelState.IsValid) // Validate data. Return to search if not valid
                return View("Index", new DebaserDataViewModel() { EventList = new List<DebaserData>(), SearchData = new DebaserDataSearch() { FromDate = DateTime.Today, ToDate = DateTime.Today.AddMonths(1) } });

            var fromDate = Convert.ToDateTime(searchedData.SearchData.FromDate).ToString("yyyyMMdd", CultureInfo.InvariantCulture);
            var toDate = Convert.ToDateTime(searchedData.SearchData.ToDate).ToString("yyyyMMdd", CultureInfo.InvariantCulture);
            var location = IsAllLocationsSelected(searchedData.SearchData.Location); // To check if empty string should be returned or not
            List<DebaserData> debaserData = GetDebaserData.GetDebaserDataBasedOnParameters(location, fromDate, toDate); // Use static class method to get data (see folder: "Classes", File: "GetDebaserData.cs") 

            var debaserDataViewModel = new DebaserDataViewModel() // Create ViewModel with needed values to present in the view
            {
                EventList = debaserData,
                SearchedFromDate = searchedData.SearchData.FromDate,
                SearchedToDate = searchedData.SearchData.ToDate,
                SearchedLocation = location
            };

            return View("Index", debaserDataViewModel); // Return model to view "index"
        }

        public ActionResult Details(int id, DateTime eventDate, string location)
        {
            var detailsEventDate = Convert.ToDateTime(eventDate).ToString("yyyyMMdd", CultureInfo.InvariantCulture);
            var debaserData = GetDebaserData.GetDebaserDataBasedOnId(location, detailsEventDate, id); // Use static class method to get data previously searched for and then select the event with
            return View(debaserData);                                                                 // the correct EventID. Uses only the eventdate chosen to minimise the datasearch. 
        }

        private string IsAllLocationsSelected(string selection)
        {
            if (selection == "1")
            {
                return string.Empty;
            }
            else
            {
                return selection;
            }
        }
    }
}
