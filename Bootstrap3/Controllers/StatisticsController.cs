using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bootstrap3.Models;

namespace Bootstrap3.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        public ActionResult Index()
        {
            RemotingClient _remotingClient = new RemotingClient();



            return View();

        }
    }
}