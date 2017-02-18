using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bootstrap3.Controllers
{
    public class StreamController : Controller
    {
        // GET: Stream
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BuildTwitterStream()
        {

            return View();
        }

        public ActionResult ViewSavedTwitterStreams()
        {

            return View();
        }
    }
}