using MobileSample.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MobileSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            WebClient wClient = new WebClient();
            wClient.Encoding = Encoding.UTF8;
            var response = wClient.DownloadString("http://www.api.cloud.taipei.gov.tw/CSCP_API/trf/pli/");

            var oJson = JsonConvert.DeserializeObject<List<AreaClass>>(response);

            return View(oJson);
        }

        public ActionResult Info(string areaId)
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            var jsonStr = client.DownloadString(string.Format("http://www.api.cloud.taipei.gov.tw/CSCP_API/trf/pli/categories/{0}/topics", areaId));

            var oJson = JsonConvert.DeserializeObject<List<InfoClass>>(jsonStr);
            return View(oJson);
        }

        public ActionResult About()
        {
            ViewBag.Message = "您的應用程式描述頁面。";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "您的連絡頁面。";

            return View();
        }
    }
}
