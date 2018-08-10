using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Debaser.Models;

namespace Debaser.Controllers.API
{
    public class DebaserController : ApiController
    {
        public IEnumerable<DebaserData> GetData()
        {
            return new List<DebaserData>();
        }

        public DebaserData Details(int id, DebaserData data)
        {
            DebaserData detailData = data;
            return detailData;
        }
    }
}
