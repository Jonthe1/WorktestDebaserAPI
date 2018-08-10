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

namespace Debaser.Controllers
{
    public class DebaserController : Controller
    {
        // GET: Debaser
        public ActionResult Index()
        {
            var debaserData = new DebaserDataViewModel();
            return View(debaserData);

        }


        [HttpPost]
        public ViewResult Search(DebaserDataSearch searchedData)
        {
            if (!ModelState.IsValid) // Validate data. Return to search if not valid
                return View("Search");

            var fromDate = Convert.ToDateTime(searchedData.FromDate).ToString("yyyyMMdd");
            var toDate = Convert.ToDateTime(searchedData.ToDate).ToString("yyyyMMdd");
            var location = IsBothLocationsSelected(searchedData.Location); // To check if empty string should be returned or not
            List<DebaserData> debaserData = GetDebaserData.GetDebaserDataBasedOnParameters(location, fromDate, toDate);

            var debaserDataViewModel = new DebaserDataViewModel()
            {
                EventList = debaserData,
                SearchedFromDate = searchedData.FromDate,
                SearchedToDate = searchedData.ToDate,
                SearchedLocation = IsBothLocationsSelected(searchedData.Location)
            };
            return View("Index", debaserDataViewModel);
        }

        public ActionResult Details(int id, string fromDate, string toDate, string location)
        {
            var detailsFromDate = Convert.ToDateTime(fromDate).ToString("yyyyMMdd");
            var detailsToDate = Convert.ToDateTime(toDate).ToString("yyyyMMdd");
            var detailsLocation = location;
            var debaserData = GetDebaserData.GetDebaserDataBasedOnParameters(detailsLocation, detailsFromDate, detailsToDate);
            DebaserData detailData = new DebaserData();

            foreach (var item in debaserData)
            {
                if(Convert.ToInt32(item.EventId) == id)
                {
                    detailData = item;
                    break;
                }
            }
            return View(detailData);
        }

        public ActionResult Search()
        {
            return View();
        }


        private string IsBothLocationsSelected(string selection)
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
