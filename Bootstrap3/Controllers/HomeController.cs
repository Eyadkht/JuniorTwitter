using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shared;
using Bootstrap3.Models;
using System.Web.Mvc;

namespace Bootstrap3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            RemotingClient _RemotingClient = new RemotingClient();
            
            string ServerName=_RemotingClient.Manger.SelectBestServer();
            if (ServerName == "Server1")
            {
                return new RedirectResult("http://localhost:7526");
            }
            if(ServerName== "Server2")
            {
                return new RedirectResult("http://localhost:12014");
            }
            if( ServerName== "Server3")
            {
                return new RedirectResult("http://localhost:12046"); 
            }

            return HttpNotFound();
            //return Content(bestPerformance.ToString());
            //return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}