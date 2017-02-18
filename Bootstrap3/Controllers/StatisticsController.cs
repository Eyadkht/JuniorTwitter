using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bootstrap3.Models;
using System.Web.Script.Serialization;

namespace Bootstrap3.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        public ActionResult Index()
        {
           

            return View();
         
        }
        
        [HttpPost]

        public ActionResult AjaxAction (string firstName, string lastName)
        {
            RemotingClient _remotingClient = new RemotingClient();

            int[] Cpu = _remotingClient.Manger.CpuServersCost();

            int[] Ram = _remotingClient.Manger.availableRamCost();

            var keyValues = new Dictionary<string, int>
               {
                  
                   { "Server1CPU", Cpu[0] },
                   { "Server2CPU", Cpu[1] },
                   { "Server3CPU", Cpu[2]},

                   { "Server1Ram",  Ram[0]},
                   { "Server2Ram",  Ram[1]},
                   { "Server3Ram",  Ram[2]},
               };

            JavaScriptSerializer js = new JavaScriptSerializer();
            string jsonObject = js.Serialize(keyValues);
           

            return Json(jsonObject);
        }


    }
}